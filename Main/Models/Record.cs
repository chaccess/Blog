namespace Main.Models
{
    public class Record : BaseEntity
    {
        public string? Title { get; set; }

        public string? Body { get; set; }

        public Author? Author { get; set; }
    }
}
