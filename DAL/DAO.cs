using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAO
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=.;Initial Catalog=TiendaLPPA;Integrated Security=True");
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

        public DataSet ExecuteDataset(SqlCommand sqlcommand)
        {
            SqlDataAdapter mda = new SqlDataAdapter();
            sqlcommand.Connection = sqlcon;
            mda.SelectCommand = sqlcommand;
            DataSet mds = new DataSet();
            mda.Fill(mds);
            return mds;
        }
        
        public DataSet ExecuteDataset(string commandText)
        {
            SqlDataAdapter mda = new SqlDataAdapter(commandText, sqlcon);
            DataSet mds = new DataSet();
            mda.Fill(mds);
            return mds;
        }

       

        public int WriteStoredProcedure(string st, SqlParameter[] parameters)
        {
            try
            {
                {
                    sqlcon.Open();
                    var CMD = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = st,
                        Connection = sqlcon
                    };
                    CMD.Parameters.AddRange(parameters);
                    return CMD.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) when (ex.Number == 2 || ex.Number == 17142)
            {
                throw new Excepciones.ConnectionToDataBaseException();
            }
        }


        public double ReadScalarValue(string st, SqlParameter[] parameters)
        {
            try
            {
                {
                    sqlcon.Open();
                    var CMD = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = st,
                        Connection = sqlcon
                    };
                    if (parameters != null)
                        CMD.Parameters.AddRange(parameters);
                    var res = CMD.ExecuteScalar();

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

        public DataTable ReadStoredProcedure(string st, SqlParameter[] parameters)
        {
            try
            {
                {
                    sqlcon.Open();
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

                        adaptador.Fill(tabla);
                    return tabla;
                }
            }
                catch (SqlException ex) when (ex.Number == 2 || ex.Number == 17142)
                {
                    throw new Excepciones.ConnectionToDataBaseException();
                }
        }

    }
}
