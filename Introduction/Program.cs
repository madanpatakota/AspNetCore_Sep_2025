// Creates a builder used to configure the Web API application.
var builder = WebApplication.CreateBuilder(args);

// Registers controller support in the dependency injection container.
builder.Services.AddControllers();

// Registers and configures CORS services.
builder.Services.AddCors(cors =>
{
    // Creates a CORS policy named "AllowLocalhost4200".
    cors.AddPolicy("AllowLocalhost4200", policy =>
    {
        // Allows requests only from the Angular application running on port 4200.
        policy
            .WithOrigins("http://localhost:4200")

            // Allows any request header, such as Content-Type and Authorization.
            .AllowAnyHeader()

            // Allows all HTTP methods, such as GET, POST, PUT and DELETE.
            .AllowAnyMethod();
    });
});

// Angular application URL:
// http://localhost:4200

// Example ASP.NET Core Web API endpoint:
// https://localhost:7115/api/Employees/GetEmpName

// Helps Swagger discover and display the available API endpoints.
builder.Services.AddEndpointsApiExplorer();

// Registers Swagger services to generate API documentation.
builder.Services.AddSwaggerGen();

// Builds the Web API application using the above configuration.
var app = builder.Build();

// Enables the Swagger JSON document.
// Usually available at: /swagger/v1/swagger.json
app.UseSwagger();

// Enables the Swagger UI webpage for viewing and testing API endpoints.
// Usually available at: /swagger
app.UseSwaggerUI();

// Enables the CORS policy created above.
// This allows the Angular application to call this Web API.
app.UseCors("AllowLocalhost4200");

// Redirects HTTP requests to HTTPS for better security.
app.UseHttpsRedirection();

// Enables authorization checks for protected API endpoints.
//app.UseAuthorization();

// Connects controller routes to the request pipeline.
// For example: /api/Employees/GetEmpName
app.MapControllers();

// Starts the Web API application and waits for incoming requests.
app.Run();