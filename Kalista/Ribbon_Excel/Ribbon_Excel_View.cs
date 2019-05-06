using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.VisualBasic;

namespace Kalista
{
    //F3C:前三列；TRS：交通饭店房态
    public partial class Ribbon_Excel
    {
        partial void InitControls()
        {
            InitGroupFilterButtons();
            InitRoomTypeFilterButtons();
        }

        private void InitGroupFilterButtons()
        {
            for(int i = 0; i < splitButton_view_group.Items.Count - 2; i++)
            {
                splitButton_view_group.Items.RemoveAt(i);
            }
            foreach (string groupName in Properties.Settings.Default.GroupNameList.Split(','))
            {
                RibbonButton rb = this.Factory.CreateRibbonButton();
                rb.Label = groupName;
                rb.Click += new RibbonControlEventHandler(FilterRoomStatusByGroup);
                splitButton_view_group.Items.Add(rb);
            }
            RibbonButton crb = splitButton_view_group.Items.Last() as RibbonButton;
            if(crb is null || crb.Label != "自定义")
            {
                RibbonButton rb = this.Factory.CreateRibbonButton();
                rb.Label = "自定义";
                rb.Click += new RibbonControlEventHandler(FilterRoomStatusByGroupCustom);
                splitButton_view_group.Items.Add(rb);
            }
            splitButton_view_group.Label = splitButton_view_group.Label;
            splitButton_view_group.OfficeImageId = splitButton_view_group.OfficeImageId;
        }

        private void FilterRoomStatusByGroup(object sender, RibbonControlEventArgs e)
        {
            RibbonButton rb = sender as RibbonButton;
            if (rb is null) return;
            ActSheet.SuperShowAllData();
            int cI = ActCell.Column;
            Range columnRange = ActSheet.Columns[cI];
            columnRange.AutoFilter(cI, string.Format("=*{0}*", rb.Label), XlAutoFilterOperator.xlAnd);
        }

        private void FilterRoomStatusByGroupCustom(object sender, RibbonControlEventArgs e)
        {
            string groupName = Interaction.InputBox("请输入要筛选的团队名称：", "提示");
            if (string.IsNullOrEmpty(groupName)) return;
            Properties.Settings.Default.GroupNameList += "," + groupName;
            FilterRoomStatusByGroup(
                splitButton_view_group.Items[splitButton_view_group.Items.Count - 2], null);
        }

        private void InitRoomTypeFilterButtons()
        {
            foreach (string type in Properties.Resources.RoomTypeString.Split(','))
            {
                RibbonButton button = this.Factory.CreateRibbonButton();
                button.Label = type;
                splitButton_view_roomType.Items.Add(button);
                button.Click += RoomTypeFilterButton_Click;
            }
        }

        private void RoomTypeFilterButton_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonButton button = sender as RibbonButton;
            App.ScreenUpdating = false;
            ActSheet.HideAllRooms();
            string label = button.Label;
            for (int ri = Setter.RoomState_MinRowIndex; ri <= Setter.RoomState_MaxRowIndex; ri++)
            {
                Range roomRange = ActSheet.Cells[ri, 3];
                if (roomRange.MergeArea[1, 1].Value.ToString() == label)
                {
                    foreach(Range r in roomRange.MergeArea)
                    {
                        ActSheet.Rows[r.Row].Hidden = false;
                    }
                    break;
                }
                else
                {
                    ri += roomRange.MergeArea.Count - 1;
                }
            }
            App.ScreenUpdating = true;
        }

        public void FormatRoomNumberToString()
        {
            try
            {
                int iFirst = 3;
                int iLast = 92;
                foreach (Worksheet ws in ActWorkbook.Sheets)
                {
                    if (!ws.Name.Contains("月")) continue;
                    for (int ri = iFirst; ri < iLast + 1; ri++)
                    {
                        Range r = ws.Cells[ri, 4];
                        if (r is null) continue;
                        var v = r.Value;
                        if (v is null || string.IsNullOrEmpty(v.ToString())) continue;
                        r.FormulaR1C1 = "'" + v.ToString();
                    }
                }
                System.Windows.Forms.MessageBox.Show("所有工作表已初始化完成！");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("存在初始化失败的工作表！");
            }
        }

        private bool IsRoomTipsHidden => ActSheet.Columns["A:C"].Hidden && ActSheet.Rows["1:1"].Hidden;

        private void HideRoomTips()
        {
            ActSheet.Columns["A:C"].Hidden = true;
            ActSheet.Rows["1:1"].Hidden = true;
        }

        private void ShowRoomTips()
        {
            ActSheet.Columns["A:C"].Hidden = false;
            ActSheet.Rows["1:1"].Hidden = false;
        }

        public void FilterByFloor_1()
        {
            FilterByFloor(1);
        }

        public void FilterByFloor_2()
        {
            FilterByFloor(2);
        }

        public void FilterByFloor_3()
        {
            FilterByFloor(3);
        }

        public void FilterByFloor_4()
        {
            FilterByFloor(4);
        }

        #region SHARED

        private void FilterByFloor(int floor)
        {
            Range columnRange = ActSheet.UsedRange;
            if (floor < 1 || floor > 4)
                columnRange.AutoFilter(4);
            else if (floor == 1)
                columnRange.AutoFilter(4, string.Format("{0}*", floor), XlAutoFilterOperator.xlOr, "=");
            else
                columnRange.AutoFilter(4, string.Format("{0}*", floor));
        }

        #endregion
        
    }
}
