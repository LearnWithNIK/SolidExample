using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CandidateProfileRatingSystem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Profile Rating System");
            Console.WriteLine("Loading Candidate Resume");

            string resumeJson = File.ReadAllText("Resume.json");
            Resume resume = JsonConvert.DeserializeObject<Resume>(resumeJson);
            int ratingPoints = 0;
            switch (resume.Designation)
            {
                case DesignationType.SoftwareEngineer:
                    Console.WriteLine("Rating candidate's profile for Software Engineer designation.");
                    if (resume.TotalExperience < 1)
                    {
                        Console.WriteLine("Candidate must have 1 or more year's of work experience.");
                        return;
                    }
                    if (resume.TechnicalSkills.Any())
                    {
                        if (resume.TechnicalSkills.Any(e => e == Skills.OOPS) && resume.TechnicalSkills.Any(e => e == Skills.DotNetCore) && resume.TechnicalSkills.Any(e => e == Skills.ASP) && resume.TechnicalSkills.Any(e => e == Skills.SQL))
                        {
                            ratingPoints += 50;
                        }
                        if (resume.TechnicalSkills.Any(e => e == Skills.Angular) && resume.TechnicalSkills.Any(e => e == Skills.React) && resume.TechnicalSkills.Any(e => e == Skills.Azure))
                        {
                            ratingPoints += 20;
                        }
                        if (resume.TechnicalSkills.Any(e => e == Skills.Javascript) && resume.TechnicalSkills.Any(e => e == Skills.JQuery) && resume.TechnicalSkills.Any(e => e == Skills.HTML5) && resume.TechnicalSkills.Any(e => e == Skills.CSS4))
                        {
                            ratingPoints += 10;
                        }
                        if(resume.RelevantExperience > 4)
                        {
                            ratingPoints += 20;
                        }
                    }
                    break;

                case DesignationType.SeniorSoftwareEngineer:
                    // Similar rating calculation as per designation
                    break;

                case DesignationType.CloudEngineer:
                    // Similar rating calculation as per designation
                    break;
                case DesignationType.TechnicalSupportEngineer:
                    // Similar rating calculation as per designation
                    break;
                default:
                    Console.WriteLine($"No openings for the designation {resume.Designation}");
                    break;
            }
            Console.WriteLine("Rating Completed.");
        }
    }
}
