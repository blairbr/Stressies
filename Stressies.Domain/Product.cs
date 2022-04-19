namespace Stressies.Domain
{
    public class Product : BaseResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
    }
}
