using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Chiropractic_V2
{
    public partial class Frm_Load : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Load()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();

        private void brnsearchWhenClicked()
        {
            try
            {
                if (txtSearch.Text == "You can write the Patient's Name or Phone Number")
                {
                    txtSearch.Clear();

                    DataTable tblSearch = new DataTable();

                    tblSearch.Clear();

                    tblSearch = db.readData("select Patient_ID as 'No', Patient_Name as 'Ad', Patient_Surname as 'Soyad', Patient_Phone as 'Telefon No', Patient_OldGoOtherDr as 'Başka bir Yere', Patient_HealthAbout as 'Diğer Hastalıklar', Patient_Surgical as 'Ameliyat', Patient_Date as 'Geliş Tarihi' from New_Patients where Patient_Name like '%" + txtSearch.Text + "%' or Patient_Phone like '%" + txtSearch.Text + "%'", "");

                    DgvSearch.DataSource = tblSearch;
                    lblItemsCount.Text = (DgvSearch.Rows.Count.ToString());
                }
                else
                {
                    DataTable tblSearch = new DataTable();

                    tblSearch.Clear();

                    tblSearch = db.readData("select Patient_ID as 'No', Patient_Name as 'Ad', Patient_Surname as 'Soyad', Patient_Phone as 'Telefon No', Patient_OldGoOtherDr as 'Başka bir Yere', Patient_HealthAbout as 'Diğer Hastalıklar', Patient_Surgical as 'Ameliyat', Patient_Date as 'Geliş Tarihi' from New_Patients where Patient_Name like '%" + txtSearch.Text + "%' or Patient_Phone like '%" + txtSearch.Text + "%'", "");

                    DgvSearch.DataSource = tblSearch;
                    lblItemsCount.Text = (DgvSearch.Rows.Count.ToString());
                }
            }
            catch (Exception) { }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            brnsearchWhenClicked();
        }

        private void BtnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                string date1;
                string date2;


                date1 = DtpTo.Value.ToString("yyyy/MM/dd");
                date2 = DtpFrom.Value.ToString("yyyy/MM/dd");
                DataTable tblSearch = new DataTable();

                tblSearch.Clear();

                tblSearch = db.readData("select Patient_ID as 'No', Patient_Name as 'Ad', Patient_Surname as 'Soyad', Patient_Phone as 'Telefon No', Patient_OldGoOtherDr as 'Başka bir Yere', Patient_HealthAbout as 'Diğer Hastalıklar', Patient_Surgical as 'Ameliyat', Patient_Date as 'Geliş Tarihi' from New_Patients where CONVERT(date, Patient_Date, 105) between '" + date1 + "' and '" + date2 + "' ", "");

                DgvSearch.DataSource = tblSearch;
                lblItemsCount.Text = (DgvSearch.Rows.Count.ToString());
            }
            catch (Exception) { }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
            Font font = new Font("Century", 21.0f);

            txtSearch.ForeColor = Color.Black;
            txtSearch.Font = font;
        }

        private void Frm_Load_Load(object sender, EventArgs e)
        {

        }

        private void lblItemsCount_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                brnsearchWhenClicked();
            }
        }
    }
}