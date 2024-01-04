public record PoliticalPartyDto(Guid Id, string Name, DateTime TimeFounded, int LastVoteCount, DateTime UploadedToDb);
public record UploadPoliticalPartyDto(string Name, DateTime TimeFounded, int LastVoteCount);
public record UpdatePoliticalPartyDto(string Name, int LastVoteCount);
public record RemovePoliticalPartyDto(Guid Id);