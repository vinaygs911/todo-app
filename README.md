# 📝 Full-Stack ToDo Application (Clean Architecture + Dockerized)

A robust full-stack ToDo app built using modern technologies — **.NET 8 with Clean Architecture** on the backend, and **React (TypeScript + Vite)** on the frontend. The entire application is fully **Dockerized** for seamless local development and deployment.

---

## 🚀 Tech Stack

### 🔧 Backend (`/todo`)
- .NET 8 Web API
- Clean Architecture (Application, Domain, Infrastructure, API)
- CQRS pattern with MediatR
- FluentValidation for input validation
- Entity Framework Core + SQLite (local DB)
- EF Core Migrations via `entrypoint.sh`
- Docker & Docker Compose

### 💻 Frontend (`/todo-ui`)
- React 18 with TypeScript
- Vite (for fast dev/build)
- Axios for API calls
- React Toastify for notifications
- Plain CSS for styling
- Docker + Nginx for production build

---

## 📁 Folder Structure

```
.
├── todo/               # Backend (.NET 8)
│   ├── Application/
│   ├── Domain/
│   ├── Infrastructure/
│   ├── API/
│   ├── Dockerfile
│   └── entrypoint.sh
├── todo-ui/            # Frontend (React + Vite)
│   ├── src/
│   ├── Dockerfile
│   └── vite.config.ts
├── docker-compose.yml  # Root Docker Compose file
└── README.md
```

---

## 🐳 Running the App with Docker

> Make sure Docker is installed and running.

```bash
# Clone the repository
git clone https://github.com/vinaygs911/todo-app.git
cd todo-app

# Build and start frontend + backend
docker-compose up --build
```

🔗 Access the app:
- Frontend: [http://localhost:3000](http://localhost:3000)
- Backend API: [http://localhost:5000](http://localhost:5000)

⚙️ Migrations are applied automatically on backend startup.

---

## ✅ Features

- Add, delete, and complete tasks
- Deadline support with overdue validation
- Toast messages for validation and backend errors
- Filtered view: all, active, completed
- Modular clean architecture
- Full Docker support — no local Node/.NET setup needed

---

## 🌱 Future Improvements

- [ ] Switch from SQLite to PostgreSQL for production
- [ ] Add user authentication (JWT)
- [ ] Add unit/integration testing
- [ ] Deploy using GitHub Actions
- [ ] UI enhancements and dark mode

---

## 🌍 Ready for Deployment

This app is easy to deploy via:
- Render
- Azure App Service
- Railway
- GitHub Actions + DockerHub
- Any Docker/Kubernetes environment

Need deployment help? Just open an issue.

---

## 👤 Author

**Vinay G S**  
🔗 [GitHub Profile](https://github.com/vinaygs911)

> ⭐ If this project helps or inspires you, consider giving it a star!