using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services;

public class CoursesService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CoursesService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<CourseResult> GetAllCourses(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        try
        {
            var allCoursesResponse = await _httpClient.GetAsync($"https://localhost:7034/api/Courses?category={Uri.EscapeDataString(category)}&searchQuery={Uri.EscapeDataString(searchQuery)}&pageNumber={pageNumber}&pageSize={pageSize}&key={_configuration["ApiKey:Secret"]}");

            var json = await allCoursesResponse.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<CourseResult>(json);

            if (courses != null)
            {
                return courses;
            }

        }
        catch (Exception ex) { }
        return null!;
    }


}
