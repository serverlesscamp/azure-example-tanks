
#r "Newtonsoft.Json"
#load "models.csx"

using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Webhook was triggered!");

    string jsonContent = await req.Content.ReadAsStringAsync();
    TankRequest request = JsonConvert.DeserializeObject<TankRequest>(jsonContent);

    var response = new TankResponse();

    if (HasTarget(request))
        response.command = "fire";
    else
        response.command = "pass";

    return req.CreateResponse(HttpStatusCode.OK, response);
}

private static Dictionary<string, Point> movements = new Dictionary<string, Point> {
    { "top", new Point { x = 0, y = -1} },
    { "left", new Point { x = -1, y = 0} },
    { "bottom", new Point { x = 0, y = 1} },
    { "right", new Point { x = 1, y = 0} },
};

private static bool HasTarget(TankRequest request) {
    var movement = movements[request.you.direction];

    for(int distance = 0; distance < request.weaponRange; distance++) {
        var pointAtDistance = new Point {
            x = request.you.x + (distance + 1) * movement.x,
            y = request.you.y + (distance + 1) * movement.y
        };
        if (request.enemies.Any(e => e.x == pointAtDistance.x && e.y == pointAtDistance.y)){
            return true;
        }
    }
    return false;
}