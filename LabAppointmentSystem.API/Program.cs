using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using LabInvoiceSystem.API.Repositories;
using LabInvoiceSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IExceptionHandlingService, ExceptionHandlingService>();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IReceptionRepository, ReceptionRepository>();
builder.Services.AddScoped<IReceptionService, ReceptionService>();
builder.Services.AddScoped<ITechnicianRepository, TechnicianRepository>();
builder.Services.AddScoped<ITechnicianService, TechnicianService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentTestRepository, AppointmentTestRepository>();
builder.Services.AddScoped<IAppointmentTestService, AppointmentTestService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "MadushanWijesuriya",
        ValidAudience = "MadushanWijesuriya",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPp"))
    };
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers().AddOData(options =>
    options.Select().Filter().Count().OrderBy().Expand());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireStaff", policy =>
    {
        policy.RequireRole("Admin", "Technician", "Reception");
    });
    options.AddPolicy("RequireDoctorRole", policy =>
    {
        policy.RequireRole("Doctor");
    });
    options.AddPolicy("RequirePatientRole", policy =>
    {
        policy.RequireRole("Patient");
    });
    options.AddPolicy("RequireTechnicianRole", policy =>
    {
        policy.RequireRole("Technician");
    });
    options.AddPolicy("RequireReceptionRole", policy =>
    {
        policy.RequireRole("Reception");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

    dbContext.Database.EnsureCreated();

    await CreateRolesAsync(serviceProvider);

    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await IdentityInitializer.InitializeAsync(userManager, roleManager);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();










async Task CreateRolesAsync(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roleNames = { "Admin", "Doctor", "Patient", "Technician", "Reception" };

    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);

        if (!roleExist)
        {
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}
