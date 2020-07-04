using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Freela.Interface;

namespace Freela.Modelo
{
    public class BD: IBD
    {
        private SqlCommand com;
        private SqlConnection con;
        public BD(string cnStr)
        {
            con = new SqlConnection(cnStr);
            con.Open();
        }

        #region IBD Members

        public int Gravar(string proc, IList<SqlParameter> ps)
        {
            com = new SqlCommand(proc, con);
            com.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter item in ps)
            {
                com.Parameters.Add(item);
            }
            
            return (com.ExecuteNonQuery());
        }

        public DataTable Ler(string proc, IList<SqlParameter> ps)
        {
            SqlDataAdapter adp;
            DataSet ds = new DataSet();

            com = new SqlCommand(proc, con);
            com.CommandType = CommandType.StoredProcedure;
            if (ps != null)
            {
                foreach (SqlParameter item in ps)
                {
                    com.Parameters.Add(item);
                }
            }
            adp = new SqlDataAdapter(com);
            adp.Fill(ds);

            return (ds.Tables[0]);
        }

        #endregion
    }
}
