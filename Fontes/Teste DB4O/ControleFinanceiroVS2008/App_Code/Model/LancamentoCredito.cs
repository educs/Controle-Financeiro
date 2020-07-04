///////////////////////////////////////////////////////////
//  LancamentoCredito.cs
//  Implementation of the Class LancamentoCredito
//  Generated by Enterprise Architect
//  Created on:      28-mar-2009 13:16:19
//  Original author: fast
///////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.IO;
using Db4objects.Db4o.Activation;
using Db4objects.Db4o.TA;
using Db4objects.Db4o;

namespace financa.model
{

    [Serializable]
    public class LancamentoCredito : Lancamento, IActivatable
    {

        [Transient]
        private IActivator _activator;

        private Image _comprovanteCredito;

        public LancamentoCredito() { }

        public LancamentoCredito(byte[] comprovante)
        {
            Activate(ActivationPurpose.Write);
            this.Imagem = comprovante;
        }

        public LancamentoCredito(Lancamento l)
        {
            Activate(ActivationPurpose.Read);
            MemoryStream ms = new MemoryStream(l.Imagem);
            this._comprovanteCredito = Image.FromStream(ms);
        }

        public override Image Comprovante
        {
            get
            {
                return this._comprovanteCredito;
            }
        }

        public override byte[] Imagem
        {
            set
            {
                Activate(ActivationPurpose.Write);
                this._imagem = value;
                MemoryStream ms = new MemoryStream(value);
                if (ms.Length > 0)
                    this._comprovanteCredito = Image.FromStream(ms);
            }
            get
            {
                Activate(ActivationPurpose.Read);
                return this._imagem;
            }
        }

        public override decimal valor
        {
            set
            {
                base._valor = this.calculaValor();
                if (base.valor == 0)
                    base._valor = value;
            }
            get
            {
                return this._valor;
            }
        }

        #region IActivatable Members

        public void Activate(Db4objects.Db4o.Activation.ActivationPurpose purpose)
        {
            if (_activator != null)
            {
                _activator.Activate(purpose);
            }
        }

        public void Bind(Db4objects.Db4o.Activation.IActivator activator)
        {
            if (null != _activator)
            {
                throw new System.InvalidOperationException();
            }
            _activator = activator;
        }


        #endregion

    }//end LancamentoCredito
}