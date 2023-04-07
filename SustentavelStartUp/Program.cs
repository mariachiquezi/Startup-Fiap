var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//dizendo que aplicação vai trabalhar com controller e view
builder.Services.AddControllersWithViews();

//cria aplicação web
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
//usa arquivos estaticos
app.UseStaticFiles();

//usa roteamento
app.UseRouting();

//usa autorizacao
app.UseAuthorization();

//usa mapeamento de rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//por fim ele executa
app.Run();
