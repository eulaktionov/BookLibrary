using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibLib
{
    public class IdName
    {
        public static int lastId { get; set; } = 0;
        public int LastId
        {
            get { return lastId; }
            set { lastId = value; }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IdName() => (Id, Name) = (++lastId, string.Empty);
    }

    public class IdNameList<T> : BindingList<T> where T : IdName
    {
    }
}