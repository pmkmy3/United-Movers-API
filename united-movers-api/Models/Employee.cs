namespace united_movers_api.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BloodGroup { get; set; }

        public string Gender { get; set; }

        public string PersonalEmailID { get; set; }

        public string ContactNumber { get; set; }

        public string AlternativeContactNumber { get; set; }

        public string EmergencyContactNumber { get; set; }

        public string AadhaarNumber { get; set; }

        public string PanNumber { get; set; }

        public string AccountNumber { get; set; }

        public string BankName { get; set; }

        public string IFSCCode { get; set; }

        public string CommunicationAddress { get; set; }

        public string PermanantAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int CreatedByID { get; set; }

        public int ModifiedByID { get; set; }

    }
}
