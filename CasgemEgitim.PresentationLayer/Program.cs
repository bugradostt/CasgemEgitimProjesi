using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.BusinessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddScoped<ICourseDal, EfCourseRepository>();
builder.Services.AddScoped<ICourseService, CourseManager>();

builder.Services.AddScoped<IMovementDal, EfMovementRepository>();
builder.Services.AddScoped<IMovementService, MovementManager>();

builder.Services.AddScoped<ICourseDetailDal, EfCourseDetailRepository>();
builder.Services.AddScoped<ICourseDetailService,CourseDetailManager>();

builder.Services.AddScoped<IStudentDal, EfStudentRepository>();
builder.Services.AddScoped<IStudentService, StudentManager>();

builder.Services.AddScoped<ITeacherDal, EfTeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();

builder.Services.AddScoped<IMessageDal, EFMessageRepository>();
builder.Services.AddScoped<IMessageService, MessageManager>();


builder.Services.AddScoped<ICommentDal, EfCommentRepository>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
options =>
{
    options.Cookie.Name = "NetCoreMvc.Auth";
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/Login";
});

builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VitrinHome}/{action=Index}/{id?}");


app.UseSession();
app.Run();
