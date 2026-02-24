using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokSatisTakipSistemi
{
    public partial class ProductForm : Form
    {
        private void ProductForm_Load(object sender, EventArgs e)
        {
            KategorileriYukle();
        }
        private void KategorileriYukle()
        {
            SqlCommand komut = new SqlCommand("Select ID,NAME FROM TBLCATEGORY",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            cmbKategori.DisplayMember = "NAME";
            cmbKategori.ValueMember = "ID";
            cmbKategori.DataSource = null;

            var liste = new System.Data.DataTable();
            liste.Load(dr);
            cmbKategori.DataSource = liste;
            bgl.baglanti().Close();
        }


        public ProductForm()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void btnEkle_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(txtUrun.Text))
            {
                MessageBox.Show("Ürün adı boş bırakılamaz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
           if(cmbKategori.SelectedValue == null)
            {
                MessageBox.Show("Lütfen kategori seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlCommand komut1 = new SqlCommand(
       "INSERT INTO TBLPRODUCT (NAME, CATEGORYID, PRICE, STOCKQUANTITY) VALUES (@p1, @p2, @p3, @p4)",
       bgl.baglanti());

            komut1.Parameters.AddWithValue("@p1", txtUrun.Text);
            komut1.Parameters.AddWithValue("@p2", cmbKategori.SelectedValue);  
            komut1.Parameters.AddWithValue("@p3", nmrcFiyat.Value);
            komut1.Parameters.AddWithValue("@p4", nmrcStok.Value);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells["ID"].Value == null)
            {
                MessageBox.Show("Güncellenecek Ürünü Seçiniz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUrun.Text))
            {
                MessageBox.Show("Ürün adı boş bırakılamaz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlCommand komut2 = new SqlCommand("update TBLPRODUCT set NAME =@p1,CATEGORYID=@p2,PRICE=@p3,STOCKQUANTITY=@p4 Where ID=@p5",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtUrun.Text);
            komut2.Parameters.AddWithValue("@p2", cmbKategori.SelectedValue);
            komut2.Parameters.AddWithValue("@p3", nmrcFiyat.Value);
            komut2.Parameters.AddWithValue("@p4", nmrcStok.Value);
            komut2.Parameters.AddWithValue("@p5", txtUrunID.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
   
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek ürünü seçiniz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var onay = MessageBox.Show("Ürün silinsin mi?", "Onay",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.No) return;

            int secilenId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            SqlCommand komut3 = new SqlCommand("DELETE FROM TBLPRODUCT WHERE ID=@p1", bgl.baglanti());

            komut3.Parameters.AddWithValue("@p1", secilenId);

            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            Temizle();  
            MessageBox.Show("Ürün başarıyla silindi.", "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
        {
            txtUrun.Text = string.Empty;
            cmbKategori.SelectedIndex = -1;
            nmrcFiyat.Value = 0;
            nmrcStok.Value = 0;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtUrunID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtUrun.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            cmbKategori.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            nmrcFiyat.Value = Convert.ToDecimal(dataGridView1.Rows[secilen].Cells[3].Value);
            nmrcStok.Value = Convert.ToDecimal(dataGridView1.Rows[secilen].Cells[4].Value);
        }
    }

    }
  

