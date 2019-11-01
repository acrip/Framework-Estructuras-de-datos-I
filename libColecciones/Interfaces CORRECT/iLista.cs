using System;
namespace Servicios.Colecciones.Interfaces
{
    interface iLista <Tipo> where Tipo : IComparable
    {
        bool Agregar(Tipo prmItem);
        bool Insertar(Tipo prmItem, int prmIndice);
        bool Remover(ref Tipo prmItem, int prmIndice);
        bool Encontrar(Tipo prmItem, ref int prmIndice);
        bool Existe(Tipo prmItem);
    }
}
