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
            var result = api.Completions.CreateCompletionAsync("Create a list of first names");
            Debug.WriteLine(result);
            
        }
    }
}
