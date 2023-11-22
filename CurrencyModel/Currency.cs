using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CurrencyModel
{
    [DataContract]
    public class Currency
    {
        [DataMember]
        public string key { get; set; }

        [DataMember]
        public double Rate { get; set; }

        [DataMember]
        public double change { get; set; }

        [DataMember]

        public int unit { get; set; }
    }
    [CollectionDataContract]
    public class CurrencyList:List<Currency> 
    {
        public CurrencyList() { }

        public CurrencyList(IEnumerable<Currency> list) { }
    }
}
