using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityLayer;
namespace DataAccessLayer
{
    public class DalCustomer
    {

        public List<EntityCustomer> GetAll()
        {
            List<EntityCustomer> liste = new List<EntityCustomer>();
            SqlCommand komut = new SqlCommand("Select * From TBLCUSTOMER ", Baglanti.bgl);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                liste.Add(new EntityCustomer
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Name = dr["NAME"].ToString(),
                    Surname = dr["SURNAME"].ToString(),
                    Phone = dr["PHONE"].ToString()
                });
                
            }
            Baglanti.bgl.Close();
            return liste;
        }

        public void Add(EntityCustomer e)
        {
            SqlCommand cmd = new SqlCommand ("INSERT INTO TBLCUSTOMER(NAME, SURNAME, PHONE) VALUES (@p1,@p2,@p3)",Baglanti.bgl);

            cmd.Parameters.AddWithValue("@p1", e.Name);
            cmd.Parameters.AddWithValue("@p2",e.Surname);
            cmd.Parameters.AddWithValue("@p3", e.Phone);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }
        public void Update(EntityCustomer c)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE TBLCUSTOMER SET NAME=@p1, SURNAME=@p2, PHONE=@p3 WHERE ID=@p4",
               Baglanti.bgl);

            cmd.Parameters.AddWithValue("@p1", c.Name);
            cmd.Parameters.AddWithValue("@p2", c.Surname);
            cmd.Parameters.AddWithValue("@p3", c.Phone);
            cmd.Parameters.AddWithValue("@p4", c.Id);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM TBLCUSTOMER WHERE ID=@p1",
               Baglanti.bgl);

            cmd.Parameters.AddWithValue("@p1", id);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }
    }
}
