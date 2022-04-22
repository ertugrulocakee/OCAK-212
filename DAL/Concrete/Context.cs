﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-I1ODVGB;database=Hospital;integrated security=true");


        }

    
      

        public DbSet<Hospital> Hospitals { get; set; }  

        public DbSet<Meeting> Meetings { get; set; }    


        public DbSet<Branch> Branches { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

   


    }
}
