namespace Kitty.Core.Infrastructure
{
    public interface IResult
    {
        bool WasSuccessful { get; }
        string[] Errors { get; }
        bool WasFailure { get; }
    }
}