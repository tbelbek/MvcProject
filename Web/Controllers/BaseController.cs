using Core;
using Data.Entity.Base;
using Data.Repository;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController<T> : Controller where T : BaseEntity<long>
    {
        protected RepositoryBase<long, T> Repository = LightInjectInstanceProvider.GetInstance<RepositoryBase<long, T>>();
        ////GET: Base
    }
}