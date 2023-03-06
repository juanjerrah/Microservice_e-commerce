using Catalog.Api.Models;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        var existProduct = productCollection.Find(p => true).Any();

        if (!existProduct)
        {
            productCollection.InsertManyAsync(GetMyProducts());
        }
    }

    private static IEnumerable<Product> GetMyProducts()
    {
        return new List<Product>()
        {
            new ()
            {
                Id = "64064841baa94574af99d589",
                Name = "Lapis",
                Description = "Um lapis bonito",
                Category = "Papelaria",
                Price = 10
            },
            new ()
            {
                Id = "640648adb83509d958024197",
                Name = "Caneta",
                Description = "Uma Caneta legal",
                Category = "Papelaria",
                Price = 10
            }
        };
    }
}