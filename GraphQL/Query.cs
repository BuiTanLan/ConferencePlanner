using GraphQL.Data;
using GraphQL.DataLoader;

namespace GraphQL;

public class Query
{
    public IQueryable<Speaker> GetSpeakers(ApplicationDbContext context)
        => context.Speakers;

    public Task<Speaker> GetSpeakerAsync(
        [ID(nameof(Speaker))] int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
}


