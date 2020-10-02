using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Entities
{
    [Table("Users")]
   public class User: MyEntityBase
    {
        [Required,StringLength(25)]
        public string UserName { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string UserSurname { get; set; }
        [Required, StringLength(70)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsAdmin { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Note> Notes { get; set; }
        public List<Liked> Likes { get; set; }

        public User()
        {
            Comments = new List<Comment>();
            Notes = new List<Note>();
            Likes = new List<Liked>();
        }
    }
}
