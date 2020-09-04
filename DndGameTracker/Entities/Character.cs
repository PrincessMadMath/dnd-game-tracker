namespace DndGameTracker.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}