# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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

[unreleased]: https://github.com/SorenA/lightops-commerce-services-category/compare/0.4.0...develop
[0.4.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.4.0
[0.3.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.3.0
[0.2.1]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.2.1
[0.2.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.2.0
[0.1.2]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.1.2
[0.1.1]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.1.1
[0.1.0]: https://github.com/SorenA/lightops-commerce-services-category/tree/0.1.0
