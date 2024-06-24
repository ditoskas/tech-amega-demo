#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/QuotesReceiver/QuotesReceiver.csproj", "Presentation/QuotesReceiver/"]
COPY ["Service/LoggerService/LoggerService.csproj", "Service/LoggerService/"]
COPY ["Domain/Contracts/Contracts.csproj", "Domain/Contracts/"]
COPY ["Domain/Entities/Entities.csproj", "Domain/Entities/"]
COPY ["Service/QueueService/QueueService.csproj", "Service/QueueService/"]
COPY ["Domain/Push.Entities/Push.Entities.csproj", "Domain/Push.Entities/"]
COPY ["Service/Shared/Shared.csproj", "Service/Shared/"]
RUN dotnet restore "./Presentation/QuotesReceiver/QuotesReceiver.csproj"
COPY . .
WORKDIR "/src/Presentation/QuotesReceiver"
RUN dotnet build "./QuotesReceiver.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QuotesReceiver.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuotesReceiver.dll"]