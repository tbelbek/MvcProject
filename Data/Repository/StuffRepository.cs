using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data.Repository
{
    public class StuffRepository : RepositoryBase<long, Stuff>
    {
        public static Stuff SaveSample()
        {
            var stuff = new Stuff()
            {
                Title = "some stuff",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            var stuffRepository = new StuffRepository();
            stuffRepository.Insert(stuff);
            stuffRepository.Save();
            return stuff;
        }

        public static List<Stuff> GetAllStuff()
        {
            var stuffRepository = new StuffRepository();
            return stuffRepository.GetAll();
        }
    }
}
