namespace Infrastructure.Models.Courses;

public class GraphQLResponseModel
{
    public class Data
    {
        public List<Course> GetCourses { get; set; }
    }

    public class GraphQLResponse
    {
        public Data Data { get; set; }
    }
}
