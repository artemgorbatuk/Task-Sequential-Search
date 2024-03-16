# Базовая стадия для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Стадия сборки для компиляции и публикации .NET Web API приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

## Копируйте все проекты в контейнер
COPY . .

## Восстанавливайте зависимости для всех проектов
#RUN dotnet restore
RUN dotnet restore ./Datasource/Datasource.csproj
RUN dotnet restore ./Repositories/Repositories.csproj
RUN dotnet restore ./Services/Services.csproj
RUN dotnet restore ./Api/Api.csproj

## Сборка проекта Api
RUN dotnet build "Api/Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Api/Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Финальная стадия для запуска собранного приложения
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]