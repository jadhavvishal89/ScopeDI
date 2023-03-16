using DotNetDIScope.Services;

namespace DotNetDIScope.Implementation
{
    public class SingltoneService:ISingltonService
    {
        private string _guid;

        public SingltoneService()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return _guid;
        }
        public string GetGuid(int test)
        {
            return _guid;
        }
    }
}
