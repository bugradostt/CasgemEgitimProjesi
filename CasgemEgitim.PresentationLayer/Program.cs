using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.BusinessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ICourseDal, EfCourseRepository>();
builder.Services.AddScoped<ICourseService, CourseManager>();

builder.Services.AddScoped<IStudentDal, EfStudentRepository>();
builder.Services.AddScoped<IStudentService, StudentManager>();


builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VitrinHome}/{action=Index}/{id?}");

app.Run();
