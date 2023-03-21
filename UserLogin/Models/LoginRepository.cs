using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserLogin.Models
{
    public class LoginRepository 
    {
        private readonly LoginDbContext _context;

        public LoginRepository(LoginDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateUser(string tcNo, string password)
        {
            var succeeded = await _context.UserLogins.FirstOrDefaultAsync(x => x.TcNo == tcNo && x.Password == password);
            return succeeded;
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            return await _context.UserLogins.ToListAsync();
        }
        public void Add(User user)
        {
            _context.UserLogins.Add(user);
        }


    }
}
