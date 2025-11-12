using ConsoleApplication.Domain.Entities;
using ConsoleApplication.Repository.Data;
using ConsoleApplication.Repository.Exceptions;
using ConsoleApplication.Repository.Repositories.Interfaces;

namespace ConsoleApplication.Repository.Repositories.Implimentations
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found");

                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public void Update(Group data)
        {
            Group group = Get(g => g.Id == data.Id);

            if (!string.IsNullOrWhiteSpace(data.Name))
            {
                group.Name = data.Name;
            }
            else if (!string.IsNullOrWhiteSpace(data.Teacher))
            {
                group.Teacher = data.Teacher;
            }
            else if (!string.IsNullOrWhiteSpace(data.Room.ToString()))
            {
                group.Room = data.Room;
            }
        }
    }
}
