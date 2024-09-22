namespace ApiPersonajes.Models
{
    public class Characters
    {
        public Info Info { get; set; }
         
        public List<Character> results { get; set; }
    }

    public class Info
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string next { get; set; }
        public string prev { get; set; }
    }
}
