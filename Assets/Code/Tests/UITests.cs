using FPS.EventSystem;
using FPS.InventorySystem;
using FPS.InventorySystem.Events;
using UnityEngine;

namespace FPS
{
	public class UITests : MonoBehaviour
	{
        private void Start()
        {
            IInventory inventory= null;
            IItem item = null;
            //EventMessenger.Instance.Raise(new EventAddItemToInventory(inventory, item));
        }
    }
}