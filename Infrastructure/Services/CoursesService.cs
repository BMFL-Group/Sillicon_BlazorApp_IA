using Infrastructure.Models;
using Infrastructure.Models.Courses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

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

    public async Task<CourseResult> GetAllCourses(string category = "all", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        try
        {
            // requests = OLDREQUESTS top - local api from asp.net project, bottom - Lucas Api from azure, GRAPHQL - björns api from graphql.

            #region OLD REQUESTS
            // var allCoursesResponse = await _httpClient.GetAsync($"https://silicon-courses-webapi.azurewebsites.net/api/courses?category={Uri.EscapeDataString(category)}&searchQuery={Uri.EscapeDataString(searchQuery)}&pageNumber={pageNumber}&pageSize={pageSize}&key={_configuration["ApiKey:Secret"]}");
            //var allCoursesResponse = await _httpClient.GetAsync($"{_configuration["ConnectionStrings:CoursesApi"]}?category={Uri.EscapeDataString(category)}&searchQuery={Uri.EscapeDataString(searchQuery)}&pageNumber={pageNumber}&pageSize={pageSize}&key={_configuration["ApiKey:Secret"]}");
            #endregion

            #region GRAPHQL QUERY
            var query = new
            {
                    query = @"
                {
                    getCourses {
                        id
                        title
                        imageUri
                        altText
                        bestSeller                    
                        categories
                        currency
                        price
                        discountPrice
                        lengthInHours
                        ratingInPercentage
                        numberOfReviews
                        numberOfLikes
                        authors {
                            name
                        }                    
                    }
                }"
            };  

            var queryJson = JsonConvert.SerializeObject(query);
            var content = new StringContent(queryJson, Encoding.UTF8, "application/json");
            var allCoursesResponse = await _httpClient.PostAsync($"{_configuration["ConnectionStrings:GraphQlApi"]}", content);

            var json = await allCoursesResponse.Content.ReadAsStringAsync();
            var graphQLResponse = JsonConvert.DeserializeObject<GraphQLResponse>(json);
            if (graphQLResponse != null)
            {
                var courses = graphQLResponse.Data.GetCourses;
                if (courses != null)
                {
                    return new CourseResult()
                    {
                        Pagination = new()
                        {
                            CurrentPage = pageNumber,
                            PageNumber = pageNumber,
                            TotalItems = courses.Count(),
                            PageSize = pageSize > courses.Count() ? courses.Count() : pageSize,
                        },
                        ReturnCourses = courses,

                        Category = new()
                        {
                            CategoryName = category,
                        }
                    };
                }
            }

            #endregion
        }
        catch (Exception ex) { }
        return null!;
    }

    //public async Task<string> GetSchemaAsync()
    //{
    //    var introspectionQuery = new
    //    {
    //        query = @"
    //        {
    //            __schema {
    //                queryType { name }
    //                mutationType { name }
    //                subscriptionType { name }
    //                types {
    //                    ...FullType
    //                }
    //                directives {
    //                    name
    //                    description
    //                    locations
    //                    args {
    //                        ...InputValue
    //                    }
    //                }
    //            }
    //        }

    //        fragment FullType on __Type {
    //            kind
    //            name
    //            description
    //            fields(includeDeprecated: true) {
    //                name
    //                description
    //                args {
    //                    ...InputValue
    //                }
    //                type {
    //                    ...TypeRef
    //                }
    //                isDeprecated
    //                deprecationReason
    //            }
    //            inputFields {
    //                ...InputValue
    //            }
    //            interfaces {
    //                ...TypeRef
    //            }
    //            enumValues(includeDeprecated: true) {
    //                name
    //                description
    //                isDeprecated
    //                deprecationReason
    //            }
    //            possibleTypes {
    //                ...TypeRef
    //            }
    //        }

    //        fragment InputValue on __InputValue {
    //            name
    //            description
    //            type { ...TypeRef }
    //            defaultValue
    //        }

    //        fragment TypeRef on __Type {
    //            kind
    //            name
    //            ofType {
    //                kind
    //                name
    //                ofType {
    //                    kind
    //                    name
    //                    ofType {
    //                        kind
    //                        name
    //                    }
    //                }
    //            }
    //        }"
    //    };

    //    // Serialize the introspection query to JSON
    //    var queryJson = JsonConvert.SerializeObject(introspectionQuery);

    //    // Create the StringContent for the POST request
    //    var content = new StringContent(queryJson, Encoding.UTF8, "application/json");

    //    // Send the POST request
    //    var response = await _httpClient.PostAsync($"{_configuration["ConnectionStrings:GraphQlApi"]}", content);

    //    // Ensure the response was successful
    //    response.EnsureSuccessStatusCode();

    //    // Read the response content
    //    var responseString = await response.Content.ReadAsStringAsync();

    //    return responseString;
 
    //}


}
