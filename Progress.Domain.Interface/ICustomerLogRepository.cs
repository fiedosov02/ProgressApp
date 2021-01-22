using Progress.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Domain.Interface
{
    public interface ICustomerLogRepository : IDisposable
    {
        Customer Register(CustomerRegister customerRegister, Customer c);
        Customer GetCustomer(CustomerRegister customerRegister, Customer c);
        Customer GetCustomerForLogin(CustomerLog customer, Customer c);
    }
}
