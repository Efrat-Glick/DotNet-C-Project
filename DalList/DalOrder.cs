namespace Dal;

using DalFacade;
using DO;

/// <summary>
/// מימוש מחלקת ה-DAL עבור ישות הזמנה (Order) באמצעות רשימה בזיכרון
/// </summary>
public class DalOrder : IOrder
{
    /// <summary>
    /// מוסיף הזמנה חדשה לרשימה בזיכרון
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int Add(Order order)
    {
        if (DataSource.Orders.Any(o => o?.Id == order.Id))
            throw new Exception($"Order with ID {order.Id} already exists.");

        DataSource.Orders.Add(order);
        return order.Id;
    }
    /// <summary>
    /// מחזיר הזמנה לפי מזהה
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    public Order? Read(int id)
    {
        return DataSource.Orders.FirstOrDefault(o => o?.Id == id);
    }
    /// <summary>
    /// מחזיר את כל ההזמנות ברשימה
    /// </summary>
    /// <returns></returns>

    public IEnumerable<Order> ReadAll()
    {
        return DataSource.Orders.Where(o => o.HasValue).Select(o => o.Value);
    }
    /// <summary>
    /// מעדכן פרטי הזמנה קיימת ברשימה בזיכרון
    /// </summary>
    /// <param name="order"></param>
    /// <exception cref="Exception"></exception>
    public void Update(Order order)
    {
        var existing = Read(order.Id);
        if (existing == null)
            throw new Exception($"Order with ID {order.Id} does not exist.");

        DataSource.Orders.Remove(existing);
        DataSource.Orders.Add(order);
    }
    /// <summary>
    /// מוחק פרטי הזמנה מהמערכת לפי מזהה
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Order with ID {id} does not exist.");

        DataSource.Orders.Remove(existing);
    }
}