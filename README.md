# Assessment  

Prerequisite  
-Have Docker installed and running  
-Have dotnet installed  

------Build Frontend------  

docker build ./frontend-test/. -t frontend  

------Run Frontend & Backend------  

Run command "docker-compose up -d" within the assessment folder  

Navigate to assessment/BackendTest/BackendTest folder and run command "dotnet run"  

Access frontend at https://localhost:3000    

Access backend at https://localhost:5001
Swagger: https://localhost:5001/swagger/index.html
