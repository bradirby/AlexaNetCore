# AlexaNetCore
A minimalistic framework for custom Alexa skills using .NET Core

AlexNetCore is a .Net Core library that can be used for creating custom Alexa skills.  
There are many sample apps you can download to get started, 
<a href="https://github.com/bradirby/AlexaNetCore_SampleApps" target="_blank">just go here.</a> 

The basic Hello World creates a skill that responds to the given wake word with a text string of your choosing.  

The samples apps provided include
* <a href="https://www.alexanetcore.com/getting-started/" target="_blank">Getting Started</a>
* <a href="https://www.alexanetcore.com/default-intent-handlers/" target="_blank">Taking advantage of default intent handlers</a>
* Easy Internationalization
* Getting user input with built in slots
* Getting user input with custom slots
* Getting custom user input with Dynamic Entities
* Display information on a screen with Cards
* Track information from one interaction to the next with Session
* Letting Alexa AI do the work with Multiturn Dialogs

You can also <a href="https://alexanetcore.com/" target="_blank">check the blog</a> for discussions
on the current state of custom Alexa skills and examples of what the library supports.

# Why .Net Core?
Alexa skills hosted by Amazon are easily created in  Python and Node.js using examples provided by Amazon, 
so why bother with .Net Core?

Developers are loving working with .Net Core for its cross platform capabilities, size of the executables, 
and the speed.  When building the many pieces that go into enterprise apps it is convenient to keep coding 
in the same technology for all your solutions.  Using this library, you can do everything you need to build 
a fully functional Alexa skill aimed at your own business, using the technology you are comfortable in.


# Another Advantage - Unit Tests!
The AlexaNetCore library was built around the ability to unit test everything.  I don't just mean the 
library itself, but you can unit test your custom skill logic processing without needing to resort to 
live voice interaction.  This is because and the library can consume a JSON string and process it as 
if it came through the Alexa voice processing services.  Just copy/paste the json from the AWS Alexa 
test console into a unit test in Visual Studio, and you can test all your voice logic just like you 
would other business logic.

# How do I get started?
Check out the [User Docs](https://alexanetcore.com/) for sample project and how-to tutorials.  There you
will find a [Getting Started guide](https://alexanetcore.com/getting-started/) and other tutorials on how to make the 
most of the architecture to build Alexa skills with .Net Core.  Also see the collection of easy to use 
[Sample Projects](https://github.com/bradirby/AlexaNetCore_SampleApps/)

