using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    // static: means no need to create new instance of the class if we want to use any of its methods
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}