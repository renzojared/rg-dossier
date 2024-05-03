FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WebClient/WebClient.csproj", "WebClient/"]
COPY ["src/Views/Views.csproj", "Views/"]
COPY ["src/Domain/Domain.csproj", "Domain/"]
COPY ["src/Gateways/Gateways.csproj", "Gateways/"]
RUN dotnet restore "WebClient/WebClient.csproj"
COPY src/ .
WORKDIR "/src/WebClient"
RUN dotnet build "WebClient.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebClient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebClient.dll"]
