using UnityEngine;
using FPS.InventorySystem.ItemSystem;
using System.Collections.Generic;
using FPS.EventSystem;
using FPS.InventorySystem.Events;
using System;

namespace FPS.InventorySystem
{
	public class Inventory : MonoBehaviour, IInventory
	{
        private List<IItem> _internalItems;
        private List<IItem> InternalItems
        {
            get
            {
                if(_internalItems == null)
                {
                    _internalItems = new List<IItem>();
                }
                return _internalItems;
            }
            set
            {
                _internalItems = value;
            }
        }

        [SerializeField]
        private string _inventoryUUID;
        public string InventoryUUID
        {
            get
            {
                if (string.IsNullOrEmpty(_inventoryUUID))
                {
                    // Only used for testing
                    _inventoryUUID = "00071875-d6be-43c2-a254-d74f0893d000";
                    //_inventoryUUID = System.Guid.NewGuid().ToString();
                }
                return _inventoryUUID;
            }
            set { _inventoryUUID = value; }
        }

        public List<IItem> Items
        {
            get { return InternalItems; }
        }

        public int ItemsCount
        {
            get { return InternalItems.Count; }
        }

        protected virtual void OnEnable()
        {
            EventMessenger.Instance.AddListner<EventAddItemToInventory>(OnAddItemEvent);
        }

        protected virtual void OnDisable()
        {
            EventMessenger.Instance.RemoveListner<EventAddItemToInventory>(OnAddItemEvent);
        }

        protected void Start()
        {
            InventoryManager.Instance.AddInventory(this);
        }

        private void OnAddItemEvent(EventAddItemToInventory e)
        {
            if(e.InventoryUUID == InventoryUUID)
            {
                AddItem(e.Item);
            }
        }

        public IItem GetItem(string uniqueUUID)
        {
            for (int i = 0; i < InternalItems.Count; i++)
            {
                IItem resultItem = InternalItems[i];
                if(resultItem.Data.UniqueUUID == uniqueUUID)
                {
                    return resultItem;
                }
            }

            return null;
        }

        public void AddItem(IItem item)
        {
            if(CheckIfExists(item.Data.UniqueUUID) == false) // We dont have the item when false
            {
                EventSystem.EventMessenger.Instance.Raise(new Events.EventBeforeAddInventoryItem(this, item));
                InternalItems.Add(item);
                EventSystem.EventMessenger.Instance.Raise(new Events.EventAfterAddInventoryItem(this, item));
            }
            else
            {
                Debug.LogError("The item with the unique uuid of [" + item.Data.UniqueUUID + "] is already in the inventory.");
            }
        }

        public void RemoveItem(IItem item)
        {
            RemoveItem(item.Data.UniqueUUID);
        }

        public void RemoveItem(string uniqueUUID)
        {
            #region Linq Version
            //EventSystem.EventMessager.Instance.Raise(new Events.EventBeforeRemoveInventoryItem(item));
            //InternalItems.RemoveAll(item => item.Data.UniqueUUID == uniqueUUID);
            //EventSystem.EventMessager.Instance.Raise(new Events.EventAfterRemoveInventoryItem(item));
            #endregion Linq Version

            #region Foreach Version
            foreach (BaseItem item in InternalItems.ToArray())
            {
                if (item.Data.UniqueUUID == uniqueUUID)
                {
                    EventSystem.EventMessenger.Instance.Raise(new Events.EventBeforeRemoveInventoryItem(this, item));
                    InternalItems.Remove(item);
                    EventSystem.EventMessenger.Instance.Raise(new Events.EventAfterRemoveInventoryItem(this, item));
                }
            }
            #endregion Foreach Version
        }

        public void UpdateItem(string uniqueUUID, IItem item)
        {
            for (int i = 0; i < InternalItems.Count; i++)
            {
                if (InternalItems[i].Data.UniqueUUID == uniqueUUID)
                {
                    EventSystem.EventMessenger.Instance.Raise(new Events.EventBeforeUpdateInventoryItem(this, item));
                    InternalItems[i] = item;
                    EventSystem.EventMessenger.Instance.Raise(new Events.EventAfterUpdateInventoryItem(this, item));
                }
            }
        }

        public void RemoveAllItems()
        {
            //Refactore
            InternalItems.Clear();
        }

        private bool CheckIfExists(string uniqueUUID)
        {
            for (int i = 0; i < InternalItems.Count; i++)
            {
                if (InternalItems[i].Data.UniqueUUID == uniqueUUID)
                {
                    return true;
                }
            }

            return false;
        }
    }
}