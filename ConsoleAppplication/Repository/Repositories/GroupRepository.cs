using Domain.Common;
using Domain.Models;
using Repository.Data;
using Repository.Exeptions;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found!");

                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int id)
        {
            Group group = AppDbContext<Group>.datas.Find(m => m.Id == id);
            AppDbContext<Group>.datas.Remove(group);
        }

        public void Update(int id, Group data)
        {
            Group existData = AppDbContext<Group>.datas.Find(m => m.Id == id);

            if (!string.IsNullOrWhiteSpace(data.Name))
                existData.Name = data.Name;

            if (!string.IsNullOrWhiteSpace(data.Teacher))
                existData.Teacher = data.Teacher;

            if (!string.IsNullOrWhiteSpace(data.Room.ToString()))
                existData.Room = data.Room;
        }

        public Group Get(Predicate<Group>? predicate)
        {
            Group existData = AppDbContext<Group>.datas.Find(predicate);
            return existData;
        }
    }
}
