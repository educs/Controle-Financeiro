using System;
using System.Collections.Generic;
using System.Text;
using Freela.Interface;

namespace Freela.Modelo
{
    public class MMenu
    {
        private int _codigo;
        private string _nome
            , _link;

        #region IMenu Members

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }

        public string Nome
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

        public string Link
        {
            get
            {
                return this._link;
            }
            set
            {
                this._link = value;
            }
        }

        #endregion
    }
}
