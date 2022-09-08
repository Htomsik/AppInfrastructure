using AppInfrastructure.Stores.Repositories;
using AppInfrastructureTests.StoresTests.RepositoryTests.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.BaseLazyRepositoryTest;

[TestClass]
public class BaseNotGenericLazyRepositoryTests : BaseAbstractLazyRepositoryTests<BaseLazyRepository,object>
{
    protected override BaseLazyRepository GenerateStore() => new ();
    
    protected override object GenerateValue() => "SomeValue";
    
}