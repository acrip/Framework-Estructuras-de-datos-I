using System;
namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable
    {
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;

        #region Metodos Constructores
        public clsNodoDobleEnlazado(Tipo prmItem):base(prmItem) { }
        #endregion

        public clsNodoDobleEnlazado<Tipo> darAnterior() { return atrAnterior; }
        public clsNodoDobleEnlazado<Tipo> darSiguiente() { return atrSiguiente; }
        public void ponerAnterior(clsNodoDobleEnlazado<Tipo> prmNodo) { atrAnterior = prmNodo; }
        public void ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmNodo) { atrSiguiente = prmNodo; }
    }
}

