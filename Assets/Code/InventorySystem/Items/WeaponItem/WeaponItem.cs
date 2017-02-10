using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem
{
    [System.Serializable]
	public class WeaponItem : BaseItem, IItem
    { 
        public IWeaponData _data;
        public override IBaseData Data
        {
            get { return _data as IBaseData; }
            set { _data = value as IWeaponData; }
        }
	}
}