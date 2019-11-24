using System;
namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
        #endregion
        #region Métodos
        #region Métodos Constructores
        public clsNodoDobleEnlazado(Tipo prmItem):base(prmItem) { }
        #endregion
        #region Métodos accesores y mutadores
        public clsNodoDobleEnlazado<Tipo> darAnterior() { return atrAnterior; }
        public clsNodoDobleEnlazado<Tipo> darSiguiente() { return atrSiguiente; }
        public void ponerAnterior(clsNodoDobleEnlazado<Tipo> prmNodo) { atrAnterior = prmNodo; }
        public void ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmNodo) { atrSiguiente = prmNodo; }
        #endregion
        #endregion
    }
}

