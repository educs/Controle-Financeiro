using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Freela.Interface;

namespace Freela.Modelo
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class MLancamento
	{
        IBD ac;
		public MLancamento()
		{
			ac = new BD("Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=Life;Data Source=ATLHON");
		}

        public int Gravar(object item)
        {
            IList<SqlParameter> ps = new List<SqlParameter>();
            //SqlParameter[] ps = new SqlParameter[3];
            string proc = string.Empty;
            //IBD ac = new BD();

            if (((ILancamento)item).Codigo == 0)
            {
                proc = "p_ins_lancamento";
            }
            else
            {
                proc = "p_upd_lancamento";
                ps.Add(new SqlParameter("codigo", ((ILancamento)item).Codigo));
            }
           
            ps.Add(new SqlParameter("descricao"
                    , ((ILancamento)item).Descricao));
            ps.Add(new SqlParameter("valor"
                    , ((ILancamento)item).Valor));
            ps.Add(new SqlParameter("data"
                    , ((ILancamento)item).Data));
            ps.Add(new SqlParameter("id_conta"
                    , ((ILancamento)item).Categoria.Codigo));

            return (ac.Gravar(proc, ps));
        }

        public DataTable Ler()
        {
            string proc = "p_sel_lancamento";
            DataTable dt = new DataTable();

            //IBD ac = new BD();
            dt = ac.Ler(proc, null);
            dt.Columns[0].ColumnName = "codigo";
            dt.Columns[1].ColumnName = "descricao";
            dt.Columns[2].ColumnName = "data";
            dt.Columns[3].ColumnName = "valor";
            dt.Columns[4].ColumnName = "idCategoria";
            dt.Columns[5].ColumnName = "tipo";

            return (dt);
        }

        public ILancamento Ler(object item)
        {
            string proc = "p_sel_lancamento";
            DataTable dr;
            IList<SqlParameter> ps = new List<SqlParameter>();
            MCategoria c;

            ps.Add(new SqlParameter("codigo", ((ILancamento)item).Codigo));
            dr = ac.Ler(proc, ps);
            //((ILancamento)item).Codigo = Convert.ToInt32(dr.Rows[0]["Codigo"]);
            ((ILancamento)item).Descricao = dr.Rows[0]["Descricao"].ToString();
            ((ILancamento)item).Data = Convert.ToDateTime(dr.Rows[0]["Data"]);
            ((ILancamento)item).Valor = Convert.ToDecimal(dr.Rows[0]["Valor"]);
            c = new MCategoria(Convert.ToInt32(dr.Rows[0]["id_conta"]), ((ILancamento)item).Categoria);
               
            return ((ILancamento)item);
        }
    }
}
