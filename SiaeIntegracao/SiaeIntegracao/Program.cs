using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.Components;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;
using SiaeIntegracao.src.Infrastructure.Repositories;
using SiaeIntegracao.src.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Adiciona o suporte aos controller
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

//Repositores
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IDocumentsType, DocumentsTypeRepository>();
builder.Services.AddScoped<IEntryTypeRepository, EntryTypeRepository>();
builder.Services.AddScoped<ICapaPcOnlineRepository, CapaPcOnlineRepository>();
//UseCases
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<AuthUserUseCase>();
builder.Services.AddScoped<GetAllowedUnitsUseCase>();
builder.Services.AddScoped<GetDocumentsTypeUseCase>();
builder.Services.AddScoped<GetAllEntryTypeByProjetoUseCase>();
builder.Services.AddScoped<CreateCapaPcUseCase>();
builder.Services.AddScoped<GetCapaPcOnlineByDate>();
//Others
builder.Services.AddScoped<UserSession>();

builder.Services.AddScoped(sp =>
{
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    };
    return new HttpClient(handler) { BaseAddress = new Uri("https://localhost:7157/") };
});


var app = builder.Build();

//Habilita o Swager, precisa de biblioteca para funcionar
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SiaeIntegracao.Client._Imports).Assembly);

// Garanta que as rotas dos seus controllers sejam mapeadas
app.MapControllers();

app.Run();
