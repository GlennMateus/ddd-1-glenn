#region

using backend;

#endregion

var builder = WebApplication.CreateBuilder(args);

var appServices = new AppServices(builder.Services, builder.Configuration);
appServices.Execute();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();