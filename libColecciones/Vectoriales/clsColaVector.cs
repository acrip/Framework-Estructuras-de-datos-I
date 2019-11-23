﻿using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;
namespace Servicios.Colecciones.Vectoriales
{
    public class clsColaVector<Tipo> : clsTadVectorial<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        #region Constructores
        public clsColaVector(): base(){ }
        public clsColaVector(int prmCapacidad) : base(prmCapacidad){ }
        public clsColaVector(bool prmCapacidadFlexible) : base(prmCapacidadFlexible){ }
        public clsColaVector(int prmCapacidad, int prmFactorDeCrecimiento): base(prmCapacidad, prmFactorDeCrecimiento){ }
        #endregion
        #region Metodos CRUDS Query
        public bool Encolar(Tipo prmItem) { return InsertarEn(atrLongitud, prmItem);}
        public bool Desencolar(ref Tipo prmItem) { return ExtraerEn(0, ref prmItem); }
        public bool Revisar(ref Tipo prmItem) { return RecuperarEn(0, ref  prmItem); }
        #endregion
    }
}
