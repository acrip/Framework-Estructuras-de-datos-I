using System;
namespace Servicios.Colecciones.TADS
{
    public class clsTadVectorial<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        protected Tipo[] atrVectorDeItems;
        private int atrCapacidad;
        private bool atrCapacidadFlexible;
        private int atrFactorCrecimiento;
        #endregion
        #region Metodos
        #region Constructores Base TadVectorial
        //UUPS: Optimizar los constructores para evitar código redundante
        public clsTadVectorial()
        {
            this.atrCapacidad = 100; //int.MaxValue/8;
            this.atrVectorDeItems = new Tipo[atrCapacidad];
            this.atrCapacidadFlexible = false;
            this.atrFactorCrecimiento = 0;
        }
        public clsTadVectorial(int prmCapacidad)
        {
            this.atrCapacidad = prmCapacidad;
            if (prmCapacidad <= 0)
            {
                this.atrCapacidad = 100;
                this.atrVectorDeItems = new Tipo[atrCapacidad];
                this.atrFactorCrecimiento = 0;
                this.atrCapacidadFlexible = false;
            }else
            {
                if (prmCapacidad >= int.MaxValue/16)
                {
                    this.atrCapacidad = 0;
                    this.atrFactorCrecimiento = 1;
                    this.atrCapacidadFlexible = true;
                }
                else
                {
                    this.atrVectorDeItems = new Tipo[atrCapacidad];
                    this.atrCapacidadFlexible = false;
                    this.atrFactorCrecimiento = 0;
                }
            }
        }
        public clsTadVectorial(bool prmCapacidadFlexible)
        {
            this.atrCapacidad = 100;
            this.atrVectorDeItems = new Tipo[atrCapacidad];
            this.atrCapacidadFlexible = prmCapacidadFlexible;
            if (atrCapacidadFlexible == true) atrFactorCrecimiento = 1;
            if (atrCapacidadFlexible == false) atrFactorCrecimiento = 0;
        }
        public clsTadVectorial(int prmCapacidad, int prmFactorDeCrecimiento)//:this(prmCapacidad)
        {
            this.atrCapacidad = prmCapacidad;
            if (prmCapacidad < 0)
            {
                this.atrCapacidad = 100;
                this.atrVectorDeItems = new Tipo[atrCapacidad];
                this.atrFactorCrecimiento = prmFactorDeCrecimiento;
                this.atrCapacidadFlexible = true;
            }
            else
            {
                if (prmCapacidad >= int.MaxValue / 16)
                {
                    this.atrCapacidad = 0;
                    this.atrFactorCrecimiento = prmFactorDeCrecimiento;
                    this.atrCapacidadFlexible = true;
                }
                else
                {
                    this.atrVectorDeItems = new Tipo[atrCapacidad];
                    this.atrCapacidadFlexible = true;
                    this.atrFactorCrecimiento = prmFactorDeCrecimiento;
                }
            }
            if (atrFactorCrecimiento < 0) atrFactorCrecimiento = 1;
        }
        #endregion
        #region Accesores
        public Tipo[] darVectorItems()
        {
            return this.atrVectorDeItems;
        }
        public int darCapacidad()
        {
            return this.atrCapacidad;
        }
        public bool darCapacidadFlexible()
        {
            return this.atrCapacidadFlexible;
        }
        public int darFactorDeCrecimiento()
        {
            return this.atrFactorCrecimiento;
        }
        #endregion
        #region Metodos Auxiliares
        public bool EstaLlena()
        {
            return atrLongitud == atrCapacidad;
        }
        public bool DesplazarItems(bool prmHaciaDerecha, int prmIndice)
        {
            if(EstaLlena() && prmHaciaDerecha && atrCapacidadFlexible)
            {
                Tipo[] varVectroAuxiliar = new Tipo[atrCapacidad + atrFactorCrecimiento];
                int varIndiceAux = 0;
                for (int varIndiceVec = 0; varIndiceVec < atrCapacidad; varIndiceVec++)
                {
                    if (varIndiceVec == prmIndice) varIndiceAux++;
                    varVectroAuxiliar[varIndiceAux] = atrVectorDeItems[varIndiceVec];
                    varIndiceAux++;
                }
                atrCapacidad += atrFactorCrecimiento;
                atrVectorDeItems = varVectroAuxiliar;
                return true;

            }
            if (!EstaLlena() && prmHaciaDerecha)
            {
                for (int varPosicion = atrLongitud - 1; varPosicion >= prmIndice; varPosicion--)
                    atrVectorDeItems[varPosicion + 1] = atrVectorDeItems[varPosicion];
                return true;
            }

            if (!prmHaciaDerecha)
            {
                for (int varPosicion = prmIndice; varPosicion < atrLongitud; varPosicion++)
                {
                    if(varPosicion + 1 == atrLongitud)
                        return true;
                    atrVectorDeItems[varPosicion] = atrVectorDeItems[varPosicion + 1];
                }
            return true;
            }
            return false;
        }
        #endregion
        #region CRUDs - Query
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            if (EsValido(prmIndice) || prmIndice == atrLongitud)
            {
                if (DesplazarItems(true, prmIndice))
                {
                    atrVectorDeItems[prmIndice] = prmItem;
                    atrLongitud ++;
                    return true;
                }
            }
            return false;
        }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            if(RecuperarEn(prmIndice, ref prmItem))
            {
                DesplazarItems(false, prmIndice);
                atrLongitud--;
                return true;
            }
            return false;
            }
        protected override bool ModificarEn(int prmIndice, Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                atrVectorDeItems[prmIndice] = prmItem;
                return true;
            }
            return false;
        }
        protected override bool RecuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                prmItem = atrVectorDeItems[prmIndice];
                return true;
            }
            return false;
        }
        #endregion
        #region Metodo auxiliar que permite ordenar tanto ascendente como descendente
        private int compare(Tipo objeto1, Tipo objeto2, bool prmOrdenarPorDescendente)
        {
            if (prmOrdenarPorDescendente)
            {
                return -1 * objeto1.CompareTo(objeto2);
            }
            return objeto1.CompareTo(objeto2);

        }
        #endregion
        #region Métodos ordenamiento
        protected override void MetodoBurbujaSimple(bool prmOrdenarPorDescendente)
        {
            int varPosExterior, varPosInterior;
            Tipo varElementoTemporal;
            for (varPosExterior = 0; varPosExterior < atrLongitud - 1; varPosExterior++)
            {
                
                for (varPosInterior = 0; varPosInterior < atrLongitud - varPosExterior - 1; varPosInterior++)
                {
                    if (atrVectorDeItems[varPosInterior].CompareTo(atrVectorDeItems[varPosInterior + 1]) > 0)
                    {
                        varElementoTemporal = atrVectorDeItems[varPosInterior];
                        atrVectorDeItems[varPosInterior] = atrVectorDeItems[varPosInterior + 1];
                        atrVectorDeItems[varPosInterior + 1] = varElementoTemporal;
                        atrNumeroIntercambios++;
                    }
                    atrNumeroComparaciones++;
                }
            }
        }
        protected override void MetodoBurbujaMejorado(bool prmOrdenarPorDescendente)
        {
            int varPosExterior = 1, varPosInterior;
            Tipo varElementoTemporal;
            bool varHuboIntercambio = true;
            while ((varPosExterior < atrVectorDeItems.Length) && (varHuboIntercambio))
            {
                varPosExterior = varPosExterior + 1;
                varHuboIntercambio = false;
                for (varPosInterior = 0; varPosInterior < atrVectorDeItems.Length - varPosExterior; varPosInterior++)
                {
                    if (atrVectorDeItems[varPosInterior].CompareTo(atrVectorDeItems[varPosInterior + 1]) > 0)
                    {
                        varElementoTemporal = atrVectorDeItems[varPosInterior];
                        atrVectorDeItems[varPosInterior] = atrVectorDeItems[varPosInterior + 1];
                        atrVectorDeItems[varPosInterior + 1] = varElementoTemporal;
                        varHuboIntercambio = true;
                    }
                }
            }
        }
        protected override void MetodoBurbujaBiDireccional(bool prmOrdenarPorDescendente)
        {
            bool varHuboIntercambios = false;
            int varPosicionIzquierda = 0;
            int varPosicionDerecha = atrLongitud - 1;
            int variableDeOrdenamiento = 0; 
            Tipo varElementoTemporal;
            do
            {
                for (int varPosicionActual = varPosicionIzquierda; varPosicionActual < varPosicionDerecha; varPosicionActual++)
                {
                    variableDeOrdenamiento = compare(atrVectorDeItems[varPosicionActual], atrVectorDeItems[varPosicionActual + 1], prmOrdenarPorDescendente);
                    if (variableDeOrdenamiento > 0)
                    {
                        varElementoTemporal = atrVectorDeItems[varPosicionActual];
                        atrVectorDeItems[varPosicionActual] = atrVectorDeItems[varPosicionActual + 1];
                        atrVectorDeItems[varPosicionActual + 1] = varElementoTemporal;
                        varHuboIntercambios = true;
                        atrNumeroIntercambios++;
                    }
                    atrNumeroComparaciones++;
                }
                if (varHuboIntercambios == false) break;
                varHuboIntercambios = false;
                for (int varPosicionActual = varPosicionDerecha; varPosicionActual > varPosicionIzquierda; varPosicionActual--)
                {
                    variableDeOrdenamiento = compare(atrVectorDeItems[varPosicionActual], atrVectorDeItems[varPosicionActual - 1], prmOrdenarPorDescendente);
                    if (variableDeOrdenamiento < 0)
                    {
                        varElementoTemporal = atrVectorDeItems[varPosicionActual];
                        atrVectorDeItems[varPosicionActual] = atrVectorDeItems[varPosicionActual - 1];
                        atrVectorDeItems[varPosicionActual - 1] = varElementoTemporal;
                        varHuboIntercambios = true;
                        atrNumeroIntercambios++;
                    }
                    atrNumeroComparaciones++;
                }
                varPosicionIzquierda++;
                varPosicionDerecha--;
            } while (varHuboIntercambios == true);
        }
        protected override void MetodoInsercion(bool prmOrdenarPorDescendente)
        {
            int varPosExterior, varPosInterior;
            Tipo varElementoInsertado;
            for (varPosExterior = 1; varPosExterior < atrVectorDeItems.Length; varPosExterior++)
            {
                varElementoInsertado = atrVectorDeItems[varPosExterior];
                varPosInterior = varPosExterior - 1;
                while ((varPosInterior >= 0) && (atrVectorDeItems[varPosInterior].CompareTo(varElementoInsertado) != 0) && (atrVectorDeItems[varPosInterior].CompareTo(varElementoInsertado) > 0))
                {
                    atrVectorDeItems[varPosInterior + 1] = atrVectorDeItems[varPosInterior];
                    varPosInterior = varPosInterior - 1;
                }
                atrVectorDeItems[varPosInterior + 1] = varElementoInsertado;
            }
        }
        protected override void MetodoSeleccion(bool prmOrdenarPorDescendente)
        {
            int varPosExterior, varPosInterior, varPosDelMinimo;
            Tipo varElementoTemporal;
            for (varPosExterior = 0; varPosExterior < atrVectorDeItems.Length - 1; varPosExterior++)
            {
                varPosDelMinimo = varPosExterior;
                for (varPosInterior = varPosExterior + 1; varPosInterior < atrVectorDeItems.Length - 1; varPosInterior++)
                {
                    if (atrVectorDeItems[varPosInterior].CompareTo(atrVectorDeItems[varPosDelMinimo]) < 0)
                    {
                        varPosDelMinimo = varPosInterior;
                    }
                }
                if (varPosDelMinimo != varPosExterior)
                {
                    varElementoTemporal = atrVectorDeItems[varPosDelMinimo];
                    atrVectorDeItems[varPosDelMinimo] = atrVectorDeItems[varPosExterior];
                    atrVectorDeItems[varPosExterior] = varElementoTemporal;
                }
            }
        }
        protected override void MetodoQuickSort(bool prmOrdenarPorDescendente, int prmIndiceInicial, int prmIndiceFinal)
        {
            /*
            int varPosIzquierdo, varPosDerecho;
            Tipo varElementoTemporal, varElementoPivote;
            varElementoPivote = atrVectorDeItems[(prmPosDelPrimero + prmPosDelUltimo) / 2];
            varPosIzquierdo = prmPosDelPrimero;
            varPosDerecho = prmPosDelUltimo;
            while (varPosIzquierdo <= varPosDerecho && (prmPosDelUltimo - prmPosDelPrimero) > 0)
            {
                while (atrVectorDeItems[varPosIzquierdo].CompareTo(varElementoPivote) < 0)
                {
                    varPosIzquierdo = varPosIzquierdo + 1;
                }
                while (atrVectorDeItems[varPosDerecho].CompareTo(varElementoPivote) > 0)
                {
                    varPosDerecho = varPosDerecho - 1;
                }
                if (varPosIzquierdo <= varPosDerecho)
                {
                    varElementoTemporal = atrVectorDeItems[varPosIzquierdo];
                    atrVectorDeItems[varPosIzquierdo] = atrVectorDeItems[varPosDerecho];
                    atrVectorDeItems[varPosDerecho] = varElementoTemporal;
                    varPosIzquierdo++;
                    varPosDerecho--;
                }
            }
            if (prmPosDelPrimero < varPosDerecho)
            {
                MetodoQuickSort(ref atrVectorDeItems, prmPosDelPrimero, varPosDerecho);
            }
            if (varPosIzquierdo < prmPosDelUltimo)
            {
                MetodoQuickSort(ref atrVectorDeItems, varPosIzquierdo, prmPosDelUltimo);

            }
            */
        }

        #endregion
        #endregion
    }
}
