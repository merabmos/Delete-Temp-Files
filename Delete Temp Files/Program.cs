DirectoryInfo di = new DirectoryInfo(Path.GetTempPath());


Task taskDeleteFiles = Task.Run(() =>
{
    foreach (FileInfo file in di.GetFiles())
    {
        try
        {
            file.Delete();
        }
        catch (Exception e)
        {
            Console.WriteLine("Davichire File Error :" + e.ToString());
        }
    }
});

Task taskDeleteFolders = Task.Run(() => {
    foreach (DirectoryInfo dir in di.GetDirectories())
    {
        try
        {
            dir.Delete(true);
        }
        catch (Exception e)
        {
            Console.WriteLine("Davichire Folder Error : " + e.ToString());
        }
    }
});

taskDeleteFiles.Wait();
taskDeleteFolders.Wait();