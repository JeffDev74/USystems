using FPS.InventorySystem.ItemSystem;
using System.Collections.Generic;

namespace FPS.InventorySystem
{
	public interface IInventory
	{
        string InventoryUUID { get; set; }
        List<IItem> Items { get; }
        int ItemsCount { get; }
        IItem GetItem(string uniqueUUID);
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        void RemoveItem(string uniqueUUID);
        void UpdateItem(string uniqueUUID, IItem item);
        void RemoveAllItems();
    }
}