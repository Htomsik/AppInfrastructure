using AppInfrastructure.Stores.Repositories;
using AppInfrastructureTests.StoresTests.RepositoryTests.BaseNotGenericLazyRepositoryTests.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.BaseNotGenericLazyRepositoryTests;

[TestClass]
public class BaseNotGenericNotGenericLazyRepositoryTests : BaseAbstractNotGenericLazyRepositoryTests<BaseLazyRepository,object>
{
    protected override BaseLazyRepository GenerateStore() => new ();
    
    protected override object GenerateValue() => "SomeValue";
    
}