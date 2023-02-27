namespace WebApplication11.Models.Userview
{
    public class Userviewcs
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set;}
    }
}
