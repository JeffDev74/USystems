﻿using FPS.EventSystem;
using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem.Events
{
	public class EventAddItemToInventory : GameEvent
	{
        private IInventory _inventory;
        public IInventory Inventory
        {
            get { return _inventory; }
            private set { _inventory = value; }
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

        public EventAddItemToInventory(IInventory inventory, IItem item, bool updateUI = true)
        {
            this.Inventory = inventory;
            this.Item = item;
            this.UpdateUI = updateUI;
        }
    }
}