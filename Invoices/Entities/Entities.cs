namespace Invoices.Entities;

public class InvoiceEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string To { get; set; }
    public int Amount { get; set; }
    public bool Paid { get; set; } = false;
}

public class InvoiceRepository
{
    public static Dictionary<string, List<InvoiceEntity>> Invoices = new Dictionary<string, List<InvoiceEntity>>();
}