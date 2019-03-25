using SocialForumData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialForumData
{
    public static class DbInitializer
    {
        public static void Initialize(SocialForumContext context)
        {
            context.Database.EnsureCreated();

            // Schaue nach ob es User gibt
            if (context.Users.Any())
            {
                return; //Datenbank ist befüllt
            }

            var users = new User[]
            {
                new User{Id=0,Name="Keskin",Username="bkeskin",DateOfBirth = new DateTime(1991,11,22),Firstname="Baris"},
                new User{Id=1,Name="Müller",Username="hmüller",DateOfBirth = new DateTime(1964,08,16),Firstname="Hans"},
                new User{Id=2,Name="Maier",Username="cmaier",DateOfBirth = new DateTime(1985,02,12),Firstname="Christian"},
                new User{Id=3,Name="Mustermann",Username="mmuster",DateOfBirth = new DateTime(2000,06,04),Firstname="Markus"},
                new User{Id=4,Name="Musterfrau",Username="lmufrau",DateOfBirth = new DateTime(1999,04,14),Firstname="Lisa"}
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

       
        }
    }
}
