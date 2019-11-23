using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;
namespace Servicios.Colecciones.SimpleEnlazadas
{
    public class clsColaSimpleEnlazada<Tipo> : clsTadSimpleEnlazado<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        public bool Encolar(Tipo prmItem){ return InsertarEn(atrLongitud, prmItem); }
        public bool Desencolar(ref Tipo prmItem){ return ExtraerEn(0, ref prmItem); }
        public bool Revisar(ref Tipo prmItem) { return RecuperarEn(0, ref prmItem); }
    }
}
