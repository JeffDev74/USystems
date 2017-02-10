using UnityEngine;
using FPS.InventorySystem;
using FPS.InventorySystem.ItemSystem;
using System.Collections.Generic;
using FPS.EventSystem;

namespace FPS
{
	public class InventoryTests : MonoBehaviour
	{
        private string ItemA_ID = "9e371875-d6be-43c2-a254-d74f0893df59";
        private string ItemB_ID = "9e371875-d6be-43c2-a254-d74f0893df60";
        [SerializeField]
        private IInventory _theInventory;
        public IInventory TheInventory
        {
            get
            {
                if(_theInventory == null)
                {
                    _theInventory = GetComponent<IInventory>();
                }
                return _theInventory;
            }
            set
            {
                _theInventory = value;
            }
        }

        public bool shouldTestInventory = false;

        private void Start()
        {
            #region INVENTORY TESTS
            if(shouldTestInventory)
            {
                Debug.Log("Start Testing inventory UUID is [" + TheInventory.InventoryUUID + "]");

                // Testing adding item to the inventory
                WeaponItem weapon = new WeaponItem();
                weapon.Data = new WeaponData();
                weapon.Data.Id = 1;
                weapon.Data.UniqueUUID = ItemA_ID;
                weapon.Data.Name = "AK47";
                weapon.Data.Description = "Weapon mid-range";

                Debug.Log(weapon.Data.UniqueUUID);

                TestAddItemToInventory(weapon);

                // Get specific item
                TestGetSpecificItem(weapon);

                // Testing updating item on inventory
                WeaponItem weapon2 = new WeaponItem();
                weapon2.Data = new WeaponData();
                weapon2.Data.Id = 1;
                weapon2.Data.UniqueUUID = ItemB_ID;
                weapon2.Data.Name = "AK47";
                weapon2.Data.Description = "Weapon mid-range altered.";

                TestUpdateItemInTheInventory(weapon2);

                // Test remove item
                TestRemoveItemFromInventory(weapon2);
                // Count all items
                TestCountAllItemsFromInventory(weapon, weapon2);

                // Get all items
                TestGetAllItemsFromInventory(weapon, weapon2);

            }
            #endregion INVENTORY TESTS

            //EventMessager.Instance.Raise(new EventTest(ItemA_ID));
        }

        private void OnEnable()
        {
            EventMessenger.Instance.AddListner<EventTest>(OnTestEvent);
        }

        private void OnDisable()
        {
            EventMessenger.Instance.RemoveListner<EventTest>(OnTestEvent);
        }

        private void OnTestEvent(EventTest e)
        {
            Debug.Log("PASSED [OnTestEvent] Received the event [" + e.GetType().Name + "] with item unique UUID [" + e.ItemUniqueUUID + "]");
        }

        #region INVENTORY TESTS
        private void TestAddItemToInventory(IItem testItem)
        {
            // Test add item
            TheInventory.AddItem(testItem);

            // Check item name and unique uuid
            IItem tmpBaseItem = TheInventory.GetItem(testItem.Data.UniqueUUID);
            if (tmpBaseItem == null)
            {
                Debug.LogError("FAILED [TestAddItemToInventory]. We should have the item in the inventory.");
            }
            else
            {
                Debug.Log("PASSED [TestAddItemToInventory]. Weapon description [" + tmpBaseItem.Data.Description + "] uniqueUUID [" + tmpBaseItem.Data.UniqueUUID + "]");
            }
        }

        private void TestGetSpecificItem(IItem testItem)
        {
            IItem tmpBaseItem = TheInventory.GetItem(testItem.Data.UniqueUUID);
            if (tmpBaseItem == null)
            {
                Debug.LogError("FAILED [TestGetSpecificItem]. We should have the item in the inventory.");
            }
            else
            {
                Debug.Log("PASSED [TestGetSpecificItem]. Weapon description [" + tmpBaseItem.Data.Description + "] uniqueUUID [" + tmpBaseItem.Data.UniqueUUID + "]");
            }
        }

        private void TestUpdateItemInTheInventory(IItem testItem)
        {
            TheInventory.UpdateItem(ItemA_ID, testItem);

            IItem tmpBaseItem = TheInventory.GetItem(ItemB_ID);
            if (tmpBaseItem == null)
            {
                Debug.LogError("FAILED [TestUpdateItemInTheInventory]. The item is missing from inventory.");
            }
            else
            {
                Debug.Log("PASSED [TestUpdateItemInTheInventory]. Weapon description [" + tmpBaseItem.Data.Description + "] uniqueUUID [" + tmpBaseItem.Data.UniqueUUID + "]");
            }
        }

        private void TestRemoveItemFromInventory(IItem testItem)
        {
            TheInventory.RemoveItem(testItem);
            IItem tmpBaseItem = TheInventory.GetItem(testItem.Data.UniqueUUID);
            if (tmpBaseItem == null)
            {
                Debug.Log("PASSED [TestRemoveItemFromInventory]. Weapon description [" + testItem.Data.Description + "] uniqueUUID [" + testItem.Data.UniqueUUID + "]");
            }
            else
            {
                Debug.LogError("FAILED [TestRemoveItemFromInventory]. We should have the item removed from the inventory.");
            }
        }

        private void TestCountAllItemsFromInventory(IItem itemA, IItem itemB)
        {
            TestAddItemToInventory(itemA);
            TestAddItemToInventory(itemB);

            if (TheInventory.ItemsCount == 2)
            {
                Debug.Log("PASSED [TestCountAllItemsFromInventory]. All items were acounted for.");
            }
            else
            {
                Debug.LogError("FAILED [TestCountAllItemsFromInventory]. We should have two items in the inventory.");
            }
            TheInventory.RemoveAllItems();
        }

        private void TestGetAllItemsFromInventory(IItem itemA, IItem itemB)
        {
            TestAddItemToInventory(itemA);
            TestAddItemToInventory(itemB);
            List<IItem> items = TheInventory.Items;
            if (items.Count == 2)
            {
                Debug.Log("PASSED [TestGetAllItemsFromInventory]. We got all the items.");
            }
            else
            {
                Debug.LogError("FAILED [TestGetAllItemsFromInventory]. We should have two items in the inventory.");
            }
            TheInventory.RemoveAllItems();
        }
        #endregion INVENTORY TESTS
    }
}