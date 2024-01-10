<%@ WebHandler Language="C#" Class="SignupHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization; // Add this for JSON serialization

public class SignupHandler : IHttpHandler
{
     [HttpPost("/signup")]
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json"; // Set response type to JSON

        try
        {
            // Retrieve form data
            string username = context.Request.Form["username"];
            string email = context.Request.Form["email"];
            string password = context.Request.Form["password"];

            // Call DatabaseManager to register the user
            DatabaseManager dbManager = new DatabaseManager();
            bool registrationSuccessful = dbManager.RegisterUser(username, email, password);

            if (registrationSuccessful)
            {
                // Return a JSON response for success
                var response = new { success = true, message = "User registered successfully!" };
                context.Response.Write(new JavaScriptSerializer().Serialize(response));
            }
            else
            {
                // Return a JSON response for failure
                var response = new { success = false, message = "Registration failed. Please try again." };
                context.Response.Write(new JavaScriptSerializer().Serialize(response));
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions and return a JSON response
            var response = new { success = false, message = "An error occurred. Please try again later." };
            context.Response.Write(new JavaScriptSerializer().Serialize(response));
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
