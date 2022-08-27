FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

RUN mkdir /environment

COPY . /environment

WORKDIR /environment

RUN dotnet publish -c Release -o /build

# Run app

FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY --from=build /build /build

WORKDIR /build

ENTRYPOINT [ "dotnet", "Hlcpereira.GithubHandler.Api.dll" ]