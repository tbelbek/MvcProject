using Core;
using Data.Entity;
using Data.Repository;

namespace Web
{
    public class IoCRegister
    {
        public static void Register()
        {
            DependencyFactory.Register(typeof(RepositoryBase<long, Stuff>), typeof(StuffRepository), "StuffRepository");
        }
    }
}
