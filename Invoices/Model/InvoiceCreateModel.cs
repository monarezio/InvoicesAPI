using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Invoices.Model;

public class InvoiceCreateModel
{
    [Required] public string To { get; set; }

    [Required] [Range(0, Int32.MaxValue)] public int Amount { get; set; }
}