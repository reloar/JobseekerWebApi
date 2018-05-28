using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class MyRepository : IRepository
    {
        private ApplicationDbContext context;
        public MyRepository()
        {
            this.context = new ApplicationDbContext();
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return context.Users.ToList();
            //throw new NotImplementedException();
        }
    }
}