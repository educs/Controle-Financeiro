using System;
using System.Collections.Generic;
using System.Text;

namespace Freela.Interface
{
    public interface IBem
    {
        int Codigo
        {
            get;
            set;
        }
        decimal Valor
        {
            get;
            set;
        }
        string Descricao
        {
            get;
            set;
        }
        string Usuario
        {
            get;
            set;
        }
        IList<IBem> Selecionar(string nomeUsuario);
        void Salvar();
    }

    public interface ICarro: IBem
    {
        string Placa
        {
            get;
            set;
        }

        string Modelo
        {
            get;
            set;
        }
    }

    public interface ICasa : IBem
    {
        string Descricao
        {
            get;
            set;
        }

        decimal Iptu
        {
            get;
            set;
        }
    }

    public interface IDinheiro : IBem
    {
        string Descricao
        {
            get;
            set;
        }
    }
}
