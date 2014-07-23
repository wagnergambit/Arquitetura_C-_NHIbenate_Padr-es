using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Arquitetura.Domain.ValueObjects
{
    [DataContract]
    public class Filters
    {
        [DataMember]
        public string groupOp { get; set; }
        [DataMember]
        public Rule[] rules { get; set; }

        public static Filters Create(string jsonData)
        {
            try
            {
                var serializer =
                  new DataContractJsonSerializer(typeof(Filters));
                System.IO.StringReader reader =
                  new System.IO.StringReader(jsonData);
                System.IO.MemoryStream ms =
                  new System.IO.MemoryStream(
                  Encoding.Default.GetBytes(jsonData));
                return serializer.ReadObject(ms) as Filters;
            }
            catch
            {
                return null;
            }
        }
    }
}
