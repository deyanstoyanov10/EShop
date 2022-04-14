namespace EShop.Common.Models.Product
{
    public class ProductRecords
    {
        public class ProductOutputModel
        {
            public int ProductId { get; set; }

            public string Label { get; set; }

            public double Price { get; set; }

            public string Amount
            {
                get
                {
                    return string.Format("{0:C}", this.Price);
                }
            }

            public string? Picture { get; set; }
        }

        public class ProductMessage
        {
            public int ProductId { get; set; }
        }
    }
}
