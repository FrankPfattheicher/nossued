
FROM mcr.microsoft.com/dotnet/core/runtime:3.1

COPY bin/Release/netcoreapp31/linux-x64/publish/ app/

EXPOSE 32000

ENTRYPOINT ["app/nossued"]

