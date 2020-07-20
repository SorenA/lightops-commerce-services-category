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

Category v1 is implemented in `Domain.Services.V1.CategoryGrpcService`.

Health v1 is implemented in `Domain.Services.V1.HealthGrpcService`.

### Health-check

Health-checks conforms to the [GRPC Health Checking Protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md)

Available services are as follows

```bash
service = '' - System as a whole
service = 'service.category.v1.ProtoCategoryService' - Category v1
```

For embedding a gRPC client for use with Kubernetes, see [grpc-ecosystem/grpc-health-probe](https://github.com/grpc-ecosystem/grpc-health-probe)

## Samples

A sample application hosting the gRPC service with mock data is available in the `samples/Sample.CategoryService` project.

## Requirements

LightOps packages available on NuGet:

- `LightOps.DependencyInjection`
- `LightOps.CQRS`
- `LightOps.Mapping`

## Using the service component

Register during startup through the `AddCategoryService(options)` extension on `IDependencyInjectionRootComponent`.

```csharp
services.AddLightOpsDependencyInjection(root =>
{
    root
        .AddMapping()
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

### Configuration options

A component backend is required, defining the query handlers tied to a data-source, see **Query handlers** section bellow for more.

A custom backend, or one of the following standard backends can be used:

- InMemory

### Overridables

Using the `ICategoryServiceComponent` configuration, the following can be overridden:

```csharp
public interface ICategoryServiceComponent
{
    #region Services
    ICategoryServiceComponent OverrideHealthService<T>() where T : IHealthService;
    ICategoryServiceComponent OverrideCategoryService<T>() where T : ICategoryService;
    #endregion Services

    #region Mappers
    ICategoryServiceComponent OverrideProtoCategoryMapperV1<T>() where T : IMapper<ICategory, Proto.Services.Category.V1.ProtoCategory>;
    #endregion Mappers

    #region Query Handlers
    ICategoryServiceComponent OverrideCheckCategoryHealthQueryHandler<T>() where T : ICheckCategoryHealthQueryHandler;

    ICategoryServiceComponent OverrideFetchCategoryByIdQueryHandler<T>() where T : IFetchCategoryByIdQueryHandler;
    ICategoryServiceComponent OverrideFetchCategoriesByIdsQueryHandler<T>() where T : IFetchCategoriesByIdsQueryHandler;

    ICategoryServiceComponent OverrideFetchCategoryByHandleQueryHandler<T>() where T : IFetchCategoryByHandleQueryHandler;
    ICategoryServiceComponent OverrideFetchCategoriesByHandlesQueryHandler<T>() where T : IFetchCategoriesByHandlesQueryHandler;

    ICategoryServiceComponent OverrideFetchCategoriesByParentIdQueryHandler<T>() where T : IFetchCategoriesByParentIdQueryHandler;
    ICategoryServiceComponent OverrideFetchCategoriesByParentIdsQueryHandler<T>() where T : IFetchCategoriesByParentIdsQueryHandler;

    ICategoryServiceComponent OverrideFetchCategoriesByRootQueryHandler<T>() where T : IFetchCategoriesByRootQueryHandler;
    ICategoryServiceComponent OverrideFetchCategoriesBySearchQueryHandler<T>() where T : IFetchCategoriesBySearchQueryHandler;
    #endregion Query Handlers
}
```

`ICategoryService` is used by the gRPC services and query the data using the `IQueryDispatcher` from the `LightOps.CQRS` package.

The mappers are used for mapping the internal data structure to the versioned protobuf messages.

## Backend modules

### In-Memory

Register during startup through the `UseInMemoryBackend(root, options)` extension on `ICategoryServiceComponent`.

```csharp
root.AddCategoryService(service =>
{
    service.UseInMemoryBackend(root, backend =>
    {
        var categories = new List<ICategory>();
        // ...

        backend.UseCategories(categories);
    });

    // Configure service
    // ...
});
```
