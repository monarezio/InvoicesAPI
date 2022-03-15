using Invoices.Entities;

string[] users = File.ReadAllLines("users.csv");
foreach (var user in users)
{
    var item = user.Split(";");
    var mockedData = new List<InvoiceEntity>();
    mockedData.Add(new InvoiceEntity()
    {
        To = "EDUCAnet – gymnázium, SOŠ a ZŠ Praha s.r.o",
        Amount = 1000
    });
    mockedData.Add(new InvoiceEntity()
    {
        To = "Alza.cz a.s.",
        Amount = 200
    });
    InvoiceRepository.Invoices.Add(item[1], mockedData);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();