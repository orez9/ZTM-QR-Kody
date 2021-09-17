using System.Windows.Forms;

namespace ZTMQRKODY
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
            langcheck();
        }

        void langcheck()
        {
            switch (Properties.Settings.Default.lang)
            {
                default:
                    this.Text = "Autor";
                    break;
                case "English":
                    this.Text = "Author";
                    break;
            }
        }
    }
}
