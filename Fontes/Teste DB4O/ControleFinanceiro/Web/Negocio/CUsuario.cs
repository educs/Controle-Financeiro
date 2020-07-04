using System.Collections;
using System.Collections.Generic;
using System.Data;
using Db4objects.Db4o;

namespace Web
{
    public class CUsuario
    {

        private string _nome;
        private string _apelido;
        private string _senha;
        private IObjectContainer db;

        public CUsuario()
        {
        }

        ~CUsuario(){
	    }

        public virtual void Dispose()
        {

        }

        public IList<CUsuario> listar()
        {
            IList<CUsuario> lista;

            db = Db4oFactory.OpenFile("E:\\Nova pasta\\Desenvolvimento\\Fontes\\dados.yap");
            lista = db.Query<CUsuario>();

            return lista;
        }
        
        public void cadastrar()
        {
            IObjectContainer db = Db4oFactory.OpenFile("E:\\Nova pasta\\Desenvolvimento\\Fontes\\dados.yap");
            db.Store(this);
            db.Commit();
        }

        public string nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }

        public string apelido
        {
            get
            {
                return _apelido;
            }
            set
            {
                _apelido = value;
            }
        }

        public string senha
        {
            get
            {
                return _senha;
            }
            set
            {
                _senha = value;
            }
        }

    }//end CUsuario
}
