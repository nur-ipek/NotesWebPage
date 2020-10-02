using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Notes.Entities;

namespace Notes.DataAccessLayer.Concrete
{
    public class MyInitializer: CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            User admin = new User()
            {
                Name = "Nur İpek",
                UserSurname = "Yılmaz",
                UserName = "Nipeeek",
                Password = "11223344",
                Email = "niy@gmail.com",
                IsActive = true,
                IsAdmin = true,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUserName = "Nipeeek",
                ActivateGuid = Guid.NewGuid(),
                CreatedOn = DateTime.Now,

            };

            User user = new User()
            {
                Name = "Tahsin",
                UserSurname = "Tiryaki",
                UserName = "Tako",
                Password = "123456",
                Email = "tt@gmail.com",
                IsActive = true,
                IsAdmin = false,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUserName = "Tako",
                ActivateGuid = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                
            };

            context.Users.Add(user);
            context.Users.Add(admin);
            for (int i = 0; i < 8; i++)
            {
                User fakeUser = new User()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    UserSurname = FakeData.NameData.GetSurname(),
                    UserName = $"user{i}",
                    Password = FakeData.TextData.GetAlphabetical(5),
                    Email = FakeData.NetworkData.GetEmail(),
                    IsActive = true,
                    IsAdmin = false,
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUserName = $"user{i}",
                    ActivateGuid = Guid.NewGuid(),
                    
                };
                context.Users.Add(fakeUser);
            }
            context.SaveChanges();


            List<User> userList = context.Users.ToList();

            for (int i = 0; i < 10; i++)
            {
                Category category = new Category()
                {
                    Title= FakeData.NameData.GetCompanyName(),
                    Description = FakeData.TextData.GetSentence(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUserName = "Nipeeek"
                };

                context.Categories.Add(category);

                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    User owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];

                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5,25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUserName = owner.Name

                    };
                    category.Notes.Add(note);

                    for (int j = 0; j < FakeData.NumberData.GetNumber(3,5); j++)
                    {

                        User ownerComment = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = ownerComment,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUserName = ownerComment.Name
                        };
                        note.Comments.Add(comment);
                    }

                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        Liked liked = new Liked()
                        {
                            Owner = userList[m]
                        };
                        note.Likes.Add(liked);
                    }

                }
            }

            context.SaveChanges();
        }
    }
}
