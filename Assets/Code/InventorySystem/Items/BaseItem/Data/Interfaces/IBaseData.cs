
namespace FPS
{
	public interface IBaseData
	{
        int Id { get; set; }
        string UniqueUUID { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        int SlotId { get; set; }
    }
}