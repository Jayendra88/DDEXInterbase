
using System;
using System.Diagnostics;
using System.Globalization;
using Microsoft.VisualStudio.Data;
using Microsoft.VisualStudio.Data.AdoDotNet;

namespace InterbaseSql.VisualStudio.DataTools
{
    /// <summary>
    /// Provides information about an ADO.NET data source in the form of 
    /// properties passed as name/value pairs.
    /// </summary>
    internal class IbDataSourceInformation : AdoDotNetDataSourceInformation
    {
        #region · Constructors ·

        public IbDataSourceInformation(DataConnection connection)
            : base(connection)
        {
            base.AddProperty(AdoDotNetDataSourceInformation.CatalogSupported, false);
            base.AddProperty(AdoDotNetDataSourceInformation.CatalogSupportedInDml, false);
            base.AddProperty(AdoDotNetDataSourceInformation.DefaultSchema);
            base.AddProperty(AdoDotNetDataSourceInformation.DefaultCatalog, null);
            base.AddProperty(AdoDotNetDataSourceInformation.DefaultSchema, null);
            base.AddProperty(AdoDotNetDataSourceInformation.IdentifierOpenQuote, "\"");
            base.AddProperty(AdoDotNetDataSourceInformation.IdentifierCloseQuote, "\"");
            base.AddProperty(AdoDotNetDataSourceInformation.ParameterPrefix, "@");
            base.AddProperty(AdoDotNetDataSourceInformation.ParameterPrefixInName, true);
            base.AddProperty(AdoDotNetDataSourceInformation.ProcedureSupported, true);
            base.AddProperty(AdoDotNetDataSourceInformation.QuotedIdentifierPartsCaseSensitive, true);
            base.AddProperty(AdoDotNetDataSourceInformation.SchemaSupported, false);
            base.AddProperty(AdoDotNetDataSourceInformation.SchemaSupportedInDml, false);
            base.AddProperty(AdoDotNetDataSourceInformation.ServerSeparator, ".");
            base.AddProperty(AdoDotNetDataSourceInformation.SupportsAnsi92Sql, true);
            base.AddProperty(AdoDotNetDataSourceInformation.SupportsQuotedIdentifierParts, true);
            base.AddProperty(AdoDotNetDataSourceInformation.SupportsCommandTimeout, false);
            base.AddProperty(AdoDotNetDataSourceInformation.SupportsQuotedIdentifierParts, true);
            base.AddProperty("DesktopDataSource", true);
            base.AddProperty("LocalDatabase", true);
        }

        #endregion
    }
}
