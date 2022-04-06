using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        const string CONNECTION_STRING = "Server=localhost; Database=Northwind ;Intergrated Secueity= True;";
        ///=======================================ExecuteParamerizedSelectCommand============================================
        #region ExecuteParamerizedSelectCommand()
        internal static DataTable ExecuteParamerizedselectCommand(string commandName, CommandType cmdType, SqlParameter[] param)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return table;
        }
        #endregion ExecuteParamerizedSelectCommand()
        ///=======================================ExecuteNonQuery============================================
        #region ExecuteNonQuery()
        internal static bool ExecuteNonQuery(string commandName, CommandType cmdType, SqlParameter[] pars)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        result = cmd.ExecuteNonQuery();

                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return result > 0;
        }
        #endregion ExecuteNonQuery()
        ///=======================================ExecuteSelectCommand============================================
        #region ExecuteSelectCommand()
        internal static DataTable ExecuteSelectCommand(string commandName, CommandType cmdType)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
                return table;
            }
        }
        #endregion ExecuteSelectCommand()
    }
}

