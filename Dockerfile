FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

COPY . ./
RUN dotnet publish "tagTour-post-info.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "tagTour-post-info.dll"]