
using Microsoft.EntityFrameworkCore;

public class politicianService : IPoliticianInterface
{
	private readonly PoliticalDbContext dbContext;

	public politicianService(PoliticalDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

    public async Task DeletePolitician(Guid id)
    {
        var politician = await dbContext.Politicians.FindAsync(id);

        if (politician == null)
        {
            throw new KeyNotFoundException($"A {id} id-vel a politikus nem található.");
        }
        else
        {
            dbContext.Politicians.Remove(politician);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Politician>> Get()
    {
        return await dbContext.Politicians.ToListAsync();
    }

    public async Task<Politician> GetById(Guid id)
    {
        var politician = await dbContext.Politicians.FindAsync(id);

        if (politician == null)
        {
            throw new KeyNotFoundException($"A {id} id-vel a politikus nem található.");
        }
        else
        {
            return politician;
        }
    }

    public async Task<IEnumerable<object>> GetPoliticiansWithPoliticalParties()
    {
        return await dbContext.Politicians.Include(u => u.PoliticalParty).ToListAsync();
    }

    public async Task PostPolitician(UploadPoliticianDto uploadPoliticianDto)
    {
        var politician = new Politician
        {
            Id = Guid.NewGuid(),
            Name = uploadPoliticianDto.Name,
            DateOfBirth = uploadPoliticianDto.DateOfBirth,
            Gender = uploadPoliticianDto.Gender,
            UploadedToDb = DateTime.Now,
            PoliticalPartyId = uploadPoliticianDto.PoliticalPartyId
        };
            await dbContext.Politicians.AddAsync(politician);
            await dbContext.SaveChangesAsync();
    }

    public async Task<Politician> PutPolitician(Guid id, UpdatePoliticianDto updatePoliticianDto)
    {
        var politician = await dbContext.Politicians.FindAsync(id);

        if (politician == null)
        {
            throw new KeyNotFoundException($"A {id} id-vel a politikus nem található.");
        }
        else
        {
            politician.Name = updatePoliticianDto.Name;
            politician.PoliticalPartyId = updatePoliticianDto.PoliticalPartyId;

            await dbContext.SaveChangesAsync();

            return politician;
        }
    }
}