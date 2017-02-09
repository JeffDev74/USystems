﻿namespace FPS.EventSystem
{
	public class EventTest : GameEvent
	{
        private string _itemUniqueUUID;
        public string ItemUniqueUUID
        {
            get { return _itemUniqueUUID; }
            private set { _itemUniqueUUID = value; }
        }

        public EventTest(string itemUniqueUUID)
        {
            this.ItemUniqueUUID = itemUniqueUUID;
        }
    }
}

//void OnEnable()
//{
//    EventMessager.Instance.AddListner<EventTest>(OnTestEvent);
//}
//void OnDisable()
//{
//    EventMessager.Instance.RemoveListner<EventTest>(OnTestEvent);
//}
//private void OnTestEvent(EventTest e)
//{
//}
//void Start()
//{
//    EventMessager.Instance.Raise(new EventTest("itemid"));
//}

