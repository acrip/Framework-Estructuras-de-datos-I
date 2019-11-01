using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;
namespace Servicios.Colecciones.Vectoriales
{
    class clsColaVector<Tipo> : clsTadVectorial<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        public bool Encolar(Tipo prmItem) { return InsertarEn(atrLongitud, prmItem);}
        public bool Desencolar(ref Tipo prmItem) { return false; }
        public bool Revisar(ref Tipo prmItem) { return false; }
    }
}
