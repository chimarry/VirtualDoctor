using System;
using Neo4j.Driver.V1;

namespace GlobalDatabase
{
    public sealed class GlobalDatabaseContext: IDisposable
    {
        public GlobalDatabaseContext(Uri uri, string user, string password)
        {
            this.Driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        public GlobalDatabaseContext(Uri uri)
        {
            this.Driver = GraphDatabase.Driver(uri, AuthTokens.None);
        }

        public IDriver Driver { get; }

        public void Dispose()
        {
            this.Driver?.Dispose();
        }
    }
}
