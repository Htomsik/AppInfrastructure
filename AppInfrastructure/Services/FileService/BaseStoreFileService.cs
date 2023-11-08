using AppInfrastructure.Services.ParserService;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.FileService;

public class BaseStoreFileService<TStore, T> : IStoreFileService where TStore : IStore<T>
{
    public string FileName { get; }
    public string DirectoryPath { get; }
    
    public bool IgnoreNullS { get; set; } = false;
    
    protected TStore Store;
    
    protected  IParserService ParserService;

    public BaseStoreFileService(TStore store, IParserService parserService, string fileName, string directoryPath)
    {
        Store = store ?? throw new ArgumentNullException(nameof(store));
        ParserService = parserService ?? throw new ArgumentNullException(nameof(parserService));
        FileName = fileName;
        DirectoryPath = directoryPath;
    }
    
    public async Task<bool> SetAsync()
    {
        if (!IgnoreNullS && Store.CurrentValue is null)
        {
            throw new ArgumentNullException(nameof(Store.CurrentValue));
        } 
        
        var serialized = ParserService.Serialize(Store.CurrentValue);
        
        await FileExtension.WriteAsync(serialized, FileName, DirectoryPath);

        return true;
    }

    public async Task<bool> GetAsync()
    {
        if (!FileExtension.IsFileExist(FileName, DirectoryPath))
        {
            throw new FileNotFoundException(Path.Combine(DirectoryPath, FileName));
        }
        
        var nonSerialize =  await FileExtension.ReadAsync(FileName, DirectoryPath);

        if (!IgnoreNullS && string.IsNullOrEmpty(nonSerialize))
        {
            throw new ArgumentNullException(nameof(nonSerialize));
        }
        
        var deSerialize =  ParserService.DeSerialize<T>(nonSerialize);

        if (deSerialize == null)
        {
            throw new  ArgumentNullException(nameof(deSerialize));
        }
        
        Store.CurrentValue = deSerialize;
        
        return true;
    }
}