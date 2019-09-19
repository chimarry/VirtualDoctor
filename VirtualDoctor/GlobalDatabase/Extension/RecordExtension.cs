using System;
using Neo4j.Driver.V1;
using Newtonsoft.Json;

namespace GlobalDatabase
{
    public static class RecordExtension
    {
        public static T AsNodeTo<T>(this IRecord record, string keyName)
        {
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            if (record[keyName] == null)
            {
                return default(T);
            }

            var recordItem = record[keyName];

            string nodeProps = JsonConvert.SerializeObject(recordItem.As<INode>().Properties);
            return JsonConvert.DeserializeObject<T>(nodeProps);
        }

        public static T To<T>(this IRecord record, string keyName)
        {
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            if (record[keyName] == null)
            {
                return default(T);
            }

            string nodeProps = JsonConvert.SerializeObject(record[keyName]);
            return JsonConvert.DeserializeObject<T>(nodeProps);
        }

        public static string AsString(this IRecord record, string keyName)
        {
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            string ret = record[keyName].As<string>();

            if (ret == null)
            {
                return string.Empty;
            }

            return ret;
        }
    }
}
