using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P4_Sister_0074
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void bersihbuku()
        {
            txtCode.Clear();
            txtJudul.Clear();
            txtPenerbit.Clear();
            txtCode.Focus();
        }

        void bersihData()
        {
            txtID.Clear();
            txtNama.Clear();
            txtNo.Clear();
            txtEmail.Clear();
            dgv1.Rows.Clear();
            bersihbuku();
            txtID.Focus();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            int n = dgv1.Rows.Add();
            dgv1.Rows[n].Cells[0].Value = txtCode.Text;
            dgv1.Rows[n].Cells[1].Value = txtJudul.Text;
            dgv1.Rows[n].Cells[2].Value = txtPenerbit.Text;
            bersihbuku();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {

            dgv1.SelectedRows[0].Cells[0].Value = txtCode.Text;
            dgv1.SelectedRows[0].Cells[1].Value = txtJudul.Text;
            dgv1.SelectedRows[0].Cells[2].Value = txtPenerbit.Text;
            bersihbuku();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            dgv1.Rows.RemoveAt(dgv1.SelectedRows[0].Index);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.Text = dgv1.SelectedRows[0].Cells[0].Value.ToString();
            txtJudul.Text = dgv1.SelectedRows[0].Cells[1].Value.ToString();
            txtPenerbit.Text = dgv1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Pengarang";
            dt.Columns.Add("ID");
            dt.Columns.Add("Nama");
            dt.Columns.Add("Telepon");
            dt.Columns.Add("Email");
            ds.Tables.Add(dt);


            DataTable dt1 = new DataTable();
            dt1.TableName = "Buku";
            dt1.Columns.Add("Kode");
            dt1.Columns.Add("Judul");
            dt1.Columns.Add("Penerbit");
            ds.Tables.Add(dt1);

            DataRow row = ds.Tables["Pengarang"].NewRow();
            row["ID"] = txtID.Text;
            row["Nama"] = txtNama.Text;
            row["Telepon"] = txtNo.Text;
            row["Email"] = txtEmail.Text;
            ds.Tables["Pengarang"].Rows.Add(row);

            foreach (DataGridViewRow baris in dgv1.Rows)
            {
                DataRow row1 = ds.Tables["Buku"].NewRow();
                row1["Kode"] = baris.Cells[0].Value;
                row1["Judul"] = baris.Cells[1].Value;
                row1["Penerbit"] = baris.Cells[2].Value;
                ds.Tables["Buku"].Rows.Add(row1);

            }
			
			//di rubah y slur nang di koe nyimpen katalog.xml 
            ds.WriteXml("D:\\katalog.xml");
            MessageBox.Show("Data sudah tersimpan","Info",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
            bersihData();
        }

        private void buttonAmbil_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
			//di rubah y slur nang di koe nyimpen katalog.xml 
            ds.ReadXml("D:\\katalog.xml");
            txtID.Text = ds.Tables["Pengarang"].Rows[0][0].ToString();
            txtNama.Text = ds.Tables["Pengarang"].Rows[0][1].ToString();
            txtNo.Text = ds.Tables["Pengarang"].Rows[0][2].ToString();
            txtEmail.Text = ds.Tables["Pengarang"].Rows[0][3].ToString();

            foreach (DataRow item in ds.Tables["Buku"].Rows)
            {
                int n = dgv1.Rows.Add();
                dgv1.Rows[n].Cells[0].Value = item["Kode"].ToString();
                dgv1.Rows[n].Cells[1].Value = item["Judul"].ToString();
                dgv1.Rows[n].Cells[2].Value = item["Penerbit"].ToString();
            }

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
