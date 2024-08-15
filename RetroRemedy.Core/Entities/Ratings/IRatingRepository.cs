namespace RetroRemedy.Core.Entities.Ratings;

public interface IRatingRepository
{
    public int i { get; set; }
    public Task AddVote(int i)
    {
        i++;
        return Task.CompletedTask;
    }
}