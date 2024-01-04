
using Microsoft.EntityFrameworkCore;

public class politicalpartyService : IPoliticalPartyInterface
{
    private readonly PoliticalDbContext dbContext;

    public politicalpartyService(PoliticalDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task DeletePoliticalParty(Guid id)
    {
        var politicalparty = await dbContext.PoliticalParties.FindAsync(id);

        if (politicalparty == null)
        {
            throw new KeyNotFoundException($"A {id} id-vel a politikai párt nem található.");
        }
        else
        {
            dbContext.PoliticalParties.Remove(politicalparty);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<PoliticalParty>> Get()
    {
        return await dbContext.PoliticalParties.ToListAsync();
    }

    public async Task<PoliticalParty> GetById(Guid id)
    {
        var politicalparty = await dbContext.PoliticalParties.FindAsync(id);

        if (politicalparty == null)
        {
            throw new KeyNotFoundException($"A {id} id-vel a politikai párt nem található.");
        }
        else
        {
            return politicalparty;
        }
    }

    public async Task PostPoliticalParty(UploadPoliticalPartyDto uploadPoliticalPartyDto)
    {
        var politicalparty = new PoliticalParty
        {
            Id = Guid.NewGuid(),
            Name = uploadPoliticalPartyDto.Name,
            TimeFounded = uploadPoliticalPartyDto.TimeFounded,
            LastVoteCount = uploadPoliticalPartyDto.LastVoteCount,
            UploadedToDb = DateTime.Now
        };
        await dbContext.PoliticalParties.AddAsync(politicalparty);
        await dbContext.SaveChangesAsync();
    }

    public async Task<PoliticalParty> PutPoliticalParty(Guid id, UpdatePoliticalPartyDto updatePoliticalPartyDto)
    {
        var politicalparty = await dbContext.PoliticalParties.FindAsync(id);

        if (politicalparty == null)
        {
            throw new KeyNotFoundException($"A {id} id-vel a politikai párt nem található.");
        }
        else
        {
            politicalparty.Name = updatePoliticalPartyDto.Name;
            politicalparty.LastVoteCount = updatePoliticalPartyDto.LastVoteCount;

            await dbContext.SaveChangesAsync();

            return politicalparty;
        }
    }
}