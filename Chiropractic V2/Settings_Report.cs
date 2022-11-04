using System;
using System.Windows.Forms;

namespace Chiropractic_V2
{
    public partial class Settings_Report : DevExpress.XtraEditors.XtraForm
    {
        public Settings_Report()
        {
            InitializeComponent();
        }
        Database db = new Database();

        private void btn_Today_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbx_NameCenter.Text == "" || tbx_Agreement.Text == "")
                {
                    MessageBox.Show("Please enter the Center Name and Agreement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    db.readData("update AgreementText set Center_Name = '" + tbx_NameCenter.Text + "', Agreement_text = '" + tbx_Agreement.Text + "'", "Information successfully changed");
                }
            }
            catch (Exception) { }
        }

        private void Settings_Report_Load(object sender, EventArgs e)
        {
            string Center_Name = db.readData("select Center_Name from AgreementText", "").ToString();
            string Agreement_Text = db.readData("select Agreement_text from AgreementText", "").ToString();

            if (Center_Name == "")
            {
                db.exceuteData("INSERT INTO AgreementText (Center_Name) VALUES ('Tempy')", "");
            }
            if (Agreement_Text == "")
            {
                db.exceuteData("INSERT INTO AgreementText (Agreement_text) VALUES ('Tempy')", "");
            }
            else
            {
                tbx_NameCenter.Text = db.readData("select Center_Name from AgreementText", "").Rows[0][0].ToString();
                tbx_Agreement.Text = db.readData("select Agreement_text from AgreementText", "").Rows[0][0].ToString();
            }

        }
    }
}