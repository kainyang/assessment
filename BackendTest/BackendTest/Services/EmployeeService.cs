using BackendTest.Interfaces;
using BackendTest.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employeesCollection;
        public EmployeeService(IOptions<CafeDatabaseSettings> cafeDatabaseSettings)
        {
            var mongoClient = new MongoClient(cafeDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(cafeDatabaseSettings.Value.DatabaseName);

            _employeesCollection = mongoDatabase.GetCollection<Employee>(cafeDatabaseSettings.Value.EmployeeCollectionName);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _employeesCollection.Find(_ => true).SortByDescending(x => x.NumberOfDaysWorked).ToListAsync();
        }

        public async Task CreateAsync(Employee employee)
        {
            var existingEmployee = await _employeesCollection.Find(x => x.EmployeeId == employee.EmployeeId).FirstOrDefaultAsync();

            if (existingEmployee != null)
            {
                throw new Exception("Error: Employee already exist.");
            }

            employee.Id = ObjectId.GenerateNewId().ToString();

            await _employeesCollection.InsertOneAsync(employee);
        }
    }
}
