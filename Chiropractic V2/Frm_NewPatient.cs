using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Chiropractic_V2
{
    public partial class Frm_NewPatient : DevExpress.XtraEditors.XtraForm
    {
        public Frm_NewPatient()
        {
            InitializeComponent();
        }
        Database db = new Database();

        DataTable tbl = new DataTable();
        private void AutoNumber()
        {
            try
            {
                tbl.Clear();


                tbl = db.readData("select max(Patient_ID) from New_Patients", "");
                //rows0 0 string'e dönüştür 
                // DBNull null sa boşsa
                //boşsa.değerleri.string'e dönüştür
                if (tbl.Rows[0][0].ToString() == DBNull.Value.ToString())
                {
                    //txtID kutusuna 1 yazdır
                    txtID.Text = "1";
                }
                else
                {
                    //tbl.Rows0 0 datatabel olduğu için ona int bir sayı eklemeyiz o yüzden
                    //ilk başta convert.toint32 dönüştürdü.. daha sonra bütün bunları txtID text olduğu için en sonra to string'e döüşütr yazdık
                    txtID.Text = ((Convert.ToInt32(tbl.Rows[0][0])) + 1).ToString();
                }
                // bir kişi eklendikten sonra bütün kutular silinir
                txtName.Clear();
                txtNote.Clear();
                txtSurname.Clear();
                txtPhone.Clear();
                rbtnNo.Select();
                rbtnNo2.Select();




                // Ekleme silme vb. kutular aktifleştirmek için yada iptal etmek için kullanırız.
                //AutoNumber fonk. içine, yeni bir sayı olunca diye burada yazdık.
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
            }
            catch (Exception) { }

        }
        int row = 0;
        private void Show()
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select * from New_Patients", "");

                if (tbl.Rows.Count <= 0)
                {
                    MessageBox.Show("Information not received");

                }

                else
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtName.Text = tbl.Rows[row][1].ToString();
                    txtSurname.Text = tbl.Rows[row][2].ToString();
                    txtPhone.Text = tbl.Rows[row][3].ToString();
                    if (tbl.Rows[row][4].ToString() == "No")
                    {
                        rbtnNo.Select();
                    }
                    else if (tbl.Rows[row][4].ToString() == "Yes")
                    {
                        rbtnYes.Select();
                    }
                    txtNote.Text = tbl.Rows[row][5].ToString();
                    if (tbl.Rows[row][6].ToString() == "No")
                    {
                        rbtnNo2.Select();
                    }
                    else if (tbl.Rows[row][6].ToString() == "Yes")
                    {
                        rbtnYes2.Select();
                    }


                    //DtpDate.Value =Convert.ToDateTime(tbl.Rows[row][7]);
                }


                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
            catch (Exception) { }

        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Patient_ID) from New_Patients", "");
            row = (Convert.ToInt32(tbl.Rows[0][0]) - 1);
            Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Patient_ID) from New_Patients", "");
            if (Convert.ToInt32(tbl.Rows[0][0]) - 1 == row)
            {
                row = 0;
                Show();
            }
            else
            {
                row++;
                Show();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Patient_ID) from New_Patients", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                Show();
            }
            else
            {
                row--;
                Show();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            Show();
        }

        private void Frm_NewPatient_Load(object sender, EventArgs e)
        {
            try
            {
                AutoNumber();
            }
            catch (Exception)
            {

            }
            rbtnNo.Select();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPhone.Text == "" || txtSurname.Text == "")
                {
                    MessageBox.Show("Please enter the Patient's name, Surname and phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (rbtnNo.Checked == true && rbtnNo2.Checked == true)
                    {
                        string d = DtpDate.Value.ToString("dd/MM/yyyy");


                        db.exceuteData("insert into New_Patients Values(" + txtID.Text + ", '" + txtName.Text + "', '" + txtSurname.Text + "', '" + txtPhone.Text + "', 'No' , '" + txtNote.Text + "', 'No', '" + d + "')", " A successful transaction Occurred");

                        AutoNumber();
                    }
                    else if (rbtnYes.Checked == true && rbtnYes2.Checked == true)
                    {
                        string d = DtpDate.Value.ToString("dd/MM/yyyy");

                        db.exceuteData("insert into New_Patients Values(" + txtID.Text + ", '" + txtName.Text + "', '" + txtSurname.Text + "', '" + txtPhone.Text + "', 'Yes', '" + txtNote.Text + "', 'Yes', '" + d + "')", "A successful transaction Occurred");

                        AutoNumber();
                    }
                    else if (rbtnYes.Checked == true && rbtnNo2.Checked == true)
                    {
                        string d = DtpDate.Value.ToString("dd/MM/yyyy");

                        db.exceuteData("insert into New_Patients Values(" + txtID.Text + ", '" + txtName.Text + "', '" + txtSurname.Text + "', '" + txtPhone.Text + "', 'Yes', '" + txtNote.Text + "', 'No', '" + d + "')", "A successful transaction Occurred");

                        AutoNumber();
                    }
                    else if (rbtnNo.Checked == true && rbtnYes2.Checked == true)
                    {
                        string d = DtpDate.Value.ToString("dd/MM/yyyy");

                        db.exceuteData("insert into New_Patients Values(" + txtID.Text + ", '" + txtName.Text + "', '" + txtSurname.Text + "', '" + txtPhone.Text + "', 'No', '" + txtNote.Text + "', 'Yes', '" + d + "')", "A successful transaction Occurred");

                        AutoNumber();
                    }
                }
            }
            catch (Exception) { }
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            try
            {
                if (rbtnNo.Checked == true && rbtnNo2.Checked == true)
                {
                    string d = DtpDate.Value.ToString("dd/MM/yyyy");

                    db.readData("update New_Patients set Patient_Name = '" + txtName.Text + "', Patient_Surname = '" + txtSurname.Text + "', Patient_Phone = '" + txtPhone.Text + "', Patient_OldGoOtherDr = 'No', Patient_HealthAbout = '" + txtNote.Text + "', Patient_Surgical = 'No' where Patient_ID = '" + txtID.Text + "'", "Information successfully changed");

                    AutoNumber();
                }
                else if (rbtnYes.Checked == true && rbtnYes2.Checked == true)
                {
                    string d = DtpDate.Value.ToString("dd/MM/yyyy");

                    db.readData("update New_Patients set Patient_Name = '" + txtName.Text + "', Patient_Surname = '" + txtSurname.Text + "', Patient_Phone = '" + txtPhone.Text + "', Patient_OldGoOtherDr = 'Yes', Patient_HealthAbout = '" + txtNote.Text + "', Patient_Surgical = 'Yes' where Patient_ID = '" + txtID.Text + "'", "Information successfully changed");

                    AutoNumber();
                }
                else if (rbtnYes.Checked == true && rbtnNo2.Checked == true)
                {
                    string d = DtpDate.Value.ToString("dd/MM/yyyy");

                    db.readData("update New_Patients set Patient_Name = '" + txtName.Text + "', Patient_Surname = '" + txtSurname.Text + "', Patient_Phone = '" + txtPhone.Text + "', Patient_OldGoOtherDr = 'Yes', Patient_HealthAbout = '" + txtNote.Text + "', Patient_Surgical = 'No' where Patient_ID = '" + txtID.Text + "'", "Information successfully changed");

                    AutoNumber();
                }
                else if (rbtnNo.Checked == true && rbtnYes2.Checked == true)
                {
                    string d = DtpDate.Value.ToString("dd/MM/yyyy");

                    db.readData("update New_Patients set Patient_Name = '" + txtName.Text + "', Patient_Surname = '" + txtSurname.Text + "', Patient_Phone = '" + txtPhone.Text + "', Patient_OldGoOtherDr = 'No', Patient_HealthAbout = '" + txtNote.Text + "', Patient_Surgical = 'Yes' where Patient_ID = '" + txtID.Text + "'", "Information successfully changed");

                    AutoNumber();
                }
            }
            catch (Exception) { }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this information?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from New_Patients where Patient_ID = " + txtID.Text + "", "Information deleted successfully");
                AutoNumber();

            }
        }
        private void btnsearchWhenClicked()
        {
            DataTable tblSearch = new DataTable();

            tblSearch.Clear();

            tblSearch = db.readData("select * from New_Patients where Patient_Phone like '%" + txtSearch.Text + "%' ", "");

            try
            {
                txtID.Text = tblSearch.Rows[0][0].ToString();
                txtName.Text = tblSearch.Rows[0][1].ToString();
                txtSurname.Text = tblSearch.Rows[0][2].ToString();
                txtPhone.Text = tblSearch.Rows[0][3].ToString();
                if (tblSearch.Rows[row][4].ToString() == "No")
                {
                    rbtnNo.Select();
                }
                else if (tblSearch.Rows[row][4].ToString() == "Yes")
                {
                    rbtnYes.Select();
                }
                txtNote.Text = tblSearch.Rows[0][5].ToString();

                if (tblSearch.Rows[0][6].ToString() == "No")
                {
                    rbtnNo2.Select();
                }
                else if (tblSearch.Rows[0][6].ToString() == "Yes")
                {
                    rbtnYes2.Select();
                }
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
            catch (Exception)
            {

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            btnsearchWhenClicked();

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
            Font font = new Font("Century", 26.0f);

            txtSearch.ForeColor = Color.Black;
            txtSearch.Font = font;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_Validated(object sender, EventArgs e)
        {

        }

        private void txtName_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // If you want, you can allow decimal (float) numbers
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            catch (Exception) { }
            try
            {
                string s = txtSearch.Text;
                if (s.Length == 9)
                {
                    double sAsD = double.Parse(s);
                    txtSearch.Text = string.Format("{0:(###) ### ## #}", sAsD).ToString();
                }
                if (txtSearch.Text.Length > 1)
                    txtSearch.SelectionStart = txtSearch.Text.Length;
                txtSearch.SelectionLength = 0;


            }
            catch (Exception) { }
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            try
            {
                string s = txtPhone.Text;
                if (s.Length == 9)
                {
                    double sAsD = double.Parse(s);
                    txtPhone.Text = string.Format("{0:(###) ### ## #}", sAsD).ToString();
                }
                if (txtPhone.Text.Length > 1)
                    txtPhone.SelectionStart = txtPhone.Text.Length;
                txtPhone.SelectionLength = 0;

            }
            catch (Exception) { }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsearchWhenClicked();
            }
        }

        private void Print()
        {


            DataTable tblRpt = new DataTable();
            tblRpt = db.readData("select * from New_Patients where Patient_ID = '" + txtID.Text + "'", "");

            Frm_Printing frm = new Frm_Printing();
            frm.crystalReportViewer1.RefreshReport();

            RptPatient rpt = new RptPatient();


            rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Chiropractic");
            rpt.SetDataSource(tblRpt);

            frm.crystalReportViewer1.ReportSource = rpt;

            frm.ShowDialog();


        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}