namespace Dal;

using DalFacade;
using DO;
using System.Data.Common;

/// <summary>
/// מימוש מחלקת ה-DAL עבור ישות לקוח (Customer) באמצעות רשימה בזיכרון
/// </summary>
public class DalCustomer : ICustomer
{
    /// <summary>
    /// מוסיף לקוח חדש לרשימת הלקוחות בזיכרון
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int Add(Customer customer)
    {
        if (DataSource.Customers.Any(c => c?.Id == customer.Id))
            throw new Exception($"Customer with ID {customer.Id} already exists.");
        DataSource.Customers.Add(customer);
        return customer.Id;
    }
    /// <summary>
    /// מחזיר לקוח לפי מזהה
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Customer? Read(int id)
    {
        return DataSource.Customers.FirstOrDefault(c => c?.Id == id);
    }
    /// <summary>
    /// מחזיר את כל הלקוחות ברשימה
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Customer?> ReadAll()
    {
        return DataSource.Customers.Select(c => c);
    }
    /// <summary>
    /// מעדכן פרטי לקוח קיים ברשימה
    /// </summary>
    /// <param name="customer"></param>
    /// <exception cref="Exception"></exception>
    public void Update(Customer customer)
    {
        var existing = Read(customer.Id);
        if (existing == null)
            throw new Exception($"Customer with ID {customer.Id} does not exist.");
        DataSource.Customers.Remove(existing);
        DataSource.Customers.Add(customer);
    }
    /// <summary>
    /// מוחק לקוח קיים מהמערכת לפי מזהה
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Customer with ID {id} does not exist.");
        DataSource.Customers.Remove(existing);
    }
}