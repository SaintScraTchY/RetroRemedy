namespace RetroRemedy.Core.Entities.BlogEntities;

public interface IRatingRepository
{
    public int i { get; set; }
    public Task AddVote(int i)
    {
        i++;
        return Task.CompletedTask;
    }
}