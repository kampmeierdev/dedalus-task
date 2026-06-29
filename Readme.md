# Denomination API

Calculates the denomination for a given amount.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Run

```bash
dotnet run --project DedalusApi
```

Swagger UI: http://localhost:5159/swagger

## Tests

```bash
dotnet test
```

### Usage

POST /api/denomination

### Example

```bash
curl -X POST http://localhost:5159/api/denomination \
  -H "Content-Type: application/json" \
  -d '{"amount": 234.23}'
```


