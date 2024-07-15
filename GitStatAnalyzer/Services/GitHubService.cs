using GitStatAnalyzer.Models;
using Octokit;
using System.Text.RegularExpressions;

namespace GitStatAnalyzer.Services
{
    public class GitHubService : IGitHubService
    {
        // Private field for the GitHubClient.
        private readonly GitHubClient _client;

        // Constructor that initializes the GitHubClient.
        public GitHubService(GitHubClient client)
        {
            _client = client;
        }

        // Method to get the letter frequencies asynchronously.
        public async Task<IEnumerable<LetterFrequency>> GetLetterFrequenciesAsync()
        {
            // Repository owner.
            var repoOwner = "lodash";
            // Repository name.
            var repoName = "lodash";
            // Fetching all contents of the repository.
            var contents = await _client.Repository.Content.GetAllContents(repoOwner, repoName);

            // Filtering JavaScript and TypeScript files.
            var jsTsFiles = contents.Where(c => c.Name.EndsWith(".js") || c.Name.EndsWith(".ts"));
            // Dictionary to store letter counts
            var letterCounts = new Dictionary<char, int>();

            // Iterating over each JavaScript/TypeScript file.
            foreach (var file in jsTsFiles)
            {
                // Fetching the raw content of the file.
                var content = await _client.Repository.Content.GetRawContent(repoOwner, repoName, file.Path);
                // Converting byte array to string.
                var fileText = System.Text.Encoding.UTF8.GetString(content);
                // Finding all letters in the file.
                var letters = Regex.Matches(fileText.ToLower(), "[a-z]");

                // Counting the occurrences of each letter.
                foreach (Match letter in letters)
                {
                    if (letterCounts.ContainsKey(letter.Value[0]))
                    {
                        letterCounts[letter.Value[0]]++;
                    }
                    else
                    {
                        letterCounts[letter.Value[0]] = 1;
                    }
                }
            }

            // Ordering the letter counts in descending order and returning as a list of LetterFrequency objects.
            return letterCounts.OrderByDescending(l => l.Value)
                               .Select(l => new LetterFrequency { Letter = l.Key, Count = l.Value });
        }
    }
}
