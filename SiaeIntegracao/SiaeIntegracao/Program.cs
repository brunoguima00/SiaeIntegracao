using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SiaeIntegracao.Components;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;
using SiaeIntegracao.src.Infrastructure.Repositories;
using SiaeIntegracao.src.Services;
using System.Text;

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

// JWT Authentication
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true; // Em prod, mude para true
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


//Repositores
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IDocumentsType, DocumentsTypeRepository>();
builder.Services.AddScoped<IEntryTypeRepository, EntryTypeRepository>();
builder.Services.AddScoped<ICapaPcOnlineRepository, CapaPcOnlineRepository>();
builder.Services.AddScoped<IDocumentsRepository, DocumentsRepository>();
//UseCases
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<AuthUserUseCase>();
builder.Services.AddScoped<GetAllowedUnitsUseCase>();
builder.Services.AddScoped<GetDocumentsTypeUseCase>();
builder.Services.AddScoped<GetAllEntryTypeByProjetoUseCase>();
builder.Services.AddScoped<CreateCapaPcUseCase>();
builder.Services.AddScoped<GetCapaPcOnlineByDate>();
builder.Services.AddScoped<GetDocumentsByDateUseCase>();
builder.Services.AddScoped<CreateDocumentsUseCase>();
builder.Services.AddScoped<DeleteDocumentByIdUseCase>();
builder.Services.AddScoped<UpdateCapaPcByDateUseCase>();
builder.Services.AddScoped<UpdateDocumentsStatusByDateUseCase>();
builder.Services.AddScoped<DeleteCapaPcByIdUseCase>();

//Others
builder.Services.AddScoped<UserSession>();

builder.Services.AddScoped(sp =>
{
    // Busca as três dependências necessárias no contêiner do ASP.NET
    var httpClient = sp.GetRequiredService<HttpClient>();
    var storage = sp.GetRequiredService<ProtectedLocalStorage>();
    var navigation = sp.GetRequiredService<NavigationManager>();

    // Cria a ApiService passando os três argumentos na ordem correta
    return new ApiService(httpClient, storage, navigation);
});

builder.Services.AddScoped(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();

    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    };

    // Usa a URL base de onde o site está rodando no momento
    return new HttpClient(handler) { BaseAddress = new Uri(navigationManager.BaseUri) };
});



var app = builder.Build();

var supportedCultures = new[] { "pt-BR" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

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
