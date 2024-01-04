using System.ComponentModel.DataAnnotations;

public class Politician
{
	[Key]
	public Guid Id { get; set; }
	public string ?Name { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string ?Gender { get; set; }
	public DateTime UploadedToDb { get; set; }

	public PoliticalParty ?PoliticalParty { get; set; }
	public Guid PoliticalPartyId { get; set; }
}