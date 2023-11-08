namespace AppInfrastructure.Services.FileService;

public static class FileExtension
{
    #region RestoreDirectories 
    
    public static bool RestoreDirectories(string path)
    {
        var ret = IsDirectoryExist(path);

        if (ret) return ret;
        
        try
        {
            Directory.CreateDirectory(path);
            ret = true;
        }
        catch (Exception error)
        {
            ret = false;
        }

        return ret;
    }

    #endregion

    #region IsDirectoryExist 
    
    public static bool IsDirectoryExist(string path) =>
        string.IsNullOrEmpty(path.Trim())
        ? throw new ArgumentNullException(nameof(path))
        : Directory.Exists(path);
    

    #endregion

    #region RestoreFile 
    
    public static bool RestoreFile(string fileName, string? directoryPath = null)
    {
        bool ret = true; 
        
        if (string.IsNullOrEmpty(directoryPath?.Trim()))
            directoryPath = Path.Combine(Directory.GetCurrentDirectory(),"Data");

        if (IsFileExist(directoryPath, fileName))
            return true;

        if (!IsDirectoryExist(directoryPath))
            ret = RestoreDirectories(directoryPath);

        var path = Path.Combine(directoryPath, fileName);
       
        if(ret)
            try
            {
                File.Create(path).Close();
                ret = true;
            }
            catch (Exception e)
            {
                ret =  false;
            }
        
        return ret;
    }

    #endregion

    #region WriteAsync 

    public static async Task<bool> WriteAsync(string data, string fileName, string? directoryPath = null, bool restoreFile = true)
    {
        var ret = true;
        
        if (string.IsNullOrEmpty(data.Trim())) throw new ArgumentNullException(nameof(data));
        
        if (string.IsNullOrEmpty(fileName.Trim())) throw new ArgumentNullException(nameof(fileName));

        if (string.IsNullOrEmpty(directoryPath))
            directoryPath = Path.Combine(Directory.GetCurrentDirectory(),"Data");
        
        if (restoreFile)
            ret = RestoreFile(fileName,directoryPath);
        
        string path = Path.Combine(directoryPath, fileName);
        
        if(ret)
            try
            {
                await using StreamWriter writer = new StreamWriter(path, false);
                
                await writer.WriteLineAsync(data);
            }
            catch (Exception error)
            {
                ret = false;
            }

        return ret;
    }

    #endregion

    #region ReadAsync : Get string data from file

    public async static Task<string> ReadAsync(string fileName, string directoryPath = "")
    {
        var textFromFile = String.Empty;
        
        if (string.IsNullOrEmpty(fileName.Trim())) throw new ArgumentNullException(nameof(fileName));

        if (string.IsNullOrEmpty(directoryPath))
            directoryPath = Path.Combine(Directory.GetCurrentDirectory());

        var path = Path.Combine(directoryPath, fileName);

        var ret = IsFileExist(fileName, directoryPath);
        
        if(ret)
            try
            {
                using (var reader = new StreamReader(path))
                {
                    while (await reader.ReadLineAsync() is { } line)
                    {
                        textFromFile += line;
                    }
                }
            }
            catch (Exception error)
            {
                textFromFile = "";
            }
        
        return textFromFile;
    }

    #endregion
    
    #region IsFileExist 
    
    public static bool IsFileExist(string fileName, string directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath.Trim())) throw new ArgumentNullException(nameof(directoryPath));
        
        if (string.IsNullOrEmpty(fileName.Trim())) throw new ArgumentNullException(nameof(fileName));
        
        return File.Exists(Path.Combine(directoryPath,fileName));
    }
    
    #endregion
}