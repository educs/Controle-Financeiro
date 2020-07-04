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
using financa.db;

namespace financa.model.fabrica
{

    /// <summary>
    /// Summary description for FabricaLancamento
    /// </summary>
    public static class FabricaLancamento
    {
        public static Lancamento fabricarLancamento(String tipoLancamento, byte[] comprovante)
        {
            if (tipoLancamento == "D")
                return new LancamentoDebito(comprovante);
            else if (tipoLancamento == "C") return new LancamentoCredito(comprovante);

            throw new Exception("Selecione o tipo do lançamento.");
        }

        public static Lancamento fabricarLancamento(String tipoLancamento, long initId)
        {
            try
            {
                db4o.conectar();

                Lancamento l;
                if (tipoLancamento.Equals(typeof(LancamentoDebito).ToString()))
                    l = new LancamentoDebito();
                else if (tipoLancamento.Equals(typeof(LancamentoCredito).ToString()))
                    l = new LancamentoCredito();
                else l = new Lancamento();
                l = (Lancamento)db4o.Selecionar(l, initId);
                if (l.GetType().Equals(typeof(LancamentoCredito)))
                    return new LancamentoCredito(l);
                else if (l.GetType().Equals(typeof(LancamentoDebito)))
                    return new LancamentoDebito(l);
            }
            catch (Exception erro)
            {
                db4o.desconectar();
            }

            return null;
        }

    }
}