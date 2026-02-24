using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{
    public class DalOrder
    {
        public int Add(EntityOrder p)
        {
            SqlCommand cmd = new SqlCommand(
               "INSERT INTO TBLORDER (CUSTOMERID, ORDERDATE, TOTALPRİCE) VALUES (@p1,@p2,@p3); SELECT SCOPE_IDENTITY();",
               //SCOPE_IDENTITY()  Az önce eklenen kaydın Identity (Id) değerini döndürüyor
               Baglanti.bgl);
            cmd.Parameters.AddWithValue("@p1", p.CustomerId);
            cmd.Parameters.AddWithValue("@p2", p.OrderDate);
            cmd.Parameters.AddWithValue("@p3", p.TotalPrice);

            int sonId = Convert.ToInt32(cmd.ExecuteScalar());
            Baglanti.bgl.Close();
            return sonId;
        }

        public List<EntityOrder> GetAll()
        {
            List<EntityOrder> liste = new List<EntityOrder>();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM TBLORDER ORDER BY ORDERDATE DESC", Baglanti.bgl);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                liste.Add(new EntityOrder
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    CustomerId = Convert.ToInt32(reader["CUSTOMERID"]),
                    OrderDate = Convert.ToDateTime(reader["ORDERDATE"]),
                    TotalPrice = Convert.ToDecimal(reader["TOTALPRICE"])
                });
            }

            Baglanti.bgl.Close();
            return liste;
        }
        public decimal GetToplamCiro()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT ISNULL(SUM(TOTALPRİCE),0) FROM TBLORDER", Baglanti.bgl);

            decimal ciro = Convert.ToDecimal(cmd.ExecuteScalar());
           Baglanti.bgl.Close();
            return ciro;
        }
        public decimal GetGunlukCiro()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT ISNULL(SUM(TOTALPRICE),0) FROM TBLORDER WHERE CAST(ORDERDATE AS DATE) = CAST(GETDATE() AS DATE)",
              Baglanti.bgl);

            decimal ciro = Convert.ToDecimal(cmd.ExecuteScalar());
            Baglanti.bgl.Close();
            return ciro;
        }
        public string GetEnCokSatilanUrun()
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 1 p.NAME
                FROM TBLORDERDETAILS 
                JOIN TBLPRODUCT p ON p.ID = TBLORDERDETAILS.PRODUCTID
                GROUP BY p.NAME
                ORDER BY SUM(TBLORDERDETAILS.QUANTITY) DESC",
                Baglanti.bgl);

            var result = cmd.ExecuteScalar();
            Baglanti.bgl.Close(); ;
            return result?.ToString() ?? "Henüz satış yok";
        }
    }
}
