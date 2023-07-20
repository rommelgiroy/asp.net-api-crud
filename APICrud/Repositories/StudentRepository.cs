using APICrud.Contracts;
using APICrud.Models;
using Dapper;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace APICrud.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IConfiguration _config;
    public StudentRepository(IConfiguration config)
    {
        _config = config;
    }
    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        using var connection = new SqlConnection(_config.GetConnectionString("default"));
        var student = await connection.QueryAsync<Student>("select * from student");
        return student;
    }
    public async Task<Student> GetStudent(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("default"));
        var student = await connection.QueryFirstAsync<Student>("select * from student where id = @id", new { Id = id });
        return student;
    }

    public async Task CreateStudent(Student student)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("default"));
        var query = "insert into student (FirstName, LastName, Grade, Section) values (@FirstName, @LastName, @Grade, @Section)";
        await connection.ExecuteAsync(query, student);
    }

    public async Task DeleteStudent(int id)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("default"));
        var student = await connection.ExecuteAsync("delete from student where id = @id", new { Id = id });
    }

    public async Task UpdateStudent(Student student)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("default"));
        var query = "update student set FirstName = @FirstName, LastName = @LastName, Grade = @Grade, Section = @Section where id = @Id";
        await connection.ExecuteAsync(query, student);
    }
}
