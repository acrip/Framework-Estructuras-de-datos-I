using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;


namespace Servicios.Colecciones.Vectoriales
{
    class clsListaVector<Tipo> : clsTadVectorial<Tipo >, iLista<Tipo> where Tipo : IComparable
    {
        #region CRUDs
        public bool Agregar(Tipo prmItem){return InsertarEn(atrLongitud, prmItem);}
        public bool Insertar(Tipo prmItem, int prmIndice){return false;}
        public bool Remover(ref Tipo prmItem, int prmIndice) { return false; }
        #endregion
    }
}
