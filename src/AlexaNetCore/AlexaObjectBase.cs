using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlexaSkillDotNet
{
    public abstract class AlexaObjectBase
    {
        protected string Serialize(dynamic obj)
        {
            string outputStr = JsonSerializer.Serialize(obj);
            outputStr = outputStr.Replace(@"\\", "");
            return outputStr;
        }
    }
}
