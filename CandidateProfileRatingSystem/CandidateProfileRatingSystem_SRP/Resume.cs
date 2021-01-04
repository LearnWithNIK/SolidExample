using System.Collections.Generic;

namespace CandidateProfileRatingSystem_SRP
{
    public class Resume
    {
        public string Designation { get; set; }

        public int TotalExperience { get; set; }

        public int RelevantExperience { get; set; }

        public List<string> TechnicalSkills { get; set; }
    }
}