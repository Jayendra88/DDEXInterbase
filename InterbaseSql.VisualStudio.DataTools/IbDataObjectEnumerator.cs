using System;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.Data;
using Microsoft.VisualStudio.Data.AdoDotNet;

namespace InterbaseSql.VisualStudio.DataTools
{
    internal class IbDataObjectEnumerator : AdoDotNetObjectEnumerator
    {
        #region · Constructors ·

        public IbDataObjectEnumerator() 
            : base()
        {
            System.Diagnostics.Trace.WriteLine("IbDataObjectEnumerator()");
        }

        #endregion

        #region · Methods ·

        public override DataReader EnumerateObjects(string typeName, object[] items, object[] restrictions, string sort, object[] parameters)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("IbDataObjectEnumerator::EnumerateObjects({0})", typeName));

            DbConnection conn = Connection.GetLockedProviderObject() as DbConnection;

            try
            {
                if (typeName.Equals(IbDataObjectTypes.Root, StringComparison.InvariantCultureIgnoreCase))
                {
                    DataTable rootSchema = new DataTable();
                    rootSchema.Locale = System.Globalization.CultureInfo.CurrentCulture;

                    rootSchema.Columns.Add("Server", typeof(string));
                    rootSchema.Columns.Add("Database", typeof(string));

                    DataRow row = rootSchema.NewRow();

                    row["Server"]   = conn.DataSource;
                    row["Database"] = System.IO.Path.GetFileNameWithoutExtension(conn.Database);

                    rootSchema.Rows.Add(row);

                    return new AdoDotNetDataTableReader(rootSchema);
                }

                return base.EnumerateObjects(typeName, items, restrictions, sort, parameters);
            }
            finally
            {
                Connection.UnlockProviderObject();
            }
        }

        #endregion
    }
}
