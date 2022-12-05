using PhoneBookMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneBookMVCApp.Context
{
    public class PeopleContext: DbContext
    {
        public DbSet<People> Peoples { get; set; }

    }
}