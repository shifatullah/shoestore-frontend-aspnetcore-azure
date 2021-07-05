FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ShoeStore.Frontend/ShoeStore.Frontend.csproj", "ShoeStore.Frontend/"]
RUN dotnet restore "ShoeStore.Frontend/ShoeStore.Frontend.csproj"
COPY . .
WORKDIR "/src/ShoeStore.Frontend"
RUN dotnet build "ShoeStore.Frontend.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ShoeStore.Frontend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShoeStore.Frontend.dll"]