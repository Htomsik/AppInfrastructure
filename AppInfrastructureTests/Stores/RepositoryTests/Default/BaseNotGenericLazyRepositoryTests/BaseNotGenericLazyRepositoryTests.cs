using AppInfrastructure.Stores.Repositories.BaseTypes;
using AppInfrastructureTests.Stores.RepositoryTests.Default.BaseNotGenericLazyRepositoryTests.Base;

namespace AppInfrastructureTests.Stores.RepositoryTests.Default.BaseNotGenericLazyRepositoryTests;

[TestClass]
public class BaseNotGenericNotGenericLazyRepositoryTests : BaseAbstractNotGenericLazyRepositoryTests<BaseLazyRepository,object>
{
    protected override BaseLazyRepository GenerateStore() => new ();
    
    protected override object GenerateValue() => "SomeValue";
    
}