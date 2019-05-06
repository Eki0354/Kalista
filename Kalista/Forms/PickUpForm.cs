using Kalista.Properties;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI = Kalista.AddIn_YuI;

namespace Kalista
{
    public enum PUResState
    {
        None,
        Unformatted,
        Formatted
    }

    public partial class PickUpForm : Form
    {
        static PickUpForm _PUForm;
        bool _IsFirstLoad = true;
        PUResState _State;
        string _OtherCommentText;
        PUResItem _Item = new PUResItem();

        public PickUpForm()
        {
            InitializeComponent();
            for (int i = 0; i < 60; i++)
            {
                string num = i.ToString().PadLeft(2, '0');
                if (i < 24)
                    cB_hour.Items.Add(num);
                cB_minute.Items.Add(num);
            }
            ListExtension.GetRandomStaffList(new List<string>(
                Resources.StaffSet.Split(','))).ForEach(staff => cB_staff.Items.Add(staff));
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private string GetPuResText()
        {
            Range r = AI.App.ActiveCell;
            this.tB_name.Text = RoomCell.GetGuestName(r);
            Comment c = r.Comment;
            string text = null;
            if (c == null)
            {
                _State = PUResState.None;
            }
            else
            {
                text = c.Shape.AlternativeText;
                _State = (text == null || !text.Contains("接机")) ? PUResState.None :
                    text.Contains("</接机>") ? PUResState.Formatted : PUResState.Unformatted;
            }
            if (string.IsNullOrEmpty(text)) return text;
            return text.Replace("\r", "").Replace("文本框: ", "");
        }

        public void LoadPURes()
        {
            _OtherCommentText = "";
            string text = GetPuResText();
            if (_IsFirstLoad)
            {
                this.cB_hour.SelectedIndex = 0;
                this.cB_minute.SelectedIndex = 0;
                this.cB_car.SelectedIndex = 0;
                _IsFirstLoad = false;
                return;
            }
            _OtherCommentText = text;
            _Item = new PUResItem();
            _Item.Name = RoomCell.GetGuestName(AI.App.ActiveCell);
            if (_State == PUResState.None) return;
            _Item = _State == PUResState.Formatted ? LoadFormattedPURes(text) :
                LoadUnformattedPURes(text);
            if (_Item.Persons == 0) _Item.Persons = 1;
            this.tB_flight.Text = _Item.FlightNumber;
            this.tB_city.Text = _Item.DepartureCity;
            this.tB_name.Text = _Item.Name;
            this.tB_persons.Text = _Item.Persons.ToString();
            if (!string.IsNullOrEmpty(_Item.CarType) && !this.cB_car.Items.Contains(_Item.CarType))
                this.cB_car.Items.Add(_Item.CarType);
            this.cB_car.SelectedItem = _Item.CarType;
            this.cB_hour.SelectedItem = _Item.ArrivalHour.ToString().PadLeft(2, '0');
            this.cB_minute.SelectedItem = _Item.ArrivalMinute.ToString().PadLeft(2, '0');
            if (!string.IsNullOrEmpty(_Item.Staff) && this.cB_staff.Items.Contains(_Item.Staff))
                this.cB_staff.Items.Add(_Item.Staff);
            this.cB_staff.SelectedItem = _Item.Staff;
        }

        private PUResItem LoadFormattedPURes(string text)
        {
            PUResItem item = new PUResItem();
            int sI = text.IndexOf("<接机>") + 4;
            int eI = text.IndexOf("</接机>");
            _OtherCommentText = text.Substring(eI + 5);
            text = text.Substring(sI, eI - sI);
            foreach(string line in text.Split('\n'))
            {
                if (string.IsNullOrEmpty(line)) continue;
                int index0 = line.IndexOf("：");
                if (index0 > -1)
                {
                    string left = line.Substring(0, index0);
                    string right = line.Substring(index0 + 1);
                    switch (left)
                    {
                        case "车型":
                            item.CarType = right;
                            break;
                        case "航班号":
                            item.FlightNumber = right;
                            break;
                        case "出发城市":
                            item.DepartureCity = right;
                            break;
                        case "到达时间":
                            int index1 = right.IndexOf(":");
                            item.ArrivalHour = Int32.Parse(right.Substring(0, index1));
                            item.ArrivalMinute = Int32.Parse(right.Substring(index1 + 1));
                            break;
                    }
                }
                else
                {
                    int index1 = line.IndexOf(" ");
                    item.Staff = line.Substring(0, index1);
                    item.ReservedDateString = line.Substring(index1 + 1);
                    break;
                }
            }
            return item;
        }

        private PUResItem LoadUnformattedPURes(string text)
        {
            PUResItem item = new PUResItem();
            string[] lines = text.Split('\n');
            for (int index = 0; index < lines.Length; index++)
            {
                if (string.IsNullOrEmpty(lines[index]) ||
                    !GetUnformattedSeprateText(lines[index].Replace(": ", ":"),
                    out string key, out string value))
                    continue;
                switch (key)
                {
                    case "Ref":
                        break;
                    case "Room":
                    case "fee":
                    case "Fee":
                    case "room":
                        return item;
                    case "车型":
                        item.CarType = value;
                        break;
                    case "航班号":
                    case "航班":
                        item.FlightNumber = value;
                        break;
                    case "出发城市":
                    case "起飞城市":
                        item.DepartureCity = value;
                        break;
                    case "到达时间":
                    case "抵达时间":
                        bool isValidTime = GetUnformattedSeprateText(value,
                            out string hour, out string minute, true);
                        item.ArrivalHour = isValidTime ? Int32.Parse(hour) : 0;
                        item.ArrivalMinute = isValidTime ? Int32.Parse(minute) : 0;
                        break;
                    case "人数":
                        item.Persons = Int32.Parse(value);
                        break;
                    default:
                        if (key.Length > 1)
                            item.Staff = key.Substring(0, 1).ToUpper() + key.Substring(1).ToLower();
                        item.ReservedDateString = value;
                        _OtherCommentText = text.Substring(text.IndexOf(value) + value.Length);
                        break;
                }
            }
            return item;
        }

        public static void ShowPickUpForm()
        {
            if (_PUForm is null) _PUForm = new PickUpForm();
            _PUForm.LoadPURes();
            _PUForm.ShowDialog();
        }
        
        public static bool GetUnformattedSeprateText(string line, out string left, out string right,
            bool isTime = false)
        {
            left = isTime ? "00" : null;
            right = isTime ? "00" : null;
            int index = -1;
            string[] dots = isTime ? new string[] { ".", ":", "：", "；", ";", " " } :
                new string[] { "；", "：", " ", ":", ";", "." };
            foreach (string dot in dots)
            {
                index = line.IndexOf(dot);
                if (index > -1) break;
            }
            if (index < 0 || line.Length <= index + 1) return false;
            left = line.Substring(0, index);
            if (isTime) left = Regex.Replace(left, "[a-zA-Z.]", "").PadLeft(2, '0');
            right = line.Substring(index + 1);
            if (isTime) right = Regex.Replace(right, "[a-zA-Z.]", "").PadLeft(2, '0');
            return true;
        }

        public static DateTime GetResDate()
        {
            Workbook wb = AI.App.ActiveWorkbook;
            return new DateTime(Int32.Parse(wb.Name.Substring(0, 4)),
                Int32.Parse(wb.ActiveSheet.Name.Substring(0, 2)),
                (AI.App.ActiveCell as Range).Column - 4);
        }

        private void button_set_Click(object sender, EventArgs e)
        {
            Range cell = AI.App.ActiveCell;
            if (cell.Comment != null)
                cell.Comment.Delete();
            string comment = string.Format("<接机>\n人数：{0}车型：{1}\n航班号：{2}\n" +
                "出发城市：{3}\n到达时间：{4}:{5}\n\n{6} {7}\n</接机>{8}",
                tB_persons.Text as string,
                cB_car.SelectedItem as string,
                tB_flight.Text,
                tB_city.Text,
                cB_hour.SelectedItem as string,
                cB_minute.SelectedItem as string,
                cB_staff.SelectedItem as string,
                string.IsNullOrEmpty(_Item.ReservedDateString) ?
                DateTime.Now.ToString("yyyy/MM/dd") : _Item.ReservedDateString,
                _OtherCommentText);
            cell.AddComment(comment);
            Ribbon_Excel.PickUp_Book();
            Ribbon_Excel.ShapeAutoSizeByAutoFit(cell);
            this.Hide();
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Format("{0}接机\n\n客人姓名：{1}\n人数：{2}\n" +
                "航班号：{3}\n出发城市：{4}\n到达时间：{5}:{6}\n\n收到请回复，谢谢",
                GetResDate().ToString("yyyy年MM月dd日"),
                tB_name.Text,
                tB_persons.Text,
                tB_flight.Text,
                tB_city.Text,
                cB_hour.SelectedItem as string,
                cB_minute.SelectedItem as string));
            this.Hide();
        }
        
    }

    public class PUResItem
    {
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public int ArrivalHour { get; set; }
        public int ArrivalMinute { get; set; }
        public string Name { get; set; }
        public int Persons { get; set; }
        public string CarType { get; set; }
        public string Staff { get; set; }
        public string ReservedDateString { get; set; }
    }
}
