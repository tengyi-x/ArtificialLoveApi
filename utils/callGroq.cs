using GroqApiLibrary;
using System.Text.Json.Nodes;

class CompatibilityService
{
    private readonly string apiKey = process.env.GROQ_API_KEY;
    private readonly GroqApiClient groqApi;

    public CompatibilityService()
    {
        groqApi = new GroqApiClient(apiKey);
    }

    public async Task<string> CheckCompatibilityAsync(string bio1, string bio2)
    {
        // Modify the prompt for compatibility check
        var prompt = $"Here is bio 1: {bio1}. Here is bio 2: {bio2}. Can you determine whether these two people are compatible?";

        // Create the request object
        var request = new JsonObject
        {
            ["model"] = "llama3-8b-8192", // Use the appropriate model here
            ["messages"] = new JsonArray
            {
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = prompt
                }
            }
        };

        // Send the request to Groq
        var result = await groqApi.CreateChatCompletionAsync(request);

        // Extract and return the result from the API response
        Console.WriteLine(result?["choices"]?[0]?["message"]?["content"]?.ToString());
    }
}