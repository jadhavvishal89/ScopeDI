using WebApplication1.Services;

namespace WebApplication1.Implementation
{
    public class ScopedService : IScopedService
    {
        private string _guid;

        public ScopedService()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return _guid;
        }
        public string GetGuid( int test)
        {
            return _guid;
        }
    }
}
