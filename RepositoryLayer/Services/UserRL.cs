using CommonLayer.User;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooDbContext dbContext;
        public UserRL(FundooDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                User user = new User();
                user.userId = new User().userId;
                user.firstName = userPostModel.firstName;
                user.lastName = userPostModel.lastName;
                user.email = userPostModel.email;
                user.phoneNumber = userPostModel.phoneNumber;
                user.address = userPostModel.address;
                user.password = userPostModel.password;
                user.cPassword = userPostModel.cPassword;
                user.registeredDate = DateTime.Now;
                user.modifiedDate = DateTime.Now;
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool LogInUser(UserLogIn userLogIn)
        {
            try
            {
                User user = new User();
                var result = dbContext.Users.Where(x => x.email == userLogIn.email && x.password == userLogIn.password).FirstOrDefault();
                if (result != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}