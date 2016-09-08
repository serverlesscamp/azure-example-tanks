
#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static HttpResponseMessage Run(HttpRequestMessage req)
{
    return req.CreateResponse(HttpStatusCode.OK, new Info() {
        name = "Fire when there is a target",
        owner = "nemesv"
    });
}

public class Info
{
    public string name { get; set; }

    public string owner { get; set; }
}