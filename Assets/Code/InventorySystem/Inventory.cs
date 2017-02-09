using UnityEngine;
using FPS.InventorySystem.ItemSystem;
using System.Collections.Generic;

namespace FPS.InventorySystem
{
	public class Inventory : MonoBehaviour, IInventory
	{
        private List<BaseItem> _internalItems;
        private List<BaseItem> InternalItems
        {
            get
            {
                if(_internalItems == null)
                {
                    _internalItems = new List<BaseItem>();
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
                if(string.IsNullOrEmpty(_inventoryUUID))
                {
                    _inventoryUUID = System.Guid.NewGuid().ToString();
                }
                return _inventoryUUID;
            }
            set { _inventoryUUID = value; }
        }

        public List<BaseItem> Items
        {
            get { return InternalItems; }
        }

        public int ItemsCount
        {
            get { return InternalItems.Count; }
        }

        public BaseItem GetItem(string uniqueUUID)
        {
            for (int i = 0; i < InternalItems.Count; i++)
            {
                BaseItem resultItem = InternalItems[i];
                if(resultItem.Data.UniqueUUID == uniqueUUID)
                {
                    return resultItem;
                }
            }

            return null;
        }

        public void AddItem(BaseItem item)
        {
            if(CheckIfExists(item.Data.UniqueUUID) == false)
            {
                EventSystem.EventMessager.Instance.Raise(new Events.EventBeforeAddInventoryItem(item));
                InternalItems.Add(item);
                EventSystem.EventMessager.Instance.Raise(new Events.EventAfterAddInventoryItem(item));
            }
            else
            {
                Debug.LogError("The item with the unique uuid of [" + item.Data.UniqueUUID + "] is already in the inventory.");
            }
        }

        public void RemoveItem(BaseItem item)
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
                    EventSystem.EventMessager.Instance.Raise(new Events.EventBeforeRemoveInventoryItem(item));
                    InternalItems.Remove(item);
                    EventSystem.EventMessager.Instance.Raise(new Events.EventAfterRemoveInventoryItem(item));
                }
            }
            #endregion Foreach Version
        }

        public void UpdateItem(string uniqueUUID, BaseItem item)
        {
            for (int i = 0; i < InternalItems.Count; i++)
            {
                if (InternalItems[i].Data.UniqueUUID == uniqueUUID)
                {
                    EventSystem.EventMessager.Instance.Raise(new Events.EventBeforeUpdateInventoryItem(item));
                    InternalItems[i] = item;
                    EventSystem.EventMessager.Instance.Raise(new Events.EventAfterUpdateInventoryItem(item));
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