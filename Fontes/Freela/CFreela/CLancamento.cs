using System;
using System.Data;
using System.Collections.Generic;
using Freela.Interface;
using Freela.Modelo;

namespace Freela.Controladora
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CLancamento: ILancamento
	{
        private int _codigo;
        private string _descricao;
        private decimal _valor;
        private byte _tipo;
        private DateTime _data;
        ICategoria _categoria;
        MLancamento Ac = new MLancamento();

		public CLancamento()
		{
			
		}

        public CLancamento(string initID)
        {
            this._codigo = Convert.ToInt32(initID);
            this.Selecionar();
        }

        #region ILancamento Members

        public void Lancar()
        {
            MLancamento Ac = new MLancamento();

            Ac.Gravar(this);
        }

        public void Atualizar()
        {
            throw new Exception("The method or operation is not implemented.");
        }

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

        public string Descricao
        {
            get
            {
                return this._descricao;
            }
            set
            {
                this._descricao = value;
            }
        }

        public decimal Valor
        {
            get
            {
                return this._valor;
            }
            set
            {
                this._valor = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }

        public ICategoria Categoria
        {
            get
            {
                if (this._categoria == null)
                    this._categoria = new CCategoria();
                return this._categoria;
            }
            set
            {
                this._categoria = value;
            }
        }

        public void Selecionar()
        {
            Ac.Ler(this);
            //MLancamento Ac = new MLancamento();
            //DataTable dt;

            //dt = Ac.Ler(ID);
            //this.Codigo = Convert.ToInt32(dt.Rows[0]["Codigo"]);
            //this.Descricao = Convert.ToString(dt.Rows[0]["Descricao"]);
            //this.Data = Convert.ToDateTime(dt.Rows[0]["Data"]);
            //this.Valor = Convert.ToDecimal(dt.Rows[0]["Valor"]);
            //this.Categoria = new CCategoria(Convert.ToInt32(dt.Rows[0]["idCategoria"]));
            
            //return (this);
        }

        public IList<ILancamento> Selecionar(byte tipo)
        {
            MLancamento Ac = new MLancamento();
            DataTable dt = new DataTable();
            IList<ILancamento> ls = new List<ILancamento>();
            ILancamento l;

            dt = Ac.Ler();
            foreach (DataRow linha in dt.Rows)
            {
                if (Convert.ToByte(linha["tipo"]) == tipo)
                {
                    l = new CLancamento();
                    l.Codigo = Convert.ToInt32(linha["codigo"]);
                    l.Descricao = Convert.ToString(linha["descricao"]);
                    l.Data = Convert.ToDateTime(linha["data"]);
                    l.Valor = Convert.ToDecimal(linha["valor"]);
                    l.Categoria = new CCategoria(Convert.ToInt16(linha["idCategoria"]));
                    ls.Add(l);
                }
            }

            return (ls);
        }

        #endregion
    }
}
