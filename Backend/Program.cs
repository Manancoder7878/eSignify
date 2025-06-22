using Backend.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var myorigin = "_myorigin";
// Add services to the container.
var jwt = builder.Configuration.GetSection("Jwt");
var key = jwt["Key"];
builder.Services.AddScoped<AgreementDbContext>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
        option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = jwt["Issuer"],
                ValidAudience = jwt["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };

        }
    );
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myorigin, policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(myorigin);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
