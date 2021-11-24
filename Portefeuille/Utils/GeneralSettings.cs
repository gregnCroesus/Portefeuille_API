using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Portefeuille.Utils
{
    public class GeneralSettings
    {
        /// <summary>
        /// Configuration key for the allowed origins for the CORS configuration
        /// </summary>
        public string[] AllowedOrigins { get; set; } = new string[0];

        /// <summary>
        /// Max file size allowed for upload (in bytes).
        /// Default value is 10MB 
        /// </summary>
        public long MultipartBodyLengthLimit { get; set; } = 10 * 1024 * 1024;

        /// <summary>
        /// Log4Net configuration file.
        /// </summary>
        public string Log4NetConfigFile { get; set; } = "";

        /// <summary>
        /// Base URL for the Auth service.
        /// </summary>
        public string AuthServicesBaseURL { get; set; } = "http://localhost/";

        /// <summary>
        /// Constructor fetching application settings from the "GeneralSettings"
        /// section in the given <paramref name="configuration"/>.
        /// </summary>
        /// <param name="configuration">Configuration object to fetch application settings from.</param>
        public GeneralSettings(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            new ConfigureFromConfigurationOptions<GeneralSettings>(
                configuration.GetSection(nameof(GeneralSettings)))
                .Configure(this);
        }
    }
}
