using System;
using System.IO;
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

namespace MVCFinancas.Controllers
{
    /// <summary>
    /// Summary description for FabricaLancamento
    /// </summary>

    public static class FabricaLancamento
    {
        public static Lancamento fabricarLancamento(String tipoLancamento, Stream comprovante)
        {
            if (tipoLancamento == "D")
                return new LancamentoDebito(comprovante);
            else return new LancamentoCredito(comprovante);
        }
    }
}