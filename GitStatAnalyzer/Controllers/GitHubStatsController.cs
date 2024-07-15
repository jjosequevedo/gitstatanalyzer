using GitStatAnalyzer.Models;
using GitStatAnalyzer.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitStatAnalyzer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubStatsController : ControllerBase
    {
        // Private field for the IGitHubService.
        private readonly IGitHubService _gitHubService;

        // Constructor that initializes the GitHubStatsController with an IGitHubService.
        public GitHubStatsController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        // GET: api/githubstats/letter-frequencies.
        // Method to get the letter frequencies asynchronously.
        [HttpGet("letter-frequencies")]
        public async Task<IEnumerable<LetterFrequency>> GetLetterFrequencies()
        {
            // Calling the service method to get the letter frequencies.
            return await _gitHubService.GetLetterFrequenciesAsync();
        }
    }
}
