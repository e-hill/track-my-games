FROM node:10-alpine AS node-build-env
WORKDIR /app

# Copy package.json and install as distinct layers
COPY src/ClientApp/package*.json ./
RUN npm install

# Copy everything else and build
COPY src/ClientApp ./
RUN npm run build -- --prod

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
COPY --from=node-build-env /app/src ./ClientApp

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TrackMyGames.dll"]