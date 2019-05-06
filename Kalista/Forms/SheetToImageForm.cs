using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Kalista
{
    public partial class SheetToImageForm : Form
    {
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseClipboard();
        [DllImport("User32.dll")]
        public static extern IntPtr GetClipboardData(System.UInt32 uFormat);

        public static void ShowOnApplication(Excel.Application app)
        {
            SheetToImageForm form = new SheetToImageForm();
            form.InitApp(app);
            form.ShowDialog();
        }

        Excel.Application _App;

        public SheetToImageForm()
        {
            InitializeComponent();
        }

        public void InitApp(Excel.Application app)
        {
            _App = app;
            foreach(Worksheet sheet in _App.Sheets)
            {
                ListBox_Sheet.Items.Add(sheet.Name);
            }
            if (ListBox_Sheet.Items.Contains("房态表"))
                ListBox_Sheet.SelectedItem = "房态表";
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_copyImage_Click(object sender, EventArgs e)
        {
            if (ListBox_Sheet.Enabled && ListBox_Sheet.SelectedIndex < 0)
            {
                MessageBox.Show("必须选择一个工作表！");
                return;
            }
            Range r = null;
            if (RadioButton_Used.Checked)
                r = _App.Sheets[ListBox_Sheet.SelectedItem as string].UsedRange;
            else if (RadioButton_Selected.Checked)
                r = _App.Selection;
            if(r != null)
            {
                if (RadioButton_Cell.Checked)
                    this.CopyInCellMode(r);
                else if (RadioButton_Screen.Checked)
                    this.CopyPicture(r, XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
                else if (RadioButton_Printer.Checked)
                    this.CopyPicture(r, XlPictureAppearance.xlPrinter, XlCopyPictureFormat.xlBitmap);
            }
            this.Close();
        }

        private void CopyInCellMode(Range r)
        {
            _App.CutCopyMode = 0;
            r.Copy();
            IntPtr hwnd = (IntPtr)_App.Hwnd;
            try
            {
                OpenClipboard(hwnd);
                IntPtr data = GetClipboardData(14);
                using (Metafile mf = new Metafile(data, true))
                {
                    Bitmap b = new Bitmap(mf);
                    Clipboard.Clear();
                    Clipboard.SetDataObject(b);
                }
            }
            catch
            {

            }
            finally
            {
                CloseClipboard();
            }
        }

        private void CopyPicture(Range r,
            XlPictureAppearance appearance, XlCopyPictureFormat format)
        {
            try
            {
                r.CopyPicture(Appearance: appearance, Format: format);
            }
            catch
            {

            }
        }

        private void RadioButton_Selected_CheckedChanged(object sender, EventArgs e)
        {
            ListBox_Sheet.Enabled = !RadioButton_Selected.Checked;
        }
        
    }
}
