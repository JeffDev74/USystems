using FPS.InventorySystem.ItemSystem;
using System.Collections.Generic;

namespace FPS.InventorySystem
{
	public interface IInventory
	{
        string InventoryUUID { get; set; }
        List<BaseItem> Items { get; }
        int ItemsCount { get; }
        BaseItem GetItem(string uniqueUUID);
        void AddItem(BaseItem item);
        void RemoveItem(BaseItem item);
        void RemoveItem(string uniqueUUID);
        void UpdateItem(string uniqueUUID, BaseItem item);
        void RemoveAllItems();
    }
}