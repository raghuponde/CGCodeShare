
inside the project all one interface like this 

  public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<List<Product>> GetByCategoryAsync(int categoryId);
}

Now add one class in the project with the name ProductRepository and implement above interface here 
