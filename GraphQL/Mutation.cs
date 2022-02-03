using GraphQL.Data;

namespace GraphQL;

public class Mutation
{
    public async Task<Speaker> AddSpeakerAsync(
        string name,
        string? bio,
        string? webSite,
        [Service] ApplicationDbContext context)
    {
        var speaker = new Speaker
        {
            Name = name,
            Bio = bio,
            WebSite = webSite
        };
        context.Add(speaker);
        await context.SaveChangesAsync();
        return speaker;
    }
}