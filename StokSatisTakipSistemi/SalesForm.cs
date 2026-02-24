using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StokSatisTakipSistemi
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        LogicCustomer logicCustomer = new LogicCustomer();
        LogicProduct logicProduct = new LogicProduct();
        LogicOrder logicOrder = new LogicOrder();
        List<EntityOrderDetail> sepet = new List<EntityOrderDetail>();


        decimal genelToplam = 0; 
        private void SalesForm_Load(object sender, EventArgs e)
        {
            nmrcAdet.Minimum = 1;
            nmrcAdet.Value = 1;

            cmbMusteri.DisplayMember = "ToString";
            cmbMusteri.ValueMember = "ID";
            cmbMusteri.DataSource = logicCustomer.GetAll();

            cmbUrun.DisplayMember = "ToString";
            cmbUrun.ValueMember = "ID";
            cmbUrun.DataSource = logicProduct.GetAll();

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("UrunAdi", "Ürün Adı");
            dataGridView1.Columns.Add("Adet", "Adet");
            dataGridView1.Columns.Add("BirimFiyat", "Birim Fiyat");
            dataGridView1.Columns.Add("Toplam", "Toplam");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            txtToplam.ReadOnly = true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbUrun.SelectedValue == null || cmbMusteri.SelectedValue == null)
            {
                MessageBox.Show("Lütfen müşteri ve ürün seçiniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int urunID = Convert.ToInt32(cmbUrun.SelectedValue);
            int adet = Convert.ToInt32(nmrcAdet.Value);
            var urun = logicProduct.GetById(urunID);

            if (urun == null)
            {
                MessageBox.Show("Ürün bulunamadı!", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (urun.StockQuantity < adet)
            {
                MessageBox.Show($"Yetersiz stok! Mevcut stok: {urun.StockQuantity}", "Stok Yetersiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sepette aynı ürün varsa adedi artır
            var mevcutDetay = sepet.FirstOrDefault(d => d.ProductId == urunID);
            if (mevcutDetay != null)
            {
                // Toplam adet stoktan büyük olmasın
                if (urun.StockQuantity < mevcutDetay.Quantity + adet)
                {
                    MessageBox.Show($"Stok aşıldı! Sepette zaten {mevcutDetay.Quantity} adet var.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                mevcutDetay.Quantity += adet;
            }
            else
            {
                EntityOrderDetail detay = new EntityOrderDetail
                {
                    ProductId = urunID,
                    Quantity = adet,
                    UnitPrice = urun.Price
                };
                sepet.Add(detay);
            }

            SepetGuncelle();
        }
        private void btnSatis_Click(object sender, EventArgs e)
        {
            if (sepet.Count == 0)
            {
                MessageBox.Show("Sepet boş!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(cmbMusteri.SelectedValue);

            EntityOrder yeniSiparis = new EntityOrder
            {
                CustomerId = musteriID,
                OrderDate = DateTime.Now,
                TotalPrice = genelToplam
            };

            try
            {
                logicOrder.SatisiTamamla(yeniSiparis, sepet);
                MessageBox.Show($"Sipariş başarıyla kaydedildi!\nToplam Tutar: {genelToplam:C2}",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SepetiTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sipariş kaydedilemedi!\nHata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SepetGuncelle()
        {
            dataGridView1.Rows.Clear();
            genelToplam = 0;

            foreach (var detay in sepet)
            {
                var urun = logicProduct.GetById(detay.ProductId);
                string urunAdi = urun != null ? urun.ToString() : "Bilinmiyor";
                decimal toplam = detay.UnitPrice * detay.Quantity;
                genelToplam += toplam;

                dataGridView1.Rows.Add(urunAdi, detay.Quantity,
                    detay.UnitPrice.ToString("C2"), toplam.ToString("C2"));
            }

            txtToplam.Text = genelToplam.ToString("C2");
        }

 
        private void SepetiTemizle()
        {
            sepet.Clear();
            genelToplam = 0;
            dataGridView1.Rows.Clear();
            txtToplam.Text = "0,00 ₺";
            nmrcAdet.Value = 1;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            var seciliDetay = sepet[e.RowIndex];

            cmbUrun.SelectedValue = seciliDetay.ProductId;
            nmrcAdet.Value = seciliDetay.Quantity;
        }
    }
}
    
    
