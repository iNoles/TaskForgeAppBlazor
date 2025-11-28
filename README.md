# TaskForge

**TaskForge** is a personal task management web application built with **Blazor WebAssembly**. It provides a clean, responsive, and modular interface for managing tasks with priority, due dates, and drag-and-drop ordering. The app is designed to be lightweight, maintainable, and deployable on **Azure Static Web Apps**.

---

## Features

- Add, edit, and delete tasks with title, description, due date, and priority
- Drag-and-drop reorder tasks to organize your workflow
- Responsive UI using **Bootstrap**
- Offline-first functionality via browser storage (optional export to JSON)
- Modular architecture with **MVVM** and **Dependency Injection**
- Unit and integration testing to ensure reliability

---

## Tech Stack

**Frontend / Web:** Blazor WebAssembly, Razor Components, Bootstrap, JavaScript, IndexedDB

**Backend / Core:** C#, .NET Core

**Tools & Practices:** Git, CI/CD, MVVM, Dependency Injection 

**Cloud Deployment:** Azure Static Web Apps  

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2022 or VS Code
- Git

### Clone the Repository

```bash
git clone https://github.com/iNoles/TaskForgeAppBlazor.git
cd TaskForgeAppBlazor
```
### Build and Run Locally

```bash
dotnet restore
dotnet build
dotnet run --project TaskForgeAppBlazor/TaskForgeAppBlazor.csproj
```
Open your browser and navigate to ```https://localhost:5001``` (or the URL shown in the terminal) to see the app in action.
