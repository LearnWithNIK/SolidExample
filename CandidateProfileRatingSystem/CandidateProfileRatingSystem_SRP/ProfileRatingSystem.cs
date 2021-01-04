using System;
using System.Linq;

namespace CandidateProfileRatingSystem_SRP
{
    public class ProfileRatingSystem
    {
        public ConsoleLogger Logger;

        public FileResumeSource ResumeSource;

        public ProfileRatingSystem()
        {
            Logger = new ConsoleLogger();
            ResumeSource = new FileResumeSource();
        }

        public int RateProfile()
        {
            Logger.Log("Starting Profile Rating System");
            Logger.Log("Loading Candidate Resume");

            string resumeJson = ResumeSource.GetResumeFromSource("Resume.json");
            Resume resume = ResumeSource.GetResumeFromJSONString(resumeJson);

            // Show upto this point in video.
            int ratingPoints = 0;
            switch (resume.Designation)
            {
                case DesignationType.SoftwareEngineer:
                    Logger.Log("Rating candidate's profile for Software Engineer designation.");
                    if (resume.TotalExperience < 1)
                    {
                        Logger.Log("Candidate must have 1 or more year's of work experience.");
                        break;
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
                    Logger.Log($"No openings for the designation {resume.Designation}");
                    break;
            }
            Logger.Log("Rating Completed.");
            return ratingPoints;
        }
    }
}
