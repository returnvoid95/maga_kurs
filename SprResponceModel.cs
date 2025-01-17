namespace MAgistrFront
{
   
    public class SprResponceModel
    {
        public Dictionary<int, string> data { get; set; }
        public string total { get; set; }
        public string result { get; set; }
        public string error { get; set; }
        public string message { get; set; }
    }
    public class ReportResponceModel1
    {
        public List<HystoryPeriodPersonsEventCount> data { get; set; }
        public string total { get; set; }
        public string result { get; set; }
        public string error { get; set; }
        public string message { get; set; }
    }
}
