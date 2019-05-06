using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalista
{
    public enum TaskPaneType { 订单详情, 订单列表, 订单房间详情 }

    public partial class AddIn_YuI
    {

        public static Func<TaskPaneType, UserControl> NewTaskPane =
            new Func<TaskPaneType, UserControl>(_CreateNewTaskPane);

        static UserControl _CreateNewTaskPane(TaskPaneType paneType)
        {
            switch (paneType)
            {
                case TaskPaneType.订单列表:
                    return new UserControl_ResDetails();
                case TaskPaneType.订单房间详情:
                case TaskPaneType.订单详情:
                default:
                    return null;
            }
        }
        
        static Dictionary<string, CustomTaskPane> _CreatedPanes = new Dictionary<string, CustomTaskPane>();

        /// <summary>
        /// Gets the taskpane by name (if exists for current excel window then returns existing instance, otherwise uses taskPaneCreatorFunc to create one). 
        /// </summary>
        /// <param name="workbookName">Some string to identify the taskpane</param>
        /// <param name="taskPaneTitle">Display title of the taskpane</param>
        /// <param name="taskPaneCreatorFunc">The function that will construct the taskpane if one does not already exist in the current Excel window.</param>
        public static CustomTaskPane GetTaskPane(Workbook wb, TaskPaneType paneType)
        {
            if (!wb.IsRoomStatusWorkbook()) return null;
            string key = string.Format("{0}::{1}", wb.Name, Globals.AddIn_YuI.Application.Hwnd);
            if (!_CreatedPanes.ContainsKey(key))
            {
                /*CustomTaskPane pane = null;
                try
                {
                    pane = Globals.AddIn_YuI.CustomTaskPanes.Add(
                        NewTaskPane(paneType), Enum.GetName(typeof(TaskPaneType), paneType));
                }
                catch
                {

                }
                finally
                {
                    _CreatedPanes[key] = Globals.AddIn_YuI.CustomTaskPanes.Add(
                        NewTaskPane(paneType), Enum.GetName(typeof(TaskPaneType), paneType));
                }*/
                _CreatedPanes[key] = Globals.AddIn_YuI.CustomTaskPanes.Add(
                        NewTaskPane(paneType), Enum.GetName(typeof(TaskPaneType), paneType));
            }
            return _CreatedPanes[key];
        }

        public static List<CustomTaskPane> GetAllTaskPanes(Workbook wb)
        {
            if (!wb.IsRoomStatusWorkbook()) return null;
            List<CustomTaskPane> panes = new List<CustomTaskPane>();
            try
            {
                foreach (TaskPaneType paneType in Enum.GetValues(typeof(TaskPaneType)))
                {
                    panes.Add(GetTaskPane(wb, paneType));
                }
            }
            catch
            {

            }
            return panes;
        }

        public static void ShowTaskPane(Workbook wb, TaskPaneType paneType) =>
            GetTaskPane(wb, paneType).Visible = true;

        public static void HideTaskPane(Workbook wb, TaskPaneType paneType) =>
            GetTaskPane(wb, paneType).Visible = false;

    }
}
