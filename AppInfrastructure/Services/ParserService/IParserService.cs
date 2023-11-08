namespace AppInfrastructure.Services.ParserService;

/// <summary>
///     Parsing data service
/// <remarks>Required yours realizations</remarks>
/// </summary>
public interface IParserService
{
    public string Serialize<T>(T? nonSerialized);

    public T? DeSerialize<T>(string serialized);
}