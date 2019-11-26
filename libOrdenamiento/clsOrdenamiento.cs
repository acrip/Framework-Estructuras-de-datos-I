using System;
namespace libOrdenamiento
{
    public partial class clsOrdenamiento
    {
        #region Atributos para el ordenamiento: TAD
        private bool atrEstaOrdenadaAscendente;
        private bool atrEstaOrdenadaDescendente;
        private long atrNumeroComparaciones;
        private long atrNumeroIntercambios;
        private long atrNumeroInserciones;
        private long atrNumeroLlamadosRecursivos;
        #endregion
        #region Métodos accesores para el ordenamiento: TAD
        public bool darEstaOrdenadaAscendente()
        {
            //Mensajero(“Retornar el valor del atributo << Está Ordenada Ascendente >>”);
            return atrEstaOrdenadaAscendente;
        }

        public bool darEstaOrdenadaDescendente()
        {
            return atrEstaOrdenadaDescendente;
            //Mensajero(“Retornar el valor del atributo <<Está Ordenada Descendente>>”);
        }

        public long darNumeroComparaciones()
        {
            //Mensajero(“Retornar el valor del atributo << Número de Comparaciones >>”);
            return atrNumeroComparaciones;
        }

        public long darNumeroIntercambios()
        {
            //Mensajero(“Retornar el valor del atributo <<Número de Intercambios>>”);
            return atrNumeroIntercambios;
        }

        public long darNumeroInserciones()
        {
            // Mensajero(“Retornar el valor del atributo <<Número de Inserciones>>”);
            return atrNumeroInserciones;
        }

        public long darNumeroLlamadosRecursivos()
        {
            //Mensajero(“Retornar el valor del atributo <<Número de Llamados Recursivos>>”);
            return atrNumeroLlamadosRecursivos;
        }
        #endregion
        #region Métodos auxiliares para el ordenamiento: TAD
        public bool AjustarOrdenColeccion(string prmCriterio)
        {
            //string varMetodoEnEjecucion = "Ajustar el orden";
            switch (prmCriterio)
            {
                case "Ascendente":
                    atrEstaOrdenadaAscendente = true;
                    atrEstaOrdenadaDescendente = false;
                    //Mensajero(verdadero, varMetodoEnEjecucion, “El orden de la colección quedó ajustado como ascendente”);
                    return true;
                case "Descendente":
                    atrEstaOrdenadaAscendente = false;
                    atrEstaOrdenadaDescendente = true;
                    //Mensajero(verdadero, varMetodoEnEjecucion, “El orden de la colección quedó ajustado como descendente”);
                    return true;
                case "Aleatorio":
                    atrEstaOrdenadaAscendente = false;
                    atrEstaOrdenadaDescendente = false;
                    //Mensajero(verdadero, varMetodoEnEjecucion, “El orden de la colección quedó ajustado como aleatorio”);
                    return true;
                case "Constante":
                    atrEstaOrdenadaAscendente = true;
                    atrEstaOrdenadaDescendente = true;
                    //Mensajero(verdadero, varMetodoEnEjecucion, “El orden de la colección quedó ajustado como constante”);
                    return true;
                default:
                    //Mensajero(falso, varMetodoEnEjecucion, “El orden de la colección no se ajustó porque el criterio proporcionado no es válido.”);
                    return false;
            }
        }
        #endregion
        #region Métodos consultores para el ordenamiento: TAD
        protected bool DebeOrdenar(bool prmOrdenarPorDescendente)
        {
            //string varMetodoEnEjecucion = "Determinar si debe ordenarse la colección";
            switch (prmOrdenarPorDescendente)
            {
                case true:
                    if (atrEstaOrdenadaDescendente)
                    {
                        //Mensajero (verdadero, varMetodoEnEjecucion, "\r" + "-No debe ordenar, la colección ya está ordenada como descendente.");
                        return false;
                    }
                    else
                    {
                        //Mensajero (verdadero, varMetodoEnEjecucion, "\r" + "-Es necesario ordenar la colección como descendente.");
                        return true;
                    }
                case false:
                    if (atrEstaOrdenadaAscendente)
                    {
                        //Mensajero (verdadero, varMetodoEnEjecucion, "\r" + "-No debe ordenar, la colección ya está ordenada como ascendente.");
                        return false;
                    }
                    else
                    {
                        //Mensajero (verdadero, varMetodoEnEjecucion, "\r" + "-Es necesario ordenar la colección como ascendente.");
                        return true;
                    }
                default:
                    return false;
            }
        }
        #endregion
        #region Métodos de ordenamiento: TAD
        protected virtual void MetodoBurbujaSimple(bool prmOrdenarPorDescendente)
        {
            //Mensajero (falso, “Ordenar colección por el método de burbuja simple”, "El método aún no se ha implementado.");
        }
        protected virtual void MetodoBurbujaMejorado(bool prmOrdenarPorDescendente)
        {
            //Mensajero (falso, “Ordenar colección por el método de burbuja mejorado”, "El método aún no se ha implementado.");
        }
        protected virtual void MetodoBurbujaBiDireccional(bool prmOrdenarPorDescendente)
        {
            //Mensajero (falso, “Ordenar colección por el método de burbuja bi-direccional”, "El método aún no se ha implementado.");        }
        protected virtual void MetodoInsercion(bool prmOrdenarPorDescendente)
        {
            //Mensajero (falso, “Ordenar colección por el método de inserción”, "El método aún no se ha implementado.");
        }
        protected virtual void MetodoSeleccion(bool prmOrdenarPorDescendente)
        {
            //Mensajero (falso, “Ordenar colección por el método de selección”, "El método aún no se ha implementado.");
        }
        protected virtual void MetodoQuickSort(bool prmOrdenarPorDescendente, int prmIndiceInicial, int prmIndiceInicial)
        {
            //Mensajero(falso, “Ordenar colección por el método de quick sort”, "El método aún no se ha implementado.");

        }
        #endregion
        #region Método marco para la invocación del ordenamiento: TAD
        protected bool Ordenar(string prmMetodoOrdenamiento, bool prmOrdenarPorDescendente)
        {
            string varMetodoEnEjecucion = "de ordenamiento por " + prmMetodoOrdenamiento;
            if (!EstaVacia())
            {
                if (DebeOrdenar(prmOrdenarPorDescendente))
                {
                    try
                    {
                        switch (prmMetodoOrdenamiento)
                        {
                            case "Burbuja Simple":
                                MetodoBurbujaSimple(prmOrdenarPorDescendente);
                                break;
                            case "Burbuja Mejorado":
                                MetodoBurbujaMejorado(prmOrdenarPorDescendente);
                                break;
                            case "Burbuja BiDireccional":
                                MetodoBurbujaBiDireccional(prmOrdenarPorDescendente);
                                break;
                            case "Insercion":
                                MetodoInsercion(prmOrdenarPorDescendente);
                                break;
                            case "Seleccion":
                                MetodoSeleccion(prmOrdenarPorDescendente);
                                break;
                            case "QuickSort":
                                MetodoQuickSort(prmOrdenarPorDescendente, 0, atrLongitud-1);
                                break;
                            default:
                                //Mensajero (falso, varMetodoEnEjecucion, "\r" + "-El método de ordenamiento indicado aún no está implementado.");
                                return false;
                        }
                        if (prmOrdenarPorDescendente) AjustarOrdenColeccion("Descendente");
                        else AjustarOrdenColeccion("Ascendente");

                        //atrMensajeUltimoMetodo += "\r" + "-El Método de Ordenamiento " + prmMetodoOrdenamiento + " arrojó los siguientes datos:";
                        //atrMensajeUltimoMetodo += "\r" + " -Número de Elementos:" + atrLongitud + ".";
                        //atrMensajeUltimoMetodo += "\r" + " -Número de Comparaciones:" + atrNumeroComparaciones + ".";
                        //atrMensajeUltimoMetodo += "\r" + " -Número de Intercambios:" + atrNumeroIntercambios + ".";
                        //atrMensajeUltimoMetodo += "\r" + " -Número de Inserciones:" + atrNumeroInserciones + ".";
                        //atrMensajeUltimoMetodo += "\r" + " -Número de Llamados Recursivos:" + atrNumeroLlamadosRecursivos + ".";
                        //Mensajero(verdadero, varMetodoEnEjecucion, atrMensajeUltimoMetodo);
                        return true;
                    }
                    catch (Exception)
                    {
                        //Mensajero(falso, varMetodoEnEjecucion, Excepción.prpmensaje);
                        return false;
                        throw;
                    }
                }
                else
                {
                    //Mensajero(falso, varMetodoEnEjecucion, atrMensajeUltimoMetodo);
                    return false;
                }
            }
            else
            {
                //Mensajero(falso, varMetodoEnEjecucion, atrMensajeUltimoMetodo);
                return false;
            }
        }
        #endregion
        #region Métodos fachada para el ordenamiento
        public bool OrdenarBurbujaSimple(bool prmOrdenarPorDescendente)
        {
            return Ordenar("Burbuja Simple", prmOrdenarPorDescendente);        }
        public bool OrdenarBurbujaMejorado(bool prmOrdenarPorDescendente)
        {
            return Ordenar("Burbuja Mejorado", prmOrdenarPorDescendente);        }
        public bool OrdenarBurbujaBIDIreccional(bool prmOrdenarPorDescendente)
        {
            return Ordenar("Burbuja BiDireccional", prmOrdenarPorDescendente);        }
        public bool OrdenarInsercion(bool prmOrdenarPorDescendente)
        {
            return Ordenar("Insercion", prmOrdenarPorDescendente);        }
        public bool OrdenarSeleccion(bool prmOrdenarPorDescendente)
        {
            return Ordenar("Seleccion", prmOrdenarPorDescendente);        }
        public bool OrdenarQuickSort(bool prmOrdenarPorDescendente)
        {
            return Ordenar("QuickSort", prmOrdenarPorDescendente);        }
        #endregion
    }
}

