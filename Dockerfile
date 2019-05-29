FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./CodingChallenge/*.csproj ./CodingChallenge/
COPY ./CodingChallenge.Tests/*.csproj ./CodingChallenge.Tests/
COPY ./reservation-gap-rule.sln ./
RUN dotnet restore reservation-gap-rule.sln

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o ./out reservation-gap-rule.sln

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/CodingChallenge/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "CodingChallenge.dll"]
