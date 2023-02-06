#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Preparation.API/Preparation.API.csproj", "Preparation.API/"]
RUN dotnet restore "Preparation.API/Preparation.API.csproj"
COPY . .
WORKDIR "/src/Preparation.API"
RUN dotnet build "Preparation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Preparation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Preparation.API.dll"]