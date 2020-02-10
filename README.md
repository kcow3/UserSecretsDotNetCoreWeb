# UserSecretsDotNetCoreWeb
A web application to demonstrate using user secrets.

Code adapted from [this](https://www.twilio.com/blog/2018/05/user-secrets-in-a-net-core-web-app.html) blog.

In this example you have to right click the project to add the following user secret:

`{
    "Secrets:Password": "Password1"
}`

The following project references are of importance:

* Microsoft.Extensions.Configuration
* Microsoft.Extensions.Configuration.UserSecrets
* Microsoft.VisualStudio.Web.CodeGeneration.Design

Secrets in the startup can be directly accessed like this:

`Configuration.GetSection("Secrets")`

Secrets in code can be accessed by injecting `IOptions<T>` where T is your mapping class for your secret.


