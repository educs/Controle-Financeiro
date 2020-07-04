using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Freela.Interface;

namespace Freela.Modelo
{
    public class MBem
    {
        IBD ac;
        public MBem()
        {
            ac = new BD("Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=Life;Data Source=ATLHON");
        }

        public MBem(int initID, object initItem)
        {
            ac = new BD("Integrated Security=SSPI;Persist Security Info=False;" +
                   "Initial Catalog=Life;Data Source=ATLHON");
            this.Ler(initID, initItem);
        }

        public DataTable Ler(string usuario)
        {
            string proc = "p_sel_bens";
            DataTable dt = new DataTable();
            IList<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("Usuario", usuario));
            //IList<IBem> ls = new List<IBem>();
            //IBem[] itens;
            //int i = 0;


            //IBD ac = new BD();
            dt = ac.Ler(proc, par);
            dt.Columns[0].ColumnName = "codigo";
            dt.Columns[1].ColumnName = "descricao";
            //dt.Columns[2].ColumnName = "data";
            //dt.Columns[3].ColumnName = "valor";
            //dt.Columns[4].ColumnName = "idCategoria";
            //dt.Columns[5].ColumnName = "tipo";
            //itens = new ILancamento[dt.Rows.Count];

            return (dt);
        }

        public void Ler(int codigo, object item)
        {
            DataTable dt;
            IList<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("Codigo", codigo));
            MBem b;
            //  ac = new BD();

            dt = ac.Ler("p_sel_bem", par);
            ((IBem)item).Codigo = Convert.ToInt32(dt.Rows[0]["Codigo"]);
            ((IBem)item).Descricao = dt.Rows[0]["Descricao"].ToString();
        }

        public void Salvar(object item)
        {
            string proc = "p_ins_bem";
            IList<SqlParameter> par = new List<SqlParameter>();
            //   ac = new BD();
            if (((IBem)item).Codigo != 0)
            {
                proc = "p_upd_bem";
                par.Add(new SqlParameter("Codigo", ((IBem)item).Codigo));
            }
            par.Add(new SqlParameter("Nome", ((IBem)item).Descricao));
            par.Add(new SqlParameter("Usuario", ((IBem)item).Usuario));
            par.Add(new SqlParameter("Valor", ((IBem)item).Valor));
            ac.Gravar(proc, par);
            ac = null;
        }
    }
}
