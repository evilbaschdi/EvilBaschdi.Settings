using System;
using System.IO;
using EvilBaschdi.Core;
using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings
{
    /// <inheritdoc cref="ISettingsFromJsonFile" />
    public abstract class SettingsFromJsonFile : CachedValue<IConfiguration>, ISettingsFromJsonFile
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="settingsFileName"></param>
        protected SettingsFromJsonFile(string settingsFileName)
        {
            var settingsFileNameInternal = settingsFileName ?? throw new ArgumentNullException(nameof(settingsFileName));
            AppSetting = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile(settingsFileNameInternal)
                         .Build();
        }

        private IConfiguration AppSetting { get; }

        /// <inheritdoc />
        protected override IConfiguration NonCachedValue => AppSetting;
    }
}