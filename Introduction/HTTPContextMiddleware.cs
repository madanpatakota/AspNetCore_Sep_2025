namespace Introduction
{
    //Middleware is nothing but act as gate keeper of your every request



    public class HTTPContextMiddleware
    {
        //"RequestDelete is a kind of a pointer whiech is useful to give your context to the controller

        // What is RequestDelegate?
        //Ans : RequestDelegate is a type that represents a function that can process an HTTP request.
        //    It is a delegate that takes an HttpContext as input and returns a Task.
        //   It is used in ASP.NET Core middleware to define the next component in the request processing pipeline.
        //  When a middleware component is invoked, it can choose to call the next RequestDelegate in the pipeline

        RequestDelegate _next;
        public HTTPContextMiddleware(RequestDelegate next) {
            _next = next;
        }



        // What is InvokeAsync method?
        // Ans : InvokeAsync is a method that is called by the ASP.NET Core framework to process an HTTP request.
        // It is defined in a middleware component and is responsible for handling the request and generating a response.
        // The method takes an HttpContext as input and returns a Task.
        // Inside the InvokeAsync method, you can access the request and response objects, modify them, and perform any necessary logic before passing the request to the next middleware component in the pipeline.
        public async Task InvokeAsync(HttpContext context)   //Gatekeeper
        {

            //var context = HttpContext;

            var httpContextHeaders = context.Request.Headers;
            var httpContextBody    = context.Request.Body;
            var httpContextPath    = context.Request.Path;
            var httpContextQueryString = context.Request.QueryString;

            Console.WriteLine("==========Request headers =================");
            Console.WriteLine($"httpContextHeaders : {httpContextHeaders}");
            Console.WriteLine($"httpContextBody    : {httpContextHeaders}");
            Console.WriteLine($"httpContextPath    : {httpContextPath}");
            Console.WriteLine($"httpContextQueryString : {httpContextQueryString}");
            Console.WriteLine("=====================================");



            //POST https://localhost:7115/api/HttpContextDemo/ShowContext/1 HTTP/1.1 application/json 200 OK
            //https://localhost:7115/api/HttpContextDemo/ShowContext/1

            //https://localhost:7115/api/Emmploee/ShowContext/1
            //context is nothtin but request
            await _next(context);     //Forware your request by asp.netcore compiler


            context.Response.OnStarting(() =>
            {
                Console.WriteLine("==========Response headers starts===========");
                context.Response.Headers["X-demo-Response"] = "This came from server";
                context.Response.Headers["X-demo-statusCode"] = "Successfull";
                Console.WriteLine("===========Response headers Eds======");

                return Task.CompletedTask; // Indicates that the task has completed successfully
                // When the response is about to be sent, this callback will be executed
                //

            });
            //context.Response.Headers.Append("X-demo-Response", "This came from server");
            //context.Response.Headers.Append("X-demo-statusCode", "Successfull");



            //

        }
    }
}
