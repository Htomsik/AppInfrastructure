using AppInfrastructure.Stores.Repositories.Collection;
using AppInfrastructureTests.StoresTests.RepositoryTests.Collection.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.Collection;

[TestClass]
public class BaseLazyCollectionRepositoryTests:BaseAbstractLazyCollectionRepositoryTests<List<string>,BaseLazyCollectionRepository<List<string>,string>,string>
{
    protected override BaseLazyCollectionRepository<List<string>, string> GenerateStore() =>
        new ();
    protected override List<string> GenerateValue() => new();
    protected override string GenerateFirstValueInCollection() => "SomeFirstValue";
    protected override string GenerateSecondValueInCollection() => "SomeSecondValue";

}