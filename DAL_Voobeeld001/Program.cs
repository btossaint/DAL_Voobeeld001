using DAL_Voobeeld001.Model;

namespace DAL_Voobeeld001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string answer;
            
            Console.WriteLine("OpleidingsSysteem v0.01");
            Employee employee = new Employee("Jan","Janssen","Fysiotherapie");
            employee.CreateEmployee();
            ShowEmployee(employee.GetEmployees());

            /*
            Console.WriteLine($"Wilt je de medewerker {employee.EmployeeId} met naam: {employee.LastName} verwijderen (J/N)?");
            answer = Console.ReadLine();
            if (answer == "J" || answer == "j")
            {
                DeleteEmployee(employee);
            }
            */
        }

        static void ShowEmployee(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                Console.WriteLine($"Medewerker {e.EmployeeId}: {e.FirstName} {e.LastName}");
            }
        }

        static void DeleteEmployee(Employee employee)
        {
           Console.WriteLine($"Verwijderen medewerker {employee.EmployeeId}: '{employee.FirstName} {employee.LastName}'");
           employee.DeleteEmployee();           
        }
    }
}
