namespace Kalista
{
    partial class Ribbon_Excel : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon_Excel()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            InitControls();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_roomStatusEdit = this.Factory.CreateRibbonTab();
            this.group_view = this.Factory.CreateRibbonGroup();
            this.checkBox_view_simplify = this.Factory.CreateRibbonCheckBox();
            this.group_tool = this.Factory.CreateRibbonGroup();
            this.checkBox_tool_autoBackup = this.Factory.CreateRibbonCheckBox();
            this.group_roomState = this.Factory.CreateRibbonGroup();
            this.buttonGroup_rs0 = this.Factory.CreateRibbonButtonGroup();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.buttonGroup2 = this.Factory.CreateRibbonButtonGroup();
            this.group_format = this.Factory.CreateRibbonGroup();
            this.buttonGroup3 = this.Factory.CreateRibbonButtonGroup();
            this.button_view_initRN = this.Factory.CreateRibbonButton();
            this.button_view_all = this.Factory.CreateRibbonButton();
            this.splitButton_view_floor = this.Factory.CreateRibbonSplitButton();
            this.button_view_floor_1 = this.Factory.CreateRibbonButton();
            this.button_view_floor_2 = this.Factory.CreateRibbonButton();
            this.button_view_floor_3 = this.Factory.CreateRibbonButton();
            this.button_view_floor_4 = this.Factory.CreateRibbonButton();
            this.splitButton_view_group = this.Factory.CreateRibbonSplitButton();
            this.splitButton_view_quick = this.Factory.CreateRibbonSplitButton();
            this.button_view_filter_exchange = this.Factory.CreateRibbonButton();
            this.button_view_filter_unCheckOut = this.Factory.CreateRibbonButton();
            this.button_view_filter_checkedOut = this.Factory.CreateRibbonButton();
            this.button_view_filter_checkingOut = this.Factory.CreateRibbonButton();
            this.splitButton_view_roomType = this.Factory.CreateRibbonSplitButton();
            this.button_view_copyRef = this.Factory.CreateRibbonButton();
            this.splitButton_tool_forms = this.Factory.CreateRibbonSplitButton();
            this.button_tool_monthReportSheet = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button_form_newRSSheet = this.Factory.CreateRibbonButton();
            this.button_qa_depositForm = this.Factory.CreateRibbonButton();
            this.button_tool_statement = this.Factory.CreateRibbonButton();
            this.button_tool_showResDetailsPanel = this.Factory.CreateRibbonButton();
            this.button_tool_changeEditMode = this.Factory.CreateRibbonButton();
            this.button_getColor = this.Factory.CreateRibbonButton();
            this.button_tool_killExcel = this.Factory.CreateRibbonButton();
            this.button_tool_countCurrency = this.Factory.CreateRibbonButton();
            this.button_qa_copyImage = this.Factory.CreateRibbonButton();
            this.button_qa_transferRecords = this.Factory.CreateRibbonButton();
            this.button_rs_noShow = this.Factory.CreateRibbonButton();
            this.button_rs_default = this.Factory.CreateRibbonButton();
            this.button_rs_prepaid = this.Factory.CreateRibbonButton();
            this.button_rs_unpaid = this.Factory.CreateRibbonButton();
            this.button_rs_paid = this.Factory.CreateRibbonButton();
            this.button_rs_checkedOut = this.Factory.CreateRibbonButton();
            this.button_rs_dep0 = this.Factory.CreateRibbonButton();
            this.button_rs_dep100 = this.Factory.CreateRibbonButton();
            this.button_rs_depOther = this.Factory.CreateRibbonButton();
            this.splitButton_view_markAll = this.Factory.CreateRibbonSplitButton();
            this.button_view_all_paid = this.Factory.CreateRibbonButton();
            this.button_view_all_unpaid = this.Factory.CreateRibbonButton();
            this.button_view_all_prepaid = this.Factory.CreateRibbonButton();
            this.button_view_all_checkedOut = this.Factory.CreateRibbonButton();
            this.button_rs_pickUp = this.Factory.CreateRibbonButton();
            this.button_rs_pasteRes = this.Factory.CreateRibbonButton();
            this.splitButton_fmt_clear = this.Factory.CreateRibbonSplitButton();
            this.button_fmt_clearSelection = this.Factory.CreateRibbonButton();
            this.splitButton_fmt_comment = this.Factory.CreateRibbonSplitButton();
            this.button_fmt_commentUniform = this.Factory.CreateRibbonButton();
            this.button_fmt_commentContent = this.Factory.CreateRibbonButton();
            this.button_fmt_commentClear = this.Factory.CreateRibbonButton();
            this.button_fmt_allBorders = this.Factory.CreateRibbonButton();
            this.tab_roomStatusEdit.SuspendLayout();
            this.group_view.SuspendLayout();
            this.group_tool.SuspendLayout();
            this.group_roomState.SuspendLayout();
            this.buttonGroup_rs0.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            this.buttonGroup2.SuspendLayout();
            this.group_format.SuspendLayout();
            this.buttonGroup3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_roomStatusEdit
            // 
            this.tab_roomStatusEdit.Groups.Add(this.group_view);
            this.tab_roomStatusEdit.Groups.Add(this.group_tool);
            this.tab_roomStatusEdit.Groups.Add(this.group_roomState);
            this.tab_roomStatusEdit.Groups.Add(this.group_format);
            this.tab_roomStatusEdit.Label = "房态编辑";
            this.tab_roomStatusEdit.Name = "tab_roomStatusEdit";
            this.tab_roomStatusEdit.Position = this.Factory.RibbonPosition.AfterOfficeId("TabHome");
            // 
            // group_view
            // 
            this.group_view.Items.Add(this.checkBox_view_simplify);
            this.group_view.Items.Add(this.button_view_initRN);
            this.group_view.Items.Add(this.button_view_all);
            this.group_view.Items.Add(this.splitButton_view_floor);
            this.group_view.Items.Add(this.splitButton_view_group);
            this.group_view.Items.Add(this.splitButton_view_quick);
            this.group_view.Items.Add(this.splitButton_view_roomType);
            this.group_view.Items.Add(this.button_view_copyRef);
            this.group_view.Label = "视图";
            this.group_view.Name = "group_view";
            // 
            // checkBox_view_simplify
            // 
            this.checkBox_view_simplify.Label = "精简视图";
            this.checkBox_view_simplify.Name = "checkBox_view_simplify";
            this.checkBox_view_simplify.ScreenTip = "设置/取消精简视图";
            this.checkBox_view_simplify.SuperTip = "选中时将以精简视图查看房态，隐藏前三列和第一行；取消选中时恢复显示。";
            this.checkBox_view_simplify.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.checkBox_view_simplify_Click);
            // 
            // group_tool
            // 
            this.group_tool.Items.Add(this.splitButton_tool_forms);
            this.group_tool.Items.Add(this.button_tool_showResDetailsPanel);
            this.group_tool.Items.Add(this.button_tool_changeEditMode);
            this.group_tool.Items.Add(this.checkBox_tool_autoBackup);
            this.group_tool.Items.Add(this.button_getColor);
            this.group_tool.Items.Add(this.button_tool_killExcel);
            this.group_tool.Items.Add(this.button_tool_countCurrency);
            this.group_tool.Items.Add(this.button_qa_copyImage);
            this.group_tool.Items.Add(this.button_qa_transferRecords);
            this.group_tool.Label = "工具";
            this.group_tool.Name = "group_tool";
            // 
            // checkBox_tool_autoBackup
            // 
            this.checkBox_tool_autoBackup.Label = "自动备份";
            this.checkBox_tool_autoBackup.Name = "checkBox_tool_autoBackup";
            // 
            // group_roomState
            // 
            this.group_roomState.Items.Add(this.buttonGroup_rs0);
            this.group_roomState.Items.Add(this.buttonGroup1);
            this.group_roomState.Items.Add(this.buttonGroup2);
            this.group_roomState.Items.Add(this.splitButton_view_markAll);
            this.group_roomState.Items.Add(this.button_rs_pickUp);
            this.group_roomState.Items.Add(this.button_rs_pasteRes);
            this.group_roomState.Label = "房态";
            this.group_roomState.Name = "group_roomState";
            // 
            // buttonGroup_rs0
            // 
            this.buttonGroup_rs0.Items.Add(this.button_rs_noShow);
            this.buttonGroup_rs0.Items.Add(this.button_rs_default);
            this.buttonGroup_rs0.Items.Add(this.button_rs_prepaid);
            this.buttonGroup_rs0.Name = "buttonGroup_rs0";
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Items.Add(this.button_rs_unpaid);
            this.buttonGroup1.Items.Add(this.button_rs_paid);
            this.buttonGroup1.Items.Add(this.button_rs_checkedOut);
            this.buttonGroup1.Name = "buttonGroup1";
            // 
            // buttonGroup2
            // 
            this.buttonGroup2.Items.Add(this.button_rs_dep0);
            this.buttonGroup2.Items.Add(this.button_rs_dep100);
            this.buttonGroup2.Items.Add(this.button_rs_depOther);
            this.buttonGroup2.Name = "buttonGroup2";
            // 
            // group_format
            // 
            this.group_format.Items.Add(this.splitButton_fmt_clear);
            this.group_format.Items.Add(this.splitButton_fmt_comment);
            this.group_format.Items.Add(this.buttonGroup3);
            this.group_format.Label = "格式";
            this.group_format.Name = "group_format";
            // 
            // buttonGroup3
            // 
            this.buttonGroup3.Items.Add(this.button_fmt_allBorders);
            this.buttonGroup3.Name = "buttonGroup3";
            // 
            // button_view_initRN
            // 
            this.button_view_initRN.Label = "初始化房号";
            this.button_view_initRN.Name = "button_view_initRN";
            this.button_view_initRN.ShowImage = true;
            this.button_view_initRN.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_initRN_Click);
            // 
            // button_view_all
            // 
            this.button_view_all.Label = "所有房态";
            this.button_view_all.Name = "button_view_all";
            this.button_view_all.ShowImage = true;
            this.button_view_all.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_all_Click);
            // 
            // splitButton_view_floor
            // 
            this.splitButton_view_floor.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton_view_floor.Items.Add(this.button_view_floor_1);
            this.splitButton_view_floor.Items.Add(this.button_view_floor_2);
            this.splitButton_view_floor.Items.Add(this.button_view_floor_3);
            this.splitButton_view_floor.Items.Add(this.button_view_floor_4);
            this.splitButton_view_floor.Label = "楼层筛选";
            this.splitButton_view_floor.Name = "splitButton_view_floor";
            this.splitButton_view_floor.OfficeImageId = "Filter";
            // 
            // button_view_floor_1
            // 
            this.button_view_floor_1.Label = "一楼";
            this.button_view_floor_1.Name = "button_view_floor_1";
            this.button_view_floor_1.ShowImage = true;
            this.button_view_floor_1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_floor_1_Click);
            // 
            // button_view_floor_2
            // 
            this.button_view_floor_2.Label = "二楼";
            this.button_view_floor_2.Name = "button_view_floor_2";
            this.button_view_floor_2.ShowImage = true;
            this.button_view_floor_2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_floor_2_Click);
            // 
            // button_view_floor_3
            // 
            this.button_view_floor_3.Label = "三楼";
            this.button_view_floor_3.Name = "button_view_floor_3";
            this.button_view_floor_3.ShowImage = true;
            this.button_view_floor_3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_floor_3_Click);
            // 
            // button_view_floor_4
            // 
            this.button_view_floor_4.Label = "四楼";
            this.button_view_floor_4.Name = "button_view_floor_4";
            this.button_view_floor_4.ShowImage = true;
            this.button_view_floor_4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_floor_4_Click);
            // 
            // splitButton_view_group
            // 
            this.splitButton_view_group.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton_view_group.Label = "团队筛选";
            this.splitButton_view_group.Name = "splitButton_view_group";
            this.splitButton_view_group.OfficeImageId = "Filter";
            // 
            // splitButton_view_quick
            // 
            this.splitButton_view_quick.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton_view_quick.Items.Add(this.button_view_filter_exchange);
            this.splitButton_view_quick.Items.Add(this.button_view_filter_unCheckOut);
            this.splitButton_view_quick.Items.Add(this.button_view_filter_checkedOut);
            this.splitButton_view_quick.Items.Add(this.button_view_filter_checkingOut);
            this.splitButton_view_quick.Label = "快捷筛选";
            this.splitButton_view_quick.Name = "splitButton_view_quick";
            this.splitButton_view_quick.OfficeImageId = "Filter";
            // 
            // button_view_filter_exchange
            // 
            this.button_view_filter_exchange.Label = "换房";
            this.button_view_filter_exchange.Name = "button_view_filter_exchange";
            this.button_view_filter_exchange.ShowImage = true;
            this.button_view_filter_exchange.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_filter_exchange_Click);
            // 
            // button_view_filter_unCheckOut
            // 
            this.button_view_filter_unCheckOut.Label = "未退房";
            this.button_view_filter_unCheckOut.Name = "button_view_filter_unCheckOut";
            this.button_view_filter_unCheckOut.ShowImage = true;
            this.button_view_filter_unCheckOut.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_filter_unCheckOut_Click);
            // 
            // button_view_filter_checkedOut
            // 
            this.button_view_filter_checkedOut.Label = "已退房";
            this.button_view_filter_checkedOut.Name = "button_view_filter_checkedOut";
            this.button_view_filter_checkedOut.ShowImage = true;
            this.button_view_filter_checkedOut.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_filter_checkedOut_Click);
            // 
            // button_view_filter_checkingOut
            // 
            this.button_view_filter_checkingOut.Label = "今日退房";
            this.button_view_filter_checkingOut.Name = "button_view_filter_checkingOut";
            this.button_view_filter_checkingOut.ShowImage = true;
            this.button_view_filter_checkingOut.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_filter_checkingOut_Click);
            // 
            // splitButton_view_roomType
            // 
            this.splitButton_view_roomType.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.splitButton_view_roomType.Label = "房型筛选";
            this.splitButton_view_roomType.Name = "splitButton_view_roomType";
            this.splitButton_view_roomType.OfficeImageId = "Filter";
            // 
            // button_view_copyRef
            // 
            this.button_view_copyRef.Label = "复制订单号";
            this.button_view_copyRef.Name = "button_view_copyRef";
            this.button_view_copyRef.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_copyRef_Click);
            // 
            // splitButton_tool_forms
            // 
            this.splitButton_tool_forms.Items.Add(this.button_tool_monthReportSheet);
            this.splitButton_tool_forms.Items.Add(this.button1);
            this.splitButton_tool_forms.Items.Add(this.button_form_newRSSheet);
            this.splitButton_tool_forms.Items.Add(this.button_qa_depositForm);
            this.splitButton_tool_forms.Items.Add(this.button_tool_statement);
            this.splitButton_tool_forms.Label = "表格生成";
            this.splitButton_tool_forms.Name = "splitButton_tool_forms";
            // 
            // button_tool_monthReportSheet
            // 
            this.button_tool_monthReportSheet.Label = "月度收入报表";
            this.button_tool_monthReportSheet.Name = "button_tool_monthReportSheet";
            this.button_tool_monthReportSheet.ShowImage = true;
            this.button_tool_monthReportSheet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_tool_monthReportSheet_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Label = "年度房态表";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            // 
            // button_form_newRSSheet
            // 
            this.button_form_newRSSheet.Label = "当前房态表";
            this.button_form_newRSSheet.Name = "button_form_newRSSheet";
            this.button_form_newRSSheet.ShowImage = true;
            this.button_form_newRSSheet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_form_newRSSheet_Click);
            // 
            // button_qa_depositForm
            // 
            this.button_qa_depositForm.Enabled = false;
            this.button_qa_depositForm.Label = "今日押金";
            this.button_qa_depositForm.Name = "button_qa_depositForm";
            this.button_qa_depositForm.ShowImage = true;
            this.button_qa_depositForm.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_qa_depositForm_Click);
            // 
            // button_tool_statement
            // 
            this.button_tool_statement.Enabled = false;
            this.button_tool_statement.Label = "收入报表";
            this.button_tool_statement.Name = "button_tool_statement";
            this.button_tool_statement.ShowImage = true;
            // 
            // button_tool_showResDetailsPanel
            // 
            this.button_tool_showResDetailsPanel.Label = "显示订单面板";
            this.button_tool_showResDetailsPanel.Name = "button_tool_showResDetailsPanel";
            this.button_tool_showResDetailsPanel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShowResDetailsButton_Click);
            // 
            // button_tool_changeEditMode
            // 
            this.button_tool_changeEditMode.Label = "变更编辑模式";
            this.button_tool_changeEditMode.Name = "button_tool_changeEditMode";
            this.button_tool_changeEditMode.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ChangeEditModeButton_Click);
            // 
            // button_getColor
            // 
            this.button_getColor.Label = "获取颜色";
            this.button_getColor.Name = "button_getColor";
            this.button_getColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_getColor_Click);
            // 
            // button_tool_killExcel
            // 
            this.button_tool_killExcel.Enabled = false;
            this.button_tool_killExcel.Label = "修复加载项";
            this.button_tool_killExcel.Name = "button_tool_killExcel";
            this.button_tool_killExcel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_tool_killExcel_Click);
            // 
            // button_tool_countCurrency
            // 
            this.button_tool_countCurrency.Label = "外币计算";
            this.button_tool_countCurrency.Name = "button_tool_countCurrency";
            this.button_tool_countCurrency.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_tool_countCurrency_Click);
            // 
            // button_qa_copyImage
            // 
            this.button_qa_copyImage.Label = "工作表图片";
            this.button_qa_copyImage.Name = "button_qa_copyImage";
            this.button_qa_copyImage.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_qa_copyImage_Click);
            // 
            // button_qa_transferRecords
            // 
            this.button_qa_transferRecords.Label = "转账记录";
            this.button_qa_transferRecords.Name = "button_qa_transferRecords";
            this.button_qa_transferRecords.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_qa_transferRecords_Click);
            // 
            // button_rs_noShow
            // 
            this.button_rs_noShow.Label = "button1";
            this.button_rs_noShow.Name = "button_rs_noShow";
            this.button_rs_noShow.ShowImage = true;
            this.button_rs_noShow.ShowLabel = false;
            this.button_rs_noShow.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_noShow_Click);
            // 
            // button_rs_default
            // 
            this.button_rs_default.Label = "button1";
            this.button_rs_default.Name = "button_rs_default";
            this.button_rs_default.ShowImage = true;
            this.button_rs_default.ShowLabel = false;
            this.button_rs_default.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_default_Click);
            // 
            // button_rs_prepaid
            // 
            this.button_rs_prepaid.Label = "button1";
            this.button_rs_prepaid.Name = "button_rs_prepaid";
            this.button_rs_prepaid.ShowImage = true;
            this.button_rs_prepaid.ShowLabel = false;
            this.button_rs_prepaid.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_prepaid_Click);
            // 
            // button_rs_unpaid
            // 
            this.button_rs_unpaid.Label = "button1";
            this.button_rs_unpaid.Name = "button_rs_unpaid";
            this.button_rs_unpaid.ShowImage = true;
            this.button_rs_unpaid.ShowLabel = false;
            this.button_rs_unpaid.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_unpaid_Click);
            // 
            // button_rs_paid
            // 
            this.button_rs_paid.Label = "button1";
            this.button_rs_paid.Name = "button_rs_paid";
            this.button_rs_paid.ShowImage = true;
            this.button_rs_paid.ShowLabel = false;
            this.button_rs_paid.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_paid_Click);
            // 
            // button_rs_checkedOut
            // 
            this.button_rs_checkedOut.Label = "button1";
            this.button_rs_checkedOut.Name = "button_rs_checkedOut";
            this.button_rs_checkedOut.ShowImage = true;
            this.button_rs_checkedOut.ShowLabel = false;
            this.button_rs_checkedOut.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_checkedOut_Click);
            // 
            // button_rs_dep0
            // 
            this.button_rs_dep0.Label = "button2";
            this.button_rs_dep0.Name = "button_rs_dep0";
            this.button_rs_dep0.ShowImage = true;
            this.button_rs_dep0.ShowLabel = false;
            this.button_rs_dep0.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_dep0_Click);
            // 
            // button_rs_dep100
            // 
            this.button_rs_dep100.Label = "button2";
            this.button_rs_dep100.Name = "button_rs_dep100";
            this.button_rs_dep100.ShowImage = true;
            this.button_rs_dep100.ShowLabel = false;
            this.button_rs_dep100.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_dep100_Click);
            // 
            // button_rs_depOther
            // 
            this.button_rs_depOther.Label = "button2";
            this.button_rs_depOther.Name = "button_rs_depOther";
            this.button_rs_depOther.ShowImage = true;
            this.button_rs_depOther.ShowLabel = false;
            this.button_rs_depOther.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_depOther_Click);
            // 
            // splitButton_view_markAll
            // 
            this.splitButton_view_markAll.Items.Add(this.button_view_all_paid);
            this.splitButton_view_markAll.Items.Add(this.button_view_all_unpaid);
            this.splitButton_view_markAll.Items.Add(this.button_view_all_prepaid);
            this.splitButton_view_markAll.Items.Add(this.button_view_all_checkedOut);
            this.splitButton_view_markAll.Label = "标记订单";
            this.splitButton_view_markAll.Name = "splitButton_view_markAll";
            // 
            // button_view_all_paid
            // 
            this.button_view_all_paid.Label = "已付";
            this.button_view_all_paid.Name = "button_view_all_paid";
            this.button_view_all_paid.ShowImage = true;
            this.button_view_all_paid.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_all_paid_Click);
            // 
            // button_view_all_unpaid
            // 
            this.button_view_all_unpaid.Label = "未付";
            this.button_view_all_unpaid.Name = "button_view_all_unpaid";
            this.button_view_all_unpaid.ShowImage = true;
            this.button_view_all_unpaid.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_all_unpaid_Click);
            // 
            // button_view_all_prepaid
            // 
            this.button_view_all_prepaid.Label = "预付";
            this.button_view_all_prepaid.Name = "button_view_all_prepaid";
            this.button_view_all_prepaid.ShowImage = true;
            this.button_view_all_prepaid.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_all_prepaid_Click);
            // 
            // button_view_all_checkedOut
            // 
            this.button_view_all_checkedOut.Label = "已退";
            this.button_view_all_checkedOut.Name = "button_view_all_checkedOut";
            this.button_view_all_checkedOut.ShowImage = true;
            this.button_view_all_checkedOut.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_view_all_checkedOut_Click);
            // 
            // button_rs_pickUp
            // 
            this.button_rs_pickUp.Enabled = false;
            this.button_rs_pickUp.Label = "接机安排";
            this.button_rs_pickUp.Name = "button_rs_pickUp";
            this.button_rs_pickUp.ShowImage = true;
            this.button_rs_pickUp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_pickUp_Click);
            // 
            // button_rs_pasteRes
            // 
            this.button_rs_pasteRes.KeyTip = "R";
            this.button_rs_pasteRes.Label = "粘贴预订";
            this.button_rs_pasteRes.Name = "button_rs_pasteRes";
            this.button_rs_pasteRes.ShowImage = true;
            this.button_rs_pasteRes.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_rs_pasteRes_Click);
            // 
            // splitButton_fmt_clear
            // 
            this.splitButton_fmt_clear.Items.Add(this.button_fmt_clearSelection);
            this.splitButton_fmt_clear.Label = "清除区域";
            this.splitButton_fmt_clear.Name = "splitButton_fmt_clear";
            this.splitButton_fmt_clear.OfficeImageId = "DeclineInvitation";
            // 
            // button_fmt_clearSelection
            // 
            this.button_fmt_clearSelection.Label = "清除选中";
            this.button_fmt_clearSelection.Name = "button_fmt_clearSelection";
            this.button_fmt_clearSelection.ShowImage = true;
            // 
            // splitButton_fmt_comment
            // 
            this.splitButton_fmt_comment.Items.Add(this.button_fmt_commentUniform);
            this.splitButton_fmt_comment.Items.Add(this.button_fmt_commentContent);
            this.splitButton_fmt_comment.Items.Add(this.button_fmt_commentClear);
            this.splitButton_fmt_comment.Label = "批注自调";
            this.splitButton_fmt_comment.Name = "splitButton_fmt_comment";
            this.splitButton_fmt_comment.OfficeImageId = "MailMergeRecipientsEditList";
            // 
            // button_fmt_commentUniform
            // 
            this.button_fmt_commentUniform.Label = "当前选中";
            this.button_fmt_commentUniform.Name = "button_fmt_commentUniform";
            this.button_fmt_commentUniform.ShowImage = true;
            this.button_fmt_commentUniform.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_fmt_commentUniform_Click);
            // 
            // button_fmt_commentContent
            // 
            this.button_fmt_commentContent.Label = "当前工作表";
            this.button_fmt_commentContent.Name = "button_fmt_commentContent";
            this.button_fmt_commentContent.ShowImage = true;
            // 
            // button_fmt_commentClear
            // 
            this.button_fmt_commentClear.Label = "当前工作簿";
            this.button_fmt_commentClear.Name = "button_fmt_commentClear";
            this.button_fmt_commentClear.ShowImage = true;
            this.button_fmt_commentClear.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_fmt_commentClear_Click);
            // 
            // button_fmt_allBorders
            // 
            this.button_fmt_allBorders.Label = "全部边框";
            this.button_fmt_allBorders.Name = "button_fmt_allBorders";
            this.button_fmt_allBorders.ShowImage = true;
            this.button_fmt_allBorders.ShowLabel = false;
            this.button_fmt_allBorders.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_fmt_allBorders_Click);
            // 
            // Ribbon_Excel
            // 
            this.Name = "Ribbon_Excel";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab_roomStatusEdit);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Excel_Load);
            this.tab_roomStatusEdit.ResumeLayout(false);
            this.tab_roomStatusEdit.PerformLayout();
            this.group_view.ResumeLayout(false);
            this.group_view.PerformLayout();
            this.group_tool.ResumeLayout(false);
            this.group_tool.PerformLayout();
            this.group_roomState.ResumeLayout(false);
            this.group_roomState.PerformLayout();
            this.buttonGroup_rs0.ResumeLayout(false);
            this.buttonGroup_rs0.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();
            this.buttonGroup2.ResumeLayout(false);
            this.buttonGroup2.PerformLayout();
            this.group_format.ResumeLayout(false);
            this.group_format.PerformLayout();
            this.buttonGroup3.ResumeLayout(false);
            this.buttonGroup3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab_roomStatusEdit;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_view;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_roomState;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup_rs0;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_noShow;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_default;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_prepaid;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_unpaid;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_paid;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_checkedOut;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_pasteRes;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_pickUp;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_format;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox_view_simplify;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_qa_depositForm;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_fmt_comment;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_fmt_clear;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_fmt_commentUniform;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_fmt_allBorders;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_dep0;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_dep100;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_rs_depOther;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_fmt_commentContent;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_fmt_commentClear;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_fmt_clearSelection;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_tool;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup3;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_view_floor;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_floor_1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_floor_2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_floor_3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_floor_4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_all;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox_tool_autoBackup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_getColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_initRN;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_tool_statement;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_view_group;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_tool_monthReportSheet;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_view_quick;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_filter_exchange;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_filter_unCheckOut;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_filter_checkedOut;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_filter_checkingOut;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_tool_killExcel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_copyRef;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_qa_copyImage;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_view_roomType;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_tool_showResDetailsPanel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_tool_changeEditMode;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_qa_transferRecords;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_tool_countCurrency;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_tool_forms;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_form_newRSSheet;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton_view_markAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_all_paid;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_all_unpaid;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_all_checkedOut;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_view_all_prepaid;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon_Excel Ribbon_Excel
        {
            get { return this.GetRibbon<Ribbon_Excel>(); }
        }
    }
}
