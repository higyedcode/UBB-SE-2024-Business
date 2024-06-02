namespace Celebration_Of_Capitalism___The_Finale.Models
{
	public class Product
	{
		public int Id { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Brand { get; set; } = string.Empty;
		public string ImageURL { get; set; } = string.Empty;
		public IDictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
	}
}
