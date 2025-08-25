# 🧑‍💼 Employee Management System

### An .NET Core Web API Microservices Project

## 🔐 AuthService

- Base URL: [`http://<EC2_PUBLIC_IP>:5000/api/auth-service`](http://<EC2_PUBLIC_IP>:5000/api/auth-service)
- Swagger UI: [`http://<EC2_PUBLIC_IP>:5000/api/auth-service/swagger/index.html`](http://<EC2_PUBLIC_IP>:5000/api/auth-service/swagger/index.html)
- Auth Mechanism: AWS Cognito (User Pool, App Client)
- Infrastructure: AWS EC2
- Image Registry: Docker Hub
- Pipeline: [![Build & Push AuthService image to Docker Hub](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-authservice-dockerhub.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-authservice-dockerhub.yml)

## 👥 EmployeeService

- Base URL: [`http://<EC2_PUBLIC_IP>:5001/api/employee-service`](http://<EC2_PUBLIC_IP>:5001/api/employee-service)
- Swagger UI: [`http://<EC2_PUBLIC_IP>:5001/api/employee-service/swagger/index.html`](http://<EC2_PUBLIC_IP>:5001/api/employee-service/swagger/index.html)
- Database: AWS RDS SQL Server
- Infrastructure: AWS EC2
- Image Registry: Docker Hub
- Pipeline: [![Build & Push EmployeeService image to Docker Hub](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-employeeservice-dockerhub.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-employeeservice-dockerhub.yml)

## ⚙️ AWS Setup Instructions

### 1. Create AWS RDS SQL Server Database

- Create AWS RDS SQL Server database
- Get **DatabaseServerEndpoint**, **DatabasePort**, **DatabaseName** (must create database to get this info), **UserId**, **UserPassword**
- **Note:** Update the following in `./EmployeeService/appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=<DatabaseServerEndpoint>,<DatabasePort>;Database=<DatabaseName>;User Id=<UserId>;Password=<UserPassword>;Encrypt=True;TrustServerCertificate=True;"
}
```

### 2. AWS Cognito Setup

#### a. Create User Pool

- Create a User Pool in AWS Cognito
- Get **UserPoolId**

#### b. Create App Client for this User Pool

- Create App Client
- Get **ClientID** and **ClientSecret**
- **Note:** Update the following in `./AuthService/appsettings.json`:

```json
"Cognito": {
    "UserPoolId": "UserPoolId",
    "ClientId": "ClientId",
    "ClientSecret": "ClientSecret"
}
```

### 3. Create IAM Policy

- Create IAM policy named `CognitoAdminAccessPolicy`:

```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": [
        "cognito-idp:ListUsers",
        "cognito-idp:AdminGetUser",
        "cognito-idp:AdminDeleteUser",
        "cognito-idp:AdminAddUserToGroup",
        "cognito-idp:AdminRemoveUserFromGroup",
        "cognito-idp:AdminListGroupsForUser"
      ],
      "Resource": "*"
    }
  ]
}
```

### 4. Create IAM User and Assign Policy

- Create IAM user
- Attach `CognitoAdminAccessPolicy` to this user
- Create user access
- Get **AccessKey** and **AccessSecret**
- **Note:** Update the following in `./AuthService/appsettings.json`:

```json
"Cognito": {
    "AccessKey": "AccessKey",
    "SecretKey": "SecretKey"
}
```

### 5. Get AWS Region

- Determine the AWS region where resources will be deployed
- Example: `us-east-1`
- **Note:** Update the following in `./AuthService/appsettings.json`:

```json
"AWS": {
    "Region": "AWSRegion"
}
```

**Common AWS Regions:**

| Region Code      | Location           |
| ---------------- | ------------------ |
| `us-east-1`      | N. Virginia, USA   |
| `us-west-1`      | N. California, USA |
| `ap-southeast-1` | Singapore          |
| `ap-northeast-1` | Tokyo, Japan       |
| ...              | ...                |

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
