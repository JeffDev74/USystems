using FPS.EventSystem;
using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem.Events
{
	public class EventAddItemToInventory : GameEvent
	{
        /// <summary>
        /// Should be removed 
        /// We should only use the inventory uuid
        /// and retrieve the inventory from a "inventory manager"
        /// </summary>
        private IInventory _inventory;
        public IInventory Inventory
        {
            get { return _inventory; }
            private set { _inventory = value; }
        }

        private string _inventoryUUID;
        public string InventoryUUID
        {
            get { return _inventoryUUID; }
            set { _inventoryUUID = value; }
        }

        private IItem _item;
        public IItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        private bool _updateUI;
        public bool UpdateUI
        {
            get { return _updateUI; }
            private set { _updateUI = value; }
        }

        public EventAddItemToInventory(IInventory inventory, string inventoryUUID, IItem item, bool updateUI = true)
        {
            this.Inventory = inventory;
            this.Item = item;
            this.UpdateUI = updateUI;
            this.InventoryUUID = inventoryUUID;
        }
    }
}