using FileService.Interfaces;
using myModels.Interfaces;
using FileService;
using FileService.Interfaces;


namespace myServices;

public class LoginServices : Ilogin
{

    IFileService<Worker> _file;
    string _path = @"H:/webApi/חדש/workerFile.json";
    public LoginServices(IFileService<Worker> file)
    {
        _file = file;
    }

    public Worker IsExists(string name, string password)
    {
        var workers = _file.Read(_path);
        foreach (var i in workers)
        {
            if (i.Name == name && i.Password == password)
            {
                return i;
            }
        };
        return null;
    }

}
