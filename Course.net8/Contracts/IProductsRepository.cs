namespace Course.net8.Contracts;

public interface IProductsRepository
{
    Task DeleteItem(int id);
    Task<List<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task<Product?> UpdateProduct(int id, Product product);
    Task<Product> AddNewProduct(Product product);



}