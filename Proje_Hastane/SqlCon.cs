using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    internal class SqlCon  // sınıfımın adı
    {
       public SqlConnection connection() // connection() metodumun adı
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-4I5CVCL1;Initial Catalog=HastaneProje;Integrated Security=True;");
            con.Open();  // con, SqlConnection sınıfımdan türettiğim ve benim adresimi tutan nesnenin adı, Open () bir metod
            return con;  // geriye dönen değeri tutan kısım

            // adresi m. sql serverda en üsteki laptop yazan yerde özelliklerine gidip namei ni kpyalayında project i tıklayıp
            // add new data source ile dabase  __> dataset __> name 'i yapıştrırız ardından gelen databaselerden ilgili databaseimizi seçince keyimizi
            // elde etmiş oluyoruz.
        }
    }
}
