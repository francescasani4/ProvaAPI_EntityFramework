using ProvaAPI_EntityFramework.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// permette di configurare il contesto 
//builder.Services.AddDbContext<MyDbContext>(); 

// Permette di aggiungere degli scopi 
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BookRepository>();
/*builder.Services.AddScoped<LoanRepository>();*/
builder.Services.AddSingleton<FakeDatabase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

