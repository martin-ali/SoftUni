/**
 * @param {{ method: string; uri: string; version: string; message: string; }} httpRequest
 */
function validateHttpRequestObject(httpRequest)
{
    /**
     * @param {string} method
     */
    function methodIsValid(method)
    {
        const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];

        if (validMethods.includes(method) === false)
        {
            const error = new Error('Invalid Method');
            throw error;
        }

        return true;
    }

    /**
     * @param {string} uri
     */
    function uriIsValid(uri)
    {
        const uriPatternChecker = /^[.A-z0-9]+$/;

        const uriIsValid = uriPatternChecker.test(uri);
        if (!uri || uriIsValid === false)
        {
            const error = new Error('Invalid URI');
            throw error;
        }

        return true;
    }

    /**
     * @param {string} version
     */
    function versionIsValid(version)
    {
        const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

        if (validVersions.includes(version) === false)
        {
            const error = new Error('Invalid Version');
            throw error;
        }

        return true;
    }

    /**
     * @param {string} message
     */
    function messageIsValid(message)
    {
        const invalidCharacters = /[<>\\&\'"]/;

        const messageIsInvalid = invalidCharacters.test(message);
        if (message === undefined || messageIsInvalid)
        {
            const error = new Error('Invalid Message');
            throw error;
        }


        return true;
    }

    try
    {
        const requestIsValid = methodIsValid(httpRequest.method)
            && uriIsValid(httpRequest.uri)
            && versionIsValid(httpRequest.version)
            && messageIsValid(httpRequest.message);

        return httpRequest;
    }
    catch (error)
    {
        throw new Error(`Invalid request header: ${error.message}`)
    }
}

// let httpRequest = validateHttpRequestObject(
// {
//     method: 'GET',
//     uri: 'svn.public.catalog',
//     version: 'HTTP/1.1',
//     message: 'asd'
// });

// validateHttpRequestObject(httpRequest);
// httpRequest.message = 'asl>pls';
// validateHttpRequestObject(httpRequest);
// httpRequest.message = 'asl&pls';
// validateHttpRequestObject(httpRequest);
// httpRequest.message = "asl'pls";
// validateHttpRequestObject(httpRequest);
// httpRequest.message = 'asl"pls';
// validateHttpRequestObject(httpRequest);
// httpRequest.message = 'asl\\pls';
// validateHttpRequestObject(httpRequest);