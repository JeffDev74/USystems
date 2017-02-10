using System;
using FPS.UI;
using UnityEngine;
using FPS.EventSystem;
using FPS.InventorySystem.Events;

namespace FPS.InventorySystem.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIInventory : MonoBehaviour, IUIPanel
    {
        private int _id;
        public int ID
        {
            get { return _id; }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
        }

        private string _panelName;
        public string PanelName
        {
            get { return _panelName; }
        }

        private string _panelUniqueUUID;
        public string PanelUniqueUUID
        {
            get { return _panelUniqueUUID; }
            set { _panelUniqueUUID = value; }
        }

        private Transform _theTransform;
        public Transform TheTransform
        {
            get
            {
                if(_theTransform == null)
                {
                    _theTransform = transform;
                }
                return _theTransform;
            }
        }

        private CanvasGroup _theCanvasGroup;
        private CanvasGroup TheCanvasGroup
        {
            get
            {
                if(_theCanvasGroup == null)
                {
                    _theCanvasGroup = GetComponent<CanvasGroup>();
                }
                return _theCanvasGroup;
            }
        }
        // slotscontainer
        // inventory
        //
        [SerializeField]
        private UISlotsContainer _theSlotsContainer;
        private UISlotsContainer TheSlotsContainer
        {
            get
            {
                if(_theSlotsContainer == null)
                {
                    _theSlotsContainer = TheTransform.GetComponentInChildren<UISlotsContainer>();
                }
                return _theSlotsContainer;
            }
        }

        private IInventory _theInventory;
        private IInventory TheInventory
        {
            get { return _theInventory; }
            set { _theInventory = value; }
        }

        public void TogglePanel(bool state)
        {
            TheCanvasGroup.alpha =  state ? 1 : 0;
            TheCanvasGroup.interactable = state;
            TheCanvasGroup.blocksRaycasts = state;
            // Are we going to animate the panels??
            // AnimatePanel(state)
        }

        private void Start()
        {
            Debug.Log(TheSlotsContainer.name);
        }

        protected void OnEnable()
        {
            EventMessenger.Instance.AddListner<EventAfterAddInventoryItem>(OnItemAddedToInventory);
        }

        protected void OnDisable()
        {
            EventMessenger.Instance.RemoveListner<EventAfterAddInventoryItem>(OnItemAddedToInventory);
        }

        private void OnItemAddedToInventory(EventAfterAddInventoryItem e)
        {
            
        }
    }
}