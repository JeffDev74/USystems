
namespace FPS.InventorySystem.ItemSystem
{
    // This class should be abstract ???
    [System.Serializable]
    public abstract class BaseItem : IItem, IItemData
    {
        public abstract IBaseData Data { get; set; }

        public NSData NSData;

        public RTData RTData;
	}
}