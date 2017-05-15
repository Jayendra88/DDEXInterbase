using System;
using Microsoft.VisualStudio.Data;

namespace InterbaseSql.VisualStudio.DataTools
{
    internal class IbDataObjectIdentifierResolver : DataObjectIdentifierResolver
    {
        #region · Private Fields ·

        private DataConnection connection;

        #endregion

        #region · Constructors ·

        public IbDataObjectIdentifierResolver(DataConnection connection) 
            : base()
        {
            System.Diagnostics.Trace.WriteLine("IbDataObjectIdentifierResolver()");
            this.connection = connection;
        }

        #endregion

        #region · Methods ·

        protected override object[] QuickContractIdentifier(string typeName, object[] fullIdentifier)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("IbDataObjectIdentifierResolver::QuickContractIdentifier({0},...)", typeName));

            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }

            if (typeName == IbDataObjectTypes.Root)
            {
                return base.QuickContractIdentifier(typeName, fullIdentifier);
            }

            object[] identifier = null;
            int length = this.GetIdentifierLength(typeName);
            if (length == -1)
            {
                throw new NotSupportedException();
            }
            identifier = new object[length];

            if (fullIdentifier != null)
            {
                fullIdentifier.CopyTo(identifier, length - fullIdentifier.Length);
            }

            if (identifier.Length > 0)
            {
                identifier[0] = null;
            }

            if (identifier.Length > 1)
            {
                identifier[1] = null;
            }

            return identifier;
        }

        protected override object[] QuickExpandIdentifier(string typeName, object[] partialIdentifier)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("IbDataObjectIdentifierResolver::QuickExpandIdentifier({0},...)", typeName));

            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }

            // Create an identifier array of the correct full length based on
            // the object type
            object[] identifier = null;
            int length = this.GetIdentifierLength(typeName);
            if (length == -1)
            {
                throw new NotSupportedException();
            }
            identifier = new object[length];

            // If the input identifier is not null, copy it to the full
            // identifier array.  If the input identifier's length is less
            // than the full length we assume the more specific parts are
            // specified and thus copy into the rightmost portion of the
            // full identifier array.
            if (partialIdentifier != null)
            {
                if (partialIdentifier.Length > length)
                {
                    throw new InvalidOperationException();
                }

                partialIdentifier.CopyTo(identifier, length - partialIdentifier.Length);
            }

            if (length > 0)
            {
                identifier[0] = null;
            }

            if (length > 1)
            {
                identifier[1] = null;
            }

            return identifier;
        }

        #endregion

        #region · Private Methods ·

        private int GetIdentifierLength(string typeName)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("GetIdentifierLength({0})", typeName));

            switch (typeName)
            {
                case IbDataObjectTypes.Root:
                    return 0;

                case IbDataObjectTypes.Table:
                case IbDataObjectTypes.View:
                case IbDataObjectTypes.StoredProcedure:
                    return 3;

                case IbDataObjectTypes.TableColumn:
                case IbDataObjectTypes.ViewColumn:
                case IbDataObjectTypes.StoredProcedureParameter:
                    return 4;
                               
                default:
                    return -1;
            }
        }

        #endregion
    }
}
