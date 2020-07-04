using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Freela.Modelo;
using Freela.Interface;

namespace Freela.Controladora
{
    public class CCategoria: ICategoria
    {
        int _codigo;
        byte _tipo;
        string _descricao;
        IBem _bem;
        MCategoria Ac = new MCategoria();

        public CCategoria()
        {
        }

        public CCategoria(int initCodigo)
        {
            this.Selecionar(initCodigo);
        }

        #region ICategoria Members

        public IList<ICategoria> Selecionar()
        {
            DataTable dt = new DataTable();
            IList<ICategoria> ls = new List<ICategoria>();
            ICategoria l;

            dt = Ac.Ler();
            foreach (DataRow linha in dt.Rows)
            {
                l = new CCategoria();
                l.Codigo = Convert.ToInt32(linha["codigo"]);
                l.Tipo = Convert.ToByte(linha["tipo"]);
                l.Descricao = Convert.ToString(linha["nome"]);
                ls.Add(l);
            }

            return (ls);
        }


        public void Selecionar(int codigo)
        {
            Ac.Ler(codigo, this);
        }

        public IList<ICategoria> Selecionar(byte tipo)
        {
            DataTable dt = new DataTable();
            IList<ICategoria> ls = new List<ICategoria>();
            ICategoria l;

            dt = Ac.Ler();
            foreach (DataRow linha in dt.Rows)
            {
                if (Convert.ToByte(linha["tipo"]) == tipo)
                {
                    l = new CCategoria();
                    l.Codigo = Convert.ToInt32(linha["codigo"]);
                    l.Tipo = Convert.ToByte(linha["tipo"]);
                    l.Descricao = Convert.ToString(linha["nome"]);
                    ls.Add(l);
                }
            }

            return (ls);
        }

        public void Salvar()
        {
            Ac.Salvar(this);
        }

        public void Excluir()
        {
            Ac.Excluir(this);
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

        #endregion

        #region ICategoria Members


        public byte Tipo
        {
            get
            {
                return this._tipo;
            }
            set
            {
                this._tipo = value;
            }
        }

        public IBem Bem
        {
            get
            {
                if (this._bem == null)
                {
                    this._bem = new CBem();
                }
                return this._bem;
            }
            set
            {
                this._bem = value;
            }
        }
        #endregion
    }
}
