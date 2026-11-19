using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Student
    {
        public Student()
        {
            
        }

        public Student(string name, string mobileNo, int course1)
        {
            Id = GlobalService.GetNextNumber().ToString();
            Name = name;
            MobileNo = mobileNo;
            Course1 = course1;
        }
        
        private string? _id;
        private string _name = string.Empty;
        private string? _mobileNo = string.Empty;
        private int _course;
        
        public string? Id { get => _id; set => _id = value; }
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get => _name; set => _name = value; }
        [Required(ErrorMessage = "Please enter mobile number")]
        [RegularExpression(@"^[0-9]{10}$",
           ErrorMessage = "Mobile number must contain exactly 10 digits")]
        public string MobileNo { get => _mobileNo; set => _mobileNo = value; }
        [Required(ErrorMessage = "Please select a course")]
        public int Course1 { get => _course; set => _course = value; }

        public enum Course
        {
            MachineLearning,
            AI_SoftwareDevelopemt,
            BigData
        }
    }
}
