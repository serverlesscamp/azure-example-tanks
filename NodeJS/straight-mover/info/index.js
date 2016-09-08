module.exports = function(context, req) {
    context.log('Node.js HTTP trigger function processed a request. RequestUri=%s', req.originalUrl);

    context.res = {
            status: 200, /* Defaults to 200 */
            body:  {
                "name": "Rectangular Mover", /* tank name */
                "owner": "Gojko" /* tank author/owner */
            }
        };
    context.done();
};