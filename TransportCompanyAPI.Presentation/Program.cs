using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Repositories;
using TransportCompanyAPI.Service.Abstractions;
using TransportCompanyAPI.Service.Services;

var builder = WebApplication.CreateBuilder(args);
// ����������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();
builder.Services.AddTransient<IServiceManager, ServiceManager>();

var app = builder.Build();

app.UseCors(options =>
    options.WithOrigins("https://localhost:3000") // ���� ����� �������� ������ � �������
    .AllowAnyMethod()
    .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
