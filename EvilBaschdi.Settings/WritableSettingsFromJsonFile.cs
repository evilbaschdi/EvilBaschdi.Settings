﻿using EvilBaschdi.Settings.Internal;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings;

/// <inheritdoc cref="ISettingsFromJsonFile" />
// ReSharper disable once UnusedType.Global
public abstract class WritableSettingsFromJsonFile : ISettingsFromJsonFile
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="settingsFileName"></param>
    protected WritableSettingsFromJsonFile([NotNull] string settingsFileName)
    {
        if (settingsFileName == null)
        {
            throw new ArgumentNullException(nameof(settingsFileName));
        }

        AppSetting = new ConfigurationBuilder().Add(
            (Action<WritableJsonConfigurationSource>)(s =>
                                                      {
                                                          s.FileProvider = null;
                                                          s.Path = settingsFileName;
                                                          s.Optional = false;
                                                          s.ReloadOnChange = true;
                                                          s.ResolveFileProvider();
                                                      })).Build();
    }

    private IConfiguration AppSetting { get; }

    /// <inheritdoc />
    public IConfiguration Value => AppSetting;
}