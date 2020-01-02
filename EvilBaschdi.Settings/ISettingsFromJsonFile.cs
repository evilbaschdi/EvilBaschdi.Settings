using EvilBaschdi.Core;
using Microsoft.Extensions.Configuration;

namespace EvilBaschdi.Settings
{
    /// <inheritdoc />
    public interface ISettingsFromJsonFile : IValue<IConfiguration>
    {
    }
}