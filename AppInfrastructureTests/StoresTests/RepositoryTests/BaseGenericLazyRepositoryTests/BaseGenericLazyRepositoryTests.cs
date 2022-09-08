using AppInfrastructure.Stores.Repositories;
using AppInfrastructureTests.StoresTests.RepositoryTests.BaseGenericLazyRepositoryTests.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.BaseGenericLazyRepositoryTests;

[TestClass]
public class BaseGenericLazyRepositoryTests : BaseAbstractGenericLazyRepositoryTests<BaseLazyRepository<int>,int>
{
    protected override BaseLazyRepository<int> GenerateStore() => new ();
    protected override int GenerateValue() => 123;

}