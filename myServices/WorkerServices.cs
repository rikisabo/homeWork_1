using myModels;
using myModels.Interfaces;
using FileService;
using FileService.Interfaces;

namespace myServices;
public class WorkerServices : Iworker
{
    IFileService<Worker> _file;

    string _path = @"H:/webApi/חדש/workerFile.json";
    public WorkerServices(IFileService<Worker> file)
    {
        _file = file;
    }
    List<Worker> workers = new List<Worker>
    {
        new Worker("Avi",20,1548,"admin","gyftt")
    };
    public bool addWorker(string Name, int Age, int Salary, string Role, string Password)
    {
        foreach (var item in workers)
        {
            if (item.Name != Name)
            {
                Worker i = new Worker(Name, Age, Salary, Role, Password);
                workers.Add(i);
                _file.Write(i, _path);
                return true;
            }

        }
        return false;
    }
    
}