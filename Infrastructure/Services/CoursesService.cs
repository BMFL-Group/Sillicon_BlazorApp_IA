﻿using Infrastructure.Models;
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

    public async Task<CourseResult> GetAllCoursesAsync(string category = "all", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
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
                        },
                        pagination {
                            currentPage
                            pageNumber
                            totalItems
                            pageSize
                            totalPages    
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
            var allCoursesResponse = await _httpClient.PostAsync($"{_configuration["ConnectionStrings:GraphQlApi"]}", content);
            if (allCoursesResponse.IsSuccessStatusCode)
            {
                var json = await allCoursesResponse.Content.ReadAsStringAsync();
                var graphQLResponse = JsonConvert.DeserializeObject<GraphQLResponse>(json);
                if (graphQLResponse != null && graphQLResponse.Data != null && graphQLResponse.Data.GetCourses != null && graphQLResponse.Data.GetCourses.Pagination != null)
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
            }
            else
            {
                return new CourseResult();
                //insert error message here...
            }

            #endregion
        }
        catch (Exception ex) { }
        return null!;
    }

    public async Task<Course> GetOneCourseByIdAsync(string id)
    {
        try
        {
            #region GRAPHQL QUERY
            var query = new
            {
                query = @"
                query GetCourseById($id: String!) {
                    getCourseById(id: $id) {
                        id
                        title
                        ingress
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
                        content {
                            description
                            courseIncludes
                            whatYouLearn
                            programDetails {
                                id
                                title
                                description
                            }
                        }
                    }
                }",
                variables = new
                {
                    id = id
                }
            };

            var queryJson = JsonConvert.SerializeObject(query);
            var content = new StringContent(queryJson, Encoding.UTF8, "application/json");

            var singleCourseResponse = await _httpClient.PostAsync($"{_configuration["ConnectionStrings:GraphQlApi"]}", content);
            if(singleCourseResponse.IsSuccessStatusCode)
            {
                var json = await singleCourseResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GraphQLResponse>(json);
                if (result != null && result.Data != null && result.Data.GetCourseById != null)
                {
                    Course resultCourse = result.Data.GetCourseById;
                    if (resultCourse != null)
                    {
                        return resultCourse;
                    }
                }
            }
            #endregion
        }
        catch (Exception ex) { }
        return null!;
    }

    public async Task<IEnumerable<SavedCoursesModel>> GetSavedCoursesAsync(string userId)
    {
        try
        {
            var saveCoursesResponse = await _httpClient.GetAsync($"{_configuration.GetConnectionString("CoursesApi")}api/SavedCourses/user/{userId}");
            if (saveCoursesResponse.IsSuccessStatusCode)
            {
                var json = await saveCoursesResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<SavedCoursesModel>>(json);
                if (result != null && result.Any())
                {
                    return result;
                }
            }
        }
        catch(Exception ex) { }
        return null!;
    }
}
