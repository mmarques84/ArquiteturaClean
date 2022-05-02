#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DDD.Web/DDD.Web.csproj", "DDD.Web/"]
COPY ["DDD.Application/DDD.Application.csproj", "DDD.Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Dominio/Domain.csproj", "Dominio/"]
RUN dotnet restore "DDD.Web/DDD.Web.csproj"
COPY . .
WORKDIR "/src/DDD.Web"
RUN dotnet build "DDD.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DDD.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDD.Web.dll"]