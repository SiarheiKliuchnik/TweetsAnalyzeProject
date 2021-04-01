using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using WindowsFormsApp;
namespace WindowsFormsApp.Presentation_Layer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void changeDirButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath) && result==DialogResult.OK)
            {
                pathLabel.Text= folderBrowserDialog1.SelectedPath;
                Data.Directory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dragPanel_MouseDown(object sender, MouseEventArgs e)
        {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void localizationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            localizationComboBox.DataSource = new System.Globalization.CultureInfo[]
            {
               System.Globalization.CultureInfo.GetCultureInfo("en-US"),
               System.Globalization.CultureInfo.GetCultureInfo("ru-RU"),
               System.Globalization.CultureInfo.GetCultureInfo("ar")
            };
            localizationComboBox.DisplayMember = "NativeName";
            localizationComboBox.ValueMember = "Name";
            tweetPointsCheckBox.Checked = Data.TweetPointsCheckBoxChecked;
            EmotionScaleCheckBox.Checked = Data.EmotionPanelCheckBoxChecked;
            pathLabel.Text = Data.Directory;
            localizationComboBox.SelectedItem = System.Globalization.CultureInfo.CurrentUICulture;
        }

        private void tweetPointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Data.TweetPointsCheckBoxChecked = tweetPointsCheckBox.Checked;
        }

        private void EmotionScaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Data.EmotionPanelCheckBoxChecked = EmotionScaleCheckBox.Checked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\\..\\..\\Data\\settings.cfg", FileMode.Truncate);
            StreamWriter w = new StreamWriter(fs, Encoding.Default);
            {
                string settings = $"{Data.EmotionPanelCheckBoxChecked.ToString()}, {Data.TweetPointsCheckBoxChecked.ToString()}, {Data.Directory}, {localizationComboBox.SelectedItem}";
                w.WriteLine(settings);
            }
            w.Close();
            w.Dispose();
            fs.Close();
            fs.Dispose();
            this.Close();
            this.Dispose();
        }
    }
}
