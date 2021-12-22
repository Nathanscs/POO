using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poo.Api.Controllers.Parsers;
using Poo.Api.Core.Application.ProductAgg.AppServices;
using Poo.Api.Core.Application.ProductAgg.Parsers;
using Poo.Api.Core.Domain.EstoqueAgg.Repositories;
using Poo.Api.Core.Domain.ProductAgg.Repositories;
using Poo.Api.Core.Domain.Shared.Repositories;
using Poo.Api.Core.Infrastructure.EstoqueAgg.Repositories;
using Poo.Api.Core.Infrastructure.ProductAgg.Repositories;
using Poo.Api.Core.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSeq());
builder.Services.AddDbContext<PedidoDbContext>(optionsBuilder =>
{
    optionsBuilder.UseInMemoryDatabase("DB");
});
builder.Services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<PedidoDbContext>());
builder.Services.AddScoped<ProdutoAppService>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IProdutoParseFactory, ProdutoParseFactory>();
builder.Services.AddScoped<ProdutoReportParser>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddMediatR(Assembly.GetEntryAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
