FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 5063
EXPOSE 7117
WORKDIR /app
COPY /publish .
ENTRYPOINT ["dotnet", "MultiShop.Discount.dll"]