using System;
using System.IO;
using System.Text.Json;
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
            var skill = new BasicSkill();
            var interactionModelObj = skill.GetInteractionModel();
            var interactionModelStr = JsonSerializer.Serialize(interactionModelObj);

            var filePath = Environment.GetEnvironmentVariable("AlexaNetCoreSourceCodeRootFolder");
            filePath = Path.Combine(filePath, "AlexaSampleSkill\\SupportingFiles\\InteractionModelEnglish.json");
            File.WriteAllText(filePath, interactionModelStr);
        }
    }
}