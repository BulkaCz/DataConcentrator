using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataConcentratorWEB
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchFiles();
                ShowLogs();
            }
            
        }

        protected void ddlConfigFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLogs();
        }



        private void ShowLogs()
        {
            lbLogs.Items.Clear();
            string[] logs = File.ReadAllLines("C:\\Users\\Bulka\\Downloads\\DataConcentrator_160103\\DataConcentrator\\" + ddlConfigFiles.SelectedValue + ".log");
            foreach (string s in logs)
            {
                lbLogs.Items.Add(s);
            }
        }

        private void SearchFiles()
        {
            string[] fileInfo = Directory.GetFiles("C:\\Users\\Bulka\\Downloads\\DataConcentrator_160103\\DataConcentrator\\", "*.log");

            foreach (string s in fileInfo)
            {
                ddlConfigFiles.Items.Add(Path.GetFileNameWithoutExtension(s));
            }
        }
    }
}