using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalista.Forms
{
    public partial class CurrencyForm : Form
    {
        #region TemplateText

        string _ReceiptOverTemplateText = "Rate => 100 : {0}\r\n\r\n{1}: {2}\r\n\r\n" +
            "RMB: ({0} - {4}) * {2} / 100 = {3}";

        string _ReceiptLessTemplateText = "Rate => 100 : {0}\r\n\r\n{1}: {2}\r\n\r\n" +
            "RMB: {0} * {2} / 100 - 5 = {3}";

        string _ReceiptTemplateText(bool isOver) => 
            isOver ? _ReceiptOverTemplateText : _ReceiptLessTemplateText;

        #endregion
        
        int _Currency
        {
            get
            {
                Int32.TryParse(textBox_currency.Text, out int result);
                return result;
            }
        }

        float _Rate
        {
            get
            {
                if (checkBox_autoGetNetRate.Checked) _GetNetRate(_CurrencyName);
                float.TryParse(textBox_rate.Text, out float result);
                return result < 10 ? float.Parse(result.ToString("F2")) : (int)result;
            }
        }

        string _CurrencyName => comboBox_currencyType.Text;

        bool _IsEng => _CurrencyName == "日元";

        public CurrencyForm()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_count_Click(object sender, EventArgs e)
        {
            if (_Rate <= 0) return;
            int currency = _IsEng ? _Currency / 100 : _Currency;
            bool isOver = currency > 100;
            float commission = isOver ? currency / 20 : 5;
            float rmb = _Rate * _Currency / 100 - commission;
            textBox_rmb.Text = rmb.ToString();
            label_receipt.Text = string.Format(_ReceiptTemplateText(isOver),
                _Rate,
                _CurrencyName,
                _Currency,
                (int)rmb,
                _IsEng ? 0.05 : 5);
        }

        #region Static

        public static void ShowCurrencyFrom()
        {
            CurrencyForm form = new CurrencyForm();
            form.Show();
        }

        #endregion

        private void _GetNetRate(string currency)
        {
            try
            {
                HttpWebRequest httpReq = WebRequest.Create(
                new Uri(Properties.Resources.CurrencyRateSite)) as HttpWebRequest;
                httpReq.Proxy = null;
                httpReq.Method = "Get";
                httpReq.Accept = "text/html, application/xhtml+xml, */*";
                httpReq.ContentType = "application/x-www-form-urlencoded";
                httpReq.UserAgent =
                    "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                httpReq.KeepAlive = true;
                httpReq.AllowAutoRedirect = false;
                Stream stream = (httpReq.GetResponse() as HttpWebResponse).GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string html = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                Regex r = new Regex(Properties.Resources.CurrencyRegexString.Replace(
                    Properties.Resources.CurrencyRegexStringReplaceKeyword, currency));
                textBox_rate.Text = float.Parse(r.Match(html).Groups[0].Value).ToString();
            }
            catch
            {
                MessageBox.Show("自动获取汇率出错！已改为手动填写。");
                checkBox_autoGetNetRate.Checked = false;
            }
        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            foreach(string currencyName in Properties.Resources.CurrencyNames.Split(','))
            {
                comboBox_currencyType.Items.Add(currencyName);
            }
        }
    }
}
