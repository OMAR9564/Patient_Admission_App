using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Chiropractic_V2
{


    public partial class Frm_Metting : DevExpress.XtraEditors.XtraForm
    {

        public Frm_Metting()
        {
            InitializeComponent();
        }


        string[] Hours = { "08.00", "08.30","09.00", "09.30", "10.00", "10.30", "11.00", "11.30", "12.00",
                            "12.30", "13.00", "13.30", "14.00", "14.30", "15.00", "15.30", "16.00", "16.30",
                             "17.00", "17.30", "18.00", "18.30", "19.00", "19.30", "20.00", "20.30", "21.00",
                              "21.30", "22.00", "22.30", "23.00", "23.30", "00.00"};
        string[] AppointmentMethod = { "Phone", "Local" };


        Database db = new Database();

        DataTable tbl = new DataTable();
        private void btnsearchWhenClicked()
        {
            DataTable tblSearch = new DataTable();

            tblSearch.Clear();

            tblSearch = db.readData("select * from New_Patients where Patient_Phone like '%" + txtSearch.Text + "%' ", string.Empty);

            try
            {

                txtNameANDSurname.Text = tblSearch.Rows[0][1].ToString() + " " + tblSearch.Rows[0][2].ToString();





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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnsearchWhenClicked();
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == nullHour)
            {
                MessageBox.Show("Please select a active hour", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void Frm_Metting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Hours.Length; i++)
            {
                comboBox1.Items.Add(Hours[i]);
            }
            for (int i = 0; i < AppointmentMethod.Length; i++)
            {
                cbx_appointmentmethod.Items.Add(AppointmentMethod[i]);
            }
            ControlHours();



        }
        private void brnsearchWhenClicked1()
        {
            try
            {
                string date1;

                date1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");

                DataTable tblSearch = new DataTable();

                tblSearch.Clear();

                tblSearch = db.readData("select Name as 'Patient Name', Phone as 'Phone Num.',Date as 'Date', Hour as 'Hour', Method as 'Appointment Method', Commnet as 'Comment' from Appointment where Date = '" + date1 + "' ", string.Empty);

                Dgv.DataSource = tblSearch;

                txtNameANDSurname.Clear();
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.Text = "Select Hour";
                cbx_appointmentmethod.Text = "Appointment Method";
            }
            catch (Exception) { }

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Select Hour")
            {
                MessageBox.Show("Please select the time!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (comboBox1.Text == nullHour)
            {
                MessageBox.Show("Please select the time!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (txtNameANDSurname.Text == string.Empty)
            {
                MessageBox.Show("Please enter name!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbx_appointmentmethod.Text == "Appointment Method")
            {
                MessageBox.Show("Please enter Appointment Method!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            DataTable tblItems = new DataTable();
            tblItems.Clear();

            string date1;

            date1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");

            DataTable tblSearch = new DataTable();

            tblSearch.Clear();

            db.exceuteData("insert into Appointment Values('" + txtNameANDSurname.Text + "', '" + date1 + "', '" + comboBox1.Text + "', '" + cbx_appointmentmethod.Text + "', '" + txtSearch.Text + "', '" + tbxComment.Text + "')", "A successful transaction Occurred");

            brnsearchWhenClicked1();
            sayac.Text = (Dgv.Rows.Count.ToString());


        }

        private void btn_Today_Click(object sender, EventArgs e)
        {
            string date1;

            date1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            DataTable tblSearch = new DataTable();

            tblSearch.Clear();

            tblSearch = db.readData("select Name as 'Patient Name', Phone as 'Phone Num.',Date as 'Date', Hour as 'Hour', Method as 'Appointment Method', Commnet as 'Comment' from Appointment where Date = '" + date1 + "' ", string.Empty);

            Dgv.DataSource = tblSearch;

            txtNameANDSurname.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.Text = "Select Hour";
            cbx_appointmentmethod.Text = "Appointment Method";
            sayac.Text = (Dgv.Rows.Count.ToString());

        }


        private void Frm_Metting_KeyDown(object sender, KeyEventArgs e)
        {

        }
        string DgvName;
        public void btnDeleteItem_Click(object sender, EventArgs e)
        {

            if (Dgv.Rows.Count >= 1)
            {
                // üstüne tıkldığımız sınıfın index aldık
                int index = (Dgv.SelectedRows[0].Index);
                int col = 1;

                Dgv.Rows.RemoveAt(index);

                try
                {



                    db.readData("delete from Appointment where Phone = '" + DgvName + "'", "Information deleted successfully");

                    lblItemsCount.Text = (Dgv.Rows.Count.ToString());

                }
                catch (Exception) { }

            }
            sayac.Text = (Dgv.Rows.Count.ToString());
        }


        public void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DgvName = Dgv.Rows[e.RowIndex].Cells[1].Value.ToString();




        }

        string nullHour = "-----";

        public void ControlHours()
        {
            string[] Hours = {
                           "08.00", "08.30","09.00", "09.30", "10.00", "10.30", "11.00", "11.30", "12.00",
                            "12.30", "13.00", "13.30", "14.00", "14.30", "15.00", "15.30", "16.00", "16.30",
                             "17.00", "17.30", "18.00", "18.30", "19.00", "19.30", "20.00", "20.30", "21.00",
                              "21.30", "22.00", "22.30", "23.00", "23.30", "00.00"
                    };

            string date1;

            date1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");

            DataTable tblControl = new DataTable();
            tblControl.Clear();
            tblControl = db.readData("select * from Appointment where Date = '" + date1 + "' ", "");


            for (int i = 0; i < tblControl.Rows.Count; i++)
            {
                for (int j = 0; j < Hours.Length; j++)
                {
                    if (Hours[j] == tblControl.Rows[i][2].ToString())
                    {
                        Hours[j] = nullHour;
                    }
                }
            }

            comboBox1.Items.Clear();

            for (int f = 0; f < Hours.Length; f++)
            {
                comboBox1.Items.Add(Hours[f]);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ControlHours();

        }

        public void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {





        }
        public DataTable tblnew()
        {
            DataTable tbledit = new DataTable();
            tbledit = db.readData("select * from Appointment where Phone = '" + DgvName + "' ", "");

            return tbledit;
        }


        private void txtNameANDSurname_TextChanged(object sender, EventArgs e)
        {

        }

        public void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DgvName = Dgv.Rows[e.RowIndex].Cells[1].Value.ToString();


        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxComment_Enter(object sender, EventArgs e)
        {
            tbxComment.Clear();
            Font font = new Font("Century", 21.0f);

            tbxComment.ForeColor = Color.Black;
            tbxComment.Font = font;

        }

        private void tbxComment_TextChanged(object sender, EventArgs e)
        {

        }
    }
}