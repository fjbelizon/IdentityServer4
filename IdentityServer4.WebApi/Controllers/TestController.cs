namespace IdentityServer4.WebServerApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        #region Methods

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // Generate test data
            string[] testData = new string[]
            {
                "data 1",
                "data 2",
                "data 3",
                "data 4",
                "data 5",
                "data 6",
                "data 7"
            };

            // Return data as json
            return new JsonResult(testData);
        }

        #endregion
    }
}