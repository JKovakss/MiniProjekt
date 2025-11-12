using ConsoleApplication.Domain.Entities;

namespace ConsoleApplication.Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id, Group group);
        void Delete(int id);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> SearchByTeacher(string teacher);
        List<Group> SearchByRoom(int room);
        List<Group> SearchByName(string name);
    }
}
