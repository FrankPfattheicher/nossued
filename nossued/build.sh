#!/usr/bin/env bash

dotnet publish -c Release -r linux-x64 -f netcoreapp31
docker build -t nossued -f Dockerfile .

