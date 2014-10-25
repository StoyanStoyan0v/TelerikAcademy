var port =1234;

var formidable = require('formidable'),
    http = require('http');

http.createServer(uploadFile).listen(port);
console.log('Server is running on port '+port);

function uploadFile(req,res) {

    if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
        var form = new formidable.IncomingForm();

        form.uploadDir = './files/';
        form.encoding = 'utf-8';
        form.keepExtensions = true;

        form.parse(req, function (err, fields, files) {
            console.log(files);
            res.writeHead(200, {'content-type': 'text/html'});
            res.write('File successfully uploaded!<hr/>' +
           '<img src="files/' + files['upload']['path'].substr('/files'.length)+ '" alt="pic"/>');
            res.end();
        });

        return;
    }

    res.writeHead(200, {'content-type': 'text/html'});
    res.end(
            '<form action="/upload" enctype="multipart/form-data" method="post">' +
            '<input type="file" name="upload" multiple="multiple"><br>' +
            '<input type="submit" value="Upload">' +
            '</form>'
    );
}

