function extractEmails(text) {
    return text.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
}

var text = "I have one email in gmail. It is pesho_ivanov@gmail.com and two more emails They are kebapchon.nadeinchkov_932.gosho@yahoo.co.uk and baklava-makaronova434@pesho-ivan.nl.";

document.writeln("Text: " + text + "</br>E-mails:</br>")
document.writeln(extractEmails(text).join("</br>"))