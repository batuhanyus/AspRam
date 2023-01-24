FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Minimale/Minimale.csproj", "Minimale/"]
RUN dotnet restore "Minimale/Minimale.csproj"
COPY . .
WORKDIR "/src/Minimale"
RUN dotnet build "Minimale.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Minimale.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS="http://*:1453"
ENTRYPOINT ["dotnet", "Minimale.dll"]
