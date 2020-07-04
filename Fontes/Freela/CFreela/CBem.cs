using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Freela.Interface;
using Freela.Modelo.BDOO;

namespace Freela.Controladora
{
    public class CBem: IBem
    {
        int _codigo;
        decimal _valor;
        string _descricao
            , _usuario;
        //Bem Ac = new Mbem();
        Bem Ac = new Bem();

        #region IBem Members

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

        public string Usuario
        {
            get
            {
                return this._usuario;
            }
            set
            {
                this._usuario = value;
            }
        }

        public IList<IBem> Selecionar(string nomeUsuario)
        {
            DataTable dt = new DataTable();
            IList<IBem> ls = new List<IBem>();
            IBem l;

            //dt = Ac.Ler(nomeUsuario);
            ls = Ac.Ler();
            foreach (DataRow linha in dt.Rows)
            {
                l = new CBem();
                l.Codigo = Convert.ToInt32(linha["codigo"]);
                l.Descricao = linha["descricao"].ToString();
                ls.Add(l);
            }

            return (ls);
        }

        public void Salvar()
        {
            //Ac.Salvar(this);
            Ac.Gravar(this);
        }

        #endregion
    }

    public class CCarro : CBem, ICarro
    {
        string _placa;
        string _modelo;

        #region ICarro Members

        public string Placa
        {
            get
            {
                return this._placa;
            }
            set
            {
                this._placa = value;
            }
        }

        public string Modelo
        {
            get
            {
                return this._modelo;
            }
            set
            {
                this._modelo = value;
            }
        }

        #endregion
    }

    public class CCasa: CBem, ICasa
    {
        string _descricao;
        decimal _iptu;
        #region ICasa Members

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

        public decimal Iptu
        {
            get
            {
                return this._iptu;
            }
            set
            {
                this._iptu = value;
            }
        }

        #endregion
    }

    public class CDinheiro : CBem, IDinheiro
    {
        string _descricao;

        #region IDinheiro Members

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

        #endregion
    }
}
