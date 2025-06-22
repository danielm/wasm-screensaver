# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage for alpine
FROM nginx:alpine

WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app/out/wwwroot /usr/share/nginx/html
# Copy the nginx configuration file
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 8080
