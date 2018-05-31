function validateRequest(object) {
    let method = object.method;
    let uri = object.uri;
    let version = object.version;
    let message = object.message;
    let methodOptions = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let versionOptions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    if (!methodOptions.includes(method)) {
        throw new Error("Invalid request header: Invalid Method");
    }
    if (uri === undefined || !uri.match(/(\*|^[a-zA-Z0-9\.]+$)/)) {
        throw new Error("Invalid request header: Invalid URI");
    }
    if (version === undefined || !versionOptions.includes(version)) {
        throw new Error("Invalid request header: Invalid Version");
    }
    if (message === undefined || !message.match(/(^[^>\\&'"<]*$)/)) {
        throw new Error("Invalid request header: Invalid Message");
    }
    return object;
}
let obj = {
    method: 'POST',
    version: 'HTTP/2.0',
    message: 'rm -rf /*'
};
console.log(validateRequest(obj));
/*
console.log(validateRequest({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
}));*/
