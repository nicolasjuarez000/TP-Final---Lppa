using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace DAL
{
    public class DVS
    {

        public byte[] GetDvfromtable(string tabla)
        {
            SqlCommand sqlcommand = new SqlCommand("Select DVV from DIGITOSVERIFICADORESVERTICALES where TABLA = '" + tabla + "';");
            DAO dAO = new DAO();
            DataSet dataSet = dAO.ExecuteDataset(sqlcommand);
            byte[] result = new byte[0];
            IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    DataRow dataRow = (DataRow)enumerator.Current;
                    result = (byte[])dataRow.ItemArray[0];
                    return result;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }

            return result;
        }

        public string Gettabledvs(string tabla)
        {
            SqlCommand cmd = new SqlCommand($@"Select dv from " + tabla + ";");

            DAO mdao = new DAO();
            DataSet mds = mdao.ExecuteDataset(cmd);
            string b64;
            string b64_aux = "";

            foreach (DataRow dr in mds.Tables[0].Rows)
            {

                b64 = Convert.ToBase64String((byte[])dr.ItemArray[0]);
                b64_aux = b64_aux + b64;
            }
          
            return b64_aux;
        }
    }
}
