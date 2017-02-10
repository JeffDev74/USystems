using FPS.InventorySystem.ItemSystem;
using UnityEngine;

namespace FPS.InventorySystem
{
    [System.Serializable]
	public class WeaponItem : BaseItem, IItem
    { 
        [SerializeField]
        private WeaponData _data;
        public override IBaseData Data
        {
            get { return _data as BaseData; }
            set { _data = value as WeaponData; }
        }

        [SerializeField]
        private WeaponNSData _weaponNSData;
        public override INSData NSData
        {
            get { return _weaponNSData as INSData; }
            set { _weaponNSData = value as WeaponNSData; }
        }
    }
}