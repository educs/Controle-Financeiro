using System;
using System.Collections.Generic;
using System.Text;

namespace Freela.Interface
{
    public interface ICategoria
    {
        void Selecionar(int codigo);
        IList<ICategoria> Selecionar(byte tipo);
        void Salvar();
        void Excluir();
        int Codigo{get; set; }
        byte Tipo { get; set; }
        string Descricao{get; set;}
        IBem Bem
        {
            get;
            set;
        }
    }
}
