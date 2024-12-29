namespace Course.net8.Services;

public class ProductsRepository : IProductsRepository
{
    private  List<Product> _products = new List<Product>();
    public ProductsRepository()
    {
        _products.Add(
            new Product
            {
                Id = 1, 
                Name= "coffee",
                Producer = "elit",
                Amount = 9,
                Price = 12.6m,
                Description = "good coffee"
            });
    }
    public async Task<List<Product>> GetAllProducts()
    {
        await Task.Delay(1000);
        return _products;
    }
    public async Task<Product?> GetProductById(int id)
    {
        await Task.Delay(1000);
        var item=this._products.FirstOrDefault(x=>x.Id==id);
        if (item == null)
        {
            return null;
        }
        return item;
        
    }
    public async Task DeleteItem(int id)
    {
        
        await Task.Delay(1000);
        var item=this._products.FirstOrDefault(x=>x.Id==id);
        if (item != null)
        {
            this._products.Remove(item);
        }
    }

   public async Task<Product?> UpdateProduct(int id, Product product)
    {
        var item = this._products.First(x => x.Id == id);
        if (item == null)
        {
            return null;
        }
        var itemToUpdate = item with{Amount = product.Amount , Description = product.Description, Price = product.Price, Name = product.Name, Producer = product.Producer};

       _products = _products.Select(x =>
        {
            if (x.Id == id)
            {
                return itemToUpdate;
            }
            else
            {
                return x;
            }
        }).ToList();
        return itemToUpdate;
    }


    public Task<Product> AddNewProduct(Product product)
    { 
        var lastId = _products.Max(x=>x.Id) + 1;
        var productToInsert = product with{Id = lastId}; 
        _products.Add(productToInsert);
        return Task.FromResult(productToInsert);
    }



}


// public class ProductsRepository2 : IProductsRepository
// {
//     public async Task<List<Product>> GetAllProducts()
//     {
//         return new List<Product>()
//         {
//             new Product
//             {
//                 Id = 2, 
//                 Name= "2",
//                 Producer = "2",
//                 Amount = 9,
//                 Price = 12.6m,
//                 Description = "good coffee"
//             },
//         };
//     }
// }