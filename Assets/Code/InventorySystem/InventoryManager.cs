using System.Collections.Generic;
using UnityEngine;

namespace FPS.InventorySystem
{
	public class InventoryManager : MonoBehaviour
	{
        List<IInventory> _inventories;
        List<IInventory> Inventories
        {
            get
            {
                if(_inventories == null)
                {
                    _inventories = new List<IInventory>();
                }
                return _inventories;
            }
        }


        [SerializeField]
        private Inventory _mainInventory;
        private IInventory MainInventory
        {
            get { return _mainInventory as IInventory; }
        }

        [SerializeField]
        private Inventory _actionBarInventory;
        private IInventory ActionBarInventory
        {
            get { return _actionBarInventory as IInventory; }
        }

        private void Start()
        {
            Inventories.Clear();
            AddInventory(MainInventory);
            AddInventory(ActionBarInventory);
        }

        public void AddInventory(IInventory inv)
        {
            Inventories.Add(inv);
        }

        public void RemoveInventory(IInventory inv)
        {

        }

        public IInventory GetInventoryByUUID(string inventoryUniqueUUID)
        {
            return null;
        }
    }
}