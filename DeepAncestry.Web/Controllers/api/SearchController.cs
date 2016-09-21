using DeepAncestry.Web.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeepAncestry.Web.Controllers.api
{
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            if (searchService == null)
            {
                throw new ArgumentNullException("searchService");
            }

            _searchService = searchService;
        }

        public HttpResponseMessage Get(string name, string gender)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var result = _searchService.FindPerson(name, gender);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Post(string name, string gender, string direction)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(direction))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var result = _searchService.FindFamily(name, gender, direction);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}