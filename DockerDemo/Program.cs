using DockerDemo.Data;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

//static IEdmModel GetEdmModel()
//{
//    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
//    builder.EntitySet<User>("Users");
//    return builder.GetEdmModel();
//}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var modelBuilder = new ODataConventionModelBuilder();


builder.Services.AddControllers().AddOData(options => options
//.AddRouteComponents("users",GetEdmModel())
.Select()
.Filter()
.OrderBy()
.Expand()
.Count()
.SetMaxTop(100)
.SkipToken());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SampleDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
