using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDSTabIndex
{
    class ControlesLista : IComparable<ControlesLista>
    {
        public string Nome;
        public string TabIndex;
        public string NomePai;
        public IComponent Componente;
        public IComponent ComponenteTabPage;
        public PropertyDescriptorCollection Propriedade;

        #region IComparable<ControleProperty> Members

        public int CompareTo(ControlesLista other)
        {
            return TabIndex.CompareTo(other.TabIndex);
        }

        #endregion
    }
}
