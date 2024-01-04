public static class Extensions
{
    public static PoliticianDto AsDto(this PoliticianDto politician)
    {
        return new PoliticianDto(politician.Id, politician.Name, politician.DateOfBirth, politician.Gender, politician.UploadedToDb, politician.PoliticalParty, politician.PoliticalPartyId);
    }
    
    public static PoliticalPartyDto AsDto(this PoliticalPartyDto politicalParty)
    {
        return new PoliticalPartyDto(politicalParty.Id, politicalParty.Name, politicalParty.TimeFounded, politicalParty.LastVoteCount, politicalParty.UploadedToDb);
    }
}