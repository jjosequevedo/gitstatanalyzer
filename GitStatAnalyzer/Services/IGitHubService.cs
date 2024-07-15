using GitStatAnalyzer.Models;

namespace GitStatAnalyzer.Services
{
    public interface IGitHubService
    {
        // Interface for the GitHub service.
        Task<IEnumerable<LetterFrequency>> GetLetterFrequenciesAsync();
    }
}
