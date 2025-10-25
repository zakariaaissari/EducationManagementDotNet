# 🎓 Système de Gestion Éducative - EducationManagementDotNet

## 📋 Description

**EducationManagementDotNet** est une application web complète développée avec ASP.NET Core et Entity Framework Core pour la gestion d'un système éducatif. Cette application permet de gérer les étudiants, les modules, les semestres, les chapitres et les activités d'apprentissage.

## 🚀 Fonctionnalités Principales

### 👥 Gestion des Étudiants
- **Ajout, modification et suppression** des étudiants
- **Informations personnelles** : nom, prénom, date de naissance, genre
- **Association** avec les filières et modules

### 📚 Gestion des Modules
- **Création et gestion** des modules d'enseignement
- **Association** avec les semestres
- **Coefficient** et nom des modules

### 🎯 Gestion des Semestres
- **Organisation** des semestres académiques
- **Association** avec les filières
- **Modules** rattachés à chaque semestre

### 📖 Gestion des Chapitres
- **Contenu détaillé** des chapitres
- **Durée** et titre des chapitres
- **Association** avec les modules

### 🎪 Gestion des Activités
- **Création d'activités** d'apprentissage
- **Types d'activités** variés
- **Instructions** et durée des activités
- **Dates d'échéance**

## 🛠️ Technologies Utilisées

- **ASP.NET Core 7.0** - Framework web
- **Entity Framework Core** - ORM pour la base de données
- **SQL Server** - Base de données relationnelle
- **Razor Pages** - Interface utilisateur
- **Bootstrap 5** - Framework CSS
- **C#** - Langage de programmation


## 🚀 Installation et Configuration

### Prérequis
- **.NET 7.0 SDK** ou version ultérieure
- **SQL Server** (local ou distant)
- **Visual Studio** ou **VS Code**

### Étapes d'Installation

1. **Cloner le repository**
```bash
git clone https://github.com/zakariaaissari/EducationManagementDotNet.git
cd EducationManagementDotNet
```

2. **Restaurer les packages NuGet**
```bash
dotnet restore
```

3. **Configurer la base de données**
   - Modifier la chaîne de connexion dans `appsettings.json`
   - Exécuter les migrations :
```bash
dotnet ef database update
```

4. **Lancer l'application**
```bash
dotnet run
```

## 📱 Interface Utilisateur

### 🏠 Page d'Accueil
La page d'accueil présente un tableau de bord avec :
- **Navigation** vers toutes les sections
- **Statistiques** des données
- **Accès rapide** aux fonctionnalités principales

### 👥 Gestion des Étudiants
- **Liste** de tous les étudiants
- **Formulaire d'ajout** avec validation
- **Modification** des informations
- **Suppression** avec confirmation

### 📚 Gestion des Modules
- **Interface intuitive** pour la gestion des modules
- **Association** avec les semestres
- **Coefficients** et informations détaillées

### 🎯 Gestion des Semestres
- **Organisation** des semestres académiques
- **Modules** associés
- **Filières** de rattachement

### 📖 Gestion des Chapitres
- **Contenu riche** des chapitres
- **Durée** et progression
- **Association** avec les modules
- **Générer Content avec AI Gemini

### 🎪 Gestion des Activités
- **Création** d'activités variées
- **Instructions** détaillées
- **Suivi** des échéances
- **Générer instructions avec AI Gemini

## 🔧 Configuration

### Chaîne de Connexion
```json
{
  "ConnectionStrings": {
    "mycon": "Data Source=.;Initial Catalog=isgasoir;User ID=sa;Password=Dev@1563;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
  }
}
```

### Variables d'Environnement
- **ASPNETCORE_ENVIRONMENT** : Development/Production
- **ConnectionStrings** : Configuration de la base de données

## 📊 API Endpoints

### Étudiants
- `GET /api/student` - Liste des étudiants
- `POST /api/student` - Créer un étudiant
- `PUT /api/student/{id}` - Modifier un étudiant
- `DELETE /api/student/{id}` - Supprimer un étudiant

### Modules
- `GET /api/module` - Liste des modules
- `POST /api/module` - Créer un module
- `PUT /api/module/{id}` - Modifier un module
- `DELETE /api/module/{id}` - Supprimer un module

### Semestres
- `GET /api/semestre` - Liste des semestres
- `POST /api/semestre` - Créer un semestre
- `PUT /api/semestre/{id}` - Modifier un semestre
- `DELETE /api/semestre/{id}` - Supprimer un semestre

### Chapitres
- `GET /api/chapitre` - Liste des chapitres
- `POST /api/chapitre` - Créer un chapitre
- `PUT /api/chapitre/{id}` - Modifier un chapitre
- `DELETE /api/chapitre/{id}` - Supprimer un chapitre

### Activités
- `GET /api/activity` - Liste des activités
- `POST /api/activity` - Créer une activité
- `PUT /api/activity/{id}` - Modifier une activité
- `DELETE /api/activity/{id}` - Supprimer une activité

## 🎨 Captures d'Écran

### 🏠 Tableau de Bord Principal
![Tableau de Bord](screenshots/dashboard.png)
*Interface principale avec navigation et statistiques*

### 👥 Gestion des Étudiants
![Gestion Étudiants](screenshots/students.png)
*Liste et gestion des étudiants avec formulaires*

### 📚 Gestion des Modules
![Gestion Modules](screenshots/modules.png)
*Interface de gestion des modules avec associations*

### 🎯 Gestion des Semestres
![Gestion Semestres](screenshots/semesters.png)
*Organisation des semestres académiques*

### 📖 Gestion des Chapitres
![Gestion Chapitres](screenshots/chapters.png)
*Contenu et organisation des chapitres*

### 🎪 Gestion des Activités
![Gestion Activités](screenshots/activities.png)
*Création et suivi des activités d'apprentissage*

## 🔒 Sécurité

- **Validation** des données d'entrée
- **Protection** contre les injections SQL
- **Gestion** des erreurs sécurisée
- **Configuration** des CORS

-
### Version 1.0.0
- ✅ Gestion complète des étudiants
- ✅ Gestion des modules et semestres
- ✅ Gestion des chapitres et activités
- ✅ Interface utilisateur responsive
- ✅ API REST complète
- ✅ Base de données SQL Server
- ✅ Documentation complète

---

**🎓 EducationManagementDotNet - Votre solution complète pour la gestion éducative !**
