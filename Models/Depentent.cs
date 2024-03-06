namespace WebApplication1.Models
{
    public class Depentent
    {
        public int essn { get; set; }
        public string dependant_name { get; set; }
        public string? sex { get; set; }
        public DateOnly bdate { get; set; }

        public virtual Employee employee { get; set; }
    }
}
