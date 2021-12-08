using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public interface IUserRepository
    {
        public User AddUser(string UserName, string UserEmail);
        public User GetUser(string UserEmail);
    }
}
