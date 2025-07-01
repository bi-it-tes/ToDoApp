# ToDo APP
---
Diese ToDo App ist eine einfache Aufgabenverwaltung, die mit Blazor entwickelt wurde. 
Sie ermöglicht es Nutzer*innen, Aufgaben zu erstellen, zu bearbeiten und zu löschen. Alle erledigte task kann man als Done markieren und dies werden
in einer Seperaten Liste angezeigt. 

Das Projekt dient als Lernprojekt, um die Grundlagen von Blazor-Komponenten und Codierren zu verstehen.

---

## Create Blazor Project

Use "blazer" as template

```ps
dotnet new blazor -o ToDoApp
```

## Add Git Remote

```ps
git remote add origin https://github.com/bi-it-tes/ToDoApp.git
```

Change main branch to "main"

```ps
git branch -M main 
```

Make sure to push the code to the remote repository and at least one commit is avaailabel


```ps
git add README.md
git commit -m "Initial commit"
git push -u origin main""
```

## Adding .gitignore file

```ps
dotnet new gitignore
```

## Build a todo list Blazor app
```ps	
dotnet new razorcomponent -n Todo -o Components/Pages
```

## Starting App in command-line
```ps
dotnet run
```