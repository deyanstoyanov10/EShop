namespace EShop.Data.Seeder
{
    using Common.Entities;

    public class Seeder
    {
        private readonly ApplicationDbContext _data;
        private bool flag = true;
        public Seeder(ApplicationDbContext data) => _data = data;

        public void Seed()
        {
            if (flag)
            {
                return;
            }

            var category1 = new Category() { Name = "Category1" };
            var category2 = new Category() { Name = "Category2" };
            var category3 = new Category() { Name = "Category3" };
            var category4 = new Category() { Name = "Category4" };

            _data.Categories.AddRange(category1, category2, category3, category4);
            _data.SaveChanges();

            var filter1 = new Filter() { Label = "TestFilter1", Category = category1 };
            var filter2 = new Filter() { Label = "TestFilter2", Category = category1 };

            _data.Filters.AddRange(filter1, filter2);
            _data.SaveChanges();

            var f1option1 = new Option() { Name = "Filter1TestOption1", Filter = filter1 };
            var f1option2 = new Option() { Name = "Filter1TestOption2", Filter = filter1 };
            var f1option3 = new Option() { Name = "Filter1TestOption3", Filter = filter1 };
            var f1option4 = new Option() { Name = "Filter1TestOption4", Filter = filter1 };

            _data.Options.AddRange(f1option1, f1option2, f1option3, f1option4);

            var f2option1 = new Option() { Name = "Filter2TestOption1", Filter = filter2 };
            var f2option2 = new Option() { Name = "Filter2TestOption2", Filter = filter2 };
            var f2option3 = new Option() { Name = "Filter2TestOption3", Filter = filter2 };
            var f2option4 = new Option() { Name = "Filter2TestOption4", Filter = filter2 };

            _data.Options.AddRange(f2option1, f2option2, f2option3, f2option4);
            _data.SaveChanges();

            var product1 = new Product() { Label = "TestProduct1", Added = DateTime.UtcNow, Status = true, Category = category1 };
            var product2 = new Product() { Label = "TestProduct2", Added = DateTime.UtcNow, Status = true, Category = category1 };
            var product3 = new Product() { Label = "TestProduct3", Added = DateTime.UtcNow, Status = true, Category = category1 };

            _data.Products.AddRange(product1, product2, product3);
            _data.SaveChanges();

            var productOption1 = new ProductOption() { Product = product1, Option = f1option1 };
            var productOption2 = new ProductOption() { Product = product1, Option = f2option1 };

            var productOption3 = new ProductOption() { Product = product2, Option = f1option1 };
            var productOption4 = new ProductOption() { Product = product2, Option = f2option1 };

            var productOption5 = new ProductOption() { Product = product3, Option = f1option1 };

            _data.ProductOptions.AddRange(productOption1, productOption2, productOption3, productOption4, productOption5);
            _data.SaveChanges();
        }
    }
}
