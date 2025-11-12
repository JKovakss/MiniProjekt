using ConsoleApplication.Domain.Common;

namespace ConsoleApplication.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Room { get; set; }
    }
}
