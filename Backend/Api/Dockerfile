# Образ asp.net
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS aspnet
EXPOSE 8080

# Образ sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS sdk
ARG BUILD_CONFIGURATION=Release

# Копируйте исходников проектов в папку /src
WORKDIR /src
#COPY . .
COPY Datasource/ Datasource/
COPY Repositories/ Repositories/
COPY Services/ Services/
COPY Api/ Api/

# Восстанавливайте зависимости для всех проектов
#RUN dotnet restore
RUN dotnet restore ./Datasource/Datasource.csproj
RUN dotnet restore ./Repositories/Repositories.csproj
RUN dotnet restore ./Services/Services.csproj
RUN dotnet restore ./Api/Api.csproj

# Сборка проекта Api в папку /app/build
RUN dotnet build "Api/Api.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

# Публикаци проекта Api в папку /app/publish
FROM sdk AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Api/Api.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

# Запуск веб сервиса из папки /app/publish
FROM aspnet AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]

# Очистка места от установочных файлов
RUN apt-get clean && \
    rm -rf /var/lib/apt/lists