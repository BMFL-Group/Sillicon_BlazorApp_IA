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
            //var query = new
            //{
            //    query = @" 
            //    query($filterQuery: CourseFiltersInput!) {
            //        getCourses($filterQuery: CourseFiltersInput!) {
            //            courses(filter $filter) {
            //                id
            //                title
            //                imageUri
            //                altText
            //                bestSeller                    
            //                categories
            //                currency
            //                price
            //                discountPrice
            //                lengthInHours
            //                ratingInPercentage
            //                numberOfReviews
            //                numberOfLikes
            //                authors {
            //                    name
            //                }                    
            //            }
            //        }
            //    }",
            //    variables = new
            //    {
            //        filterQuery = new
            //        {
            //            category = category,
            //            searchQuery = searchQuery,
            //            pageSize = pageSize,
            //            pageNumber = pageNumber,
            //        }
            //    }
            //};
            //
            var query = new
            {
                query = @"
                query($filterQuery: CourseFiltersInput!) {
                    getCourses(filterQuery: $filterQuery) {
                        courses {
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
                    }
                }",
                variables = new
                {
                    filterQuery = new
                    {
                        category = category,
                        searchQuery = searchQuery,
                        pageSize = pageSize,
                        pageNumber = pageNumber,
                    }
                }
            };


            var queryJson = JsonConvert.SerializeObject(query);
            var content = new StringContent(queryJson, Encoding.UTF8, "application/json");
            var allCoursesResponse = await _httpClient.PostAsync($"{_configuration["ConnectionStrings:LocalGraphQlApi"]}", content);

            var json = await allCoursesResponse.Content.ReadAsStringAsync();
            var graphQLResponse = JsonConvert.DeserializeObject<GraphQLResponse>(json);
            if (graphQLResponse != null && graphQLResponse.Data != null && graphQLResponse.Data.GetCourses != null)
            {
                //return graphQLResponse.Data.Courses;

                return new CourseResult()
                {
                    Pagination = graphQLResponse.Data.GetCourses.Pagination,
                    Courses = graphQLResponse.Data.GetCourses.Courses,

                    Category = new()
                    {
                        CategoryName = category,
                    }
                };

            }
            else
            {
                return new CourseResult();
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
