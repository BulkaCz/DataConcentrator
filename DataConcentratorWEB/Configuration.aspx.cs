using System;
using System.IO.Ports;
using System.Xml;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataConcentratorWEB
{
    public partial class Configuration : System.Web.UI.Page
    {
        string connectionString,
            port1_Name, port1_Parity, port1_Device,
            port2_Name, port2_Parity, port2_Device;
        bool port1_Enabled,
             port2_Enabled;
        int port1_DeviceID, port1_PollInterval, port1_BaudRate, port1_DataBit, port1_StopBit,
            port2_DeviceID, port2_PollInterval, port2_BaudRate, port2_DataBit, port2_StopBit;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*ddlPort1Name.Items.Clear();
            ddlPort2Name.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {             
                ddlPort1Name.Items.Add(s);
                ddlPort2Name.Items.Add(s);
            }*/

            ddlPort1Name.Items.Add("COM1");
            ddlPort1Name.Items.Add("COM2");
            ddlPort1Name.Items.Add("COM3");
            ddlPort1Name.Items.Add("COM4");

            ddlPort2Name.Items.Add("COM1");
            ddlPort2Name.Items.Add("COM2");
            ddlPort2Name.Items.Add("COM3");
            ddlPort2Name.Items.Add("COM4");
        }

        protected void btnSaveConfig_Click(object sender, EventArgs e)
        {
            WriteSetting("Port1_Enabled", cbPort1Enabled.Checked.ToString());
            WriteSetting("Port1_Device", ddlPort1Typ.SelectedValue.ToString());
            WriteSetting("Port1_DeviceID", tbPort1ID.Text);
            WriteSetting("Port1_PollInterval", tbPort1PollInterval.Text);
            WriteSetting("Port1_Name", ddlPort1Name.SelectedValue.ToString());
            WriteSetting("Port1_BaudRate", ddlPort1BaudRate.SelectedValue.ToString());
            WriteSetting("Port1_Parity", ddlPort1Parity.SelectedValue.ToString());
            WriteSetting("Port1_DataBit", ddlPort1DataBits.SelectedValue.ToString());
            WriteSetting("Port1_StopBit", ddlPort1StopBits.SelectedValue.ToString());

            WriteSetting("Port2_Enabled", cbPort2Enabled.Checked.ToString());
            WriteSetting("Port2_Device", ddlPort2Typ.SelectedValue.ToString());
            WriteSetting("Port2_DeviceID", tbPort2ID.Text);
            WriteSetting("Port2_PollInterval", tbPort2PollInterval.Text);
            WriteSetting("Port2_Name", ddlPort2Name.SelectedValue.ToString());
            WriteSetting("Port2_BaudRate", ddlPort2BaudRate.SelectedValue.ToString());
            WriteSetting("Port2_Parity", ddlPort2Parity.SelectedValue.ToString());
            WriteSetting("Port2_DataBit", ddlPort2DataBits.SelectedValue.ToString());
            WriteSetting("Port2_StopBit", ddlPort2StopBits.SelectedValue.ToString());
        }

        protected void btnLoadConfig_Click(object sender, EventArgs e)
        {
            LoadConfigFile();
            FillConfigPage();
        }

        private void FillConfigPage()
        {
            cbPort1Enabled.Checked = port1_Enabled;
            ddlPort1Typ.SelectedValue = port1_Device;
            tbPort1ID.Text = port1_DeviceID.ToString();
            tbPort1PollInterval.Text = port1_PollInterval.ToString();
            ddlPort1Name.SelectedValue = port1_Name;
            ddlPort1BaudRate.SelectedValue = port1_BaudRate.ToString();
            ddlPort1Parity.SelectedValue = port1_Parity.ToString();
            ddlPort1DataBits.SelectedValue = port1_DataBit.ToString();
            ddlPort1StopBits.SelectedValue = port1_StopBit.ToString();

            cbPort2Enabled.Checked = port2_Enabled;
            ddlPort2Typ.SelectedValue = port1_Device;
            tbPort2ID.Text = port2_DeviceID.ToString();
            tbPort2PollInterval.Text = port2_PollInterval.ToString();
            ddlPort2Name.SelectedValue = port2_Name;
            ddlPort2BaudRate.SelectedValue = port2_BaudRate.ToString();
            ddlPort2Parity.SelectedValue = port2_Parity.ToString();
            ddlPort2DataBits.SelectedValue = port2_DataBit.ToString();
            ddlPort1StopBits.SelectedValue = port2_StopBit.ToString();
        }

        private void LoadConfigFile()
        {
            XmlDocument config = new XmlDocument();
            config.Load("C:\\Users\\Bulka\\Downloads\\DataConcentrator_160103\\DataConcentrator\\DataConcentrator\\bin\\Debug\\DataConcentrator.exe.config");
            XmlNode node = config.SelectSingleNode("//appSettings");
            foreach (XmlNode xnn in node.ChildNodes)
            {
                if (xnn.Attributes[0].Value == "ConnectionString") connectionString = xnn.Attributes[1].Value;

                if (xnn.Attributes[0].Value == "Port1_Enabled") port1_Enabled = Boolean.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port1_Device") port1_Device = xnn.Attributes[1].Value;
                if (xnn.Attributes[0].Value == "Port1_DeviceID") port1_DeviceID = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port1_PollInterval") port1_PollInterval = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port1_Name") port1_Name = xnn.Attributes[1].Value;
                if (xnn.Attributes[0].Value == "Port1_BaudRate") port1_BaudRate = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port1_Parity") port1_Parity = xnn.Attributes[1].Value;
                if (xnn.Attributes[0].Value == "Port1_DataBit") port1_DataBit = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port1_StopBit") port1_StopBit = Int32.Parse(xnn.Attributes[1].Value);

                if (xnn.Attributes[0].Value == "Port2_Enabled") port2_Enabled = Boolean.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port2_Device") port2_Device = xnn.Attributes[1].Value;
                if (xnn.Attributes[0].Value == "Port2_DeviceID") port2_DeviceID = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port2_PollInterval") port2_PollInterval = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port2_Name") port2_Name = xnn.Attributes[1].Value;
                if (xnn.Attributes[0].Value == "Port2_BaudRate") port2_BaudRate = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port2_Parity") port2_Parity = xnn.Attributes[1].Value;
                if (xnn.Attributes[0].Value == "Port2_DataBit") port2_DataBit = Int32.Parse(xnn.Attributes[1].Value);
                if (xnn.Attributes[0].Value == "Port2_StopBit") port2_StopBit = Int32.Parse(xnn.Attributes[1].Value);
            }
        }

        private static void WriteSetting(string key, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Bulka\\Downloads\\DataConcentrator_160103\\DataConcentrator\\DataConcentrator\\bin\\Debug\\DataConcentrator.exe.config");
            XmlNode node = doc.SelectSingleNode("//appSettings");
            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));

                if (elem != null)
                {
                    elem.SetAttribute("value", value);
                }
                else
                {
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save("C:\\Users\\Bulka\\Downloads\\DataConcentrator_160103\\DataConcentrator\\DataConcentrator\\bin\\Debug\\DataConcentrator.exe.config");
            }
            catch
            {

            }
        }
    }
}