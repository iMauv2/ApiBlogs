using Blogs.Data;

namespace Blogs.Interfaces
{
    public interface IRepository
    {
        public void CreateObject(object obj);
        public void UpdateObject(object obj);
        public bool IfExist(object obj);
        public void DeleteObject(object obj);
    }
}
