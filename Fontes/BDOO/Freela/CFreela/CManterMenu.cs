using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using Freela.Interface;

namespace Freela.Controladora
{
    public class CManterMenu: CBase, IManterMenu
    {
        string enderecoXml = "D:\\Fontes\\freela\\menu.xml";
        #region IXml Members

        public override XmlDocument ConsultarXml()
        {
            //XmlDocument Xml = new XmlDocument();
            DataSet dsXml = new DataSet();
            //DataTable dt, dtTrans = new DataTable();

            try
            {
                //Xml.LoadXml(enderecoXml);
                dsXml.ReadXml(enderecoXml);
            }
            catch
            {
                dsXml.Tables.Add("Menu");
                dsXml.Tables[0].Columns.Add("Item");
                XmlDocument x = new XmlDocument();
                
                //dsXml.WriteXml(enderecoXml);
                //DataTable tab = this.MontarTabela();
                //dsXml.Tables.Add(tab);
            }
            //dt = dsXml.Tables[0];
            //dtTrans = MontarTabela();
            //foreach (DataRow linha in dt.Rows)
            //{
            //    DataRow dr = dtTrans.NewRow();
            //    dr["imagem"] = linha["imagem"];
            //    dr["texto"] = "<a href link='" + linha["destino"] + "'>" + linha["titulo"] + "</a>" + linha["descricao"];
            //    dtTrans.Rows.Add(dr);
            //    //dr = dtTrans.NewRow();
            //    //dr["descricao"] = linha["descricao"];
            //    //dtTrans.Rows.Add(dr);
            //}

            return (Xml);
        }

        #endregion

        #region IManterMenu Members

        public int IncluirItem(string nome)
        {
            DataSet dsXml = new DataSet();
            DataTable tab;
            DataRow linha;

            dsXml.ReadXml(enderecoXml);
            //tab = this.MontarTabela();
            if (dsXml.Tables.Count > 0)
            {
                linha = dsXml.Tables[0].NewRow();
                linha["Nome"] = nome;
                linha["Codigo"] = dsXml.Tables[0].Rows.Count;
                dsXml.Tables[0].Rows.Add(linha);
                dsXml.WriteXml(enderecoXml);
            }
            else return 0;
            
            //tab.Rows.Add(linha);

            return (dsXml.Tables[0].Rows.Count);
        }

        public int ExcluirItem(int codigo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private DataTable MontarTabela()
        {
            DataTable tabela = new DataTable();

            tabela.Columns.Add("Codigo");
            tabela.Columns.Add("Nome");

            return (tabela);
        }
    }
}
