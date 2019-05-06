using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;
using YuI = Kalista.AddIn_YuI;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;

namespace Kalista
{
    public partial class Ribbon_Excel
    {
        #region Fields

        public static Microsoft.Office.Interop.Excel.Application App => YuI.App;
        public static Workbook ActWorkbook => App.ActiveWorkbook;
        public static Worksheet ActSheet => App.ActiveSheet;
        public static Range ActCell => App.ActiveCell;
        public static Range ActSelection => App.Selection;
        public static int YesterdayColumnIndex => DateTime.Now.Day + 3;
        public static int TodayColumnIndex => DateTime.Now.Day + 4;
        public static int MinRowIndex => Setter.RoomState_MinRowIndex;
        public static int MaxRowIndex => Setter.RoomState_MaxRowIndex;

        #endregion
        
        partial void InitControls();

        #region MAIN

        private void Ribbon_Excel_Load(object sender, RibbonUIEventArgs e)
        {
            Setter.Initialize();
            InitializeButtonImage();
        }

        private void InitializeButtonImage()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\Kalista\\buttons.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("按钮图标配置文件不存在，目标路径：" + path);
                return;
            }
            List<RibbonButton> buttons = new List<RibbonButton>();
            string typeName = "";
            foreach (RibbonTab tab in this.Tabs)
            {
                foreach (RibbonGroup group in tab.Groups)
                {
                    foreach (RibbonControl obj in group.Items)
                    {
                        typeName = obj.GetType().Name;
                        if (typeName == "RibbonButtonImpl")
                            buttons.Add(obj as RibbonButton);
                        else if (typeName == "RibbonSplitButtonImpl")
                        {
                            foreach (RibbonButton button in ((RibbonSplitButton)obj).Items)
                                buttons.Add(button);
                        }
                        else if (typeName == "RibbonButtonGroupImpl")
                        {
                            foreach (RibbonButton button in ((RibbonButtonGroup)obj).Items)
                                buttons.Add(button);
                        }
                        else
                            continue;
                    }
                }
            }
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string[] id = new string[6];
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                if (str.StartsWith("//"))
                    continue;
                id = str.Split(',');
                if (id[0] == null || id[0] == "")
                    continue;
                RibbonButton button = buttons.Find(x => x.Name == id[0]);
                if (button == null)
                    continue;
                button.OfficeImageId = id[1];
                button.Visible = id[2] != "0";
                button.KeyTip = id[3];
                button.ScreenTip = id[4];
                button.SuperTip = id[5];
            }
            sr.Close();
            fs.Close();
        }

        #endregion

        #region VIEW

        private void checkBox_view_simplify_Click(object sender, RibbonControlEventArgs e)
        {
            if (IsRoomTipsHidden)
            {
                ShowRoomTips();
                checkBox_view_simplify.Checked = false;
            }
            else
            {
                HideRoomTips();
                checkBox_view_simplify.Checked = true;
            }
        }
        
        private void button_view_initRN_Click(object sender, RibbonControlEventArgs e)
        {
            FormatRoomNumberToString();
        }

        private void button_view_floor_1_Click(object sender, RibbonControlEventArgs e)
        {
            FilterByFloor_1();
        }

        private void button_view_floor_2_Click(object sender, RibbonControlEventArgs e)
        {
            FilterByFloor_2();
        }

        private void button_view_floor_3_Click(object sender, RibbonControlEventArgs e)
        {
            FilterByFloor_3();
        }

        private void button_view_floor_4_Click(object sender, RibbonControlEventArgs e)
        {
            FilterByFloor_4();
        }

        #endregion

        #region ROOMSTATUS

        private void button_rs_noShow_Click(object sender, RibbonControlEventArgs e)
        {
            RS_NoShow();
        }

        private void button_rs_default_Click(object sender, RibbonControlEventArgs e)
        {
            RS_Default();
        }

        private void button_rs_prepaid_Click(object sender, RibbonControlEventArgs e)
        {
            RS_Prepaid();
        }

        private void button_rs_unpaid_Click(object sender, RibbonControlEventArgs e)
        {
            RS_Unpaid();
        }

        private void button_rs_paid_Click(object sender, RibbonControlEventArgs e)
        {
            RS_Paid();
        }

        private void button_rs_checkedOut_Click(object sender, RibbonControlEventArgs e)
        {
            RS_CheckedOut();
        }

        private void button_rs_pickUp_Click(object sender, RibbonControlEventArgs e)
        {
            //PickUp_Book();
            PickUpForm.ShowPickUpForm();
        }

        private void button_rs_pasteRes_Click(object sender, RibbonControlEventArgs e)
        {
            RES_PasteReservation();
        }

        #endregion

        #region FORMAT

        private void button_fmt_allBorders_Click(object sender, RibbonControlEventArgs e)
        {
            InitRange(ActSelection);
        }

        private void button_fmt_shape_Click(object sender, RibbonControlEventArgs e)
        {
            //ShapeAutoSize_Selected();
        }

        private void button_fmt_bordersAll_Click(object sender, RibbonControlEventArgs e)
        {
            BordersAll(ActSelection);
        }

        private void button_fmt_initialize_Click(object sender, RibbonControlEventArgs e)
        {
            ItinializeSelected();
        }

        private static void FORMAT_InitializeControls()
        {

        }

        #endregion
        
        private void button_fmt_commentUniform_Click(object sender, RibbonControlEventArgs e)
        {
            ShapeAutoSizeByAutoFit(ActCell);
            //ShapeAutoSize_ActiveCell();
        }

        private void button_rs_dep0_Click(object sender, RibbonControlEventArgs e)
        {
            SetDep_0();
        }

        private void button_rs_dep100_Click(object sender, RibbonControlEventArgs e)
        {
            SetDep_100();
        }

        private void button_rs_depOther_Click(object sender, RibbonControlEventArgs e)
        {
            SetDep_Custom();
        }

        private void button_qa_depositForm_Click(object sender, RibbonControlEventArgs e)
        {
            
        }

        private void button_getColor_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show(ActCell.Interior.Color.ToString());
        }
        
        private void button_view_all_Click(object sender, RibbonControlEventArgs e)
        {
            ActSheet.SuperShowAllData();
        }

        private void button_tool_monthReportSheet_Click(object sender, RibbonControlEventArgs e)
        {
            MonthReportForm.ShowMonthReportForm();
        }

        private void button_view_filter_exchange_Click(object sender, RibbonControlEventArgs e)
        {
            App.ScreenUpdating = false;
            ActSheet.HideAllRooms();
            for(int rI = Setter.RoomState_MinRowIndex; rI < Setter.RoomState_MaxRowIndex + 1; rI++)
            {
                string tValue = ActSheet.GetValue(rI, TodayColumnIndex);
                string yValue = ActSheet.GetValue(rI, TodayColumnIndex - 1);
                if ((!string.IsNullOrEmpty(tValue) && Regex.IsMatch(tValue, @"\d+[转至]+")) ||
                    (!string.IsNullOrEmpty(yValue) && Regex.IsMatch(yValue, @"[转至]+\d+"))) 
                    ActSheet.Rows[rI].Hidden = false;
            }
            App.ScreenUpdating = true;
        }

        private void button_view_filter_unCheckOut_Click(object sender, RibbonControlEventArgs e)
        {
            return;
            /*
            App.ScreenUpdating = false;
            ActSheet.HideAllRooms();
            for (int rI = Setter.RoomState_MinRowIndex; rI < Setter.RoomState_MaxRowIndex + 1; rI++)
            {
                RoomStatusRange yR = new RoomStatusRange(ActSheet.Cells[rI, TodayColumnIndex - 1]);
                RoomStatusRange tR = new RoomStatusRange(ActSheet.Cells[rI, TodayColumnIndex]);
                if (yR.GuestName == null || yR.GuestName == tR.GuestName) continue;
                if (yR.RoomState == RoomState.CHECKED_IN) ActSheet.Rows[rI].Hidden = false;
            }
            App.ScreenUpdating = true;*/
        }

        private void button_view_filter_checkedOut_Click(object sender, RibbonControlEventArgs e)
        {
            App.ScreenUpdating = false;
            ActSheet.HideAllRooms();
            for (int rI = Setter.RoomState_MinRowIndex; rI < Setter.RoomState_MaxRowIndex + 1; rI++)
            {
                Range yR = ActSheet.Cells[rI, TodayColumnIndex - 1];
                string yColor = yR.Interior.Color.ToString();
                if (yColor == "8421504") ActSheet.Rows[rI].Hidden = false;
            }
            App.ScreenUpdating = true;
        }

        private void button_view_filter_checkingOut_Click(object sender, RibbonControlEventArgs e)
        {
            return;
            /*App.ScreenUpdating = false;
            ActSheet.HideAllRooms();
            for (int rI = Setter.RoomState_MinRowIndex; rI < Setter.RoomState_MaxRowIndex + 1; rI++)
            {
                RoomStatusRange yR = new RoomStatusRange(ActSheet.Cells[rI, TodayColumnIndex - 1]);
                RoomStatusRange tR = new RoomStatusRange(ActSheet.Cells[rI, TodayColumnIndex]);
                if (yR.GuestName == null || yR.GuestName == tR.GuestName) continue;
                ActSheet.Rows[rI].Hidden = false;
            }
            App.ScreenUpdating = true;*/
        }

        private void button_tool_killExcel_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void button_view_copyRef_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Clipboard.SetText((new Regex(@"(?<=[Rr]?ef[:：]*\s*)\d+"))
                    .Match(ActSelection.CommentString()).Value);
                button_view_copyRef.Label = "复制订单号√";
            }
            catch
            {
                Clipboard.Clear();
                button_view_copyRef.Label = "复制订单号×";
            }
        }

        private void button_qa_copyImage_Click(object sender, RibbonControlEventArgs e)
        {
            SheetToImageForm.ShowOnApplication(App);
        }

        private void button_qa_transferRecords_Click(object sender, RibbonControlEventArgs e)
        {
            if (!new Regex(@"[白夜]班收入").IsMatch(ActWorkbook.Name)) return;
        }

        private void button_tool_countCurrency_Click(object sender, RibbonControlEventArgs e)
        {
            Forms.CurrencyForm.ShowCurrencyFrom();
        }

        private void ShowResDetailsButton_Click(object sender, RibbonControlEventArgs e)
        {
            YuI.ShowTaskPane(ActWorkbook, TaskPaneType.订单列表);
        }

        private void ChangeEditModeButton_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeEditMode();
        }

        private void button_form_newRSSheet_Click(object sender, RibbonControlEventArgs e)
        {
            CreateCurrentRoomStatusSheet();
        }

        private void button_view_all_paid_Click(object sender, RibbonControlEventArgs e)
        {
            _ChangeRoomState(ResCellColor.Blue);
        }

        private void button_view_all_unpaid_Click(object sender, RibbonControlEventArgs e)
        {
            _ChangeRoomState(ResCellColor.Red);
        }

        private void button_view_all_checkedOut_Click(object sender, RibbonControlEventArgs e)
        {
            _ChangeRoomState(ResCellColor.Gray);
        }

        private void button_view_all_prepaid_Click(object sender, RibbonControlEventArgs e)
        {
            _ChangeRoomState(ResCellColor.Yellow);
        }

        private void button_fmt_commentClear_Click(object sender, RibbonControlEventArgs e)
        {
            ShapeAutoSize_Workbook();
        }
    }
}
