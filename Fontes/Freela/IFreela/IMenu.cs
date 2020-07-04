using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

namespace Freela.Interface
{
    public interface IMenu
    {
        int Codigo { get; set; }
        string Nome { get; set; }
        string Link { get; set; }
        int GravarItem(IMenu menu);
        int ExcluirItem(int codigo);
        IMenu[] Consultar();
        IMenu[] Consultar(XmlDocument x);
    }
}
