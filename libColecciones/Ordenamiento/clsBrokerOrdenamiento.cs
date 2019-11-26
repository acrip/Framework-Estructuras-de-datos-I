using System;
namespace Servicios.Colecciones.Ordenamiento
{
    public class clsBrokerOrdenamiento<Tipo> where Tipo : IComparable
    {
        /// <summary>
        /// Esta fue la clase que compartio Siclos 
        /// Ni idea de donde va
        /// pero como lo veo parece ser la implemetacion de
        /// los metodos de ordenamiento en el TadVectorial
        /// 
        /// Tampoco se porque se llama BrokerOrdenamiento
        /// 
        /// Igual como son de vagos, esto nadie lo va a ver
        /// asi que valen verga todos pirobos .l.
        /// 
        /// </summary>
        protected int atrCapacidad;
        protected Tipo[] atrColeccion;
        //private int v;

        public clsBrokerOrdenamiento(int prmCapacidad, Tipo[] prmColeccion)
        {
            atrCapacidad = prmCapacidad;
            atrColeccion = prmColeccion;
        }

        //public clsBrokerOrdenamiento(int v)
        //{
            //this.v = v;
        //}

        public static void BurbujaSimple(Tipo[] prmColeccion)
        {
            int varPosExterior, varPosInterior;
            Tipo varElementoTemporal;
            for (varPosExterior = 1; varPosExterior < prmColeccion.Length - 1; varPosExterior++)
            {
                for (varPosInterior = 0; varPosInterior < prmColeccion.Length - varPosExterior - 1; varPosInterior++)
                {
                    if (prmColeccion[varPosInterior].CompareTo(prmColeccion[varPosInterior + 1]) > 0)
                    {
                        varElementoTemporal = prmColeccion[varPosInterior];
                        prmColeccion[varPosInterior] = prmColeccion[varPosInterior + 1];
                        prmColeccion[varPosInterior + 1] = varElementoTemporal;
                    }
                }
            }
        }
        public static void BurbujaMejorado(Tipo[] prmColeccion)
        {
            int varPosExterior = 1, varPosInterior;
            Tipo varElementoTemporal;
            Boolean varHuboIntercambio = true;
            while ((varPosExterior < prmColeccion.Length) && (varHuboIntercambio))
            {
                varPosExterior = varPosExterior + 1;
                varHuboIntercambio = false;
                for (varPosInterior = 0; varPosInterior < prmColeccion.Length - varPosExterior; varPosInterior++)
                {
                    if (prmColeccion[varPosInterior].CompareTo(prmColeccion[varPosInterior + 1]) > 0)
                    {
                        varElementoTemporal = prmColeccion[varPosInterior];
                        prmColeccion[varPosInterior] = prmColeccion[varPosInterior + 1];
                        prmColeccion[varPosInterior + 1] = varElementoTemporal;
                        varHuboIntercambio = true;
                    }
                }
            }
        }
        public static void BurbujaBiDireccional(Tipo[] prmColeccion)
        {
            Boolean varHuboIntercambios = false;
            int varPos;
            Tipo varElementoTemporal;
            do
            {
                for (varPos = 0; varPos < prmColeccion.Length; varPos++)
                {
                    if (prmColeccion[varPos].CompareTo(prmColeccion[varPos + 1]) > 0)
                    {
                        varElementoTemporal = prmColeccion[varPos];
                        prmColeccion[varPos] = prmColeccion[varPos + 1];
                        prmColeccion[varPos + 1] = varElementoTemporal;
                        varHuboIntercambios = true;
                    }
                }
                if (varHuboIntercambios == false)
                {
                    break;
                }
                varHuboIntercambios = false;
                for (varPos = prmColeccion.Length - 2; varPos < 0; varPos--)//ojo con el <
                {
                    if (prmColeccion[varPos].CompareTo(prmColeccion[varPos]) > 0)
                    {
                        varElementoTemporal = prmColeccion[varPos];
                        prmColeccion[varPos] = prmColeccion[varPos + 1];
                        prmColeccion[varPos + 1] = varElementoTemporal;
                        varHuboIntercambios = true;
                    }
                }
            } while (varHuboIntercambios == true);
        }
        public static void Insercion(Tipo[] prmColeccion)
        {
            int varPosExterior, varPosInterior;
            Tipo varElementoInsertado;
            for (varPosExterior = 1; varPosExterior < prmColeccion.Length; varPosExterior++)
            {
                varElementoInsertado = prmColeccion[varPosExterior];
                varPosInterior = varPosExterior - 1;
                while ((varPosInterior >= 0) && (prmColeccion[varPosInterior].CompareTo(varElementoInsertado) != 0) && (prmColeccion[varPosInterior].CompareTo(varElementoInsertado) > 0))
                {
                    prmColeccion[varPosInterior + 1] = prmColeccion[varPosInterior];
                    varPosInterior = varPosInterior - 1;
                }
                prmColeccion[varPosInterior + 1] = varElementoInsertado;
            }
        }
        public static void Seleccion(Tipo[] prmColeccion)
        {
            int varPosExterior, varPosInterior, varPosDelMinimo;
            Tipo varElementoTemporal;
            for (varPosExterior = 0; varPosExterior < prmColeccion.Length - 1; varPosExterior++)
            {
                varPosDelMinimo = varPosExterior;
                for (varPosInterior = varPosExterior + 1; varPosInterior < prmColeccion.Length - 1; varPosInterior++)
                {
                    if (prmColeccion[varPosInterior].CompareTo(prmColeccion[varPosDelMinimo]) < 0)
                    {
                        varPosDelMinimo = varPosInterior;
                    }
                }
                if (varPosDelMinimo != varPosExterior)
                {
                    varElementoTemporal = prmColeccion[varPosDelMinimo];
                    prmColeccion[varPosDelMinimo] = prmColeccion[varPosExterior];
                    prmColeccion[varPosExterior] = varElementoTemporal;
                }
            }
        }
        public static void MetodoQuickSort(ref Tipo[] prmColeccion, int prmPosDelPrimero, int prmPosDelUltimo)
        {
            int varPosIzquierdo, varPosDerecho;
            Tipo varElementoTemporal, varElementoPivote;
            varElementoPivote = prmColeccion[(prmPosDelPrimero + prmPosDelUltimo) / 2];
            varPosIzquierdo = prmPosDelPrimero;
            varPosDerecho = prmPosDelUltimo;
            while (varPosIzquierdo <= varPosDerecho && (prmPosDelUltimo - prmPosDelPrimero) > 0)
            {
                while (prmColeccion[varPosIzquierdo].CompareTo(varElementoPivote) < 0)
                {
                    varPosIzquierdo = varPosIzquierdo + 1;
                }
                while (prmColeccion[varPosDerecho].CompareTo(varElementoPivote) > 0)
                {
                    varPosDerecho = varPosDerecho - 1;
                }
                if (varPosIzquierdo <= varPosDerecho)
                {
                    varElementoTemporal = prmColeccion[varPosIzquierdo];
                    prmColeccion[varPosIzquierdo] = prmColeccion[varPosDerecho];
                    prmColeccion[varPosDerecho] = varElementoTemporal;
                    varPosIzquierdo++;
                    varPosDerecho--;
                }
            }
            if (prmPosDelPrimero < varPosDerecho)
            {
                MetodoQuickSort(ref prmColeccion, prmPosDelPrimero, varPosDerecho);
            }
            if (varPosIzquierdo < prmPosDelUltimo)
            {
                MetodoQuickSort(ref prmColeccion, varPosIzquierdo, prmPosDelUltimo);

            }

        }
    }
}
