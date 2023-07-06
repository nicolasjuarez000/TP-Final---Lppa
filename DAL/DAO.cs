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


        public async Task<int> WriteStoredProcedure(string st, SqlParameter[] parameters)
        {
            try
            {
                {
                    await Task.Delay(000);
                    await sqlcon.OpenAsync();
                    var CMD = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = st,
                        Connection = sqlcon
                    };
                    CMD.Parameters.AddRange(parameters);
                    return await CMD.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException ex) when (ex.Number == 2 || ex.Number == 17142)
            {
                throw new Excepciones.ConnectionToDataBaseException();
            }
        }






        public async Task<double> ReadScalarValue(string st, SqlParameter[] parameters)
        {
            try
            {
                {
                    await Task.Delay(000);
                    await sqlcon.OpenAsync();
                    var CMD = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = st,
                        Connection = sqlcon
                    };
                    if (parameters != null)
                        CMD.Parameters.AddRange(parameters);
                    var res = await CMD.ExecuteScalarAsync();

                    try
                    {
                        if (res != null)
                            return float.Parse(res.ToString());
                        return 0.0;
                    }
                    catch
                    {
                        return 0.0;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2 || ex.Number == 17142)
            {
                throw new Excepciones.ConnectionToDataBaseException();
            }
        }







        public async Task<DataTable> ReadStoredProcedure(string st, SqlParameter[] parameters)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(0000);
                    {
                        await sqlcon.OpenAsync();
                        var tabla = new DataTable();
                        var adaptador = new SqlDataAdapter
                        {
                            SelectCommand = new SqlCommand
                            {
                                CommandType = CommandType.StoredProcedure,
                                CommandText = st,
                                Connection = sqlcon
                            }
                        };

                        if (parameters != null)
                            adaptador.SelectCommand.Parameters.AddRange(parameters);

                        await Task.Run(() =>
                        {
                            adaptador.Fill(tabla);
                        });
                        return tabla;
                    }
                }
                catch (SqlException ex) when (ex.Number == 2 || ex.Number == 17142)
                {
                    throw new Excepciones.ConnectionToDataBaseException();
                }
            });
        }

    }
}
