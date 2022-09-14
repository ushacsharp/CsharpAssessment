using AssessmentProj;

namespace System.Linq
{
    internal class SystemCore_EnumerableDebugView<T>
    {
        private ILookup<ItemTypeEnum, ItemClass> itemsTypeWise;

        public SystemCore_EnumerableDebugView(ILookup<ItemTypeEnum, ItemClass> itemsTypeWise)
        {
            this.itemsTypeWise = itemsTypeWise;
        }
    }
}
