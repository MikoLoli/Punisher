using System;

namespace Punisher.DTO
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FIO { get; set; }
        public DateTime RecruitmentDate { get; set; }
        public int Reputation { get; set; }
        public string Position { get; set; }
        public decimal WageRate { get; set; }
        public decimal Salary { get; set; }
        public string Action { get; set; }
    }
}
