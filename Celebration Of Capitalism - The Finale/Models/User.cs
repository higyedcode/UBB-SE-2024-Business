using System.ComponentModel.DataAnnotations;

namespace Celebration_Of_Capitalism___The_Finale.Models
{
	public class User
	{
		public int Id { get; set; } = 0;
		[Required] public string Username { get; set; }
		[Required] public string Password { get; set; }
	}
}
