
using System;
using Microsoft.VisualStudio.Data;

namespace InterbaseSql.VisualStudio.DataTools
{
    internal class IbDataObjectSupport : DataObjectSupport
    {
        #region · Constructors ·

		public IbDataObjectSupport()
            : base("InterbaseSql.VisualStudio.DataTools.IbDataObjectSupport", typeof(IbDataObjectSupport).Assembly)
		{
            System.Diagnostics.Trace.WriteLine("IbDataObjectSupport()");
		}

        #endregion
    }
}
