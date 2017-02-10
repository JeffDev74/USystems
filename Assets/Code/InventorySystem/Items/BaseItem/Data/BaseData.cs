
using UnityEngine;
namespace FPS.InventorySystem.ItemSystem
{
    // This class is used to hold unchangeable data; should this be abstract class ????
    [System.Serializable]
	public abstract class BaseData : IBaseData
	{
        [SerializeField]
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [SerializeField]
        private string _uniqueUUID;
        public string UniqueUUID
        {
            get { return _uniqueUUID; }
            set { _uniqueUUID = value; }
        }

        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [SerializeField]
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}