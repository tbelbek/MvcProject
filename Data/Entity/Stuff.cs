using Data.Entity.Base;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    /// <summary>
    /// Veritabani testleri icin kullanilir.
    /// </summary>
    public class Stuff : BaseEntity<long>, IBaseEntity<long>
    {
        public string Title { get; set; }
    }
}