using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CandidateProfileRatingSystem_SRP
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
                        if (resume.TechnicalSkills.Any(e => e == "OOPS") && resume.TechnicalSkills.Any(e => e == ".net Core") && resume.TechnicalSkills.Any(e => e == "Asp.net") && resume.TechnicalSkills.Any(e => e == "SQL"))
                        {
                            ratingPoints += 50;
                        }
                        if (resume.TechnicalSkills.Any(e => e == "Angular JS") && resume.TechnicalSkills.Any(e => e == "React") && resume.TechnicalSkills.Any(e => e == "Azure Services"))
                        {
                            ratingPoints += 20;
                        }
                        if (resume.TechnicalSkills.Any(e => e == "Javascript") && resume.TechnicalSkills.Any(e => e == "Jquery") && resume.TechnicalSkills.Any(e => e == "HTML5") && resume.TechnicalSkills.Any(e => e == "CSS4"))
                        {
                            ratingPoints += 10;
                        }
                        if (resume.RelevantExperience > 4)
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
