using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcCoreTutuorial.Models.Domain
{
	public class Person
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set; }

	}	
}
