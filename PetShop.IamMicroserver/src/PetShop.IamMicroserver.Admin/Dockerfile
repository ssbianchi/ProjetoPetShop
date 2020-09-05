FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/PetShop.IamMicroserver.Admin/PetShop.IamMicroserver.Admin.csproj", "src/PetShop.IamMicroserver.Admin/"]
COPY ["src/PetShop.IamMicroserver.Admin.EntityFramework.Shared/PetShop.IamMicroserver.Admin.EntityFramework.Shared.csproj", "src/PetShop.IamMicroserver.Admin.EntityFramework.Shared/"]
COPY ["src/PetShop.IamMicroserver.Admin.EntityFramework.SqlServer/PetShop.IamMicroserver.Admin.EntityFramework.SqlServer.csproj", "src/PetShop.IamMicroserver.Admin.EntityFramework.SqlServer/"]
COPY ["src/PetShop.IamMicroserver.Admin.EntityFramework.PostgreSQL/PetShop.IamMicroserver.Admin.EntityFramework.PostgreSQL.csproj", "src/PetShop.IamMicroserver.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/PetShop.IamMicroserver.Admin.EntityFramework.MySql/PetShop.IamMicroserver.Admin.EntityFramework.MySql.csproj", "src/PetShop.IamMicroserver.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/PetShop.IamMicroserver.Admin/PetShop.IamMicroserver.Admin.csproj"
COPY . .
WORKDIR "/src/src/PetShop.IamMicroserver.Admin"
RUN dotnet build "PetShop.IamMicroserver.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetShop.IamMicroserver.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "PetShop.IamMicroserver.Admin.dll"]