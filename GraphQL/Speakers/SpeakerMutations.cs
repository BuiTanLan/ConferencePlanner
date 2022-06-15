using GraphQL.Data;

namespace GraphQL.Speakers;

[ExtendObjectType("Mutation")]
public class SpeakerMutations
{

    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        [ScopedService] ApplicationDbContext context)
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };
        context.Add(speaker);
        var result = await context.SaveChangesAsync();
        if (result <= 0)
        {
            throw new Exception();
        }

        return new AddSpeakerPayload(speaker);
    }
}