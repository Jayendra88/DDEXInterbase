using System;
using Microsoft.VisualStudio.Data;
using Microsoft.VisualStudio.Data.AdoDotNet;

namespace InterbaseSql.VisualStudio.DataTools
{
    internal class IbDataConnectionSupport : AdoDotNetConnectionSupport
    {
        #region · Constructors ·

        public IbDataConnectionSupport() 
            : base("InterbaseSql.Data.InterbaseClient")
        {
            System.Diagnostics.Trace.WriteLine("IbDataConnectionSupport()");
        }

        #endregion

        #region · Protected Methods ·

        protected override DataSourceInformation CreateDataSourceInformation()
        {
            System.Diagnostics.Trace.WriteLine("IbDataConnectionSupport::CreateDataSourceInformation()");

            return new IbDataSourceInformation(base.Site as DataConnection);
        }

        protected override DataObjectIdentifierConverter CreateObjectIdentifierConverter()
        {
            return new IbDataObjectIdentifierConverter(base.Site as DataConnection);
        }

        protected override object GetServiceImpl(Type serviceType)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("IbDataConnectionSupport::GetServiceImpl({0})", serviceType.FullName));

            if (serviceType == typeof(DataViewSupport))
            {
                return new IbDataViewSupport();
            }
            else if (serviceType == typeof(DataObjectSupport))
            {
                return new IbDataObjectSupport();
            }
            else if (serviceType == typeof(DataObjectIdentifierResolver))
            {
                return new IbDataObjectIdentifierResolver(base.Site as DataConnection);
            }

            return base.GetServiceImpl(serviceType);
        }

        #endregion
    }
}
