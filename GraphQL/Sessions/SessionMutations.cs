using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Sessions;

public class SessionMutations
{
    [UseApplicationDbContext]
    public async Task<ScheduleSessionPayload> ScheduleSessionAsync(
        ScheduleSessionInput input,
        [ScopedService] ApplicationDbContext context)
    {
        if (input.EndTime < input.StartTime)
        {
            return new ScheduleSessionPayload(
                new UserError("endTime has to be larger than startTime.", "END_TIME_INVALID"));
        }

        Session session = await context.Sessions.FindAsync(input.SessionId);
        int? initialTrackId = session.TrackId;

        if (session is null)
        {
            return new ScheduleSessionPayload(
                new UserError("Session not found.", "SESSION_NOT_FOUND"));
        }

        session.TrackId = input.TrackId;
        session.StartTime = input.StartTime;
        session.EndTime = input.EndTime;

        await context.SaveChangesAsync();

        return new ScheduleSessionPayload(session);
    }
}