using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Freela.Interface;

namespace Freela.Modelo
{
    public class MCategoria
    {
        IBD ac;

        public MCategoria()
        {
            ac = new BD("Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=Life;Data Source=ATLHON");
        }

        public MCategoria(int initID, object initItem)
        {
            ac = new BD("Integrated Security=SSPI;Persist Security Info=False;" +
                   "Initial Catalog=Life;Data Source=ATLHON");
            this.Ler(initID, initItem);
        }
        
        public DataTable Ler()
        {
            string proc = "p_sel_conta";
            DataTable dt = new DataTable();
            IList<ICategoria> ls = new List<ICategoria>();
            ICategoria[] itens;
           // ac = new BD();
            
            dt = ac.Ler(proc, null);
            dt.Columns[0].ColumnName = "codigo";
            dt.Columns[1].ColumnName = "nome";
            //dt.Columns[2].ColumnName = "tipo";

            return (dt);
        }

        public void Ler(int codigo, object item)
        {
            DataTable dt;
            IList<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("Codigo", codigo));
            MBem b;
          //  ac = new BD();

            dt = ac.Ler("p_sel_conta", par);
            ((ICategoria)item).Codigo = Convert.ToInt32(dt.Rows[0]["Codigo"]);
            ((ICategoria)item).Descricao = dt.Rows[0]["Nome"].ToString();
            ((ICategoria)item).Tipo = Convert.ToByte(dt.Rows[0]["Tipo"]);
            b = new MBem(Convert.ToInt32(dt.Rows[0]["idBem"]), ((ICategoria)item).Bem);
        }

        public void Salvar(object item)
        {
            string proc = "p_ins_categoria";
            IList<SqlParameter> par = new List<SqlParameter>();
         //   ac = new BD();
            if (((ICategoria)item).Codigo != 0)
            {
                proc = "p_upd_categoria";
                par.Add(new SqlParameter("Codigo", ((ICategoria)item).Codigo));
            }
            par.Add(new SqlParameter("Nome", ((ICategoria)item).Descricao));
            par.Add(new SqlParameter("Tipo", ((ICategoria)item).Tipo));
            par.Add(new SqlParameter("idBem", ((ICategoria)item).Bem.Codigo));
            ac.Gravar(proc, par);
            ac = null;
        }

        public void Excluir(object item)
        {
            string proc = "p_del_categoria";
            IList<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("Codigo", ((ICategoria)item).Codigo));
            ac.Gravar(proc, par);
            ac = null;
        }
    }
}
