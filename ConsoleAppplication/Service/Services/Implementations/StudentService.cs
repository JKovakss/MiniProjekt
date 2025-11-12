using ConsoleApplication.Domain.Entities;
using ConsoleApplication.Repository.Repositories.Implimentations;
using ConsoleApplication.Service.Services.Interfaces;

public class StudentService : IStudentSevice
{
    private StudentRepository _studentRepository;
    private GroupRepository _groupRepository;

    private int _count = 1;

    public StudentService()
    {
        _studentRepository = new StudentRepository();
        _groupRepository = new GroupRepository();
    }

    public Student Create(int studentId, Student student)
    {
        var group = _groupRepository.Get(s => s.Id == studentId);
        if (group is null) return null;

        student.Id = _count++;
        student.Group = group;

        _studentRepository.Create(student);
        return student;
    }

    public Student Update(int id, Student student)
    {
        Student dbStudent = GetById(id);

        if (dbStudent == null) return null;

        dbStudent.Name = student.Name;
        dbStudent.Surname = student.Surname;
        dbStudent.Age = student.Age;
        dbStudent.Group = student.Group;

        _studentRepository.Update(dbStudent);

        return dbStudent;
    }

    public void Delete(int id)
    {
        Student student = GetById(id);
        _studentRepository.Delete(student);
    }

    public List<Student> GetAll()
    {
        return _studentRepository.GetAll();
    }

    public Student GetById(int id)
    {
        Student student = _studentRepository.Get(s => s.Id == id);

        if (student == null) return null;

        return student;
    }

    public List<Student> SearchByAge(int age)
    {
        return _studentRepository.GetAll(a => a.Age == age);
    }

    public List<Student> SearchByName(string name)
    {
        return _studentRepository.GetAll(s => s.Name == name);
    }

    public List<Student> SearchBySurname(string surname)
    {
        return _studentRepository.GetAll(s => s.Surname == surname);
    }
}
