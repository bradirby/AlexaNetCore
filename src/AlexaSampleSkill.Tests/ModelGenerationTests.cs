using System;
using System.IO;
using System.Text.Json;
using AlexaNetCore;
using NUnit.Framework;

namespace AlexaSampleSkill.Tests
{
    /// <summary>
    /// These tests are all explicit and are used to generate the various supporting files.  Run
    /// them when you want to regenerate the files
    /// </summary>
    public class ModelGenerationTests
    {
        [Test]
        [Explicit]
        public void CreateInteractionModelFile()
        {
            var filePath = Environment.GetEnvironmentVariable("AlexaNetCoreSourceCodeRootFolder");
            filePath = Path.Combine(filePath, "AlexaSampleSkill\\SupportingFiles\\InteractionModels");

            var skill = new BasicSkill();
            
            var locale = AlexaLocale.English_US;
            File.WriteAllText(Path.Combine(filePath, $"{locale.LocaleString}.json"), 
                JsonSerializer.Serialize(skill.GetInteractionModel(locale)));

            locale = AlexaLocale.Spanish_ES;
            File.WriteAllText(Path.Combine(filePath, $"{locale.LocaleString}.json"), 
                JsonSerializer.Serialize(skill.GetInteractionModel(locale)));

            locale = AlexaLocale.Italian;
            File.WriteAllText(Path.Combine(filePath, $"{locale.LocaleString}.json"), 
                JsonSerializer.Serialize(skill.GetInteractionModel(locale)));
        }
    }
}