using FPS.EventSystem;
using FPS.InventorySystem;
using FPS.InventorySystem.Events;
using FPS.InventorySystem.ItemSystem;
using FPS.InventorySystem.UI;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
	public class AddItemBtn : MonoBehaviour
	{
        private string ItemA_ID = "9e371875-d6be-43c2-a254-d74f0893df59";

        private string inventory_uuid = "00071875-d6be-43c2-a254-d74f0893d000";

        public Sprite itemIcon;

        public UIInventory uiInventory;

        private void Start()
        {
            //UIInventory uiInventory = FindObjectOfType<UIInventory>();
            uiInventory.InventoryUUID = inventory_uuid;
        }

        public void AddItem()
        {
            //InventoryManager.Instance.GetInventoryByUUID(inventory_uuid)
            EventMessenger.Instance.Raise(new EventAddItemToInventory(null, inventory_uuid, FactoryItem(), true));
        }

        public IItem FactoryItem()
        {
            IItem testItem = new WeaponItem();
            testItem.Data = new WeaponData();
            testItem.Data.Id = 1;
            testItem.Data.UniqueUUID = ItemA_ID;
            testItem.Data.Name = "AK47";
            testItem.Data.Quantity = 777;
            testItem.Data.Description = "Weapon mid-range";

            testItem.NSData = new WeaponNSData();

            testItem.NSData.Icon = itemIcon;

            return testItem as IItem;
        }
	}
}