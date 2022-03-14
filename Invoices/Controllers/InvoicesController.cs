using Invoices.Entities;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers;

[ApiController]
[Route("{studentId}/[controller]")]
public class InvoicesController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<InvoiceEntity>> Get(string studentId)
    {
        if (!InvoiceRepository.Invoices.ContainsKey(studentId)) return NotFound();

        return Ok(InvoiceRepository.Invoices[studentId]);
    }
    
    [HttpPost]
    public ActionResult<InvoiceEntity> Create(string studentId, InvoiceCreateModel invoice)
    {
        if (!InvoiceRepository.Invoices.ContainsKey(studentId)) return NotFound();

        InvoiceEntity createdEntity = new InvoiceEntity
        {
            Id = Guid.NewGuid(),
            Amount = invoice.Amount,
            To = invoice.To
        };

        InvoiceRepository.Invoices[studentId].Add(createdEntity);
        return createdEntity;
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult Destroy(string studentId, Guid id)
    {
        if (!InvoiceRepository.Invoices.ContainsKey(studentId)) return NotFound();

        InvoiceEntity c = InvoiceRepository.Invoices[studentId].Find(c => c.Id == id);
        if (c == null) return NotFound();

        InvoiceRepository.Invoices[studentId].Remove(c);
        return NoContent();
    }
    
    [HttpPost]
    [Route("{id:guid}/Paid")]
    public ActionResult<InvoiceEntity> TogglePayment(string studentId, Guid id)
    {
        if (!InvoiceRepository.Invoices.ContainsKey(studentId)) return NotFound();

        InvoiceEntity c = InvoiceRepository.Invoices[studentId].Find(c => c.Id == id);
        if (c == null) return NotFound();

        c.Paid = !c.Paid;
        return Ok();
    }
}