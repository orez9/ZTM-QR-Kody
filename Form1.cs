using QRCoder;
using System;
using System.Windows.Forms;

namespace ZTMQRKODY
{
    public partial class General : Form
    {
        public General()
        {
            InitializeComponent();
            langcheck();
            textBox1.Text = Properties.Settings.Default.number;
            this.Size = Properties.Settings.Default.size;
            qrreload();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author a = new Author();
            a.ShowDialog();
        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Closed += (s, args) => { qrreload(); langcheck(); };
            s.ShowDialog();
        }

        void qrreload()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData;
            switch (Properties.Settings.Default.qrtype)
            {
                default: qrCodeData = qrGenerator.CreateQrCode(Properties.Settings.Default.location + textBox1.Text, QRCodeGenerator.ECCLevel.L); break;
                case "M": qrCodeData = qrGenerator.CreateQrCode(Properties.Settings.Default.location + textBox1.Text, QRCodeGenerator.ECCLevel.M); break;
                case "Q": qrCodeData = qrGenerator.CreateQrCode(Properties.Settings.Default.location + textBox1.Text, QRCodeGenerator.ECCLevel.Q); break;
                case "H": qrCodeData = qrGenerator.CreateQrCode(Properties.Settings.Default.location + textBox1.Text, QRCodeGenerator.ECCLevel.H); break;
            }
            QRCode qrCode = new QRCode(qrCodeData);
            pictureBox1.Image = qrCode.GetGraphic(40);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 4) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            qrreload();
        }

        private void General_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.number = textBox1.Text;
            Properties.Settings.Default.size = this.Size;
            Properties.Settings.Default.Save();
        }
        void langcheck()
        {
            switch (Properties.Settings.Default.lang)
            {
                default:
                    opcjeToolStripMenuItem.Text = "Opcje";
                    ustawieniaToolStripMenuItem.Text = "Ustawienia";
                    informacjeToolStripMenuItem.Text = "Informacje";
                    autorToolStripMenuItem.Text = "Author";
                    groupBox1.Text = "Numer boczny autobusu";
                    this.Text = "ZTM QR Kody";
                    break;
                case "English":
                    opcjeToolStripMenuItem.Text = "Options";
                    ustawieniaToolStripMenuItem.Text = "Settings";
                    informacjeToolStripMenuItem.Text = "Informations";
                    autorToolStripMenuItem.Text = "Author";
                    groupBox1.Text = "Vehicle number";
                    this.Text = "ZTM QR Codes";
                    break;
            }
        }
    }
}
