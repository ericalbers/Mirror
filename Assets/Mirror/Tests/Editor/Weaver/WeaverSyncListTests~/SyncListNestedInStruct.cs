using Mirror;

namespace SyncListNestedInStruct
{
    class MyBehaviour : NetworkBehaviour
    {
        SomeData.SyncList Foo;
    }

    public struct SomeData
    {
        public int usefulNumber;

        public class SyncList : Mirror.SyncList<SomeData> { }
    }
}
