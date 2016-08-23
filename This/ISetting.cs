using System.Collections.Generic;
using System.Threading.Tasks;

namespace This
{

    public interface ISetting
    {
         int CurrIndex { get; set; }
         IList<object> Table { get; set; }
         IList<string> TableName { get; }
         bool Asc { get; set; }
         Task ReadOrWrite(bool read);


    }
}
