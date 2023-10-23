﻿using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrastructure.DataAction
{
    public  class DataContexts : DbContext
    {
        protected DbSet<User> User {  get; set; }
        protected DbSet<Photo> Photos {  get; set; }
        protected DbSet<Friend> Friends {  get; set; }

        //public DataContext ( DbSet<User> user, DbSet<Photo> photos, DbSet<Friend> friends)
        //{
        //    User = user;
        //    Photos = photos;
        //    Friends = friends;
        //}
        public DataContexts (DbContextOptions <DataContexts> options)
            : base (options)
        {
        //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
       
    }
}