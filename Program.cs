using ToDoApp.Components;
using ToDoApp.Repository;

var builder = WebApplication.CreateBuilder(args);  // = static void Main(String[] args) 

// Add services to the container. 
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); 

//Dependecy Injection // Scope = Neue Instanz pro Anfrage. 
builder.Services.AddScoped<ToDoItemRepository>(serviceProvider =>
    new ToDoItemRepository(builder.Configuration.GetConnectionString("DefaultConnection")) // ConnectionString aus appsettings.json
);

var app = builder.Build();  // Baut die App zusammen 

// Middleware HTTP Request implementieren...
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // sorgt für eine sichere Verbindung 


app.UseAntiforgery();

app.MapStaticAssets();  // Stellt statische Dateien (Css,Js) bererit
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Startet AppServer, wartet auf Anfrage
app.Run(); 
