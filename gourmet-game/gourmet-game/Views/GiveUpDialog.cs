using System;
using System.Windows.Forms;

namespace gourmet_game.Views
{
    public partial class GiveUpDialog : Form
    {
        public string labelText;
        public string result;
        
        public GiveUpDialog()
        {
            InitializeComponent();
        }

        private void GiveUp_Load(object sender, EventArgs e)
        {
            label1.Text = labelText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
