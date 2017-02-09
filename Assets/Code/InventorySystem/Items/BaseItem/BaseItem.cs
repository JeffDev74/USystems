
namespace FPS.InventorySystem.ItemSystem
{
    // This class should be abstract ???
    [System.Serializable]
    public class BaseItem : IItem, IItemData
    {
        public Data Data;
        public NSData NSData;
        public RTData RTData;
	}
}