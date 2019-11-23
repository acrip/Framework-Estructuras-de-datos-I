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
            //this.atrCapacidadFlexible == true ? this.atrFactorCrecimiento = 1 : atrFactorCrecimiento = 0;
            if (atrCapacidadFlexible == true) atrFactorCrecimiento = 1;
            if (atrCapacidadFlexible == false) atrFactorCrecimiento = 0;
        }
        public clsTadVectorial(int prmCapacidad, int prmFactorDeCrecimiento)
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
        public bool DesplazarItems1(bool prmHaciaDerecha, int prmIndice)
        {
            if(EstaLlena() && prmHaciaDerecha && atrCapacidadFlexible)
            {
                Tipo[] varVectroAuxiliar = new Tipo[atrCapacidad + atrFactorCrecimiento];
                atrCapacidad += atrFactorCrecimiento;
                int varIndice2 = 0;
                for (int varIndice1 = 0; varIndice1 < atrCapacidad; varIndice1++)
                {
                    varVectroAuxiliar[varIndice1] = atrVectorDeItems[varIndice2];
                    if (varIndice1 != prmIndice)
                    {
                        varIndice2++;
                    }
                    else
                        continue;
                }
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
        #region CRUDs




        public bool DesplazarItems(bool prmHaciaDerecha, int prmIndice)
        {
            if (EstaLlena() && prmHaciaDerecha && atrCapacidadFlexible)
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

        










        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //
        //protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        //{
        //    if (EsValido(prmIndice))
        //    {
        //        DesplazarItems(true, prmIndice);
        //        return true;
        //    }
        //

          //  if(EstaVacia() && atrCapacidad != 0)
          //  {
          //      atrVectorDeItems[0] = prmItem;
          //      atrLongitud++;
          //      return true;
          //  }
          //
          //  if (EsValido(prmIndice) || prmIndice == atrLongitud)
          //      if (DesplazarItems(true, prmIndice))
          //      {
          //          atrVectorDeItems[prmIndice] = prmItem;
          //          atrLongitud++;
          //          return true;
          //      }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                prmItem = atrVectorDeItems[prmIndice];
                DesplazarItems(false, prmIndice);
                atrLongitud--;
                return true;
            }
            return false;
            /*
            if(RecuperarEn(prmIndice, ref prmItem))
            {
                DesplazarItems(false, prmIndice);
                atrLongitud--;
                return true;
            }
            return false;
            */
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
