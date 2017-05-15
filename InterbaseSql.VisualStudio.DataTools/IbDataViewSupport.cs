
using System;
using Microsoft.VisualStudio.Data;

namespace InterbaseSql.VisualStudio.DataTools
{
    internal class IbDataViewSupport : DataViewSupport
    {
        #region · Constructors ·

        public IbDataViewSupport()
            : base("InterbaseSql.VisualStudio.DataTools.IbDataViewSupport", typeof(IbDataViewSupport).Assembly)
		{
            System.Diagnostics.Trace.WriteLine("IbDataViewSupport()");
		}

        #endregion
    }
}
