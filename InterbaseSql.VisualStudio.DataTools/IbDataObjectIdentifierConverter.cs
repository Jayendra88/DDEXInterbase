using System;
using Microsoft.VisualStudio.Data;
using Microsoft.VisualStudio.Data.AdoDotNet;

namespace InterbaseSql.VisualStudio.DataTools
{
    internal class IbDataObjectIdentifierConverter : AdoDotNetObjectIdentifierConverter
    {
        #region · Fields ·

        private DataConnection connection;

        #endregion

        #region · Constructors ·

        public IbDataObjectIdentifierConverter(DataConnection connection) 
            : base(connection)
        {
            this.connection = connection;
        }

        #endregion

        #region · Protected Methods ·

        protected override string FormatPart(string typeName, object identifierPart, bool withQuotes)
        {
            string openQuote    = (string)this.connection.SourceInformation[DataSourceInformation.IdentifierOpenQuote];
            string closeQuote   = (string)this.connection.SourceInformation[DataSourceInformation.IdentifierCloseQuote];
            string identifier   = (identifierPart is string) ? (string)identifierPart : null;

            if (withQuotes && identifier != null && !this.IsQuoted(identifier))
            {
                if (!identifier.StartsWith(openQuote))
                {
                    identifier = openQuote + identifier;
                }

                if (!identifier.EndsWith(closeQuote))
                {
                    identifier = identifier + openQuote;
                }
            }

            // return ((identifier != null) ? identifier : String.Empty);
            return identifier;
        }

        #endregion

        #region · Private Methods ·

        private bool IsQuoted(string value)
        {
            string openQuote    = (string)this.connection.SourceInformation[DataSourceInformation.IdentifierOpenQuote];
            string closeQuote   = (string)this.connection.SourceInformation[DataSourceInformation.IdentifierOpenQuote];

            return (value.StartsWith(openQuote) && value.EndsWith(closeQuote));
        }

        #endregion
    }
}
