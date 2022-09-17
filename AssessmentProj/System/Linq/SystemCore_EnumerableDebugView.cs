using AssessmentProj;

namespace System.Linq
{
    internal class SystemCoreEnumerableDebugView<T>
    {
        private ILookup<ItemTypeEnum, ItemClass> _itemsTypeWise;

        public SystemCoreEnumerableDebugView(ILookup<ItemTypeEnum, ItemClass> itemsTypeWise)
        {
            this._itemsTypeWise = itemsTypeWise;
        }
    }
}
