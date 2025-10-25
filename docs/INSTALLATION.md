# 🚀 Guide d'Installation - EducationManagementDotNet

## 📋 Prérequis

### 🛠️ Logiciels Nécessaires
- **.NET 7.0 SDK** ou version ultérieure
- **SQL Server** (2019 ou version ultérieure)
- **Visual Studio 2022** ou **VS Code**
- **Git** pour le contrôle de version

### 📦 Vérification des Prérequis

#### Vérifier .NET SDK
```bash
dotnet --version
```
*Doit afficher 7.0.x ou version ultérieure*

#### Vérifier SQL Server
```bash
sqlcmd -S localhost -E -Q "SELECT @@VERSION"
```
*Doit afficher la version de SQL Server*

## 🔧 Installation

### 1️⃣ Cloner le Repository

```bash
git clone https://github.com/zakariaaissari/EducationManagementDotNet.git
cd EducationManagementDotNet
```

### 2️⃣ Restaurer les Packages

```bash
dotnet restore
```

### 3️⃣ Configuration de la Base de Données

#### Option A : SQL Server Local
1. Ouvrir **SQL Server Management Studio**
2. Créer une nouvelle base de données :
```sql
CREATE DATABASE isgasoir;
```

#### Option B : SQL Server Express
```bash
# Installer SQL Server Express
# Télécharger depuis : https://www.microsoft.com/en-us/sql-server/sql-server-downloads
```

### 4️⃣ Configuration de la Chaîne de Connexion

Modifier le fichier `appsettings.json` :

```json
{
  "ConnectionStrings": {
    "mycon": "Data Source=.;Initial Catalog=isgasoir;User ID=sa;Password=VotreMotDePasse;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
  }
}
```

**⚠️ Important :** Remplacer `VotreMotDePasse` par votre mot de passe SQL Server.

### 5️⃣ Exécuter les Migrations

```bash
dotnet ef database update
```

### 6️⃣ Lancer l'Application

```bash
dotnet run
```

L'application sera accessible à l'adresse : `http://localhost:5000`

## 🐳 Installation avec Docker

### 1️⃣ Créer le Dockerfile

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["isgasoir.csproj", "."]
RUN dotnet restore "./isgasoir.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "isgasoir.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "isgasoir.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "isgasoir.dll"]
```

### 2️⃣ Créer docker-compose.yml

```yaml
version: '3.8'
services:
  web:
    build: .
    ports:
      - "5000:80"
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__mycon=Server=db;Database=isgasoir;User Id=sa;Password=YourPassword123!;TrustServerCertificate=true;
    depends_on:
      - db

  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourPassword123!
    ports:
      - "1433:1433"
    volumes:
      - sqlserver_data:/var/opt/mssql

volumes:
  sqlserver_data:
```

### 3️⃣ Lancer avec Docker

```bash
docker-compose up -d
```

## 🌐 Déploiement Azure

### 1️⃣ Créer une App Service

```bash
az webapp create --resource-group myResourceGroup --plan myAppServicePlan --name myAppName --runtime "DOTNET|7.0"
```

### 2️⃣ Configurer la Base de Données Azure SQL

```bash
az sql server create --name myServer --resource-group myResourceGroup --location "West Europe" --admin-user myAdmin --admin-password myPassword
```

### 3️⃣ Déployer l'Application

```bash
az webapp deployment source config --name myAppName --resource-group myResourceGroup --repo-url https://github.com/zakariaaissari/EducationManagementDotNet.git --branch master --manual-integration
```

## 🔧 Configuration Avancée

### 🔐 Variables d'Environnement

#### Development
```bash
export ASPNETCORE_ENVIRONMENT=Development
export ConnectionStrings__mycon="Data Source=.;Initial Catalog=isgasoir;Integrated Security=true;"
```

#### Production
```bash
export ASPNETCORE_ENVIRONMENT=Production
export ConnectionStrings__mycon="Server=your-server;Database=isgasoir;User Id=your-user;Password=your-password;TrustServerCertificate=true;"
```

### 📊 Configuration des Logs

Ajouter dans `appsettings.json` :

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  }
}
```

## 🧪 Tests

### 🔍 Tests Unitaires

```bash
dotnet test
```

### 🔍 Tests d'Intégration

```bash
dotnet test --filter Category=Integration
```

## 🐛 Résolution des Problèmes

### ❌ Erreur de Connexion à la Base de Données

**Problème :** `Cannot connect to SQL Server`

**Solutions :**
1. Vérifier que SQL Server est démarré
2. Vérifier la chaîne de connexion
3. Vérifier les permissions utilisateur

### ❌ Erreur de Migration

**Problème :** `Migration failed`

**Solutions :**
```bash
# Supprimer la dernière migration
dotnet ef migrations remove

# Recréer les migrations
dotnet ef migrations add InitialCreate

# Appliquer les migrations
dotnet ef database update
```

### ❌ Erreur de Port

**Problème :** `Address already in use`

**Solutions :**
```bash
# Utiliser un autre port
dotnet run --urls "http://localhost:5001"

# Ou tuer le processus utilisant le port
lsof -ti:5000 | xargs kill -9
```

## 📞 Support

### 🆘 Aide et Support

- **Documentation** : [README.md](../README.md)
- **Issues** : [GitHub Issues](https://github.com/zakariaaissari/EducationManagementDotNet/issues)
- **Email** : zakariaaissari@example.com

### 📚 Ressources Utiles

- [Documentation .NET](https://docs.microsoft.com/en-us/dotnet/)
- [Documentation Entity Framework](https://docs.microsoft.com/en-us/ef/)
- [Documentation ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)

---

**🎓 EducationManagementDotNet - Installation Complète**

*Guide d'installation mis à jour - Octobre 2024*
