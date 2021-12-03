namespace AlexaSkillDotNet
{
    public static class AlexaBuiltInIntents
    {
        /// <summary>
        /// Lets the user request that the skill turn off a loop or repeat mode, usually for audio skills that stream a playlist of tracks.
        /// </summary>
        public const string LoopOffIntent = "AMAZON.LoopOffIntent";
        public const string LoopOnIntent = "AMAZON.LoopOnIntent";

        /// <summary>
        /// Either of the following: 
        ///     Let the user cancel a transaction or task(but remain in the skill)
        ///     Let the user completely exit the skill
        /// </summary>
        public const string CancelIntent = "AMAZON.CancelIntent";
        public const string StopIntent = "AMAZON.StopIntent";

        /// <summary>
        /// Provide help about what the skill does and how to use it.
        /// </summary>
        public const string HelpIntent = "AMAZON.HelpIntent";

        public const string FallbackIntent = "AMAZON.FallbackIntent";

        public const string NextIntent = "AMAZON.NextIntent";
        public const string PreviousIntent = "AMAZON.PreviousIntent";

        public const string PauseIntent = "AMAZON.PauseIntent";
        public const string RepeatIntent = "AMAZON.RepeatIntent";
        public const string ResumeIntent = "AMAZON.ResumeIntent";
        public const string ShuffleOffIntent = "AMAZON.ShuffleOffIntent";
        public const string ShuffleOnIntent = "AMAZON.ShuffleOnIntent";

        public const string StartOverIntent = "AMAZON.StartOverIntent";

        public const string YesIntent = "AMAZON.YesIntent";
        public const string NoIntent = "AMAZON.NoIntent";
        public const string LaunchRequest = "LaunchRequest";
        public const string SessionEndedRequest = "SessionEndedRequest";
    }
}
