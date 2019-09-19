using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDatabase
{
    public class Test
    {
        public GlobalDatabaseContext GlobalDatabaseContext { get; set; } = new GlobalDatabaseContext(new Uri("bolt://localhost:7687"), "neo4j", "marija97");

        public async void Populate()
        {
            using (ISession session = GlobalDatabaseContext.Driver.Session())
            {
                string query = "create (user:User {name:\"User\"})";
                await session.WriteTransactionAsync(async x =>
                     await x.RunAsync(query)
                   );
            }


        }
        public async Task<string> Read()
        {
            string result = string.Empty;
            using (ISession session = GlobalDatabaseContext.Driver.Session())
            {
                string query = "match (user:User {name:\"User\"}) return user.name as Name";
                await session.ReadTransactionAsync(async x =>
                {
                    IStatementResultCursor cursor = await x.RunAsync(query);
                    var tmp = await cursor.ToListAsync(c => {
                        return c.To<string>("Name");
                    });
                    result = tmp.FirstOrDefault();
                    query = string.Empty;
                });
                return result;
            }
          

        }
    }
}
