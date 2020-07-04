using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MVCFinancas.Controllers
{
    /// <summary>
    /// Summary description for Usuario
    /// </summary>
    /// 
    public class Usuario
    {
        private string _nome;
        private string _apelido;
        private string _senha;
        private string _email;
        private List<Conta> _contas;
        private List<Lancamento> _lancamentos;

        public Usuario()
        {

        }

        public void cadastrar()
        {
            db4o.cadastrar(this);
        }

        public void incluirConta(Conta c)
        {
            this._contas.Add(c);
            db4o.cadastrar(this);
        }

        public bool logar(string nomeUsuario, string senha)
        {
            Usuario usuario;


            this.apelido = nomeUsuario;
            this.senha = senha;
            usuario = (Usuario)db4o.Selecionar(this);
            if (usuario != null)
                return true;

            return false;
        }

        public IList listar(Usuario usuario)
        {
            ArrayList cs;

            cs = (ArrayList)db4o.listar(usuario); // db.Query<Conta>();

            return cs;
        }

        public string nome
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

        public string apelido
        {
            get
            {
                return this._apelido;
            }
            set
            {
                this._apelido = value;
            }
        }

        public string senha
        {
            get
            {
                return this._senha;
            }
            set
            {
                this._senha = value;
            }
        }

        public string email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public List<Conta> contas
        {
            get
            {
                if (_contas == null)
                    _contas = new List<Conta>();

                return this._contas;
            }
            //set { this.m_Categorias.Add(value); }
        }

        public IList lancamentos
        {
            get
            {
                Lancamento l = new Lancamento();
                l.usuario = this;

                return (ArrayList)l.listar();
            }
            //set { this.m_Categorias.Add(value); }
        }

    }//end Usuario
}