#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["summer_enterprice_work/summer_enterprice_work.csproj", "summer_enterprice_work/"]
RUN dotnet restore "summer_enterprice_work/summer_enterprice_work.csproj"
COPY . .
WORKDIR "/src/summer_enterprice_work"
RUN dotnet build "summer_enterprice_work.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "summer_enterprice_work.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "summer_enterprice_work.dll"]