using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    //var brandsData =
                    //File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    const string brandsData = "[\r\n  {\r\n    \"Id\": 1,\r\n    \"Name\": \"Angular\"\r\n  },\r\n  {\r\n    \"Id\": 2,\r\n    \"Name\": \"NetCore\"\r\n  },\r\n  {\r\n    \"Id\": 3,\r\n    \"Name\": \"VS Code\"\r\n  },\r\n  {\r\n    \"Id\": 4,\r\n    \"Name\": \"React\"\r\n  },\r\n  {\r\n    \"Id\": 5,\r\n    \"Name\": \"Typescript\"\r\n  },\r\n  {\r\n    \"Id\": 6,\r\n    \"Name\": \"Redis\"\r\n  }\r\n]";

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }


                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = "[\r\n  {\r\n    \"Id\": 1,\r\n    \"Name\": \"Boards\"\r\n  },\r\n  {\r\n    \"Id\": 2,\r\n    \"Name\": \"Hats\"\r\n  },\r\n  {\r\n    \"Id\": 3,\r\n    \"Name\": \"Boots\"\r\n  },\r\n  {\r\n    \"Id\": 4,\r\n    \"Name\": \"Gloves\"\r\n  }\r\n]";
                    //File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }


                }
                if (!context.Products.Any())
                {
                    var productsData = "[\r\n  {\r\n    \"Name\": \"Angular Speedster Board 2000\",\r\n    \"Description\": \"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\",\r\n    \"Price\": 200,\r\n    \"PictureUrl\": \"images/products/sb-ang1.png\",\r\n    \"ProductTypeId\": 1,\r\n    \"ProductBrandId\": 1\r\n  },\r\n  {\r\n    \"Name\": \"Green Angular Board 3000\",\r\n    \"Description\": \"Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.\",\r\n    \"Price\": 150,\r\n    \"PictureUrl\": \"images/products/sb-ang2.png\",\r\n    \"ProductTypeId\": 1,\r\n    \"ProductBrandId\": 1\r\n  },\r\n  {\r\n    \"Name\": \"Core Board Speed Rush 3\",\r\n    \"Description\": \"Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.\",\r\n    \"Price\": 180,\r\n    \"PictureUrl\": \"images/products/sb-core1.png\",\r\n    \"ProductTypeId\": 1,\r\n    \"ProductBrandId\": 2\r\n  },\r\n  {\r\n    \"Name\": \"Net Core Super Board\",\r\n    \"Description\": \"Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.\",\r\n    \"Price\": 300,\r\n    \"PictureUrl\": \"images/products/sb-core2.png\",\r\n    \"ProductTypeId\": 1,\r\n    \"ProductBrandId\": 2\r\n  },\r\n  {\r\n    \"Name\": \"React Board Super Whizzy Fast\",\r\n    \"Description\": \"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\",\r\n    \"Price\": 250,\r\n    \"PictureUrl\": \"images/products/sb-react1.png\",\r\n    \"ProductTypeId\": 1,\r\n    \"ProductBrandId\": 4\r\n  },\r\n  {\r\n    \"Name\": \"Typescript Entry Board\",\r\n    \"Description\": \"Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.\",\r\n    \"Price\": 120,\r\n    \"PictureUrl\": \"images/products/sb-ts1.png\",\r\n    \"ProductTypeId\": 1,\r\n    \"ProductBrandId\": 5\r\n  },\r\n  {\r\n    \"Name\": \"Core Blue Hat\",\r\n    \"Description\": \"Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\",\r\n    \"Price\": 10,\r\n    \"PictureUrl\": \"images/products/hat-core1.png\",\r\n    \"ProductTypeId\": 2,\r\n    \"ProductBrandId\": 2\r\n  },\r\n  {\r\n    \"Name\": \"Green React Woolen Hat\",\r\n    \"Description\": \"Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.\",\r\n    \"Price\": 8,\r\n    \"PictureUrl\": \"images/products/hat-react1.png\",\r\n    \"ProductTypeId\": 2,\r\n    \"ProductBrandId\": 4\r\n  },\r\n  {\r\n    \"Name\": \"Purple React Woolen Hat\",\r\n    \"Description\": \"Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\",\r\n    \"Price\": 15,\r\n    \"PictureUrl\": \"images/products/hat-react2.png\",\r\n    \"ProductTypeId\": 2,\r\n    \"ProductBrandId\": 4\r\n  },\r\n  {\r\n    \"Name\": \"Blue Code Gloves\",\r\n    \"Description\": \"Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.\",\r\n    \"Price\": 18,\r\n    \"PictureUrl\": \"images/products/glove-code1.png\",\r\n    \"ProductTypeId\": 4,\r\n    \"ProductBrandId\": 3\r\n  },\r\n  {\r\n    \"Name\": \"Green Code Gloves\",\r\n    \"Description\": \"Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.\",\r\n    \"Price\": 15,\r\n    \"PictureUrl\": \"images/products/glove-code2.png\",\r\n    \"ProductTypeId\": 4,\r\n    \"ProductBrandId\": 3\r\n  },\r\n  {\r\n    \"Name\": \"Purple React Gloves\",\r\n    \"Description\": \"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.\",\r\n    \"Price\": 16,\r\n    \"PictureUrl\": \"images/products/glove-react1.png\",\r\n    \"ProductTypeId\": 4,\r\n    \"ProductBrandId\": 4\r\n  },\r\n  {\r\n    \"Name\": \"Green React Gloves\",\r\n    \"Description\": \"Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.\",\r\n    \"Price\": 14,\r\n    \"PictureUrl\": \"images/products/glove-react2.png\",\r\n    \"ProductTypeId\": 4,\r\n    \"ProductBrandId\": 4\r\n  },\r\n  {\r\n    \"Name\": \"Redis Red Boots\",\r\n    \"Description\": \"Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.\",\r\n    \"Price\": 250,\r\n    \"PictureUrl\": \"images/products/boot-redis1.png\",\r\n    \"ProductTypeId\": 3,\r\n    \"ProductBrandId\": 6\r\n  },\r\n  {\r\n    \"Name\": \"Core Red Boots\",\r\n    \"Description\": \"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\",\r\n    \"Price\": 189.99,\r\n    \"PictureUrl\": \"images/products/boot-core2.png\",\r\n    \"ProductTypeId\": 3,\r\n    \"ProductBrandId\": 2\r\n  },\r\n  {\r\n    \"Name\": \"Core Purple Boots\",\r\n    \"Description\": \"Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.\",\r\n    \"Price\": 199.99,\r\n    \"PictureUrl\": \"images/products/boot-core1.png\",\r\n    \"ProductTypeId\": 3,\r\n    \"ProductBrandId\": 2\r\n  },\r\n  {\r\n    \"Name\": \"Angular Purple Boots\",\r\n    \"Description\": \"Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.\",\r\n    \"Price\": 150,\r\n    \"PictureUrl\": \"images/products/boot-ang2.png\",\r\n    \"ProductTypeId\": 3,\r\n    \"ProductBrandId\": 1\r\n  },\r\n  {\r\n    \"Name\": \"Angular Blue Boots\",\r\n    \"Description\": \"Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.\",\r\n    \"Price\": 180,\r\n    \"PictureUrl\": \"images/products/boot-ang1.png\",\r\n    \"ProductTypeId\": 3,\r\n    \"ProductBrandId\": 1\r\n  }\r\n]";
                    //File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }


                }
                if (!context.DeliveryMethods.Any())
                {
                    var deliveryMethodsData = "[\r\n  {\r\n    \"Id\": 1,\r\n    \"ShortName\": \"UPS1\",\r\n    \"Description\": \"Fastest delivery time\",\r\n    \"DeliveryTime\": \"1-2 Days\",\r\n    \"Price\": 10\r\n  },\r\n  {\r\n    \"Id\": 2,\r\n    \"ShortName\": \"UPS2\",\r\n    \"Description\": \"Get it within 5 days\",\r\n    \"DeliveryTime\": \"2-5 Days\",\r\n    \"Price\": 5\r\n  },\r\n  {\r\n    \"Id\": 3,\r\n    \"ShortName\": \"UPS3\",\r\n    \"Description\": \"Slower but cheap\",\r\n    \"DeliveryTime\": \"5-10 Days\",\r\n    \"Price\": 2\r\n  },\r\n  {\r\n    \"Id\": 4,\r\n    \"ShortName\": \"FREE\",\r\n    \"Description\": \"Free! You get what you pay for\",\r\n    \"DeliveryTime\": \"1-2 Weeks\",\r\n    \"Price\": 0\r\n  }\r\n]";
                    //File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");

                    var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodsData);

                    foreach (var item in deliveryMethods)
                    {
                        context.DeliveryMethods.Add(item);
                    }


                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}