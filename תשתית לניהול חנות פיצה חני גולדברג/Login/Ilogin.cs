using myModels;
using myModels.Interfaces;
namespace myModels.Interfaces
{
    public interface Ilogin
    {
        public Worker IsExists(string name,string password);
    }
}