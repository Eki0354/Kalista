using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSOTools = Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;
using MSOCore = Microsoft.Office.Core;
using YuI = Kalista.AddIn_YuI;

namespace Kalista
{
    public partial class Ribbon_Excel
    {

        #region ControlEvent
        
        private void _App_SheetBeforeDoubleClick(object Sh, Microsoft.Office.Interop.Excel.Range Target, ref bool Cancel)
        {
            Form_Cell form = new Form_Cell();
            form.InitializeInfo(Target);
            form.ShowDialog();
        }

        #endregion

        public void ChangeEditMode()
        {
            bool isInFormEditMode = YuI.App.EditDirectlyInCell;
            YuI.App.EditDirectlyInCell = !isInFormEditMode;
            if (isInFormEditMode)
            {
                YuI.App.SheetBeforeDoubleClick += _App_SheetBeforeDoubleClick;
                MessageBox.Show("已变更为窗口编辑模式");
            }
            else
            {
                YuI.App.SheetBeforeDoubleClick -= _App_SheetBeforeDoubleClick;
                MessageBox.Show("已变更为单元格编辑模式");
            }
        }
    }
}
