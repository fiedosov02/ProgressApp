using Progress.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Domain.Interface
{
    public interface ICustomerRepository : IDisposable
    {
        Task<IEnumerable<Customer>> GetCustomerList();
        Task<Customer> GetCustomer(int id);
        void Create(Customer customer);
        void Delete(int id);
        void UpDate(Customer customer);
        void Save();
    }
}
