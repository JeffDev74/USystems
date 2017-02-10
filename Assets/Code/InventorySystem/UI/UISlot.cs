﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace FPS.InventorySystem.UI
{
    public class UISlot : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private UIItem _uiItem;
        private UIItem UIItem
        {
            get
            {
                _uiItem = GetComponentInChildren<UIItem>();
                return _uiItem;
            }
        }

        private Transform _theTransform;
        private Transform TheTransform
        {
            get
            {
                if(_theTransform == null)
                {
                    _theTransform = transform;
                }
                return transform;
            }
        }

        private void AttachUIItem(UIItem uiItem)
        {
            uiItem.transform.SetParent(TheTransform);

            UIItem.Item.Data.SlotId = ID;
            UIItem.Item.NSData.Slot = this;
        }

        public void OnDrop(PointerEventData eventData)
        {
            AttachUIItem(UIItem._tmpItemBeingDragged);
            UIItem.transform.SetParent(UIItem._tmpItemStartSlot.transform);
        }
    }
}