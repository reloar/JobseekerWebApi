﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IRepository
    {
        IEnumerable<ApplicationUser> GetAll();
        
    }
}