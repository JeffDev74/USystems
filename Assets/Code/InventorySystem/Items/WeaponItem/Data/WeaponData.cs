using UnityEngine;
using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem
{
    [System.Serializable]
    public class WeaponData : BaseData
    {
        [SerializeField]
        private int _ammo;
        public int Ammo
        {
            get { return _ammo; }
            set { _ammo = value; }
        }
    }
}