using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Kalista
{
    
    public partial class Ribbon_Excel
    {

        //注意：禁用Range.Clear()方法，此方法初始化所有内容和格式
        #region DELETE
        //DELETE中所有方法仅对单元格文字内容（包括批注）和单元格背景色进行更改，不涉及单元格文字格式
        public void Del_Shape_ActiveCell()
        {
            ActCell.ClearComments();
        }

        public void Del_ActiveCell()
        {
            Del_Range(ActCell);
        }

        public void Del_Res()
        {
            Worksheet ws = Globals.AddIn_YuI.Application.ThisWorkbook.ActiveSheet;
            Range selR = ActSelection;
            if (selR == null) { return; }
            selR = selR.Columns[1];
            if (selR == null) { return; }
            DateTime dt = DateTime.Now;
            int maxIndex = DateTime.DaysInMonth(dt.Year, dt.Month) + Setter.Day0ColumnIndex;
            List<string> adds = new List<string>();
            foreach (Range sR in selR.Cells)
            {
                string name = RoomCell.GetGuestName(sR);
                int rI = sR.Row;
                Range eR = sR;
                for (int i = sR.Column + 1; i < maxIndex + 1; i++)
                {
                    Range r = ws.Cells[rI, i];
                    string value = r.Value;
                    if (value == null || value.IndexOf(name) < 0)
                    {
                        adds.Add(sR.Address + ":" + eR.Address);
                        break;
                    }
                    else
                    {
                        eR = r;
                    }
                }
            }
            Del_Range(ws.Range[String.Join(",", adds.ToArray())]);
            selR.Cells[1, 1].select();
        }

        public void Del_Shape_Selected()
        {
            ActSelection.ClearComments();
        }

        public void Del_Selected()
        {
            Del_Range(ActSelection);
        }

        private void Del_Range(Range r)
        {
            r.ClearComments();
            r.ClearContents();
            r.Interior.Color = 16777215;//白色
        }

        #endregion

        #region ROOMSTATUS
        
        public void RS_Paid()
        {
            _ChangeSingleRoomState(ActSelection, ResCellColor.Blue, null);
        }

        public void RS_Unpaid()
        {
            _ChangeSingleRoomState(ActSelection, ResCellColor.Red, null);
        }

        public void RS_Prepaid()
        {
            _ChangeSingleRoomState(ActSelection, ResCellColor.Yellow, null);
        }

        public void RS_CheckedOut()
        {
            _ChangeSingleRoomState(ActSelection, ResCellColor.Gray, null);
        }

        public void RS_Default()
        {
            _ChangeSingleRoomState(ActSelection, ResCellColor.White, null);
        }

        public void RS_NoShow()
        {
            _ChangeSingleRoomState(ActSelection, ResCellColor.Purple, null);
        }

        private void _ChangeRoomState(ResCellColor color, System.Action action = null)
        {
            Range r = ActCell;
            r.Application.ExecuteWithoutUpdate(delegate ()
            {
                _ChangePreviewRoomStateChain(r, color, action);
                _ChangeAfterRoomStateChain(r, color, action);
            });
        }

        private void _ChangePreviewRoomStateChain(Range r, ResCellColor color,
            System.Action action = null)
        {
            try
            {
                _ChangeSingleRoomState(r, color, action);
                string name = RoomCell.GetGuestName(r);
                Range lR = r.LastRoomRange();
                while(RoomCell.GetGuestName(lR) == name)
                {
                    _ChangeSingleRoomState(lR, color, action);
                    lR = lR.LastRoomRange();
                }
            }
            catch
            {

            }
        }

        private void _ChangeAfterRoomStateChain(Range r, ResCellColor color,
            System.Action action = null)
        {
            try
            {
                _ChangeSingleRoomState(r, color, action);
                string name = RoomCell.GetGuestName(r);
                Range rR = r.NextRoomRange();
                while (RoomCell.GetGuestName(rR) == name)
                {
                    _ChangeSingleRoomState(rR, color, action);
                    rR = rR.NextRoomRange();
                }
            }
            catch
            {

            }
        }

        private void _ChangeSingleRoomState(Range r, ResCellColor color, System.Action action)
        {
            r.Interior.Color = color;
            InitRange(r);
            action?.Invoke();
        }

        #endregion

        #region DEPOSIT

        public void SetDep_100()
        {
            SetDeposit("100");
        }

        public void SetDep_0()
        {
            SetDeposit("0");
        }

        public void SetDep_Custom()
        {
            SetDeposit(Microsoft.VisualBasic.Interaction.InputBox("请输入要记录的押金：", "提示"));
        }

        public void RemoveDeposit()
        {
            Range range = ActSelection;
            Worksheet ws = AddIn_YuI.App.ActiveSheet;
            foreach(Range cell in range)
            {
                string roomNumber = GetRoomNumber(ws, cell.Row);
                if (roomNumber == null) continue;
            }
        }

        #endregion

        #region PICKUP

        public static void PickUp_Book()
        {
            /*Range r = _ActCell;
            if (r.Interior.Color != 52224)
            {
                r.Interior.Color = 52224;//绿色
            }
            string value = r.Value;
            if (string.IsNullOrEmpty(value)) return;
            r.Value = "接机未通知 " + r.Value.Replace("接机未通知", "")
                .TrimStart().Replace("接机已通知", "").TrimStart();*/
        }

        public void PickUp_Noticed()
        {
            Range r = ActCell;
            string value = r.Value;
            if (value != null && value.IndexOf("接机未通知") > -1)
            {
                r.Value = value.Replace("接机未通知", "接机已通知");
            }
        }

        public void PickUp_Cancel()
        {
            Range r = ActCell;
            string value = r.Value;
            if (value != null)
            {
                r.Value = value.Replace("接机未通知", "").TrimStart();
                r.Value = value.Replace("接机已通知", "").TrimStart();
            }
            r.Interior.Color= 16777215;//白色
        }

        #endregion

        #region RESERVATION

        public void RES_PasteReservation()
        {
            string text = Clipboard.GetText();
            int index = text.IndexOf(";;;");
            if (index > 0)
            {
                Range r = ActCell;
                string valueText = text.Substring(0, index);
                string channel = text.Substring(0, text.IndexOf("\r\n"));
                RS_Default();
                switch(channel)
                {
                    case "Agoda":
                    case "美团":
                    case "青芒果":
                        RS_Prepaid();
                        break;
                    case "携程":
                        if (text.Contains("预付订单"))
                            RS_Prepaid();
                        else if (text.Contains("担保订单"))
                            valueText = "担保 " + valueText;
                        break;
                }
                r.Value = valueText;
                if (r.Comment != null) { r.Comment.Delete(); }
                r.AddComment(text.Substring(index + 3));
                BasicShapeAutoSize(r);
                InitRange(r);
            }
        }

        #endregion

        #region SHARED
        
        private void SetDeposit(string deposit)
        {
            
        }

        private Worksheet Sheet_Today() => AddIn_YuI.App.Worksheets[DateTime.Now.ToString("MM月")];

        #endregion
    }
}
