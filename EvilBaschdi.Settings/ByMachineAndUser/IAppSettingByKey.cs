namespace EvilBaschdi.Settings.ByMachineAndUser;

/// <inheritdoc cref="IValueFor{TIn,TOut}" />
/// <inheritdoc cref="IRunFor2{TIn,TOut}" />
public interface IAppSettingByKey : IValueFor<string, string>, IRunFor2<string, string>
{
}