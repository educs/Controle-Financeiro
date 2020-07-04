using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using Freela.Interface;

namespace Freela.Controladora
{
    public class CManterMenu : CBase, IMenu
    {
        string enderecoXml = "D:\\Fontes\\Freela\\Web.sitemap";
        private int _codigo;
        private string _nome
            , _link;

        #region IMenu Members

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }
        public string Nome
        {
            get
            {
                return this._nome;
            }
            set
            {
                this._nome = value;
            }
        }
        public string Link
        {
            get
            {
                return this._link;
            }
            set
            {
                this._link = value;
            }
        }

        #endregion
        #region IXml Members

        public override DataSet ConsultarXml()
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

            return (dsXml);
        }

        #endregion

        #region IManterMenu Members

        public int GravarItem(IMenu menu)
        {
            DataSet dsXml = new DataSet();
            //DataTable tab;
            //DataRow linha;
            XmlDocument x = new XmlDocument();
            XmlNode y
                , xn;

            if (menu.Codigo == 0)
            {
                x.Load(enderecoXml);
                xn = x.ChildNodes[1].ChildNodes[0];
                if (xn.HasChildNodes)
                {
                    y = xn.ChildNodes[0].CloneNode(false);
                    y.Attributes["url"].InnerXml = menu.Link;
                    y.Attributes["description"].InnerXml = menu.Nome;
                    y.Attributes["title"].InnerXml = menu.Nome;
                    xn.InsertAfter(y, xn.LastChild);
                    x.Save(enderecoXml);
                }
                else return 0;
            }
            else
            {
                xn = x.GetElementById(menu.Codigo.ToString());
                xn.Attributes["url"].InnerXml = menu.Link;
                xn.Attributes["description"].InnerXml = menu.Nome;
                xn.Attributes["title"].InnerXml = menu.Nome;
                x.Save(enderecoXml);
            }
            
            //dsXml.ReadXml(enderecoXml);
            ////tab = this.MontarTabela();
            //if (dsXml.Tables.Count > 0)
            //{
            //    linha = dsXml.Tables[0].NewRow();
            //    linha["title"] = nome;
            //    linha["url"] = "teste.aspx";
            //    dsXml.Tables[0].Rows.Add(linha);
            //    dsXml.WriteXml(enderecoXml);
            //}
            //else return 0;

            ////tab.Rows.Add(linha);

            //return (dsXml.Tables[0].Rows.Count);
            return 1;
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

        #region IMenu Members


        public IMenu[] Consultar()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IMenu[] Consultar(XmlDocument x)
        {
             //XmlDocument Xml = new XmlDocument();
            DataSet dsXml = new DataSet();
            //DataTable dt, dtTrans = new DataTable();
            //XmlNodeList nl;
            IMenu[] items = new IMenu[x.ChildNodes.Count];
            int i = 0;

            if (x.HasChildNodes)
            {
                foreach (XmlNode noh in x.ChildNodes)
                {
                    IMenu item = new CManterMenu();
                    item.Codigo = noh.InnerText[0];
                    item.Link = noh.InnerText[1].ToString();
                    item.Nome = noh.InnerText[2].ToString();
                    items.SetValue(item, i);
                    i++;
                }
            }

            return items;
        }

        #endregion
    }
}
