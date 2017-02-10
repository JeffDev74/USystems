
using System;

namespace FPS.InventorySystem.ItemSystem
{
    // This class is used to hold unchangeable data; should this be abstract class ????
    [System.Serializable]
	public struct BaseData : IBaseData
	{
        public int Id { get; set; }
        public string UniqueUUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
	}
}