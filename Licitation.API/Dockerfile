#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Licitation.API/Licitation.API.csproj", "Licitation.API/"]
RUN dotnet restore "Licitation.API/Licitation.API.csproj"
COPY . .
WORKDIR "/src/Licitation.API"
RUN dotnet build "Licitation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Licitation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Licitation.API.dll"]