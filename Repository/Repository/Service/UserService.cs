using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using Repository.Repository.Interface;
using System.Drawing.Printing;

namespace Repository.Repository.Service
{
    public class UserService :iUser
    {
        private readonly ApplicationContext context;

        public UserService(ApplicationContext context)
        {
            this.context = context;
            
        }

        public async Task<IEnumerable<User>> Getusers()
        {
            var data = await context.Users.ToListAsync();
            return data;
        }
        public async Task<int>AddUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user.UserId;
        }
        public async Task<User>GetUserById(int id)
        {
            var data = await context.Users.Where(e=>e.UserId == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<bool>UpdateRecord(User user)
        {
            bool status = false;
            if (user != null)
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
                status = true;
            }
            return status;


        }
    }
}
