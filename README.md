# 🧑‍💼 Employee Management System

## 🔐 AuthService

- Base URL: [`http://<EC2_PUBLIC_IP>:5000/api/auth-service`](http://<EC2_PUBLIC_IP>:5000/api/auth-service)
- Swagger UI: [`http://<EC2_PUBLIC_IP>:5000/api/auth-service/swagger/index.html`](http://<EC2_PUBLIC_IP>:5000/api/auth-service/swagger/index.html)

## 👥 EmployeeService

- Base URL: [`http://<EC2_PUBLIC_IP>:5001/api/employee-service`](http://<EC2_PUBLIC_IP>:5001/api/employee-service)
- Swagger UI: [`http://<EC2_PUBLIC_IP>:5001/api/employee-service/swagger/index.html`](http://<EC2_PUBLIC_IP>:5001/api/employee-service/swagger/index.html)

## 📡 Connect to AWS EC2

```bash
ssh -o StrictHostKeyChecking=accept-new -i "my-key.pem" ubuntu@<EC2_PUBLIC_IP>
```

## 📂 Clone GitHub repository

Clone repository:

```bash
git https://github.com/huynhducthanhtuan/EmployeeManagement.git
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
