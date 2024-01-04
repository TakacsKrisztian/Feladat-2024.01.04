public interface IPoliticianInterface
{
	Task<IEnumerable<Politician>> Get();
	Task<IEnumerable<object>> GetPoliticiansWithPoliticalParties();
	Task<Politician> GetById(Guid id);
	Task PostPolitician(UploadPoliticianDto uploadPoliticianDto);
	Task<Politician> PutPolitician(Guid id, UpdatePoliticianDto updatePoliticianDto);
	Task DeletePolitician(Guid id);
}