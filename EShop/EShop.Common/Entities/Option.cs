namespace EShop.Common.Entities
{
    public class Option
    {
        public Option() => this.ProductOptions = new HashSet<ProductOption>();

        public int Id { get; set; }

        public string Name { get; set; }

        public int FilterId { get; set; }

        public Filter Filter { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}
