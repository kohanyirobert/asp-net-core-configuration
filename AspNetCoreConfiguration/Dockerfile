FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AspNetCoreConfiguration/AspNetCoreConfiguration.csproj", "AspNetCoreConfiguration/"]
RUN dotnet restore "AspNetCoreConfiguration/AspNetCoreConfiguration.csproj"
COPY . .
WORKDIR "/src/AspNetCoreConfiguration"
RUN dotnet build "AspNetCoreConfiguration.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AspNetCoreConfiguration.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreConfiguration.dll"]
