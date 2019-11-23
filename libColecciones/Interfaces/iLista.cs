using System;
namespace Servicios.Colecciones.Interfaces
{
    interface iLista <Tipo> where Tipo : IComparable
    {
        bool Agregar(Tipo prmItem);
        bool Insertar(int prmIndice, Tipo prmItem);
        bool Modificar(int prmindice, Tipo prmItem);
        bool Remover(int prmIndice, ref Tipo prmItem);
        bool Recuperar(int prmIndice, ref Tipo prmItem);
    }
}
