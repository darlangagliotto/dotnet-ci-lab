# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/CatalogService/CatalogService.csproj ./CatalogService/
RUN dotnet restore CatalogService/CatalogService.csproj

COPY src/CatalogService/. ./CatalogService/
WORKDIR /src/CatalogService
RUN dotnet publish -c Release -o /app/publish


# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "CatalogService.dll"]
