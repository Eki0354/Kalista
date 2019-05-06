using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalista
{
    public partial class KillExcelForm : Form
    {
        public KillExcelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static void ShowKillExcelForm()
        {
            (new KillExcelForm()).Show();
        }
    }
}
