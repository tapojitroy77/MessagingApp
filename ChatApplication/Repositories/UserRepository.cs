using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>();
        public User AddUser(string UserName, string UserEmail)
        {
            if (this.GetUser(UserEmail) != null)
            {
                return this.GetUser(UserEmail);
            }
            var user = new User { UserEmail = UserEmail, UserName = UserName };
            users.Add(user);
            return user;
        }
        public User GetUser(string UserEmail)
        {
            return users.FirstOrDefault(user => user.UserEmail == UserEmail, null);
        }
    }
}
