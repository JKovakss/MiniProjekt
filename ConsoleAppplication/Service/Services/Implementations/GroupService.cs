using ConsoleApplication.Domain.Entities;
using ConsoleApplication.Repository.Data;
using ConsoleApplication.Repository.Repositories.Implimentations;
using ConsoleApplication.Service.Services.Interfaces;

namespace ConsoleApplication.Service.Services.Implimentations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;

        private int _count = 1;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public Group Create(Group group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;

            return group;
        }

        public Group Update(int id, Group group)
        {
            Group dbGroup = GetById(id);

            if (dbGroup == null) return null;

            dbGroup.Name = group.Name;
            dbGroup.Teacher = group.Teacher;
            dbGroup.Room = group.Room;

            _groupRepository.Update(dbGroup);

            return dbGroup;
        }

        public void Delete(int id)
        {
            Group group = GetById(id);
            _groupRepository.Delete(group);
        }

        public Group GetById(int id)
        {
            Group group = _groupRepository.Get(l => l.Id == id);

            if (group == null) return null;

            return group;
        }

        public List<Group> SearchByTeacher(string teacher)
        {
            return _groupRepository.GetAll(G => G.Teacher == teacher);
        }

        public List<Group> SearchByRoom(int room)
        {
            return _groupRepository.GetAll(G => G.Room == room);
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> SearchByName(string name)
        {
            return _groupRepository.GetAll(G => G.Name == name);
        }
    }
}
