FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#bind heroku port
CMD gunicorn --bind 0.0.0.0:$PORT wsgi


# Copy csproj and restore as distinct layers
COPY Ownerofglory.Tasket.Backend.sln ./
COPY Ownerofglory.Tasket.Backend/Ownerofglory.Tasket.Backend.csproj Ownerofglory.Tasket.Backend/
COPY Ownerofglory.Tasket.BackendTest/Ownerofglory.Tasket.BackendTest.csproj Ownerofglory.Tasket.BackendTest/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Ownerofglory.Tasket.Backend.dll"]