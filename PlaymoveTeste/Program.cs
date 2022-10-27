using Microsoft.EntityFrameworkCore;
using PlaymoveTeste.DataContext;
using PlaymoveTeste.Repositorie;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles) ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Pegando string de conexao com o banco de dados a partir do arquivo .config
string SqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(SqlConnection));

//Incluindo injeção de Dependencias
builder.Services.AddScoped<IFornecedoresRepositorie, FornecedoresRepostorie>();
builder.Services.AddScoped<IEmpresasRepositorie, EmpresasRepositorie>();
builder.Services.AddScoped<IFornecedoresTelefonesRepositorie, FornecedoresTelefonesRepositorie>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();
