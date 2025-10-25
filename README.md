# 🎓 Système de Gestion Éducative - EducationManagementDotNet

## 📋 Description

**EducationManagementDotNet** est une application web complète développée avec ASP.NET Core et Entity Framework Core pour la gestion d'un système éducatif. Cette application permet de gérer les étudiants, les modules, les semestres, les chapitres et les activités d'apprentissage.

## 🚀 Fonctionnalités Principales
<img width="1497" height="754" alt="Screenshot 2025-10-25 at 13 35 59" src="https://github.com/user-attachments/assets/7b968e3c-c3b7-49ec-9f9d-c07fb74d4f05" />


### 👥 Gestion des Étudiants
- **Ajout, modification et suppression** des étudiants
- **Informations personnelles** : nom, prénom, date de naissance, genre
- **Association** avec les filières et modules
<img width="1512" height="757" alt="Screenshot 2025-10-25 at 13 50 09" src="https://github.com/user-attachments/assets/ea22b643-2be1-44ca-ba53-389af4f4a119" />

<img width="1512" height="757" alt="Screenshot 2025-10-25 at 13 51 02" src="https://github.com/user-attachments/assets/7ff4bdb5-a744-44ad-8f87-af9cf0461b25" />


### 📚 Gestion des Modules
- **Création et gestion** des modules d'enseignement
- **Association** avec les semestres
- **Coefficient** et nom des modules

<img width="1512" height="757" alt="Screenshot 2025-10-25 at 13 52 47" src="https://github.com/user-attachments/assets/31fbc2b5-f5e4-4bce-8112-547462f98aaa" />


### 🎯 Gestion des Semestres
- **Organisation** des semestres académiques
- **Association** avec les filières
- **Modules** rattachés à chaque semestre

<img width="1512" height="757" alt="Screenshot 2025-10-25 at 13 54 45" src="https://github.com/user-attachments/assets/09eb424e-dd38-4b7c-97b8-43cd1d9f0506" />


### 📖 Gestion des Chapitres
- **Contenu détaillé** des chapitres
- **Durée** et titre des chapitres
- **Association** avec les modules

<img width="1503" height="777" alt="Screenshot 2025-10-25 at 13 56 49" src="https://github.com/user-attachments/assets/6a167626-c009-4588-8938-cfd437ef9532" />

<img width="1503" height="777" alt="Screenshot 2025-10-25 at 13 57 31" src="https://github.com/user-attachments/assets/52255afb-e926-4245-aa64-b0ebea2919da" />



### 🎪 Gestion des Activités
- **Création d'activités** d'apprentissage
- **Types d'activités** variés
- **Instructions** et durée des activités
- **Dates d'échéance**

<img width="1503" height="777" alt="Screenshot 2025-10-25 at 13 58 25" src="https://github.com/user-attachments/assets/6592b149-5354-4654-83d4-5b0dc77c774e" />


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
    "mycon": "Data Source=.;Initial Catalog=isgasoir;User ID=;Password=;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
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
