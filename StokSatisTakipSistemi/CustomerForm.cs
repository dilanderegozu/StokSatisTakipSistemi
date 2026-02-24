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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert ınto TBLCUSTOMER (NAME,SURNAME,PHONE) VALUES (@p@p2,@p3,@p4)", bgl.baglanti());
        
            komut.Parameters.AddWithValue("@p2", txtAd.Text);
            komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p4", mskTextPhone.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncellenecek Müşteriyi Seçiniz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int secilenId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

            SqlCommand komut = new SqlCommand(
                "UPDATE TBLCUSTOMER SET NAME=@p1, SURNAME=@p2, PHONE=@p3 WHERE ID=@p4",
                bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTextPhone.Text);
            komut.Parameters.AddWithValue("@p4", secilenId);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Müşteri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek ürünü seçiniz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            var onay = MessageBox.Show("Ürün silinsin mi?", "Onay",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.No) return;


            int secilenId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            SqlCommand komut = new SqlCommand("DELETE FROM TBLPRODUCT WHERE ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", secilenId);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
