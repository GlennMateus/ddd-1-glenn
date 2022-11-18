namespace backend.Services.Models;

public class PostCodeService
{
    public class Response
    {
        public int Status { get; set; }
        public Result Result { get; set; }
    }

    public class Result
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Config
    {
        public string BaseUrl { get; set; }
        public string Path { get; set; }
    }
}