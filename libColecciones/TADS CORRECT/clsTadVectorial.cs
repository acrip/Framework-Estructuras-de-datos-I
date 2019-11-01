using System;

namespace Servicios.Colecciones.TADS
{
    public class clsTadVectorial<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {

        #region Atributos
        protected Tipo[] atrVectorDeItems; // = new Tipo[int.MaxValue / 8];
        private long atrCapacidad; // = int.MaxValue/8;
        private bool atrCapacidadFlexible = true;
        private long atrFactorCrecimiento = 1;
        #endregion  
        #region Metodos
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
                atrCapacidad += atrFactorCrecimiento;
                int varIndice2 = 0;
                for (int varIndice1 = 0; varIndice1 < prmIndice; varIndice1++)
                {
                    if (varIndice1 != prmIndice)
                    {
                        varVectroAuxiliar[varIndice1] = atrVectorDeItems[varIndice2];
                        varIndice2++;
                    }
                    else
                        varIndice2--;
                }
                atrVectorDeItems = varVectroAuxiliar; 
            }

            if (!EstaLlena() && prmHaciaDerecha)
                for (int varPosicion = atrLongitud - 1; varPosicion >= prmIndice; varPosicion--)
                    atrVectorDeItems[varPosicion + 1] = atrVectorDeItems[varPosicion];

            if (!prmHaciaDerecha)
                for (int varPosicion = prmIndice; varPosicion < atrLongitud; varPosicion++)
                    atrVectorDeItems[varPosicion] = atrVectorDeItems[varPosicion + 1];
            return true;
        }
        #endregion
        #region CRUDs
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            if (EsValido(prmIndice))
                if (DesplazarItems(true, prmIndice))
                {
                    atrVectorDeItems[prmIndice] = prmItem;
                    atrLongitud += 1;
                    return true;
                }
            return false;
        }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            /*
            if (EsValido(prmIndice))
            {
                prmItem = atrVectorDeItems[prmIndice];
                DesplazarItems(false, prmIndice);
                atrLongitud--;
                return true;
            }
            return false;
            */
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
        #endregion
    }
}
 //                   Tipo[] varVectorAuxiliar = new Tipo[atrCapacidad + atrFactorCrecimiento];
 //                   varVectorAuxiliar[prmIndice] = prmItem;
 //                   #region Algoritmo Version Obsoleta
 //                   for (int varIndice = 0; varIndice < prmIndice; varIndice++)
 //                       varVectorAuxiliar[varIndice] = atrVectorDeItems[varIndice];
 //                   for (int varIndice = prmIndice + 1; varIndice < atrLongitud; varIndice++)
 //                       varVectorAuxiliar[varIndice] = atrVectorDeItems[varIndice];
 //                   #endregion
 //                   #region Algoritmo Version 2
 //                   int varIndice2 = 0;
 //                   for (int varIndice1 = 0; varIndice1< prmIndice; varIndice1++)
 //                   {
 //                       if(varIndice1 != prmIndice)
 //                       {
 //                           varVectorAuxiliar[varIndice1] = atrVectorDeItems[varIndice2];
 //                           varIndice2++;
 //                       }
 //                       else
 //                       {
 //                           varIndice2--;
 //                       }
 //                   }
 //                   #endregion
 //
 //                   atrCapacidad += atrFactorCrecimiento;
 //                   atrLongitud += 1;
 //                   atrVectorDeItems = varVectorAuxiliar
 //                       for (int varIndice = atrLongitud - 1; varIndice >= prmIndice; varIndice--)
 //                           atrVectorDeItems[varIndice + 1] = atrVectorDeItems[varIndice];
 //                       atrVectorDeItems[prmIndice] = prmItem;
 //
 //               }
 //               atrLongitud += 1;
 //           return false;
 //       }
