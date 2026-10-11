using DalFacade;
using DalFacade.DO;
using System.Linq;
using System.Collections.Generic;

namespace Dal;

public class DalProduct : IProduct
{
    /// <summary>
    /// מוסיף מוצר חדש לרשימה
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="Exception"></exception>
    public void Add(Product product)
    {
        if (Read(product.Id) != null)
            throw new Exception($"Product with ID {product.Id} already exists.");
        DataSource.Products.Add(product);
    }
    /// <summary>
    /// מחזיר מוצר לפי מזהה
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Product? Read(int id)
    {
        return DataSource.Products.FirstOrDefault(p => p?.Id == id);
    }
    /// <summary>
    /// מחזיר את כל המוצרים ברשימה
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Product> ReadAll()
    {
        return DataSource.Products.Where(p => p.HasValue).Select(p => p.Value);
    }
    /// <summary>
    /// מעדכן פרטי מוצר קיים ברשימה
    /// </summary>
    /// <param name="product"></param>
    /// <exception cref="Exception"></exception>
    public void Update(Product product)
    {
        var existing = Read(product.Id);
        if (existing == null)
            throw new Exception($"Product with ID {product.Id} does not exist.");
        DataSource.Products.Remove(existing.Value);
        DataSource.Products.Add(product);
    }
    /// <summary>
    /// מוחק מוצר קיים מהמערכת לפי מזה
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Product with ID {id} does not exist.");
        DataSource.Products.Remove(existing.Value);
    }
}