using Freela.Interface;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System.Collections.Generic;
using System;
using System.IO;

namespace Freela.Modelo.BDOO
{
    public class Base
    {
        public readonly static string YapFileName = Path.Combine(
                               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                               "bd.yap");
        public readonly static int ServerPort = 0xdb40;
        public readonly static string ServerUser = "user";
        public readonly static string ServerPassword = "password";
       
        #region IBD Members

        public int Gravar(string proc, IList<string> ps)
        {
            return 0;
        }

        public System.Data.DataTable Ler(string proc, IList<string> ps)
        {
            return null;
        }

        #endregion
    }
}
