# AlexaNetCore
A minimalistic framework for Alexa using .NET Core

AlexNetCore is a .Net Core library that can be used for creating Alexa custom skills.  The basic <a href="https://github.com/bradirby/AlexaNetCore_HelloWorld" target="_blank">HelloWorld skill</a> has only 3 lines but creates a skill that responds to the given wake word with a text string of your choosing.  As I add functionality, I will also add other sample projects so you can exercise you skills.

# Why .Net Core?
Alexa skills hosted by Amazon are easily created in  Python and Node.js using examples provided by Amazon, so why bother with .Net Core?

Developers are loving working with .Net Core for its cross platform capabilities, size of the executables, and the speed.  When building the many pieces that go into enterprise apps it is convenient to keep coding in the same technology for all your solutions.  Using this library, you can do everything you need to build a fully functional Alexa skill aimed at your own business, using the technology you are comfortable in.

# Why is AlexaNetCore in version 3.1?
I keep AlexaNetCore in version 3.1 because it is the latest version that AWS Lambdas support natively.  If I update it to the latest v6 you would not be able to create an AWS Lambda function without a container.  However, if you are running your infrastructure on Azure and want to create a webmethod instead of an AWS Lambda, then AlexaNetCore will run perfectly in .Net 6.

# Another Advantage - Unit Tests!
The AlexaNetCore library was built around the ability to unit test everything.  I don't just mean the library itself, but you can unit test your custom skill logic processing without needing to resort to live voice interaction.  This is because and the library can consume a JSON string and process it as if it came through the Alexa voice processing services.  Just copy/paste the json from the AWS Alexa test console into a unit test in Visual Studio, and you can test all your voice logic just like you would other business logic.

# How do I get started?
User docs are in progress, but in the mean time I have made some sample projects you can clone and use for testing, and some instructional postings on how to move forward.  
* <a href="https://github.com/bradirby/AlexaNetCore_HelloWorld" target="_blank">Hello World</a> to get started
* <a href="https://bradirby.com/publish-a-csharp-function-to-aws-lambda/" target="_blank">How to publish a C# method to an AWS Lambda</a>
* <a href="https://bradirby.com/alexa-skill-lifecycle-for-solo-developers/" target="_blank">Typical Workflow for maintaining an Alexa skill in .Net Core</a>