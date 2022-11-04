using System;
using System.Data;
using System.Windows.Forms;

namespace Chiropractic_V2
{
    public partial class DesservedType : DevExpress.XtraEditors.XtraForm
    {
        public DesservedType()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();

        //AutoNumber() : ID'de otomatik olarak sayı saysın diye yazdık
        private void AutoNumber()
        {
            try
            {
                tbl.Clear();


                tbl = db.readData("select max(Des_ID) from Deserved_Type", "");
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


                // Ekleme silme vb. kutular aktifleştirmek için yada iptal etmek için kullanırız.
                //AutoNumber fonk. içine, yeni bir sayı olunca diye burada yazdık.
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
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
                tbl = db.readData("select * from Deserved_Type", "");

                if (tbl.Rows.Count <= 0)
                {
                    MessageBox.Show("Information not received");

                }

                else
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtName.Text = tbl.Rows[row][1].ToString();


                }


                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
            catch
            {

            }

        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select count (Des_ID) from Deserved_Type", "");
                row = (Convert.ToInt32(tbl.Rows[0][0]) - 1);
                Show();
            }
            catch (Exception)
            {

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select count (Des_ID) from Deserved_Type", "");
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
            catch (Exception) { }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (row == 0)
                {
                    tbl.Clear();
                    tbl = db.readData("select count (Des_ID) from Deserved_Type", "");
                    row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                    Show();
                }
                else
                {
                    row--;
                    Show();
                }
            }
            catch (Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                row = 0;
                Show();
            }
            catch (Exception) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please enter the name of the Variety", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    db.exceuteData("insert into Deserved_Type Values(" + txtID.Text + ", '" + txtName.Text + "')", "Information deleted successfully");

                    AutoNumber();
                }
            }
            catch (Exception) { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                db.readData("update Deserved_Type set Name = '" + txtName.Text + "' where Des_ID = '" + txtID.Text + "'", "Information successfully changed");
                AutoNumber();
            }
            catch (Exception) { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to delete this information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.readData("delete from Deserved_Type where Des_ID = " + txtID.Text + "", "Information deleted successfully");
                    AutoNumber();

                }
            }
            catch (Exception)
            {

            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                Pass frm = new Pass();
                frm.ShowDialog();

                if (MessageBox.Show("Are you sure to delete this information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (Properties.Settings.Default.Pass1 == "9564")
                    {
                        db.readData("delete from Deserved_Type ", "Information deleted successfully");
                        AutoNumber();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception) { }
        }

        private void DesservedType_Load(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}