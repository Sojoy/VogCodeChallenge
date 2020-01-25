namespace VogCodeChallenge.Core.Models
{
    public class Employee: Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public virtual Department Department { get; set; }
    }
}