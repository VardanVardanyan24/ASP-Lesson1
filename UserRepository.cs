namespace Lesson1
{
    public class UserRepository
    {
        public string innerGuid = Guid.NewGuid().ToString();
        public IEnumerable<User> GetList()
        {
            return new List<User>();
        }

        public User Get(int id)
        {
            return new User() { Id = id, Name = innerGuid };
        }


        public void Add(User book)
        {
        }
    }
}
