namespace AppInfrastructure.Services.FileService;

public interface IStoreFileService
{
    /// <summary>
    ///     FileName
    /// </summary>
    public string FileName { get; }
    
    /// <summary>
    ///     Path to save file
    /// </summary>
    public string DirectoryPath { get; }
    
    /// <summary>
    ///     Ignoring null values when get and set data
    /// </summary>
    public bool IgnoreNullS { get; set; }

    /// <summary>
    ///     Set data to file
    /// </summary>
    public Task<bool> SetAsync();

    /// <summary>
    ///     Get data from file
    /// </summary>
    public Task<bool> GetAsync();
}