namespace EShop.Common.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public string FilePath { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
