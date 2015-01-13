using System;
using System.Collections.Generic;
using System.Text;
using FCatalog = FISCA.Permission.Catalog;
using FFeatureItem = FISCA.Permission.FeatureItem;
using FRibbonFeature = FISCA.Permission.RibbonFeature;
using FReportFeature = FISCA.Permission.ReportFeature;
using FDetailItemFeature = FISCA.Permission.DetailItemFeature;
using FCustomeFeature = FISCA.Permission.CustomeFeature;

namespace Framework.Security
{
    public class Catalog
    {
        public Catalog(FCatalog fcatalog)
        {
            FCatalog = fcatalog;
            SubCatalogs = new CatalogCollection(FCatalog);
            _features = new List<FeatureItem>();
        }

        public CatalogCollection SubCatalogs { get; set; }

        private List<FeatureItem> _features;
        public IList<FeatureItem> Features { get { return _features.AsReadOnly(); } }

        public void Add(FeatureItem feature)
        {
            _features.Add(feature);

            if (feature is CustomeFeature)
                throw new ArgumentException("不支援，請改用 FISCA.Permission.CustomeFeature。");
            else if (feature is DetailItemFeature)
                FCatalog.Add(new FDetailItemFeature(feature.Code, feature.Title));
            else if (feature is RibbonFeature)
                FCatalog.Add(new FRibbonFeature(feature.Code, feature.Title));
            else if (feature is ReportFeature)
                FCatalog.Add(new FReportFeature(feature.Code, feature.Title));
            else
                throw new ArgumentException("不支援指定的項目：" + feature.GetType().FullName);
        }

        public Catalog this[string name]
        {
            get
            {
                return SubCatalogs[name];
            }
        }

        private FCatalog FCatalog { get; set; }
    }
}
