using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
	public class User
	{
        public int Id { get; set; }
		public string TcNo { get; set; }
		public string Password { get; set; }
    }
}
