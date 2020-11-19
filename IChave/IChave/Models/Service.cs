namespace IChave.Models
{
    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double low_price { get; set; }
        public double high_price { get; set; }

        public Service()
        {
        }
    }
}