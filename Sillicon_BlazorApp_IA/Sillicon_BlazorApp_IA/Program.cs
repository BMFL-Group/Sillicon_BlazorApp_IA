using Blazored.LocalStorage;
using Infrastructure.Hubs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Sillicon_BlazorApp_IA.Components;
using Sillicon_BlazorApp_IA.Components.Account;
using Sillicon_BlazorApp_IA.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery(x =>
{
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.Cookie.SameSite = SameSiteMode.None;
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<SiteSettingsLocalStorage>();
builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(x =>
    {
        x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<CoursesService>();
builder.Services.AddScoped<SiteSettingsLocalStorage>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddSignInManager()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddRoleStore<RoleStore<IdentityRole, ApplicationDbContext>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration["FacebookAppId"]!;
    options.AppSecret = builder.Configuration["FacebookAppSecret"]!;
    options.Fields.Add("first_name");
    options.Fields.Add("last_name");
});

builder.Services.AddAuthentication().AddGoogle(x =>
{
    x.ClientId = builder.Configuration["GoogleAppId"]!;
    x.ClientSecret = builder.Configuration["GoogleAppSecret"]!;
});

builder.Services.AddScoped<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

//builder.Services.AddSignalR();
//builder.Services.AddSignalR().AddAzureSignalR();
builder.Services.AddSignalR().AddAzureSignalR();
//builder.Services.AddSignalR().AddAzureSignalR(builder.Configuration.GetConnectionString("AzureSignalRNegotiate"));
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[] { "application/octet-stream" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStatusCodePagesWithRedirects("/Error");
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()    
    .AddAdditionalAssemblies(typeof(Sillicon_BlazorApp_IA.Client._Imports).Assembly);
//app.MapHub<ChatHub>("/chathub");
app.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl, options =>
{
    options.CloseOnAuthenticationExpiration = true;
});



//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapBlazorHub();
//    endpoints.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
//    //endpoints.MapRazorPages();
//    //endpoints.MapFallbackToPage("/Error");
//});



// Add additional endpoints required by the Identity /Account Razor components.
//app.MapControllers();
app.MapAdditionalIdentityEndpoints();
app.Run();
