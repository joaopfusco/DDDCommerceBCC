# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000


# This stage is used to build the Application project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DDDCommerceBCC.Api/DDDCommerceBCC.Api.csproj", "DDDCommerceBCC.Api/"]
COPY ["DDDCommerceBCC.Domain/DDDCommerceBCC.Domain.csproj", "DDDCommerceBCC.Domain/"]
COPY ["DDDCommerceBCC.Infra/DDDCommerceBCC.Infra.csproj", "DDDCommerceBCC.Infra/"]
COPY ["DDDCommerceBCC.Application/DDDCommerceBCC.Application.csproj", "DDDCommerceBCC.Application/"]
RUN dotnet restore "./DDDCommerceBCC.Api/DDDCommerceBCC.Api.csproj"
COPY . .
WORKDIR "/src/DDDCommerceBCC.Api"
RUN dotnet build "./DDDCommerceBCC.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the Application project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DDDCommerceBCC.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDDCommerceBCC.Api.dll"]