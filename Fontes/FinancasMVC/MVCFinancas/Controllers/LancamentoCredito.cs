///////////////////////////////////////////////////////////
//  LancamentoCredito.cs
//  Implementation of the Class LancamentoCredito
//  Generated by Enterprise Architect
//  Created on:      28-mar-2009 13:16:19
//  Original author: fast
///////////////////////////////////////////////////////////

using System.IO;

namespace MVCFinancas.Controllers
{

    public class LancamentoCredito : Lancamento
    {

        private Stream _comprovanteCredito;

        public LancamentoCredito() { }

        public LancamentoCredito(Stream comprovante)
        {
            this._comprovanteCredito = comprovante;
        }

        public Stream comprovanteCredito
        {
            get
            {
                return this._comprovanteCredito;
            }
            set
            {
                this._comprovanteCredito = value;
            }
        }

        public override decimal valor
        {
            get
            {
                return base._valor;
            }
            set
            {
                base._valor = value;
            }
        }

    }//end LancamentoCredito
}