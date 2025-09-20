# 🧑‍💼 Employee Management System

### A .NET Core Web API Microservices Project With AWS Services

## 🔐 AuthService - Auth APIs

- Base URL: [`BaseURL`](http://lb-employeemanagement-1568128750.ap-southeast-1.elb.amazonaws.com/api/auth-service)
- Swagger UI: [`SwaggerUI`](http://lb-employeemanagement-1568128750.ap-southeast-1.elb.amazonaws.com/api/auth-service/swagger/index.html)
- Auth Mechanism: AWS Cognito (User Pool, App Client)
- Infrastructure: AWS EC2
- Image Registry: Docker Hub [`hdthanhtuan/authservice`](https://hub.docker.com/repository/docker/hdthanhtuan/authservice)
- Pipeline: [![Build & Push AuthService image to Docker Hub](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-authservice-dockerhub.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-authservice-dockerhub.yml)
- Image Registry: AWS ECR Repository
- Pipeline: [![Build & Push AuthService image to AWS ECR repository](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-authservice-aws-ecr.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-authservice-aws-ecr.yml)
<img width="1601" height="742" alt="image" src="https://github.com/user-attachments/assets/734d5a9c-ab77-4a81-b785-da63b28de85e" />

## 👥 EmployeeService - Employee APIs

- Base URL: [`BaseURL`](http://lb-employeemanagement-1568128750.ap-southeast-1.elb.amazonaws.com/api/employee-service)
- Swagger UI: [`SwaggerUI`](http://lb-employeemanagement-1568128750.ap-southeast-1.elb.amazonaws.com/api/employee-service/swagger/index.html)
- Database: AWS RDS SQL Server
- Image Storage: AWS S3
- Infrastructure: AWS EC2
- Image Registry: Docker Hub [`hdthanhtuan/employeeservice`](https://hub.docker.com/repository/docker/hdthanhtuan/employeeservice)
- Pipeline: [![Build & Push EmployeeService image to Docker Hub](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-employeeservice-dockerhub.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-employeeservice-dockerhub.yml)
- Image Registry: AWS ECR Repository
- Pipeline: [![Build & Push EmployeeService image to AWS ECR repository](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-employeeservice-aws-ecr.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-employeeservice-aws-ecr.yml)
<img width="1587" height="790" alt="image" src="https://github.com/user-attachments/assets/f1002674-ca9c-4003-a5d9-8ea6b93aca52" />

## ⚙️ InfraCore - Infrastructure Commons

- Package Manager: NuGet.org
- NuGet package: [`EmployeeManagement.InfraCore`](https://www.nuget.org/packages/EmployeeManagement.InfraCore/)
- Pipeline: [![Build & Push InfraCore commons to Nuget.org](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-infracore-nugetorg.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/publish-infracore-nugetorg.yml)

## 🚀 Automation Deployment - Auto Deploy Docker Hub Images

- Runner: GitHub Self-Hosted Runner
- Infrastructure: AWS EC2
- Pipeline: [![Auto deploy Docker Hub images to AWS EC2](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/auto-deploy-dockerhub-images-ec2.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/auto-deploy-dockerhub-images-ec2.yml)

## 🚀 Manual Deployment - Deploy AWS ECR Images From Workflow Inputs

- Runner: GitHub Self-Hosted Runner
- Infrastructure: AWS EC2
- Pipeline: [![Manual deploy AWS ECR images to EC2](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/manual-deploy-aws-ecr-images-ec2.yml/badge.svg)](https://github.com/huynhducthanhtuan/EmployeeManagement/actions/workflows/manual-deploy-aws-ecr-images-ec2.yml)

Copyright © 2025 Huynh Duc Thanh Tuan. All rights reserved.
