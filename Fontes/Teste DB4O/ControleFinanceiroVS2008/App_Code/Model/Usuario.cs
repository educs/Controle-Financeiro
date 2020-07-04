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
using financa.db;

namespace financa.model
{

    /// <summary>
    /// Summary description for Usuario
    /// </summary>
    [Serializable]
    public class Usuario
    {
        private string _nome;
        private string _apelido;
        private string _senha;
        private string _email;
        private List<Conta> _contas = new List<Conta>();

        public Usuario()
        {

        }

        public Usuario selecionar()
        {
            Usuario u = null;
            try
            {
                db4o.conectar();
                u = (Usuario)db4o.Selecionar(this);
            }
            finally
            {
                db4o.desconectar();
            }
            return (u);
        }

        public void cadastrar()
        {
            try
            {
                db4o.conectar();
                if (db4o.Selecionar(this) != null)
                    throw (new Exception("Nome de Usuário indisponível!"));
                db4o.cadastrar(this);
            }
            catch (Exception erro)
            {
                db4o.rollBack();
                throw (new Exception(erro.Message));
            }
            finally
            {
                db4o.desconectar();
            }
        }

        public Usuario incluirConta(Conta c)
        {
            Usuario usuario;
            try
            {
                db4o.conectar();
                usuario = (Usuario)db4o.Selecionar(this);
                c.usuario = usuario;
                if (db4o.Selecionar(c) != null)
                    throw (new Exception("Conta já cadastrada!"));

                usuario.contas.Add(c);
                db4o.cadastrar(usuario);
            }
            catch (Exception erro)
            {
                db4o.rollBack();
                throw (new Exception(erro.Message));
            }
            finally
            {
                db4o.desconectar();
            }

            return (usuario);
        }

        /*  public Usuario incluirLancamento(Lancamento l)
          {
              Usuario usuario;
              try
              {
                  db4o.conectar();
                  usuario = (Usuario)db4o.Selecionar(this);
                  usuario.lancamentos.Add(l);
            
                  db4o.cadastrar(usuario);
              }
              catch (Exception erro)
              {
                  db4o.rollBack();
                  throw (new Exception(erro.Message));
              }
              finally
              {
                  db4o.desconectar();
              }

              return usuario;
          }*/

        public bool logar(string nomeUsuario, string senha)
        {
            Usuario usuario;

            try
            {
                this.apelido = nomeUsuario;
                this.senha = senha;
                usuario = this.selecionar();
                if (usuario != null)
                {
                    this.contas = usuario.contas;
                    this.email = usuario.email;
                    //this.lancamentos = usuario.lancamentos;
                    this.nome = usuario.nome;
                    return true;
                }
            }
            finally
            {
                usuario = null;
            }

            return false;
        }

        public IList listar()
        {
            List<Usuario> us = new List<Usuario>();

            try
            {
                db4o.conectar();
                foreach (Usuario u in db4o.listar(this))
                { // db.Query<Conta>();
                    us.Add(u);
                }
            }
            finally
            {
                db4o.desconectar();
            }

            return us;
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
            get { return this._email; }
            set { this._email = value; }
        }

        public List<Conta> contas
        {
            get { return this._contas; }
            set { this._contas = value; }
        }

    }//end Usuario
}