# LightOps Commerce - Category Service

Microservice for categories.

Defines categories.  
Uses CQRS to fetch entities from data-source without defining any.  
Provides gRPC services for integrations into other services.

![Nuget](https://img.shields.io/nuget/v/LightOps.Commerce.Services.Category)

| Branch | CI |
| --- | --- |
| master | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Commerce/_apis/build/status/LightOps.Commerce.Services.Category?branchName=master) |
| develop | ![Build Status](https://dev.azure.com/sorendev/LightOps%20Commerce/_apis/build/status/LightOps.Commerce.Services.Category?branchName=develop) |

## gRPC services

Protobuf service definitions located at [SorenA/lightops-commerce-proto](https://github.com/SorenA/lightops-commerce-proto).

Category is implemented in `Domain.GrpcServices.CategoryGrpcService`.

Health is implemented in `Domain.GrpcServices.HealthGrpcService`.

### Health-check

Health-checks conforms to the [GRPC Health Checking Protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md)

Available services are as follows

```bash
service = '' - System as a whole
service = 'lightops.service.CategoryService' - Category
```

For embedding a gRPC client for use with Kubernetes, see [grpc-ecosystem/grpc-health-probe](https://github.com/grpc-ecosystem/grpc-health-probe)

## Samples

A sample application hosting the gRPC service with mock data is available in the `samples/Sample.CategoryService` project.

## Requirements

LightOps packages available on NuGet:

- `LightOps.DependencyInjection`
- `LightOps.CQRS`

## Using the service component

Register during startup through the `AddCategoryService(options)` extension on `IDependencyInjectionRootComponent`.

```csharp
services.AddLightOpsDependencyInjection(root =>
{
    root
        .AddCqrs()
        .AddCategoryService(service =>
        {
            // Configure service
            // ...
        });
});

services.AddGrpc();
```

Register gRPC services for integrations.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<CategoryGrpcService>();
    endpoints.MapGrpcService<HealthGrpcService>();

    // Map other endpoints...
});
```

The gRPC services use `ICommandDispatcher` & `IQueryDispatcher` from the `LightOps.CQRS` package to dispatch commands and queries, see configuration bellow.

### Configuration options

A component backend is required, implementing the command & query handlers tied to a data-source, see configuration overridables bellow.

A custom backend, or one of the following standard backends can be used:

- InMemory

### Overridables

Using the `ICategoryServiceComponent` configuration, the following can be overridden:

```csharp
public interface ICategoryServiceComponent
{
    #region Query Handlers
    ICategoryServiceComponent OverrideCheckCategoryServiceHealthQueryHandler<T>() where T : ICheckCategoryServiceHealthQueryHandler;

    ICategoryServiceComponent OverrideFetchCategoriesByHandlesQueryHandler<T>() where T : IFetchCategoriesByHandlesQueryHandler;
    ICategoryServiceComponent OverrideFetchCategoriesByIdsQueryHandler<T>() where T : IFetchCategoriesByIdsQueryHandler;
    ICategoryServiceComponent OverrideFetchCategoriesBySearchQueryHandler<T>() where T : IFetchCategoriesBySearchQueryHandler;
    #endregion Query Handlers

    #region Command Handlers
    ICategoryServiceComponent OverridePersistCategoryCommandHandler<T>() where T : IPersistCategoryCommandHandler;
    ICategoryServiceComponent OverrideDeleteCategoryCommandHandler<T>() where T : IDeleteCategoryCommandHandler;
    #endregion Command Handlers
}
```

## Backend modules

### In-Memory

Register during startup through the `UseInMemoryBackend(root, options)` extension on `ICategoryServiceComponent`.

```csharp
root.AddCategoryService(service =>
{
    service.UseInMemoryBackend(root, backend =>
    {
        var categories = new List<Category>();
        // ...

        backend.UseCategories(categories);
    });

    // Configure service
    // ...
});
```
