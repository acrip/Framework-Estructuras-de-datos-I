using System;
using Servicios.Colecciones.Nodos;
namespace Servicios.Colecciones.TADS
{
    public class clsTadDobleEnlazado<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrNodoPrimero;
        private clsNodoDobleEnlazado<Tipo> atrNodoUltimo;
        #endregion
        #region Accesores
        public clsNodoDobleEnlazado<Tipo> darNodoPrimero()
        {
            return this.atrNodoPrimero;
        }
        public clsNodoDobleEnlazado<Tipo> darNodoUltimo()
        {
            return this.atrNodoUltimo;
        }
        #endregion
        #region CRUD-Query
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varNodoNuevo = new clsNodoDobleEnlazado<Tipo>(prmItem);
            #region Insertar el primer elemento
            if (EstaVacia())
            {
                atrNodoPrimero = varNodoNuevo;
                atrNodoUltimo = atrNodoPrimero;
                atrNodoUltimo.ponerAnterior(atrNodoPrimero);
                atrNodoPrimero.ponerSiguiente(atrNodoUltimo);
                atrLongitud++;
                return true;
            }
            #endregion
            #region Insertar en la primera posicion
            if (prmIndice == 0)
            {
                varNodoNuevo.ponerSiguiente(atrNodoPrimero);
                atrNodoPrimero.ponerAnterior(varNodoNuevo);
                atrNodoPrimero = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            #endregion
            #region Insertar en la ultima posicion
            if (prmIndice == atrLongitud)
            {
                atrNodoUltimo.ponerSiguiente(varNodoNuevo);
                varNodoNuevo.ponerAnterior(atrNodoUltimo);
                atrNodoUltimo = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            #endregion
            #region Insertar en cualquier posicion
            if (EsValido(prmIndice))
            {
                clsNodoDobleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 1; varIndice < prmIndice - 1; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoNuevo.ponerSiguiente(varNodoActual.darSiguiente());
                varNodoNuevo.ponerAnterior(varNodoActual);
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
                #region extraer en 0
                if (prmIndice == 0)
                {
                    prmItem = atrNodoPrimero.darItem();
                    if (atrLongitud == 1)
                    {
                        atrNodoPrimero = null;
                        atrNodoUltimo = null;
                        atrLongitud--;
                        return true;
                    }
                    atrNodoPrimero = atrNodoPrimero.darSiguiente();
                    atrNodoPrimero.ponerAnterior(null);
                    atrLongitud--;
                    return true;
                }
                #endregion
                #region Extraer en longitud
                if (prmIndice == atrLongitud - 1)
                {
                    prmItem = atrNodoUltimo.darItem();
                    atrNodoUltimo = atrNodoUltimo.darAnterior();
                    atrNodoUltimo.ponerSiguiente(null);
                    atrLongitud--;
                    return true;
                }
                #endregion
                #region extraer en n posicion
                if (EsValido(prmIndice))
                {
                    clsNodoDobleEnlazado<Tipo> varNodoExtraido = atrNodoPrimero;
                    for (int varIndice = 1; varIndice < prmIndice ; varIndice++)
                        varNodoExtraido = varNodoExtraido.darSiguiente();
                    prmItem = varNodoExtraido.darItem();
                    varNodoExtraido.darSiguiente().ponerAnterior(varNodoExtraido.darAnterior());
                    varNodoExtraido.darAnterior().ponerSiguiente(varNodoExtraido.darSiguiente());
                    varNodoExtraido.ponerSiguiente(null); 
                    varNodoExtraido.ponerAnterior(null);
                    atrLongitud--;
                    GC.Collect();
                    return true;
                }
                #endregion
            }
            return false;
        }
        protected override bool ModificarEn(int prmIndice, Tipo prmItem){
            if (!EstaVacia())
            {
                #region modificar en 0
                if (prmIndice == 0)
                {
                    atrNodoPrimero.ponerItem(prmItem);
                    if(atrLongitud == 1)
                    {
                        atrNodoUltimo = atrNodoPrimero;
                    }
                    return true;
                }
                #endregion
                #region modificar en longitud
                if (prmIndice == atrLongitud - 1)
                {
                    atrNodoUltimo.ponerItem(prmItem);
                    return true;
                }
                #endregion
                #region modificar en n posicion
                if (EsValido(prmIndice))
                {
                    clsNodoDobleEnlazado<Tipo> varNodoModificado = atrNodoPrimero;
                    for (int varIndice = 1; varIndice <= prmIndice; varIndice++)
                        varNodoModificado = varNodoModificado.darSiguiente();
                    varNodoModificado.ponerItem(prmItem);
                    return true;
                }
                #endregion
            }
            return false;
            }
        protected override bool RecuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (!EstaVacia())
                {
                #region recuperar en 0
                if (prmIndice == 0)
                {
                    prmItem = atrNodoPrimero.darItem();
                    return true;
                }
                #endregion
                #region recuperar en longitud
                if (prmIndice == atrLongitud - 1)
                {
                    prmItem = atrNodoUltimo.darItem();
                    return true;
                }
                #endregion
                #region recuperar en n posicion
                if (EsValido(prmIndice))
                {
                    clsNodoDobleEnlazado<Tipo> varNodoRecuperado = atrNodoPrimero;
                    for (int varIndice = 1; varIndice <= prmIndice; varIndice++)
                        varNodoRecuperado = varNodoRecuperado.darSiguiente();
                    prmItem = varNodoRecuperado.darItem();
                    return true;
                }
                #endregion
                }
            return false;
        }
        #endregion
    }
}
