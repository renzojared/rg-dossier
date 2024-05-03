var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationDependencies();
builder.Services.AddInfrastructureDependencies(
    dbOptions
        => builder.Configuration.GetSection(Domain.Options.DbOptions.SectionKey).Bind(dbOptions));
builder.Services.AddWebApiDependencies();
builder.Services.AddCors(options => options.AddDefaultPolicy(config =>
{
    config.AllowAnyMethod();
    config.AllowAnyHeader();
    config.AllowAnyOrigin();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    await app.InitialiseDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();