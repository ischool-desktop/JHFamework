using System;
using System.Collections.Generic;
using System.Text;
using FCatalog = FISCA.Permission.Catalog;

namespace Framework.Security
{
    public class CatalogCollection : IEnumerable<KeyValuePair<string, Catalog>>
    {
        public CatalogCollection(FCatalog owner)
        {
            Owner = owner;
        }

        private FCatalog Owner { get; set; }

        private Dictionary<string, Catalog> Catalogs = new Dictionary<string, Catalog>();

        public Catalog this[string name]
        {
            get
            {
                if (!Catalogs.ContainsKey(name))
                    Catalogs.Add(name, new Catalog(Owner[name]));

                return Catalogs[name];
            }
        }

        public int Count { get { return Catalogs.Count; } }

        #region IEnumerable<KeyValuePair<string,Catalog>> 成員

        public IEnumerator<KeyValuePair<string, Catalog>> GetEnumerator()
        {
            return Catalogs.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成員

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Catalogs.GetEnumerator();
        }

        #endregion
    }
}
