using System;

namespace Chiropractic_V2
{
    public partial class Pass : DevExpress.XtraEditors.XtraForm
    {
        public Pass()
        {
            InitializeComponent();

        }

        private void Pass_Load(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = '*';
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Pass1 = txtpass.Text;
            Pass.ActiveForm.Close();

        }
    }
}