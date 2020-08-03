using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using Shopy.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Persistance.Context
{
    public class ShopyDbSeeder : IDbSeeder
    {
        private readonly IRepository<Product> productRepo;
        private readonly IUnitOfWork unitOfWork;

        public ShopyDbSeeder(IRepository<Product> productRepo, IUnitOfWork unitOfWork)
        {
            this.productRepo = productRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task Seed()
        {
            //define products
            var products = GetProducts();

            //define categories
            var tShirts = new Category("T-shirts", "T-shirts");
            var jackets = new Category("Jackets", "Jackets");
            var footwear = new Category("Footwear", "Footwear");
            var shoes = new Category("Shoes", "Shoes");
            var clothes = new Category("Clothes", "Clothes");

            //products categories
            products[0].AddCategory(footwear);
            products[0].AddCategory(shoes);

            products[1].AddCategory(jackets);
            products[1].AddCategory(clothes);

            products[2].AddCategory(jackets);
            products[2].AddCategory(clothes);

            products[3].AddCategory(jackets);
            products[3].AddCategory(clothes);

            products[4].AddCategory(jackets);
            products[4].AddCategory(clothes);

            products[5].AddCategory(footwear);
            products[5].AddCategory(shoes);

            products[6].AddCategory(jackets);
            products[6].AddCategory(tShirts);

            products[7].AddCategory(clothes);
            products[7].AddCategory(tShirts);

            products[8].AddCategory(clothes);
            products[8].AddCategory(tShirts);

            products[9].AddCategory(clothes);
            products[9].AddCategory(tShirts);

            products[10].AddCategory(clothes);
            products[10].AddCategory(jackets);

            products[11].AddCategory(footwear);
            products[11].AddCategory(shoes);

            products[12].AddCategory(footwear);
            products[12].AddCategory(shoes);

            products[13].AddCategory(clothes);
            products[13].AddCategory(tShirts);

            //add products
            await productRepo.AddRange(products);

            //save
            await unitOfWork.Save();
        }

        private static Product[] GetProducts()
        {
            var products = new[]
            {
                //0
                new Product
                (
                    "White sneackers addidas",
                    "White sneackers addidas",
                    100.5m,
                    Brand.Active,
                    new [] { Size.Xs, Size.S, Size.M }
                ),
                //1
                new Product
                (
                    "T-shirts for boys",
                    "Blue yellow and black shirst",
                    40m,
                    Brand.Nike,
                    new [] { Size.S, Size.L, Size.M }
                ),
                //2
                new Product
                (
                    "Jackets",
                    "Green jackets for a man",
                    140.25m,
                    Brand.Rebook,
                    new [] { Size.S, Size.M }
                    ),
                //3
                new Product
                (
                    "Fancy jackets",
                    "Brown and black fancy jackets",
                    120.5m,
                    Brand.Puma,
                    new [] { Size.L, Size.Xl }
                ),
                //4
                new Product
                (
                    "Winter jacket black",
                    "Winter jacket black",
                    130.5m,
                    Brand.Addidas,
                    new [] { Size.S, Size.L }
                ),
                //5
                new Product
                (
                    "Sneakers",
                    "Original white addidas sneakers",
                    90.5m,
                    Brand.Puma,
                    new [] { Size.L, Size.Xl }
                ),
                //6
                new Product
                (
                    "T-shirt black jacket kit",
                    "-shirt black jacket kit",
                    80.5m,
                    Brand.Addidas,
                    new [] { Size.S, Size.L, Size.Xs }
                ),
                //7
                new Product
                (
                    "Girls sweat rose shirts",
                    "Girls sweat rose shirts",
                    20.5m,
                    Brand.Rebook,
                    new [] { Size.S, Size.Xl }
                ),
                //8
                new Product
                (
                    "Thirts white and blue",
                    "Thirts white and blue",
                    22.5m,
                    Brand.Active,
                    new [] { Size.S, Size.M, Size.Xl }
                ),
                //9
                new Product
                (
                    "Tshrits rozes for women",
                    "Tshrits rozes for women",
                    23.5m,
                    Brand.Nike,
                    new [] { Size.L, Size.Xl }
                ),
                //10
                new Product
                (
                    "Suits",
                    "Nice suits for a real mans",
                    130.5m,
                    Brand.Addidas,
                    new [] { Size.S, Size.Xl }
                ),
                //11
                new Product
                (
                    "Brown man shoes",
                    "Elegant shoes for all part of the day",
                    152.5m,
                    Brand.Nike,
                    new [] { Size.S, Size.Xl }
                ),
                //12
                new Product
                (
                    "Black man shoes",
                    "Elegant shoes for all part of the day",
                    150.5m,
                    Brand.Active,
                    new [] { Size.S, Size.M, Size.Xl }
                ),
                //13
                new Product
                (
                    "Elegant polo shirts",
                    "Elegant polo shirts",
                    37.5m,
                    Brand.Rebook,
                    new [] { Size.S, Size.M, Size.L }
                )
            };


            products[0].GetType().GetProperty("ExternalId").SetValue(products[0], new Guid("0f485e38-92d5-49f0-8ed3-b2550f2f04f5"));
            products[1].GetType().GetProperty("ExternalId").SetValue(products[1], new Guid("1bc0dae4-b4f1-4144-b2f5-607f5e685767"));
            products[2].GetType().GetProperty("ExternalId").SetValue(products[2], new Guid("1e01864c-79a4-4af2-a99f-0398e583349e"));
            products[3].GetType().GetProperty("ExternalId").SetValue(products[3], new Guid("41ec1d4a-372b-4774-af20-21be451a2c99"));
            products[4].GetType().GetProperty("ExternalId").SetValue(products[4], new Guid("47aa7d6a-a178-4c2d-8812-9218db301f39"));
            products[5].GetType().GetProperty("ExternalId").SetValue(products[5], new Guid("57066b95-3265-47f3-91bd-bbbb26d8359c"));
            products[6].GetType().GetProperty("ExternalId").SetValue(products[6], new Guid("67542922-4b0c-4e5a-9a0f-753798747815"));
            products[7].GetType().GetProperty("ExternalId").SetValue(products[7], new Guid("a5779a04-5fa6-42e3-8793-8f8569922bbc"));
            products[8].GetType().GetProperty("ExternalId").SetValue(products[8], new Guid("ab52ab5b-3dea-4b4b-8436-2de9ef8eb346"));
            products[9].GetType().GetProperty("ExternalId").SetValue(products[9], new Guid("c4791738-9b3f-4828-9303-f50d9e1dde01"));
            products[10].GetType().GetProperty("ExternalId").SetValue(products[10], new Guid("e5f5d746-6c5d-4f3d-8e72-d25265e48b5b"));
            products[11].GetType().GetProperty("ExternalId").SetValue(products[11], new Guid("ec59112c-71bf-429d-9036-110c640bc9e5"));
            products[12].GetType().GetProperty("ExternalId").SetValue(products[12], new Guid("f562c840-cc8d-414a-aeeb-eec8a2602db6"));
            products[13].GetType().GetProperty("ExternalId").SetValue(products[13], new Guid("fe384831-ef32-483f-a4b2-6d8796949a1d"));

            return products;
        }

    }
}