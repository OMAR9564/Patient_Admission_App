using System;
using System.Data;
using System.Windows.Forms;

namespace Chiropractic_V2
{
    public partial class Deserved : DevExpress.XtraEditors.XtraForm
    {
        public Deserved()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();

        //AutoNumber() : ID'de otomatik olarak sayı saysın diye yazdık
        private void AutoNumber()
        {
            tbl.Clear();


            tbl = db.readData("select max(Des_ID) from Deserved", "");
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

            txtNote.Clear();
            NudPrice.Value = 1;

            // Ekleme silme vb. kutular aktifleştirmek için yada iptal etmek için kullanırız.
            //AutoNumber fonk. içine, yeni bir sayı olunca diye burada yazdık.
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;

            tbl.Clear();

        }
        int row = 0;
        private void Show()
        {
            tbl.Clear();
            tbl = db.readData("select * from Deserved", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("Information not received");

            }

            else
            {

                try
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    NudPrice.Value = Convert.ToDecimal(tbl.Rows[row][1]);

                    this.Text = tbl.Rows[row][2].ToString();
                    DateTime dt = DateTime.ParseExact(this.Text, "dd/MM/yyyy", null);
                    DtpDate.Value = dt;

                    // DtpDate.Text = tbl.Rows[row][2].ToString();

                    txtNote.Text = tbl.Rows[row][3].ToString();
                    cbxType.SelectedValue = Convert.ToDecimal(tbl.Rows[row][4]);
                }
                catch (Exception)
                {

                }
            }
            //NudPrice.Value = 1;
            DtpDate.Text = DateTime.Now.ToShortDateString();

            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = true;

        }

        private void FillType()
        {
            cbxType.DataSource = db.readData("select * from Deserved_Type", "");
            cbxType.DisplayMember = "Name";
            cbxType.ValueMember = "Des_ID";
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Deserved_Load(object sender, EventArgs e)
        {
            AutoNumber();
            FillType();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Des_ID) from Deserved", "");
            row = (Convert.ToInt32(tbl.Rows[0][0]) - 1);
            Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Des_ID) from Deserved", "");
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
                tbl = db.readData("select count (Des_ID) from Deserved", "");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxType.Items.Count <= 0)
            {
                MessageBox.Show("Please enter types first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string d = DtpDate.Value.ToString("dd/MM/yyyy");

                db.exceuteData("insert into Deserved Values(" + txtID.Text + ", '" + NudPrice.Value + "', '" + d + "', '" + txtNote.Text + "', " + cbxType.SelectedValue + ")", "Başarılı bir işlem Gerçekleşti");

                AutoNumber();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");
            db.readData("update Deserved set Price = '" + NudPrice.Value + "', Date = '" + d + "', Notes = '" + txtNote.Text + "', Type_ID = '" + cbxType.SelectedValue + "' where Des_ID = '" + txtID.Text + "'", "Bilgiler başarılı bir şekilde değiştirildi");
            AutoNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Deserved where Des_ID = " + txtID.Text + "", "Information deleted successfully");
                AutoNumber();

            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Pass frm = new Pass();
            frm.ShowDialog();

            if (MessageBox.Show("Are you sure to delete this information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (Properties.Settings.Default.Pass1 == "9564")
                {
                    db.readData("delete from Deserved", "All information deleted successfully");
                    AutoNumber();
                }
                else
                {
                    MessageBox.Show("Wrong password", "Error", MessageBoxButtons.OK);
                }



            }
        }
    }
}