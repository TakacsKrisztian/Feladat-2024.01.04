public record PoliticianDto(Guid Id, string Name, DateTime DateOfBirth, string Gender, DateTime UploadedToDb, PoliticalParty PoliticalParty, Guid PoliticalPartyId);
public record UploadPoliticianDto(string Name, DateTime DateOfBirth, string Gender, Guid Guid, Guid PoliticalPartyId);
public record UpdatePoliticianDto(string Name, Guid PoliticalPartyId);
public record RemovePoliticianDto(Guid Id);