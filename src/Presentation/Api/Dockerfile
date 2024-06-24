#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/Api/Api.csproj", "Presentation/Api/"]
COPY ["Service/DatabaseService/DatabaseService.csproj", "Service/DatabaseService/"]
COPY ["Domain/Contracts/Contracts.csproj", "Domain/Contracts/"]
COPY ["Domain/Entities/Entities.csproj", "Domain/Entities/"]
COPY ["Service/LoggerService/LoggerService.csproj", "Service/LoggerService/"]
COPY ["Service/QuotesManager/QuotesManager.csproj", "Service/QuotesManager/"]
COPY ["Domain/Push.Entities/Push.Entities.csproj", "Domain/Push.Entities/"]
COPY ["Service/CexService/CexService.csproj", "Service/CexService/"]
COPY ["Service/Shared/Shared.csproj", "Service/Shared/"]
COPY ["Service/Repository/Repository.csproj", "Service/Repository/"]
RUN dotnet restore "./Presentation/Api/Api.csproj"
COPY . .
WORKDIR "/src/Presentation/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]