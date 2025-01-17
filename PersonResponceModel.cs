namespace MAgistrFront
{
    public class PersonResponceModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int TimePeriodId { get; set; }
        public string TimePeriodName { get; set; }

        public DateTime EditOn { get; set; }
        public ShortUserData Author { get; set; }
        public List<string> Ilustrations { get; set; }
        public List<Urls> Urls { get; set; }
        public List<int> RegionIds { get; set; }
        public List<iIdName> Regions { get; set; }



    }
    public class ShortUserData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }



    public class PersonMassResponceModel
    {
        public PersonResponceModel data { get; set; }
        public string total { get; set; }
        public string result { get; set; }
        public string error { get; set; }
        public string message { get; set; }
    }

    
}
