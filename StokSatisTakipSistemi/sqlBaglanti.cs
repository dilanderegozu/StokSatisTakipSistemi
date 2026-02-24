using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace StokSatisTakipSistemi
{
    internal class sqlBaglanti
    {

      public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=localhost;Initial Catalog=StokSatis;Integrated Security=True;Trust Server Certificate=True");
            baglan.Open();
            return baglan;
        }
    }
}
