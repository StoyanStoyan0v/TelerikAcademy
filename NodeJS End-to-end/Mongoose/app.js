'use strict';

var chatDb = require('./chat-db');

chatDb.initDb('localhost:27017/chat');

chatDb.registerUser({username: 'Pesho', pass: 123456});
chatDb.registerUser({username: 'Stamat', pass: 123456});

chatDb.sendMessage({
   from: 'Pesho',
   to: 'Stamat',
   text: 'Whats up!'
});

chatDb.sendMessage({
   from: 'Stamat',
   to: 'Pesho',
   text: 'Hello. Whats up?'
});


chatDb.getMessages('Pesho', 'Stamat', function (err, results) {
    if (err) {
        console.log(err);
    }

    console.log(results);
});
