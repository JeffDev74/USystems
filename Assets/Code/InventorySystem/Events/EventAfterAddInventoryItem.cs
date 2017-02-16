﻿using FPS.EventSystem;
using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem.Events
{
	public class EventAfterAddInventoryItem : GameEvent
    {
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

        public EventAfterAddInventoryItem(string inventoryUUID, IItem item, bool updateUI = true)
        {
            this.InventoryUUID = inventoryUUID;
            this.Item = item;
            this.UpdateUI = updateUI;
        }
    }
}