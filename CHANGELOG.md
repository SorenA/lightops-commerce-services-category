# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.6.0] - 2021-02-20

### Changed

- **Breaking** - Change handles to localized strings
- Pluralize image alt text collection

## [0.5.1] - 2021-01-31

### Added

- Sort order on categories for default sorting

### Changed

- **Breaking** - Change protobuf service namespace to prevent message clashes when using multiple services
- **Breaking** - Isolate search sort key enum

## [0.5.0] - 2021-01-30

### Added

- Persist and delete category commands
- In-memory backend persist and delete command handlers

### Changed

- **Breaking** - Migrated to .NET 5
- **Breaking** - Updated refactored and renamed service definition
- **Breaking** - Refactored health check query
- Use Protobuf generated models and services directly instead of mapping and re-implementing services, reduce code required by a lot

### Removed

- **Breaking** - Local entity interfaces, models and mappers, no longer needed
- **Breaking** - CategoryService and HealthService

## [0.4.2] - 2020-12-28

### Added

- Image focal center

## [0.4.1] - 2020-12-03

### Changed

- In-memory backend category provider made overridable on startup
- In-memory query handlers now support category collection being null

## [0.4.0] - 2020-08-13

### Changed

- Search term changed to nullable in service definition
- **Breaking** - Refactored search response to provide edge-style results, with each result carrying a cursor

## [0.3.0] - 2020-08-11

### Added

- Image model and proto mapper

### Changed

- **Breaking** - Updated refactored service definition
- **Breaking** - Removed deprecated queries, query handlers and service methods
- **Breaking** - Extending search query, adding cursor-based pagination
- **Breaking** - Changed health-check service name

## [0.2.1] - 2020-07-21

### Fixed

- Null exeption in in-memory query handler for fetching by parent ids

## [0.2.0] - 2020-07-21

### Added

- Service endpoint, queryies and query handlers for fetching multiple categories by parent ids

### Changed

- Service endpoint for fetching multiple categories by ids or handles pluralized
- Queries and query handlers for fetching multiple categories by ids or handles pluralized

## [0.1.2] - 2020-07-16

### Added

- Service endpoint for fetching multiple categories by ids or handles
- Queries and query handlers for fetching multiple categories by ids or handles

## [0.1.1] - 2020-07-16

### Added

- Type field to category model

## [0.1.0] - 2020-07-08

### Added

- CHANGELOG file
- README file describing project
- Azure Pipelines based CI/CD setup
- Category v1 gRPC server implementation and mappers
- Health v1 gRPC server implementation and mappers
- Category models
- Sample application with mock data
- Queries and query handlers for fetching data and running health-checks
- Category service using CQRS for data retrival
- Health service using CQRS for status checks
- In-memory backend providing default query handlers

[unreleased]: https://github.com/SorenA/lightops-commerce-services-category/compare/0.6.0...develop
[0.6.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.6.0
[0.5.1]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.5.1
[0.5.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.5.0
[0.4.2]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.4.2
[0.4.1]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.4.1
[0.4.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.4.0
[0.3.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.3.0
[0.2.1]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.2.1
[0.2.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.2.0
[0.1.2]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.1.2
[0.1.1]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.1.1
[0.1.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.1.0
