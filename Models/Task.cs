using System.ComponentModel.DataAnnotations;

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
        public string TaskName { get; set; }
        public string Tools { get; set; }
        public string Steps { get; set; }
        public Categories Category { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public int Duration { get; set; }
        public string VideoLink { get; set; }
        public int EstimatedPrice { get; set; }


    }
}
