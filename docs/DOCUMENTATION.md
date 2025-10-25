# 📚 Documentation Technique - EducationManagementDotNet

## 🎯 Vue d'Ensemble

**EducationManagementDotNet** est une application web complète développée avec ASP.NET Core pour la gestion d'un système éducatif. Cette application permet aux administrateurs et enseignants de gérer efficacement les étudiants, les modules d'enseignement, les semestres, les chapitres et les activités d'apprentissage.

## 🏗️ Architecture de l'Application

### 🎨 Pattern MVC + Razor Pages
L'application utilise une architecture hybride combinant :
- **MVC Pattern** pour les API REST
- **Razor Pages** pour l'interface utilisateur
- **Entity Framework Core** pour l'accès aux données
- **Repository Pattern** pour l'abstraction des données

### 📁 Structure du Projet

```
EducationManagementDotNet/
├── Controllers/           # Contrôleurs API
│   ├── ActivitiesController.cs
│   ├── ChapitresController.cs
│   ├── ModulesController.cs
│   ├── SemestreController.cs
│   └── StudentApi.cs
├── Pages/                # Pages Razor
│   ├── Activities/
│   ├── Chapters/
│   ├── Modules/
│   ├── Semesters/
│   ├── Students/
│   └── Shared/
├── Models/               # Modèles de données
│   ├── Activity.cs
│   ├── Chapitre.cs
│   ├── Module.cs
│   ├── Semestre.cs
│   └── Studant.cs
├── Services/             # Services métier
├── Migrations/           # Migrations EF Core
└── wwwroot/             # Fichiers statiques
```

## 🗄️ Modèle de Données

### 📊 Diagramme de Relations

```
Filiere (1) ──→ (N) Semestre (1) ──→ (N) Module (1) ──→ (N) Chapitre (1) ──→ (N) Activity
     │
     └── (N) Studant
```

### 🔗 Relations Entre Entités

#### Filiere → Semestre (1:N)
- Une filière peut avoir plusieurs semestres
- Un semestre appartient à une seule filière

#### Semestre → Module (1:N)
- Un semestre contient plusieurs modules
- Un module appartient à un seul semestre

#### Module → Chapitre (1:N)
- Un module contient plusieurs chapitres
- Un chapitre appartient à un seul module

#### Chapitre → Activity (1:N)
- Un chapitre peut avoir plusieurs activités
- Une activité appartient à un seul chapitre

#### Filiere → Studant (1:N)
- Une filière peut avoir plusieurs étudiants
- Un étudiant appartient à une seule filière

## 🚀 Guide d'Utilisation

### 👥 Gestion des Étudiants

#### Ajouter un Étudiant
1. Naviguer vers **"Étudiants"** dans le menu
2. Cliquer sur **"Ajouter un Étudiant"**
3. Remplir le formulaire :
   - **Nom** : Nom de famille
   - **Prénom** : Prénom
   - **Date de naissance** : Date au format DD/MM/YYYY
   - **Genre** : Masculin/Féminin
4. Cliquer sur **"Enregistrer"**

#### Modifier un Étudiant
1. Dans la liste des étudiants, cliquer sur **"Modifier"**
2. Modifier les informations nécessaires
3. Cliquer sur **"Mettre à jour"**

#### Supprimer un Étudiant
1. Dans la liste des étudiants, cliquer sur **"Supprimer"**
2. Confirmer la suppression

### 📚 Gestion des Modules

#### Créer un Module
1. Naviguer vers **"Modules"**
2. Cliquer sur **"Nouveau Module"**
3. Remplir les informations :
   - **Nom du module** : Ex. "Mathématiques"
   - **Coefficient** : Valeur numérique
   - **Semestre** : Sélectionner le semestre
4. Cliquer sur **"Créer"**

### 🎯 Gestion des Semestres

#### Organiser les Semestres
1. Aller dans **"Semestres"**
2. Cliquer sur **"Nouveau Semestre"**
3. Définir :
   - **Nom** : Ex. "Semestre 1"
   - **Filière** : Sélectionner la filière
4. **Enregistrer**

### 📖 Gestion des Chapitres

#### Ajouter un Chapitre
1. Naviguer vers **"Chapitres"**
2. Cliquer sur **"Nouveau Chapitre"**
3. Remplir :
   - **Titre** : Titre du chapitre
   - **Contenu** : Description détaillée
   - **Durée** : Temps estimé
   - **Module** : Module associé
4. **Enregistrer**

### 🎪 Gestion des Activités

#### Créer une Activité
1. Aller dans **"Activités"**
2. Cliquer sur **"Nouvelle Activité"**
3. Définir :
   - **Titre** : Nom de l'activité
   - **Description** : Description détaillée
   - **Type** : Ex. "Exercice", "Projet", "Examen"
   - **Instructions** : Instructions pour les étudiants
   - **Durée** : Temps alloué
   - **Date d'échéance** : Date limite
   - **Chapitre** : Chapitre associé
4. **Créer l'activité**

## 🔧 Configuration Avancée

### ⚙️ Configuration de la Base de Données

#### Chaîne de Connexion SQL Server
```json
{
  "ConnectionStrings": {
    "mycon": "Data Source=.;Initial Catalog=isgasoir;User ID=sa;Password=Dev@1563;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
  }
}
```

#### Configuration pour Production
```json
{
  "ConnectionStrings": {
    "mycon": "Server=your-server;Database=isgasoir;User Id=your-user;Password=your-password;TrustServerCertificate=true;"
  }
}
```

### 🚀 Variables d'Environnement

#### Development
```bash
ASPNETCORE_ENVIRONMENT=Development
```

#### Production
```bash
ASPNETCORE_ENVIRONMENT=Production
```

## 📊 API Documentation

### 🔗 Endpoints Principaux

#### Étudiants API
```http
GET    /api/student          # Liste tous les étudiants
POST   /api/student          # Créer un nouvel étudiant
GET    /api/student/{id}     # Obtenir un étudiant par ID
PUT    /api/student/{id}     # Mettre à jour un étudiant
DELETE /api/student/{id}     # Supprimer un étudiant
```

#### Modules API
```http
GET    /api/module           # Liste tous les modules
POST   /api/module           # Créer un nouveau module
GET    /api/module/{id}      # Obtenir un module par ID
PUT    /api/module/{id}      # Mettre à jour un module
DELETE /api/module/{id}      # Supprimer un module
```

#### Semestres API
```http
GET    /api/semestre         # Liste tous les semestres
POST   /api/semestre         # Créer un nouveau semestre
GET    /api/semestre/{id}    # Obtenir un semestre par ID
PUT    /api/semestre/{id}    # Mettre à jour un semestre
DELETE /api/semestre/{id}    # Supprimer un semestre
```

#### Chapitres API
```http
GET    /api/chapitre         # Liste tous les chapitres
POST   /api/chapitre         # Créer un nouveau chapitre
GET    /api/chapitre/{id}    # Obtenir un chapitre par ID
PUT    /api/chapitre/{id}    # Mettre à jour un chapitre
DELETE /api/chapitre/{id}    # Supprimer un chapitre
```

#### Activités API
```http
GET    /api/activity         # Liste toutes les activités
POST   /api/activity         # Créer une nouvelle activité
GET    /api/activity/{id}    # Obtenir une activité par ID
PUT    /api/activity/{id}    # Mettre à jour une activité
DELETE /api/activity/{id}    # Supprimer une activité
```

### 📝 Exemples de Requêtes

#### Créer un Étudiant
```json
POST /api/student
Content-Type: application/json

{
  "nom": "Dupont",
  "prenom": "Jean",
  "date": "1995-05-15",
  "gender": "Masculin"
}
```

#### Créer un Module
```json
POST /api/module
Content-Type: application/json

{
  "name": "Mathématiques",
  "coiff": 3,
  "semId": 1
}
```

#### Créer une Activité
```json
POST /api/activity
Content-Type: application/json

{
  "title": "Exercice de Calcul",
  "description": "Résoudre les équations du second degré",
  "type": "Exercice",
  "instructions": "Utiliser la méthode du discriminant",
  "duration": 60,
  "dueDate": "2024-12-31",
  "chapitreId": 1
}
```

## 🛠️ Développement

### 🔧 Outils Nécessaires
- **Visual Studio 2022** ou **VS Code**
- **.NET 7.0 SDK**
- **SQL Server** (LocalDB ou Express)
- **Git** pour le contrôle de version

### 📦 Packages NuGet Utilisés
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.0" />
<PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="7.0.0" />
```

### 🗄️ Migrations

#### Créer une Migration
```bash
dotnet ef migrations add NomDeLaMigration
```

#### Appliquer les Migrations
```bash
dotnet ef database update
```

#### Supprimer la Dernière Migration
```bash
dotnet ef migrations remove
```

### 🧪 Tests

#### Tests Unitaires
```bash
dotnet test
```

#### Tests d'Intégration
```bash
dotnet test --filter Category=Integration
```

## 🚀 Déploiement

### 🌐 Déploiement Azure

#### 1. Créer une App Service
```bash
az webapp create --resource-group myResourceGroup --plan myAppServicePlan --name myAppName --runtime "DOTNET|7.0"
```

#### 2. Configurer la Base de Données
```bash
az sql server create --name myServer --resource-group myResourceGroup --location "West Europe" --admin-user myAdmin --admin-password myPassword
```

#### 3. Déployer l'Application
```bash
az webapp deployment source config --name myAppName --resource-group myResourceGroup --repo-url https://github.com/zakariaaissari/EducationManagementDotNet.git --branch master --manual-integration
```

### 🐳 Déploiement Docker

#### Dockerfile
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

#### Docker Compose
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
```

## 🔒 Sécurité

### 🛡️ Bonnes Pratiques Implémentées

#### Validation des Données
- **Validation côté client** avec JavaScript
- **Validation côté serveur** avec Data Annotations
- **Sanitisation** des entrées utilisateur

#### Protection contre les Attaques
- **Protection CSRF** activée
- **Validation des entrées** pour prévenir l'injection SQL
- **Gestion sécurisée** des erreurs

#### Configuration de Sécurité
```csharp
// Dans Program.cs
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
```

## 📈 Performance

### ⚡ Optimisations Implémentées

#### Base de Données
- **Index** sur les colonnes fréquemment utilisées
- **Requêtes optimisées** avec Entity Framework
- **Pagination** pour les grandes listes

#### Application
- **Mise en cache** des données statiques
- **Compression** des réponses HTTP
- **Minification** des fichiers CSS/JS

### 📊 Monitoring

#### Logs d'Application
```csharp
// Configuration des logs
builder.Logging.AddConsole();
builder.Logging.AddDebug();
```

#### Métriques de Performance
- **Temps de réponse** des API
- **Utilisation mémoire**
- **Requêtes base de données**

## 🤝 Contribution

### 🔄 Workflow de Contribution

1. **Fork** le repository
2. Créer une **branche feature**
3. **Développer** la fonctionnalité
4. **Tester** les modifications
5. **Commit** avec un message descriptif
6. **Push** vers la branche
7. Créer une **Pull Request**

### 📝 Standards de Code

#### Convention de Nommage
- **Classes** : PascalCase (ex: `StudentController`)
- **Méthodes** : PascalCase (ex: `GetStudentById`)
- **Variables** : camelCase (ex: `studentId`)
- **Constantes** : UPPER_CASE (ex: `MAX_STUDENTS`)

#### Documentation du Code
```csharp
/// <summary>
/// Récupère un étudiant par son identifiant
/// </summary>
/// <param name="id">L'identifiant de l'étudiant</param>
/// <returns>L'étudiant correspondant ou null si non trouvé</returns>
public async Task<Studant> GetStudentByIdAsync(int id)
{
    // Implémentation
}
```

## 📞 Support et Maintenance

### 🐛 Signalement de Bugs
1. Vérifier que le bug n'existe pas déjà
2. Créer une **issue** détaillée
3. Inclure les **étapes de reproduction**
4. Ajouter les **logs d'erreur**

### 💡 Demandes de Fonctionnalités
1. Vérifier que la fonctionnalité n'existe pas
2. Créer une **issue** avec le label "enhancement"
3. Décrire le **cas d'usage**
4. Proposer une **solution**

### 📧 Contact
- **Email** : zakariaaissari@example.com
- **GitHub** : [@zakariaaissari](https://github.com/zakariaaissari)
- **Issues** : [GitHub Issues](https://github.com/zakariaaissari/EducationManagementDotNet/issues)

---

**🎓 EducationManagementDotNet - Documentation Technique Complète**

*Dernière mise à jour : Octobre 2024*
