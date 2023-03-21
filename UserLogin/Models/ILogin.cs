using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserLogin.Models
{
    public interface ILogin
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> AuthenticateUser(string tcNo, string password);


    }
}
