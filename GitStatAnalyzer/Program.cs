using GitStatAnalyzer.Services;
using Octokit;

// Creating a WebApplication builder.
var builder = WebApplication.CreateBuilder(args);

// Adding controllers to the services collection.
builder.Services.AddControllers();

// Adding API explorer to the services collection.
builder.Services.AddEndpointsApiExplorer();
// Adding Swagger generation to the services collection.
builder.Services.AddSwaggerGen();

// Register GitHubClient as a singleton service.
builder.Services.AddSingleton<GitHubClient>(sp =>
{
    // Creating a new GitHubClient with a custom product header value.
    return new GitHubClient(new ProductHeaderValue("GitHubStatsAPI"));
});

// Register GitHubService as a scoped service.
builder.Services.AddScoped<IGitHubService, GitHubService>();

// Building the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())  // If the application is in development environment.
{
    // Use Swagger for API documentation.
    app.UseSwagger();
    // Use Swagger UI for interactive API documentation.
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Use authorization middleware.
app.UseAuthorization();

// Map controller endpoints.
app.MapControllers();

// Run the application
app.Run();
