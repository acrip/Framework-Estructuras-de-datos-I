using System;
namespace Servicios.Colecciones.Nodos
{
    public class clsNodo <Tipo> where Tipo:IComparable
    {
        #region Atributos
        private Tipo atrItem;
        #endregion
        #region Métodos
        #region Método Contructor
        public clsNodo(Tipo prmItem){atrItem = prmItem;}
        #endregion
        #region Métodos accesores y mutadores
        public Tipo darItem(){return atrItem;}             
        public void ponerItem(Tipo prmItem){atrItem = prmItem; }
        #endregion
        #endregion
    }
}
