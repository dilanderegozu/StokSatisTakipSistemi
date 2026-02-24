using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalOrderDetail
    {

        public void Add(EntityOrderDetail detail)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO TBLORDERDETAIL (ORDERID,PRODUCTID,QUANTITY,UNITPRICE) VALUES (@p1,@p2,@p3,@p4)",
               Baglanti.bgl);

            cmd.Parameters.AddWithValue("@p1", detail.OrderId);
            cmd.Parameters.AddWithValue("@p2", detail.ProductId);
            cmd.Parameters.AddWithValue("@p3", detail.Quantity);
            cmd.Parameters.AddWithValue("@p4", detail.UnitPrice);
            cmd.ExecuteNonQuery();
            Baglanti.bgl.Close();
        }
    }
    }
