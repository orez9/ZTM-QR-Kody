using System;
using System.Windows.Forms;


namespace ZTMQRKODY
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            comboBox2.Text = Properties.Settings.Default.lang;
            comboBox1.Text = Properties.Settings.Default.qrtype;
            radioButton2.Checked = Properties.Settings.Default.radioButton2;
            textBox2.Text = Properties.Settings.Default.sellocation;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            switch (radioButton2.Checked)
            {
                case true: textBox2.Enabled = true; break;
                case false: textBox2.Enabled = false; break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            textBox2.Text = String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "Polski";
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (radioButton1.Checked) { Properties.Settings.Default.location = textBox1.Text; Properties.Settings.Default.sellocation = textBox2.Text; }
            if (radioButton2.Checked) { Properties.Settings.Default.sellocation = textBox2.Text; Properties.Settings.Default.location = textBox2.Text; }
            Properties.Settings.Default.lang = comboBox2.Text;
            Properties.Settings.Default.qrtype = comboBox1.Text;
            Properties.Settings.Default.radioButton2 = radioButton2.Checked;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "L";
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            langcheck();
        }

        void langcheck()
        {
            switch (comboBox2.Text)
            {
                default:
                    this.Text = "Ustawienia";
                    groupBox1.Text = "Rejon";
                    radioButton2.Text = "Własne";
                    button1.Text = button2.Text = button3.Text = "Przywróć domyślne";
                    groupBox2.Text = "Kod QR";
                    groupBox3.Text = "Język";
                    label1.Text = "Typ kodu";
                    break;
                case "English":
                    this.Text = "Settings";
                    groupBox1.Text = "Area";
                    radioButton2.Text = "Custom";
                    button1.Text = button2.Text = button3.Text = "Reset to defaults";
                    groupBox2.Text = "QR Code";
                    groupBox3.Text = "Language";
                    label1.Text = "Code type";
                    break;
            }
        }
    }
}
