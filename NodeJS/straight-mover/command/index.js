var tankAI = require('./tanks');

module.exports = function(context, req) {
    context.log('Node.js HTTP as trigger function processed a request. RequestUri=%s', req.originalUrl);
   
    var map = req.body;
    context.res = {
            status: 200, /* Defaults to 200 */
            body:  {
                "command": tankAI(map, [])
            }
        };
    context.done();
};