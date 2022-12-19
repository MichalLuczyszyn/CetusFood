FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CetusFood.Restaurants.API/CetusFood.Restaurants.API.csproj", "CetusFood.Restaurants.API/"]
RUN dotnet restore "CetusFood.Restaurants.API/CetusFood.Restaurants.API.csproj"
COPY . .
WORKDIR "/src/CetusFood.Restaurants.API"
RUN dotnet build "CetusFood.Restaurants.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CetusFood.Restaurants.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CetusFood.Restaurants.API.dll"]
