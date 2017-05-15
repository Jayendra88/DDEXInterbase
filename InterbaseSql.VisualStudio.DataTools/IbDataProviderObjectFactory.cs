using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Data;
using Microsoft.VisualStudio.Data.AdoDotNet;

namespace InterbaseSql.VisualStudio.DataTools
{
    [Guid(GuidList.GuidObjectFactoryServiceString)]
    internal class IbDataProviderObjectFactory : AdoDotNetProviderObjectFactory
    {
        #region · Constructors ·

        public IbDataProviderObjectFactory() : base()
        {
            System.Diagnostics.Trace.WriteLine("IbDataProviderObjectFactory()");
        }

        #endregion

        #region · Methods ·

        public override object CreateObject(Type objectType)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("IbDataProviderObjectFactory::CreateObject({0})", objectType.FullName));

            if (objectType == typeof(DataConnectionSupport))
            {
                return new IbDataConnectionSupport();
            }
            else if (objectType == typeof(DataConnectionUIControl))
            {
                return new IbDataConnectionUIControl();
            }
            else if (objectType == typeof(DataConnectionProperties))
            {
                return new IbDataConnectionProperties();
            }

            return base.CreateObject(objectType);
        }

        #endregion
    }
}
