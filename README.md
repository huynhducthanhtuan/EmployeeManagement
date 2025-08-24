# 🧑‍💼 Employee Management System

### An .NET Core Web API Microservices Project

## 🔐 AuthService

- Base URL: [`http://<EC2_PUBLIC_IP>:5000/api/auth-service`](http://<EC2_PUBLIC_IP>:5000/api/auth-service)
- Swagger UI: [`http://<EC2_PUBLIC_IP>:5000/api/auth-service/swagger/index.html`](http://<EC2_PUBLIC_IP>:5000/api/auth-service/swagger/index.html)
- Auth Mechanism: AWS Cognito (User Pool, App Client)
- Infrastructure: AWS EC2
- Image Registry: Docker Hub

## 👥 EmployeeService

- Base URL: [`http://<EC2_PUBLIC_IP>:5001/api/employee-service`](http://<EC2_PUBLIC_IP>:5001/api/employee-service)
- Swagger UI: [`http://<EC2_PUBLIC_IP>:5001/api/employee-service/swagger/index.html`](http://<EC2_PUBLIC_IP>:5001/api/employee-service/swagger/index.html)
- Database: AWS RDS SQL Server
- Infrastructure: AWS EC2
- Image Registry: Docker Hub

## 📡 Connect to AWS EC2

```bash
ssh -o StrictHostKeyChecking=accept-new -i "my-key.pem" ubuntu@<EC2_PUBLIC_IP>
```

## 📂 Clone GitHub repository

Clone repository:

```bash
git clone https://github.com/huynhducthanhtuan/EmployeeManagement.git
```

Change directory to this folder:

```bash
cd EmployeeManagement
```

## 🐳 Run Microservices with Docker Compose

Start docker compose:

```bash
docker-compose up -d --build
```

Stop docker compose:

```bash
docker-compose down
```
