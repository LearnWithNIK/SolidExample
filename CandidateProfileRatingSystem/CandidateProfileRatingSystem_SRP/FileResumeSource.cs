using System;
using System.IO;
using Newtonsoft.Json;

namespace CandidateProfileRatingSystem_SRP
{
    public class FileResumeSource
    {
        public string GetResumeFromSource(string filename)
        {
            return File.ReadAllText(filename);
        }

        public Resume GetResumeFromJSONString(string json)
        {
            return JsonConvert.DeserializeObject<Resume>(json);
        }
    }
}
 