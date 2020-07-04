using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Freela.Interface;

namespace Freela.Modelo.BDOO
{
    public class Bem: Base
    {
        private IObjectContainer db;
        
        public Bem()
        {
            File.Delete(Base.YapFileName);
			//AccessDb4o();
			File.Delete(Base.YapFileName);
			try
			{
                db = Db4oFactory.OpenFile(Base.YapFileName);
            }
            finally
            {
                //db.Close();
            }
        }

        #region IBD Members

        public void Gravar(IBem b)
        {
            db.Store(b);
        }

        public IList<IBem> Ler()
        {
            IQuery query = db.Query();
            IList<IBem> b = new List<IBem>();

            query.Constrain(typeof(Bem));
            IObjectSet resultado = query.Execute();
            while (resultado.HasNext())
            {
                b.Add((IBem)resultado.Next());
            }

            return b;
        }

        #endregion
    }
}
