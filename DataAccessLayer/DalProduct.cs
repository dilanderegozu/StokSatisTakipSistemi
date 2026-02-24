using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
namespace DataAccessLayer
{
    public class DalProduct
    {
        public List<EntityProduct> GetAll ()
        {
            List<EntityProduct> liste = new List<EntityProduct>();
            SqlCommand cmd = new SqlCommand("Select *From TBLPRODUCT WHERE ISACTIVE=1", Baglanti.bgl);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                liste.Add(new EntityProduct
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Name = dr["NAME"].ToString(),
                    CategoryId = Convert.ToInt32(dr["CATEGORYID"]),
                    Price = Convert.ToDecimal(dr["PRICE"]),
                    StockQuantity = Convert.ToInt32(dr["STOCKQUANTITY"]),
                    IsActive = Convert.ToBoolean(dr["ISACTIVE"])
                });
            }
            Baglanti.bgl.Close();
            return liste;

        }
        public void Add(EntityProduct p)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TBLPRODUCT  (NAME,CATEGORYID,PRICE,STOCKQUANTITY,ISACTIVE) VALUES (@p1,@p2,@p3,@p4,1)", Baglanti.bgl);
            cmd.Parameters.AddWithValue("@p1", p.Name);
            cmd.Parameters.AddWithValue("@p2", p.CategoryId);
            cmd.Parameters.AddWithValue("@p3", p.Price);
            cmd.Parameters.AddWithValue("@p4", p.StockQuantity);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }
        public void Update(EntityProduct p)
        {
            SqlCommand cmd = new SqlCommand(
              "UPDATE TBLPRODUCT SET NAME=@p1,CATEGORYID=@p2,PRICE=@p3,STOCKQUANTITY=@p4 WHERE ID=@p5",
              Baglanti.bgl);

            cmd.Parameters.AddWithValue("@p1", p.Name);
            cmd.Parameters.AddWithValue("@p2", p.CategoryId);
            cmd.Parameters.AddWithValue("@p3", p.Price);
            cmd.Parameters.AddWithValue("@p4", p.StockQuantity);
            cmd.Parameters.AddWithValue("@p5", p.Id);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }
        public void Delete(int id)
        {
          
            SqlCommand cmd = new SqlCommand(
                "UPDATE TBLPRODUCT SET ISACTIVE=0 WHERE ID=@p1",
                Baglanti.bgl);

            cmd.Parameters.AddWithValue("@p1", id);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }
        public void StokDus(int productId,int miktar)
        {
            SqlCommand cmd = new SqlCommand("Update TBLPRODUCT SET STOCKQUANTITY = STOCKQUANTITY - @p1 Where ID=@p2", Baglanti.bgl);

            cmd.Parameters.AddWithValue("@p1", miktar);
            cmd.Parameters.AddWithValue("@p2", productId);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }

    }
}

