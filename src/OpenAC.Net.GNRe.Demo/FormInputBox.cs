using System;
using System.Windows.Forms;

namespace OpenAC.Net.GNRe.Demo
{
    public partial class FormInputBox : Form
    {
        public FormInputBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tag = TextBox1.Text;
            Close();
        }
    }
}