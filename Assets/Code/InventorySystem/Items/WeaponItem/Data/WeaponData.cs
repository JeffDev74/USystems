using System;
using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem
{
    [System.Serializable]
    public struct WeaponData : IBaseData, IWeaponData
    {

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _uniqueUUID;
        public string UniqueUUID
        {
            get { return _uniqueUUID; }
            set { _uniqueUUID = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _ammo;
        public int Ammo
        {
            get { return _ammo; }
            set { _ammo = value; }
        }
    }
}