  namespace FileService.Interfaces;
  public interface IFileService<T>
  {
    List<T> Read(string path);
    void Write(T obj,string path);
  }