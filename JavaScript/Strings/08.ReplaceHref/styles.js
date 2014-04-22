var text = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

document.writeln("Initial text: " + text.replace(/</g, "&lt").replace(/>/g, "&gt") + "<br/><br/>");
document.writeln("Result: " + text.replace(/<a href/g, "[URL").replace(/<\/a>/g, "[/URL]").replace(/</g, "&lt").replace(/>/g, "&gt"));