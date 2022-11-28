namespace JobSearch.Models
{
    public class Job
    {
        public int id { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public int locationId { get; set; }
        public int departmentId { get; set; }
        public DateTime closingDate { get; set; }

        public DateTime postDate { get; set; }

        public string Jobcode { get; set; }

       
    }

    public class department
    {
        public int id { get; set; }
        public string title { get; set; }


    }

    public class location
    {
        public int id { get; set; }
        public string title { get; set; }

        public string city { get; set; }

        public string state { get; set; }
        public string country { get; set; }

        public int zip { get; set; }      

    }


}
