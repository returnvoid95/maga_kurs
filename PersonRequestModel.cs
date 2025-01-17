namespace MAgistrFront
{
  
    public class PersonRequestModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int TimePeriodIds { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public List<Urls> Urls { get; set; }
        public List<iIdName> RegionIds { get; set; }
        public List<int> Regions { get; set; }


    }
    public class Urls
    {
        public int? Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
    public class iIdName
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
