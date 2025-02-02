# This document contains important notes about swagger


## General Swagger Knowledge


### What is swagger

    Swagger (OpenAPI) is a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of a REST API without direct access to the source code.
     
    Its main goals are to:
     - Minimize the amount of work needed to connect decoupled services.
     - Reduce the amount of time needed to accurately document a service.

    The two main OpenAPI implementations for .NET are Swashbuckle and NSwag.

    In this project we have used Swashbuckle

## There are three main components to Swashbuckle:

    Swashbuckle.AspNetCore.Swagger: a Swagger object model and middleware to expose SwaggerDocument objects as JSON endpoints.

    Swashbuckle.AspNetCore.SwaggerGen: a Swagger generator that builds SwaggerDocument objects directly from your routes, controllers, and models. It's typically combined with the Swagger endpoint middleware to automatically expose Swagger JSON.

    Swashbuckle.AspNetCore.SwaggerUI: an embedded version of the Swagger UI tool. It interprets Swagger JSON to build a rich, customizable experience for describing the web API functionality. It includes built-in test harnesses for the public methods.


## How to add swagger to your project

    - Install-Package Swashbuckle.AspNetCore
    - Add the Swagger generator to the services collection in Program.cs
        - builder.Services.AddEndpointsApiExplorer();
        - builder.Services.AddSwaggerGen();
    - Enable the middleware for serving the generated JSON document and the Swagger UI, in Program.cs
        - app.UseSwagger();
        - app.UseSwaggerUI();
    

## You can configure swagger implementation for example:

    - By using the OpenApiInfo class, we can modify the information displayed in the UI:

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ToDo API",
                Description = "An ASP.NET Core Web API for managing ToDo items",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

    - options.IncludeXmlComments will also display the XML comments that are added 





