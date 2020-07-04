using System;
using System.Collections.Generic;
using System.Text;

namespace Freela.Interface
{
    public interface ILancamento
    {
        void Lancar();
        void Atualizar();
        void Selecionar();
        IList<ILancamento> Selecionar(byte tipo);
        int Codigo { get; set; }
        string Descricao { get; set; }
        decimal Valor { get; set; }
        DateTime Data { get; set; }
        ICategoria Categoria { get; set; }
    }
}
