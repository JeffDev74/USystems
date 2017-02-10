using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem
{
    [System.Serializable]
	public class WeaponItem : BaseItem, IItem
    { 
        public WeaponData _data;
        public override IBaseData Data
        {
            get { return _data as BaseData; }
            set { _data = value as WeaponData; }
        }
	}
}