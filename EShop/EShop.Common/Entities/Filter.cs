namespace EShop.Common.Entities
{
    public class Filter
    {
        public Filter() => this.Options = new HashSet<Option>();

        public int Id { get; set; }

        public string Label { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
