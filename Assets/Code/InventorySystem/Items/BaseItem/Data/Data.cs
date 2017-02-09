
namespace FPS.InventorySystem.ItemSystem
{
    // This class is used to hold unchangeable data; should this be abstract class ????
    [System.Serializable]
	public class Data
	{
        public int Id;
        public string UniqueUUID;
        public string Name;
        public string Description;
	}
}