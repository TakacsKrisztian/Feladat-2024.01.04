using System.ComponentModel.DataAnnotations;

public class PoliticalParty
{
	[Key]
	public Guid Id { get; set; }
	public string ?Name { get; set; }
    public DateTime TimeFounded { get; set; }
    public int LastVoteCount { get; set; }
	public DateTime UploadedToDb { get; set;}

	public List<Politician> ?Politicians { get; set; }
}