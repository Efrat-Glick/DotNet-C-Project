namespace Dal;

using DalFacade.DO;
using DO;
/// <summary>
/// מחלקה סטטית המרכזת את מקור הנתונים בזיכרון עבור כל ישויות המערכת
/// </summary>
internal static class DataSource
{
    /// <summary>
    /// רשימת הלקוחות במערכת
    /// </summary>
    internal static List<Customer?> Customers { get; } = [];
    /// <summary>
    /// רשימת המוצרים במערכת
    /// </summary>
    internal static List<Product?> Products { get; } = [];
    /// <summary>
    /// רשימת ההזמנות במערכת
    /// </summary>
    internal static List<Order?> Orders { get; } = [];
}