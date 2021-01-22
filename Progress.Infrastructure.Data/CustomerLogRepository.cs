using Progress.Domain.Data;
using Progress.Domain.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Security;

namespace Progress.Infrastructure.Data
{
    public class CustomerLogRepository : ICustomerLogRepository
    {
        CustomerRepository cs = new CustomerRepository();
        private CustomerContext db;
        public CustomerLogRepository() => this.db = new CustomerContext();

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Customer Register(CustomerRegister customerRegister, Customer c)
        {

            cs.Create(new Customer { Email = customerRegister.Login, Password = customerRegister.Password, TimeForTask=2, Task="dasd", Time = DateTime.Now});
            cs.Save();
            c = cs.GetRegistCustomer(customerRegister);
            return c;
        }
        public Customer GetCustomer(CustomerRegister customerRegister, Customer c)
        {
            c = db.Customers.FirstOrDefault(a => a.Email == customerRegister.Login);
            return c;
        }
        public Customer GetCustomerForLogin(CustomerLog customer, Customer c)
        {
            c = db.Customers.FirstOrDefault(a => a.Email == customer.Login && a.Password == customer.Password);
            return c;
        }
    }
}
