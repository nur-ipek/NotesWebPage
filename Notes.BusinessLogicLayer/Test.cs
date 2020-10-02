using Notes.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.DataAccessLayer.Concrete;

namespace Notes.BusinessLogicLayer
{
    public class Test
    {
        private Repository<User> repo_user = new Repository<User>();
        private Repository<Category> repo_category = new Repository<Category>();
        private Repository<Comment> repo_comment = new Repository<Comment>();
        private Repository<Note> repo_note = new Repository<Note>();
        private Repository<Liked> repo_like = new Repository<Liked>();
        public Test()
        {
            List<Category> categories2 = repo_category.GetList();
        }

        public int InsertTest()
        {
            User user = new User()
            {
                Name = "Tahsin",
                UserSurname = "Tiryaki",
                UserName = "Takoo",
                Password = "qwerty",
                Email = "tt@gmail.com",
                IsActive = true,
                IsAdmin = false,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUserName = "Takoo",
                ActivateGuid = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
            };
           int result = repo_user.Insert(user);
            return result;


        }


    
        
    }
}
