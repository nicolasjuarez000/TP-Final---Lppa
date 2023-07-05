using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    internal class DAO
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=localhost;Initial Catalog=lppa_tpfinal;Integrated Security=True");
        public int ExecuteNonQuery(string commandText)
        {
            SqlCommand sqlcom = new SqlCommand(commandText, sqlcon);
            sqlcon.Open();
            int i = sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            return i;
        }
        public int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = sqlcon;
            sqlcon.Open();
            int i = sqlCommand.ExecuteNonQuery();
            sqlcon.Close();
            return i;
        }

        public DataSet ExecuteDataset(string commandText)
        {
            SqlDataAdapter mda = new SqlDataAdapter(commandText, sqlcon);
            DataSet mds = new DataSet();
            mda.Fill(mds);
            return mds;
        }
    }
}
