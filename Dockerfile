FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/Wish.Web.Host/Wish.Web.Host.csproj", "src/Wish.Web.Host/"]
COPY ["src/Wish.Web.Core/Wish.Web.Core.csproj", "src/Wish.Web.Core/"]
COPY ["src/Wish.Application/Wish.Application.csproj", "src/Wish.Application/"]
COPY ["src/Wish.Core/Wish.Core.csproj", "src/Wish.Core/"]
COPY ["src/Wish.EntityFrameworkCore/Wish.EntityFrameworkCore.csproj", "src/Wish.EntityFrameworkCore/"]
WORKDIR "/src/src/Wish.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Wish.Web.Host", "src/Wish.Web.Host"]
COPY ["src/Wish.Web.Core", "src/Wish.Web.Core"]
COPY ["src/Wish.Application", "src/Wish.Application"]
COPY ["src/Wish.Core", "src/Wish.Core"]
COPY ["src/Wish.EntityFrameworkCore", "src/Wish.EntityFrameworkCore"]
WORKDIR "/src/src/Wish.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Wish.Web.Host.dll"]
