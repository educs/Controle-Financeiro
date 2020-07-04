using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Freela.Interface
{
    public interface IBD
    {
        int Gravar(string proc, IList<SqlParameter> ps);
        System.Data.DataTable Ler(string proc, IList<SqlParameter> ps);
    }
}
