using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace EvilBaschdi.Settings.Internal;

/// <inheritdoc />
public class WritableJsonConfigurationSource : JsonConfigurationSource
{
    /// <inheritdoc />
    public override IConfigurationProvider Build([NotNull] IConfigurationBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        EnsureDefaults(builder);
        return new WritableJsonConfigurationProvider(this);
    }
}