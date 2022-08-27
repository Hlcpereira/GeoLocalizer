FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

RUN mkdir /environment

WORKDIR /environment

RUN dotnet dev-certs https --trust

WORKDIR /environment
