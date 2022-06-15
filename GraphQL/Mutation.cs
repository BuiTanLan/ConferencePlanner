using GraphQL.Data;

namespace GraphQL;

public class Mutation
{
    public async Task<Speaker> AddSpeakerAsync(
        string name,
        string? bio,
        string? webSite,
        [ScopedService] ApplicationDbContext context)
    {
        var speaker = new Speaker
        {
            Name = name,
            Bio = bio,
            WebSite = webSite
        };
        context.Add(speaker);
        var result = await context.SaveChangesAsync();
        if (result <= 0)
        {
            throw new Exception();
        }

        return speaker;
    }
}