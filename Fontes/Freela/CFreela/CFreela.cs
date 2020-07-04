using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using System.Web;
using Freela.Interface;

namespace Freela.Controladora
{
    public class CFreela : CBase
    {
        private void MontarTabela(out DataSet tabela)
        {
            tabela = new DataSet();

            tabela.Tables[0].Columns.Add("Imagem");
            tabela.Tables[0].Columns.Add("Texto");

            //return (tabela);
        }

    }
}
