using System;
using Servicios.Colecciones.Nodos;
namespace Servicios.Colecciones.TADS
{
    public class clsTadSimpleEnlazado <Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoSimpleEnlazado<Tipo> atrNodoPrimero;
        private clsNodoSimpleEnlazado<Tipo> atrNodoUltimo;
        #endregion
        #region Metodos
        #region Accesores
        public clsNodoSimpleEnlazado<Tipo> darNodoPrimero()
        {
            return this.atrNodoPrimero;
        }
        public clsNodoSimpleEnlazado<Tipo> darNodoUltimo()
        {
            return this.atrNodoUltimo;
        }
        #endregion
        #region CRUDs
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            clsNodoSimpleEnlazado<Tipo> varNodoNuevo = new clsNodoSimpleEnlazado<Tipo>(prmItem);
            #region Insertar el primer elemento
            if (EstaVacia())
            {
                atrNodoPrimero = varNodoNuevo;
                atrNodoPrimero.ponerSiguiente(atrNodoUltimo);
                atrNodoUltimo = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            #endregion
            #region Insertar al inicio de la coleccion
            if (prmIndice == 0)
            {
                varNodoNuevo.ponerSiguiente(atrNodoPrimero);
                atrNodoPrimero = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            #endregion
            #region Insertar al final de la coleccion
            if (prmIndice == atrLongitud)
            {
                atrNodoUltimo.ponerSiguiente(varNodoNuevo);
                atrNodoUltimo = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            #endregion
            #region Insertar en cualquier posicion
            if (EsValido(prmIndice))
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 1; varIndice < prmIndice - 1; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoNuevo.ponerSiguiente(varNodoActual.darSiguiente());
                varNodoActual.ponerSiguiente(varNodoNuevo);
                atrLongitud++;
                return true;
            }
            #endregion
            return false;
        }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (!EstaVacia())
            {
                #region Entraer al inicio de la colección
                if (prmIndice == 0)
                {
                    prmItem = atrNodoPrimero.darItem();
                    atrNodoPrimero = atrNodoPrimero.darSiguiente();
                    atrLongitud--;
                    return true;
                }
                #endregion
                #region Extraer al final de la coleccion
                if (prmIndice == atrLongitud - 1)
                {
                    clsNodoSimpleEnlazado<Tipo> varNodoExtraido = atrNodoPrimero;
                    for (int varIndice = 1; varIndice < prmIndice; varIndice++)
                        varNodoExtraido = varNodoExtraido.darSiguiente();
                    prmItem = varNodoExtraido.darSiguiente().darItem();
                    atrNodoUltimo = varNodoExtraido;
                    varNodoExtraido.ponerSiguiente(null);
                    atrLongitud--;
                    return true;
                }
                #endregion
                #region Extraer en cualquier posicion
                if (EsValido(prmIndice))
                {
                    clsNodoSimpleEnlazado<Tipo> varNodoExtraido = atrNodoPrimero;
                    for(int varIndice = 1; varIndice <= prmIndice; varIndice ++)
                        varNodoExtraido = varNodoExtraido.darSiguiente();
                    prmItem = varNodoExtraido.darItem();
                    varNodoExtraido.ponerSiguiente(varNodoExtraido.darSiguiente());
                    atrLongitud--;
                    return true;
                }
                #endregion
            }
            return false;
        }
        protected override bool ModificarEn(int prmIndice, Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 0; varIndice < prmIndice; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoActual.ponerItem(prmItem);
                return true;
            }
            return false;
        }
        protected override bool RecuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 0; varIndice < prmIndice; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                prmItem = varNodoActual.darItem(); 
                return true;
            }
            return false;
        }
        #endregion
        #endregion
    }
}
