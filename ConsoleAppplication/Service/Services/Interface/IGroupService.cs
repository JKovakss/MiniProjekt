using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IGroupService
    {
        Group Create(Group data);
        Group Update(int id, Group data);
        void Delete(int id);

    }
}
