# From https://docs.docker.com/engine/examples/dotnetcore/
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
RUN npm install -g bower

# Create empty prod app settings.
RUN echo "{}" > /app/appsettings.Production.json

# Copy everything else and build
COPY . ./
RUN bower install
RUN dotnet publish -c Release -o build


# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app

# Copy build output
COPY --from=build-env /app/build .

# Set environment vars
ENV ASPNETCORE_ENVIRONMENT=Production

# Mount database volume
VOLUME /app/data

ENTRYPOINT ["dotnet", "SchoDotCom.WebUI.dll"]
