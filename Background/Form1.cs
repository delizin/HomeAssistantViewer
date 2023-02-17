using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
using System;
using System.Xml.Serialization;

namespace Background
{
    [Serializable]
    public class AppConfig
    {
        [XmlElement("url_string")]
        public string UrlString { get; set; } = "http://homeassistant.local:8123/";

        [XmlElement("width_offset")]
        public int WidthOffset { get; set; } = 0;

        [XmlElement("height_offset")]
        public int HeightOffset { get; set; } = 0;
    }
    
    public partial class HomeAssistant : Form
    {
        private int width_offset = 0;
        //private int width_offset = 0;
        private int height_offset = 0;
        private const int HWND_BOTTOM = 1;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        private static string url_string = "http://homeassistant.local:8123/";

        public HomeAssistant()
        {
            // Check if the config file exists
            if (File.Exists("config.xml"))
            {
                // Load the config data from the file
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                using (StreamReader reader = new StreamReader("config.xml"))
                {
                    AppConfig config = (AppConfig)serializer.Deserialize(reader);
                    url_string = config.UrlString;
                    width_offset = config.WidthOffset;
                    height_offset = config.HeightOffset;
                }
            }
            else
            {
                // Write the default config data to the file
                AppConfig config = new AppConfig();
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                using (StreamWriter writer = new StreamWriter("config.xml"))
                {
                    serializer.Serialize(writer, config);
                }
            }

            InitializeComponent();
            webBrowser1.Dock = DockStyle.Fill;            
            webBrowser1.Source = new Uri(url_string);
           
            FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;

            WindowState = FormWindowState.Normal;
            TopMost = false;
            Screen[] sc;
            sc = Screen.AllScreens;
            if (sc.Length > 1)
            {
                this.Location = sc[1].WorkingArea.Location;
                this.StartPosition = FormStartPosition.Manual;
                this.Height = sc[1].WorkingArea.Height - height_offset;
                this.Width = sc[1].WorkingArea.Width - width_offset;
                this.Location = sc[1].WorkingArea.Location;
            }

            // Move back to secondary monitor after waking from sleep
            SystemEvents.DisplaySettingsChanged += OnDisplaySettingsChanged;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void OnDisplaySettingsChanged(object sender, EventArgs e)
        {
            Screen[] sc = Screen.AllScreens;
            if (sc.Length > 1)
            {
                this.Location = sc[1].WorkingArea.Location;
                this.Height = sc[1].WorkingArea.Height - height_offset;
                this.Width = sc[1].WorkingArea.Width - width_offset;
            }
            else
            {
                this.Location = new Point(0, 0);
                this.Height = Screen.PrimaryScreen.WorkingArea.Height - height_offset;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width - width_offset;
            }
        }
    }
}