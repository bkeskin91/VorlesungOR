using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialForumData.Models
{
    /*
     * Das hier ist eine sogenannte POCO Klasse
     * Diese Räpresentiert mit seinen Attributen unsere benötigten Entitäten
     */
    public class User
    {
        public int Id { get; set; }

        /*
         * Das hier ist eine sog. Daten Annotation
         * Diese erlaubt uns ein Attribut genauer zu spezifizieren oder einzugrenzen
         * In diesem Beispiel sagen wir, dass ein Username ein ebnötigtes Attribut darstellt
         * Für mehr Siehe: https://docs.microsoft.com/en-us/ef/core/modeling/relational/
         */
        [Required]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        public DateTime DateOfBirth { get; set; }


    }
}
