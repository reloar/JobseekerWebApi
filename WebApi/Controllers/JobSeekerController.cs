using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repository;
//using WebApi.Repository;

namespace WebApi.Controllers
{
    
    [Authorize(Roles ="ADMIN")]
 
    public class JobSeekerController : ApiController
    {
        private MyRepository repository { get; }
        public JobSeekerController()
        {
            repository = new MyRepository();
        }
  
       [HttpGet]
       
        public IEnumerable<ApplicationUser> Get()
        {

            return repository.GetAll();
        }
    }
}
