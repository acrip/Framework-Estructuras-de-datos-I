using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsPilaDobleEnlazada <Tipo> : iPila<Tipo> where Tipo : IComparable
    {
        #region Métodos
        public bool Apilar(Tipo prmItem) { return false; }
        public bool Desapilar(ref Tipo prmItem) { return false; }
        public bool Revisar(ref Tipo prmItem) { return false; }
        #endregion
    }
}
