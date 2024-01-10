<%@ WebHandler Language="C#" Class="LoginHandler" %>

using System;
using System.Web;

public class LoginHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // Retrieve form data
        string username = context.Request.Form["username"];
        string password = context.Request.Form["password"];

        // Call DatabaseManager to authenticate the user
        DatabaseManager dbManager = new DatabaseManager();
        bool authenticationSuccessful = dbManager.AuthenticateUser(username, password);

        if (authenticationSuccessful)
        {
            context.Response.Write("Login successful! Redirect to welcome page.");
            // You can redirect the user to the welcome page or perform other actions.
        }
        else
        {
            context.Response.Write("Login failed. Please check your credentials and try again.");
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
