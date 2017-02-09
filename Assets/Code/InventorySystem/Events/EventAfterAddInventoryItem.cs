using FPS.EventSystem;
using FPS.InventorySystem.ItemSystem;

namespace FPS.InventorySystem.Events
{
	public class EventAfterAddInventoryItem : GameEvent
    {
        private BaseItem _item;
        public BaseItem Item
        {
            get { return _item; }
            private set { _item = value; }
        }

        public EventAfterAddInventoryItem(BaseItem item)
        {
            this.Item = item;
        }
    }
}