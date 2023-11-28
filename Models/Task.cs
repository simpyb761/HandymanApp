using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Handyman.Models
{
    public enum Categories
    {
        Auto,
        Home,
        Lawn
    }
    public enum SkillLevel
    {
        Beginner,
        Intermediate,
        Expert
    }
    public class Tasks
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        public string Tools { get; set; }
        public string Steps { get; set; }
        public Categories Category { get; set; }
        [Display(Name = "Skill Level")]
        public SkillLevel SkillLevel { get; set; }
        public int Duration { get; set; }

        [Display(Name = "Youtube Video")]

        [CustomValidation(typeof(AWValidation), "ValidateYoutubeLink")]
        public string VideoLink { get; set; }
        [Display(Name = "Estimated Price")]
        public int EstimatedPrice { get; set; }


    }
    public class AWValidation
    {
        public static ValidationResult? ValidateYoutubeLink(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }
            else
            {
                if (Regex.IsMatch(url, "embed"))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Please enter an embedded YouTube link!");
            }

        }
    }
}
