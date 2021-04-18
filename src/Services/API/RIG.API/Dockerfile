#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/API/RIG.API/RIG.API.csproj", "Services/API/RIG.API/"]
COPY ["Services/Application/RIG.Application/RIG.Application.csproj", "Services/Application/RIG.Application/"]
COPY ["Services/Domain/RIG.Domain/RIG.Domain.csproj", "Services/Domain/RIG.Domain/"]
COPY ["Services/Infrastructure/RIG.Infrastructure/RIG.Infrastructure.csproj", "Services/Infrastructure/RIG.Infrastructure/"]
RUN dotnet restore "Services/API/RIG.API/RIG.API.csproj"
COPY . .
WORKDIR "/src/Services/API/RIG.API"
RUN dotnet build "RIG.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RIG.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RIG.API.dll"]
