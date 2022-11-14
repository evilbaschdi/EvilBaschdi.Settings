using Microsoft.Extensions.Configuration.Json;

Json;

namespace EvilBaschdi.Settings.Tests.Internal;

public class WritableJsonConfigurationProviderTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WritableJsonConfigurationProvider).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(WritableJsonConfigurationProvider sut)
    {
        sut.Should().BeAssignableTo<JsonConfigurationProvider>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WritableJsonConfigurationProvider).GetMethods().Where(method => !method.IsAbstract)

    }
}