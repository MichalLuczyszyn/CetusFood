FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CetusFood.Auth.API/CetusFood.Auth.API.csproj", "CetusFood.Auth.API/"]
RUN dotnet restore "CetusFood.Auth.API/CetusFood.Auth.API.csproj"
COPY . .
WORKDIR "/src/CetusFood.Auth.API"
RUN dotnet build "CetusFood.Auth.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CetusFood.Auth.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CetusFood.Auth.API.dll"]
