using System;
using Servicios.Colecciones.Nodos;
using System.Collections.Generic;

namespace Servicios.Colecciones.TADS
{
    public class clsTadSimpleEnlazado <Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoSimpleEnlazado<Tipo> atrNodoPrimero;
        private clsNodoSimpleEnlazado<Tipo> atrNodoUltimo;
        #endregion
        #region Metodos
        #region CRUDs
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            #region Metodo para validar cuando no se puede realizar una insersion
            if ((!EsValido(prmIndice) && prmIndice != atrLongitud))
            {
                return false;
            }
            #endregion
            #region Conjunto de Metodos que garantizan la creacion e insercion del item en la coleccion
            #region Creacion del nodo con su respectivo item para insertar en la coleccion
            clsNodoSimpleEnlazado<Tipo> varNodoNuevo = new clsNodoSimpleEnlazado<Tipo>(prmItem);
            #endregion
            #region Metodo para agregar el primer elemento a la coleccion
            if (atrLongitud == 0)
            {
                atrNodoPrimero = varNodoNuevo;
                atrNodoUltimo = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            #endregion
            #region Metodo para insertar en la primera posicion de la coleccion
            else if (prmIndice == 0)
            {
                varNodoNuevo.ponerSiguiente(atrNodoPrimero);
                atrNodoPrimero = varNodoNuevo;
                return true;
            }
            #endregion
            #region Metodo para insertar en la ultima posicion de la coleecion
            else if (prmIndice == atrLongitud)
            {
                atrNodoUltimo.ponerSiguiente(varNodoNuevo);
                atrLongitud++;
                return true;
            }
            #endregion
            #region Metodo para insertar un elemento en cualquier indice de la coleccion
            else
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 1; varIndice < prmIndice; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoNuevo.ponerSiguiente(varNodoActual.darSiguiente());
                varNodoActual.ponerSiguiente(varNodoNuevo);
                atrLongitud++;
                return true;
            }
            #endregion
            #endregion
        }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (RecuperarEn(prmIndice, ref prmItem))
            {
            clsNodoSimpleEnlazado<Tipo> varNodoAEliminar;
            clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
            for (int varIndice = 0; varIndice < prmIndice-1; varIndice++)
                varNodoActual = varNodoActual.darSiguiente();
            varNodoAEliminar = varNodoActual.darSiguiente();
            varNodoActual.ponerSiguiente(varNodoAEliminar.darSiguiente());
            return true;
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
                clsNodoSimpleEnlazado<Tipo> varNodoActual = new clsNodoSimpleEnlazado<Tipo>(prmItem);
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
