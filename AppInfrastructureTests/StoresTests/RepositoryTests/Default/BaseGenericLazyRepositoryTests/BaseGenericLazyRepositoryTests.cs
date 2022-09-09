using AppInfrastructure.Stores.Repositories.BaseTypes;
using AppInfrastructureTests.StoresTests.RepositoryTests.Default.BaseGenericLazyRepositoryTests.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.Default.BaseGenericLazyRepositoryTests;

[TestClass]
public class BaseGenericLazyRepositoryTests : BaseAbstractGenericLazyRepositoryTests<BaseLazyRepository<int>,int>
{
    protected override BaseLazyRepository<int> GenerateStore() => new ();
    protected override int GenerateValue() => 123;

}