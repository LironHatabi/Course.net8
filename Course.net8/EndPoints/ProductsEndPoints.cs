
namespace Course.net8.EndPoints;

public static class ProductsEndPoints
{
    public static void MapProducts(this WebApplication app)
    {
        var productsGroup = app.MapGroup("products").WithTags("Products");


        productsGroup.MapGet("",GetAllProducts).WithName(nameof(GetAllProducts));
        productsGroup.MapGet("{id:int}",GetProductById).WithName(nameof(GetProductById));
        productsGroup.MapDelete("{id:int}",DeleteItem).WithName(nameof(DeleteItem));
        productsGroup.MapPut("{id:int}",UpdateProduct).WithName(nameof(UpdateProduct));
        productsGroup.MapPost("",AddNewProduct).WithName(nameof(AddNewProduct));
    }

    

    private static async Task<Ok<List<Product>>> GetAllProducts(IProductsRepository repository)
    {
        var result = await repository.GetAllProducts();
        return TypedResults.Ok(result);
    }
    private static async Task<Results<NotFound, Ok<Product>>> GetProductById(int id, IProductsRepository repository)
    {
        var result = await repository.GetProductById(id);
        if (result == null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(result);
    }
    private static  async Task<Results<NotFound, Ok<Product>>> DeleteItem(int id, IProductsRepository repository)
     {
         var result = await repository.GetProductById(id);
         if (result == null)
         {
             return TypedResults.NotFound();
         }
         await repository.DeleteItem(id);
         return TypedResults.Ok(result);
     }
    private static  async Task<Results<NotFound, Ok<Product>>> UpdateProduct(int id, Product product, IProductsRepository repository)
     {
         var result = await repository.GetProductById(id);
         if (result == null)
         {
             return TypedResults.NotFound();
         }

         await repository.UpdateProduct(id, product);

         return TypedResults.Ok(result);
     }
    private static  async Task<Created<Product>> AddNewProduct(Product product, IProductsRepository repository)
    {
        var addedProduct = await repository.AddNewProduct(product);
        return TypedResults.Created($"api/products/{addedProduct.Id}", addedProduct);
    }
}