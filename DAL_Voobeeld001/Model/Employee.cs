using DAL_Voobeeld001.DAL;

namespace DAL_Voobeeld001.Model
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }

        public Employee(int _id, string _fn, string _ln, string dep)
        {
            EmployeeId = _id;
            FirstName = _fn;
            LastName = _ln;
            Department = dep;
        }

        public Employee(string _fn, string _ln, string dep)
        {
            FirstName = _fn;
            LastName = _ln;
            Department = dep;
        }

        public void CreateEmployee()
        { 
            // is bankrekeningnummer correct
            SQLDal DAL = new SQLDal();
            DAL.AddEmployee(this);
        }
        public void DeleteEmployee()
        {
            SQLDal DAL = new SQLDal();
            DAL.DeleteEmployee(this.EmployeeId);
        }

        public List<Employee> GetEmployees()
        {
            SQLDal DAL = new SQLDal();
            return DAL.GetAllEmployees();
        }
    }
}
