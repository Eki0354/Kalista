using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Kalista
{
    public partial class Form_Cell : Form
    {
        static List<string> _channels = new List<string>(new string[]
        {
            "BK",
            "交青",
            "HW",
            "Agoda",
            "携程",
            "青芒果",
            "邮件预定",
            "电话预定",
            "到店",
            "返客",
            "员工",
            "员工朋友",
            "嘉博国旅",
            "龙之旅",
            "格林卫"
        });

        private Range _range;

        public Form_Cell()
        {
            InitializeComponent();
        }

        private void Form_Cell_Closing(object sender, FormClosingEventArgs e)
        {
            _range.Select();
        }

        public void InitializeInfo(Range range)
        {
            _range = range;
            if (_range.Value == null) return;
            if (_range.Cells.Count > 1) _range = _range.Cells[0];
            if (_range.Value == null || _range.Value.ToString() == "") return;
            //单元格及其内容非空，提取信息(去除收尾空格)
            string value = _range.Value.ToString().Trim();
            string[] infos = value.Split(Convert.ToChar("\n"));
            string attrText = "";
            string name = "";
            if (infos.Length == 1)
            {
                name = infos[0].Trim();
            }
            else
            {
                attrText = infos[0].Trim();
                name = infos[1].Trim();
            }
            if (attrText != "")
            {
                List<string> attrs = attrText.Split(Convert.ToChar(" ")).ToList();
                string channel = attrs.Find(x => _channels.Contains(x));
                int index = -1;
                if (channel != null)
                {
                    textBox_channel.Text = channel;
                    index = attrs.IndexOf(channel);
                    attrs.Remove(channel);
                }
                if (attrs.Count > 1)
                {
                    comboBox_leftTag.Items.Add(attrs[0]);
                    comboBox_leftTag.SelectedItem = attrs[0];
                    comboBox_rightTag.Items.Add(attrs[1]);
                    comboBox_rightTag.SelectedItem = attrs[1];
                }
                else if (attrs.Count > 0)
                {
                    if (index == 0)
                    {
                        comboBox_rightTag.Items.Add(attrs[0]);
                        comboBox_rightTag.SelectedItem = attrs[0];
                    }
                    else
                    {
                        comboBox_leftTag.Items.Add(attrs[0]);
                        comboBox_leftTag.SelectedItem = attrs[0];
                    }
                }
            }
            if (name != "")
            {
                string[] names = name.Split(Convert.ToChar("/"));
                foreach(string n in names)
                {
                    listBox_guests.Items.Add(n);
                }
            }
        }

        private void listBox_guests_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_deleteGuest.Enabled = listBox_guests.SelectedIndex > -1;
            button_addGuest.Enabled = listBox_guests.Items.Count > 2;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            List<string> tags = new List<string>();
            string value = "";
            if (comboBox_leftTag.Text != null)
                tags.Add(comboBox_leftTag.Text.ToString());
            if (textBox_channel.Text != "")
                tags.Add(textBox_channel.Text);
            if (comboBox_rightTag.Text != null)
                tags.Add(comboBox_rightTag.Text.ToString());
            if (tags.Count > 0) value = String.Join(" ", tags.ToArray());
            value += "\n";
            List<string> guests = new List<string>();
            foreach (object obj in listBox_guests.Items)
                if (obj != null) guests.Add(obj.ToString());
            if (guests.Count > 0) value += String.Join("/", guests.ToArray());
            _range.Value = value;
            _range.ShrinkToFit = true;
            this.Close();
        }
        
    }
}
