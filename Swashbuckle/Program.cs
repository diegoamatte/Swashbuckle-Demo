using Microsoft.OpenApi.Models;
using Swashbuckle.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    options => 
    {
        options.SwaggerDoc("v1", new OpenApiInfo { 
            Title = "Swagger example", 
            Description= "# Hi *I'm a Markdown text.*\nAnd this a tool implementation **example** [ReDoc](../api-docs/)",
            Version = "1.0.0"
        });
        options.AddServer(new OpenApiServer
        {
            Url = "https://{baseurl}:{port}",
            Variables =
            {
                { 
                    "baseurl", 
                    new OpenApiServerVariable{
                        Default = "localhost"
                    } 
                },
                { 
                    "port", 
                    new OpenApiServerVariable{
                        Default = "7020",
                        Enum = new List<string>{ "7020","8443", "443"},
                    } 
                },            
            }
        });
        options.AddServer(new OpenApiServer
        {
            Url = "https://{username}.ms-server.com:{port}/{basePath}",
            Variables =
            {
                { 
                    "username", 
                    new OpenApiServerVariable{
                        Default = "admin"
                    } 
                },
                { 
                    "port", 
                    new OpenApiServerVariable{
                        Default = "7020",
                        Enum = new List<string>{ "7020","8443", "443"},
                    } 
                },                 
                { 
                    "basePath", 
                    new OpenApiServerVariable{
                        Default = "v1",
                    } 
                },            
            }
        });
        options.EnableAnnotations();
        options.SchemaFilter<SwaggerSchemaExampleFilter>();
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options => options.InjectStylesheet("/swagger-ui/Styles.css")
    );

    app.UseReDoc();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
