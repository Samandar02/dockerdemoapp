FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 5012

ENV ASPNETCORE_URLS=http://+:5012

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["App.Server.csproj", "."]
RUN dotnet restore "App.Server.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "App.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Server.dll"]
