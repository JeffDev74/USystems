using FPS.EventSystem;
using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem.Events
{
	public class EventBeforeAddInventoryItem : GameEvent
	{
        private BaseItem _item;
        public BaseItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public EventBeforeAddInventoryItem(BaseItem item)
        {
            this.Item = item;
        }
    }
}