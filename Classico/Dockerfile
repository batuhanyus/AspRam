FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Classico/Classico.csproj", "Classico/"]
RUN dotnet restore "Classico/Classico.csproj"
COPY . .
WORKDIR "/src/Classico"
RUN dotnet build "Classico.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Classico.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Classico.dll"]
