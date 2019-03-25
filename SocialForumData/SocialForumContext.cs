using Microsoft.EntityFrameworkCore;
using SocialForumData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialForumData
{
    /*
     * 
     * Diese Klasse stellt unseren Datenbank Kontext Klasse dar
     * Hier ist spezifiziert welche Unserer Entitäten bei der generierung der Datenbank 
     * von Entity Framework Core beachtet werden soll
     */
    public class SocialForumContext : DbContext
    {
        public SocialForumContext(DbContextOptions<SocialForumContext> options) : base(options) 
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Thread> Threads{ get; set; }
        public DbSet<Comment> Comments{ get; set; }

          
    }
}
