using System;
using System.Data;

namespace Chiropractic_V2
{
    public partial class Frm_LoadToday : DevExpress.XtraEditors.XtraForm
    {
        public Frm_LoadToday()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();
        private void brnsearchWhenClicked1()
        {
            try
            {
                string date1;

                date1 = DateTime.Today.ToString("yyyy/MM/dd");

                DataTable tblSearch = new DataTable();

                tblSearch.Clear();

                tblSearch = db.readData("select Patient_ID as 'No', Patient_Name as 'Ad', Patient_Surname as 'Soyad', Patient_Phone as 'Telefon No', Patient_OldGoOtherDr as 'Başka bir Yere', Patient_HealthAbout as 'Diğer Hastalıklar', Patient_Surgical as 'Ameliyat', Patient_Date as 'Geliş Tarihi' from New_Patients where CONVERT(date, Patient_Date, 105) = '" + date1 + "' ", "");

                DgvSearch.DataSource = tblSearch;
                lblItemsCount.Text = (DgvSearch.Rows.Count.ToString());
            }
            catch (Exception) { }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void Frm_LoadToday_Load(object sender, EventArgs e)
        {
            brnsearchWhenClicked1();
        }
    }
}