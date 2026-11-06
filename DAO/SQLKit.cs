using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Internal;

namespace DAO
{
    public abstract class SQLKit
    {
        protected SqlConnection con;
        protected SqlCommand com;

        public SQLKit()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=Seele;Integrated Security=True;Trust Server Certificate=True");
            com = new SqlCommand("", con);
        }

        public void conectar()
        {
            con.Open();
        }
        public void desconectar()
        {
            con.Close();
        }

        

    }
}
