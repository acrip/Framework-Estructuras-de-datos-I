using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;


namespace Servicios.Colecciones.Vectoriales
{
    public class clsListaVector<Tipo> : clsTadVectorial<Tipo >, iLista<Tipo> where Tipo : IComparable
    {
        #region Constructores
        public clsListaVector(): base(){}
        public clsListaVector(int prmCapacidad) : base(prmCapacidad){}
        public clsListaVector(bool prmCapacidadFlexible) : base(prmCapacidadFlexible){ }
        public clsListaVector(int prmCapacidad, int prmFactorDeCrecimiento): base(prmCapacidad, prmFactorDeCrecimiento){}
        #endregion
        #region Metodos CRUDs-Query
        public bool Agregar(Tipo prmItem){return InsertarEn(atrLongitud, prmItem);}
        public bool Insertar(int prmIndice, Tipo prmItem) {return InsertarEn(prmIndice, prmItem);}
        public bool Modificar(int prmIndice, Tipo prmItem) { return false; }
        public bool Remover(int prmIndice, ref Tipo prmItem) { return ExtraerEn(prmIndice,ref prmItem);}
        public bool Recuperar(int prmIndice, ref Tipo prmItem) { return false; }
        #endregion
    }
}
