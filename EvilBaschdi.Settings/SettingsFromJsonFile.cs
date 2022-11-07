using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings;

/// <inheritdoc cref="ISettingsFromJsonFile" />
// ReSharper disable once UnusedType.Global
public abstract class SettingsFromJsonFile : CachedValue<IConfiguration>, ISettingsFromJsonFile
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="settingsFileName"></param>
    protected SettingsFromJsonFile(string settingsFileName)
    {
        if (settingsFileName == null)
        {
            throw new ArgumentNullException(nameof(settingsFileName));
        }

        AppSetting = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile(settingsFileName)
                     .Build();
    }

    private IConfiguration AppSetting { get; }

    /// <inheritdoc />
    protected override IConfiguration NonCachedValue => AppSetting;
}