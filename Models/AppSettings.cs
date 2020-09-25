namespace MedicalTelegrammBot.Models
{
    /// <summary>
    /// Defines bot settings. Use for set webhook <see cref="AppSettings" />.
    /// </summary>
    internal static class AppSettings
    {
        /// <summary>
        /// Gets or sets the Url for webhook.
        /// </summary>
        internal static string Url { get; set; } = "https://URL:443/{0}";

        /// <summary>
        /// Gets or sets the Bot name.
        /// </summary>
        internal static string Name { get; set; } = "<BOT_NAME>";

        /// <summary>
        /// Gets or sets the Bot token from BotFather.
        /// </summary>
        internal static string Token { get; set; } = "<BOT_TOKEN>";
    }
}
