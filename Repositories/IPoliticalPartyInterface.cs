public interface IPoliticalPartyInterface
{
	Task<IEnumerable<PoliticalParty>> Get();
	Task<PoliticalParty> GetById(Guid id);
	Task PostPoliticalParty(UploadPoliticalPartyDto uploadPoliticalPartyDto);
	Task<PoliticalParty> PutPoliticalParty(Guid id, UpdatePoliticalPartyDto updatePoliticalPartyDto);
	Task DeletePoliticalParty(Guid id);
}