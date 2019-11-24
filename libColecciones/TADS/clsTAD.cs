﻿using System;
namespace Servicios.Colecciones.TADS
{
    public class clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        protected int atrLongitud = 0;
        #endregion
        #region Metodos
        #region Mñetodos Auxiliares
        public bool EstaVacia()
        {
            return atrLongitud == 0;
        }
        public int darLongitud()
        {
            return this.atrLongitud;
        }
        protected bool EsValido(int prmIndice)
        {
            return prmIndice >= 0 && prmIndice < atrLongitud;
        }
        #endregion
        #region CRUDS-Query
        protected virtual bool InsertarEn(int prmIndice, Tipo prmItem) { return false; }
        protected virtual bool ModificarEn(int prmIndice, Tipo prmItem) { return false; }
        protected virtual bool ExtraerEn(int prmIndice, ref Tipo prmItem) { return false; }
        protected virtual bool RecuperarEn(int prmIndice, ref Tipo prmItem) { return false; }
        public bool Encontrar(Tipo prmItem, ref int prmIndice) { return false; }
        public bool Existe(Tipo prmItem) { return false; }
        #endregion
        #endregion
    }
}
