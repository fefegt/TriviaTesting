using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Services
{
    public class AIService
    {
        OpenAIAPI api;

        public AIService()
        {
            Debug.WriteLine("test");
            api = new OpenAIAPI("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");
            
            
        }

        public async Task<string> TestApi()
        {
            var result = api.Completions.CreateCompletionAsync(new CompletionRequest("Convert movie titles into emoji.\n\nBack to the Future:"));
            //result.WaitAsync();
            Debug.WriteLine(result);
            return result.ToString();
        }
    }
}
