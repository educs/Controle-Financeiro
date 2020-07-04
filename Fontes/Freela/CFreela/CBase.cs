using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using Freela.Interface;

namespace Freela.Controladora
{
    public class CBase : IBase
    {
        #region IBase Members

        public virtual DataSet ConsultarXml()
        {
            return null;
        }

        #endregion
    }
}
