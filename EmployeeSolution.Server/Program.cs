using EmployeeSolution.Server;
using EmployeeSolution.Shared;
using EmployeeSolution.Shared.Modell;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ConfigService>();
builder.Services.AddDbContext<SolutionDb>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Myploice",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
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

//app.UseAuthorization();

//app.MapControllers();
app.UseCors("Myploice");




app.MapGet("/getemployees", (SolutionDb db) =>
{
    var employees = db.Employees.ToList();
    return employees;

})
    .WithName("getemployees");

app.MapPost("/employee",(SolutionDb db,HttpContext context, Employee emp) =>
    {
        var resp = new SaveEmployeeRespons();
        try
        {
            string action = "None";
            var employee =db.Employees.Where(e => e.EmpID == emp.EmpID).FirstOrDefault();
            if(employee !=null)
            {
                action = "Update";
                employee.FirstName= emp.FirstName;
                employee.LastName = emp.LastName;
                employee.Age = emp.Age;
                employee.Email = emp.Email;
                employee.Phone = emp.Phone;
                employee.HireDate = emp.HireDate;
                employee.EmployeeStatus= emp.EmployeeStatus;

            }
            else
            {
                action = "Created";
                db.Employees.Add(emp);
            }
            db.SaveChanges();
            resp.Returncod = 1;
            resp.ReturnMessage = $"Employee {emp.EmpID} -{emp.FirstName} {emp.LastName}-{action}";
            
        }
        catch(Exception ex)
        {
            resp.Returncod = -1;
            resp.ReturnMessage = $"{ex}";
        }
        return context.Response.WriteAsJsonAsync(resp);
});


app.Run();



