using Service.Services;
using Domain.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Services.Interface;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        public int count;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public Group Create(Group group)
        {
            group.Id = count;

            _groupRepository.Create(group);
            count++;

            return group;
        }

        public void Delete(int id)
        {
            _groupRepository.Delete(id);
        }

        public Group Update(int id, Group group)
        {
            Group existData = _groupRepository.Get(m => m.Id == id);
            //existData.Id = id;
            _groupRepository.Update(id, group);
            return existData;
        }

        public Group GetById(int id)
        {
            Group existData = _groupRepository.Get(m => m.Id == id);
            return existData;
        }

        public List<Group> GetAll()
        {
            List<Group> libraries = _groupRepository.GetAll();
            return libraries;
        }
    }
}
