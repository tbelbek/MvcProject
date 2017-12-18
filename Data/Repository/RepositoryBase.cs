using Data.Interface;
using Data.RepositoryBase;

namespace Data.Repository
{
    public class RepositoryBase<TKeyType, TEntity> : AbstractRepositoryBase<TKeyType, TEntity, DbContext>
        where TEntity : class, IBaseEntity<TKeyType>
    {
        public RepositoryBase()
        {
            if (Context == null)
            {
                Context = new DbContext();
            }
            Context.Configuration.LazyLoadingEnabled = false;
            Context.Database.Log = s => System.Diagnostics.Trace.WriteLine(s);
        }

        //public override DbContext Context
        //{
        //    get { _DbContext; }
        //}
    }
}
