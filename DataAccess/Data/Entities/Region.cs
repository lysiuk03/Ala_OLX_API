namespace DataAccess.Data.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Announcement> Announcements { get; set; }
    }
}
