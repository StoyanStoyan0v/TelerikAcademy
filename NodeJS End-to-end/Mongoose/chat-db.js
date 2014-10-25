'use strict';
var mongoose = require('mongoose');
var User = require('./models/user');
var Message = require('./models/message');

function initDb(connectionString){
    mongoose.connect(connectionString);
    var db= mongoose.connection;
    db.once('open', function (err) {
       if(err){
           console.log("Database failed to open: "+err)
       }
        console.log("Database running: "+connectionString);
    });
}

 function registerUser(user) {
     var newUser = new User({
         username: user.username,
         pass: user.pass
     });

     return newUser.save(function (err, result) {
         if (err) {
             return err;
         }

         return result;
     });
}

function sendMessage(message) {
    User.findOne({username: message.from}, function (err, result) {
        var from = result;

        User.findOne({username: message.to}, function (err, result) {
            var to = result;

            var newMessage = new Message({
                from: from._id,
                to: to._id,
                text: message.text
            });

            newMessage.save(function (err, result) {
                if (err) {
                    return err;
                }

                return result;
            });
        });
    });
}

function getMessages(from, to, callback) {
    var query = User.findOne({username: from}, function (err, result) {
        var from = result._id;

        User.findOne({username: to}, function (err, result) {
            var to = result._id;

            Message
                .find()
                .where('from').in([from, to])
                .where('to').in([from, to])
                .populate('from to')
                .exec(callback);

        });
    });

    return query;
}


module.exports={
    initDb: initDb,
    registerUser:registerUser,
    getMessages:getMessages,
    sendMessage:sendMessage
};