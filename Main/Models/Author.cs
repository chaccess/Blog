namespace Main.Models
{
    public class Author : BaseEntity
    {
        public string? NickName { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }
    }
}
