using myModels;

public class Worker
{
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public Worker(string name, int age, int salary, string role, string password)
        {
                this.Name = name;
                this.Age = age;
                this.Salary = salary;
                this.Role = role;
                this.Password = password;
        }
}