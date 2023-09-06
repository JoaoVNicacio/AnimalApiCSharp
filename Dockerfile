# Use a imagem oficial do SDK do .NET 6.0 como base para a fase de compilação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Define o diretório de trabalho no contêiner
WORKDIR /app

# Copie o arquivo csproj da pasta "Src" e restaure as dependências
COPY src/AnimalApiCSharp/*.csproj ./src/AnimalApiCSharp/
RUN dotnet restore ./src/AnimalApiCSharp/AnimalApiCSharp.csproj

# Copie todo o código-fonte para o contêiner
COPY . .

# Compile o aplicativo
RUN dotnet publish -c Release -o out

# Crie uma imagem final do aplicativo usando a imagem oficial do ASP.NET 6.0
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Define o diretório de trabalho no contêiner
WORKDIR /app

# Copie os arquivos compilados da fase de compilação para o contêiner
COPY --from=build /app/out ./

# Defina o comando de entrada para iniciar o aplicativo
ENTRYPOINT ["dotnet", "AnimalApiCSharp.dll"]
