namespace EShop.Data.Seeder
{
    using Common.Entities;

    public class Seeder
    {
        private readonly ApplicationDbContext _data;
        private bool flag = false;
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
            var filter3 = new Filter() { Label = "TestFilter3", Category = category1 };

            _data.Filters.AddRange(filter1, filter2, filter3);
            _data.SaveChanges();

            var f1option1 = new Option() { Name = "Filter1Option1", Filter = filter1 };
            var f1option2 = new Option() { Name = "Filter1Option2", Filter = filter1 };
            var f1option3 = new Option() { Name = "Filter1Option3", Filter = filter1 };
            var f1option4 = new Option() { Name = "Filter1Option4", Filter = filter1 };

            _data.Options.AddRange(f1option1, f1option2, f1option3, f1option4);

            var f2option1 = new Option() { Name = "Filter2Option1", Filter = filter2 };
            var f2option2 = new Option() { Name = "Filter2Option2", Filter = filter2 };
            var f2option3 = new Option() { Name = "Filter2Option3", Filter = filter2 };
            var f2option4 = new Option() { Name = "Filter2Option4", Filter = filter2 };

            _data.Options.AddRange(f2option1, f2option2, f2option3, f2option4);
            _data.SaveChanges();

            var f3option1 = new Option() { Name = "Filter3Option1", Filter = filter3 };
            var f3option2 = new Option() { Name = "Filter3Option2", Filter = filter3 };
            var f3option3 = new Option() { Name = "Filter3Option3", Filter = filter3 };
            var f3option4 = new Option() { Name = "Filter3Option4", Filter = filter3 };

            _data.Options.AddRange(f3option1, f3option2, f3option3, f3option4);
            _data.SaveChanges();

            var product1 = new Product() { Label = "TestProduct1", Price = 100, Description = "Test Drecription", Added = DateTime.UtcNow, Active = true, Category = category1 };
            var product2 = new Product() { Label = "TestProduct2", Price = 200, Description = "Test Drecription", Added = DateTime.UtcNow, Active = true, Category = category1 };
            var product3 = new Product() { Label = "TestProduct3", Price = 300, Description = "Test Drecription", Added = DateTime.UtcNow, Active = true, Category = category1 };
            var product4 = new Product() { Label = "TestProduct4", Price = 400, Description = "Test Drecription", Added = DateTime.UtcNow, Active = true, Category = category1 };
            var product5 = new Product() { Label = "TestProduct5", Price = 500, Description = "Test Drecription", Added = DateTime.UtcNow, Active = true, Category = category1 };
            var product6 = new Product() { Label = "TestProduct6", Price = 600, Description = "Test Drecription", Added = DateTime.UtcNow, Active = true, Category = category1 };

            _data.Products.AddRange(product1, product2, product3, product4, product5, product6);
            _data.SaveChanges();

            var picture1 = new Picture() { FilePath = "https://localhost:7139/images/items/1.jpg", Position = 0, Product = product1 };
            var picture2 = new Picture() { FilePath = "https://localhost:7139/images/items/2.jpg", Position = 1, Product = product1 };
            var picture3 = new Picture() { FilePath = "https://localhost:7139/images/items/3.jpg", Position = 2, Product = product1 };
            var picture4 = new Picture() { FilePath = "https://localhost:7139/images/items/4.jpg", Position = 3, Product = product1 };
            var picture5 = new Picture() { FilePath = "https://localhost:7139/images/items/5.jpg", Position = 4, Product = product1 };

            _data.Pictures.AddRange(picture1, picture2, picture3, picture4, picture5);
            _data.SaveChanges();

            picture1 = new Picture() { FilePath = "https://localhost:7139/images/items/1.jpg", Position = 3, Product = product2 };
            picture2 = new Picture() { FilePath = "https://localhost:7139/images/items/2.jpg", Position = 0, Product = product2 };
            picture3 = new Picture() { FilePath = "https://localhost:7139/images/items/3.jpg", Position = 4, Product = product2 };
            picture4 = new Picture() { FilePath = "https://localhost:7139/images/items/4.jpg", Position = 3, Product = product2 };
            picture5 = new Picture() { FilePath = "https://localhost:7139/images/items/5.jpg", Position = 1, Product = product2 };

            _data.Pictures.AddRange(picture1, picture2, picture3, picture4, picture5);
            _data.SaveChanges();

            picture1 = new Picture() { FilePath = "https://localhost:7139/images/items/1.jpg", Position = 2, Product = product3 };
            picture2 = new Picture() { FilePath = "https://localhost:7139/images/items/2.jpg", Position = 6, Product = product3 };
            picture3 = new Picture() { FilePath = "https://localhost:7139/images/items/3.jpg", Position = 4, Product = product3 };
            picture4 = new Picture() { FilePath = "https://localhost:7139/images/items/4.jpg", Position = 1, Product = product3 };
            picture5 = new Picture() { FilePath = "https://localhost:7139/images/items/5.jpg", Position = 5, Product = product3 };

            _data.Pictures.AddRange(picture1, picture2, picture3, picture4, picture5);
            _data.SaveChanges();

            picture1 = new Picture() { FilePath = "https://localhost:7139/images/items/1.jpg", Position = 2, Product = product4 };
            picture2 = new Picture() { FilePath = "https://localhost:7139/images/items/2.jpg", Position = 5, Product = product4 };
            picture3 = new Picture() { FilePath = "https://localhost:7139/images/items/3.jpg", Position = 2, Product = product4 };
            picture4 = new Picture() { FilePath = "https://localhost:7139/images/items/4.jpg", Position = 1, Product = product4 };
            picture5 = new Picture() { FilePath = "https://localhost:7139/images/items/5.jpg", Position = 0, Product = product4 };

            _data.Pictures.AddRange(picture1, picture2, picture3, picture4, picture5);
            _data.SaveChanges();

            picture1 = new Picture() { FilePath = "https://localhost:7139/images/items/1.jpg", Position = 2, Product = product5 };
            picture2 = new Picture() { FilePath = "https://localhost:7139/images/items/2.jpg", Position = 2, Product = product5 };
            picture3 = new Picture() { FilePath = "https://localhost:7139/images/items/3.jpg", Position = 7, Product = product5 };
            picture4 = new Picture() { FilePath = "https://localhost:7139/images/items/4.jpg", Position = 3, Product = product5 };
            picture5 = new Picture() { FilePath = "https://localhost:7139/images/items/5.jpg", Position = 0, Product = product5 };

            _data.Pictures.AddRange(picture1, picture2, picture3, picture4, picture5);
            _data.SaveChanges();

            picture1 = new Picture() { FilePath = "https://localhost:7139/images/items/1.jpg", Position = 7, Product = product6 };
            picture2 = new Picture() { FilePath = "https://localhost:7139/images/items/2.jpg", Position = 2, Product = product6 };
            picture3 = new Picture() { FilePath = "https://localhost:7139/images/items/3.jpg", Position = 0, Product = product6 };
            picture4 = new Picture() { FilePath = "https://localhost:7139/images/items/4.jpg", Position = 1, Product = product6 };
            picture5 = new Picture() { FilePath = "https://localhost:7139/images/items/5.jpg", Position = 9, Product = product6 };

            _data.Pictures.AddRange(picture1, picture2, picture3, picture4, picture5);
            _data.SaveChanges();

            var productOption1 = new ProductOption() { Product = product1, Option = f1option1 };
            var productOption2 = new ProductOption() { Product = product1, Option = f2option1 };
            var productOption3 = new ProductOption() { Product = product1, Option = f3option1 };

            var productOption4 = new ProductOption() { Product = product2, Option = f1option1 };
            var productOption5 = new ProductOption() { Product = product2, Option = f2option1 };

            var productOption6 = new ProductOption() { Product = product3, Option = f1option1 };

            var productOption7 = new ProductOption() { Product = product4, Option = f1option1 };
            var productOption8 = new ProductOption() { Product = product4, Option = f3option1 };
            var productOption9 = new ProductOption() { Product = product4, Option = f2option2 };

            _data.ProductOptions.AddRange(productOption1, productOption2, productOption3, productOption4, productOption5, productOption6, productOption7, productOption8, productOption9);
            _data.SaveChanges();
        }
    }
}
