using Progress.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Services.Interface
{
    public interface IResult
    {
        (double,double,double) CreateResult(Customer customer);
        DateTime FinishOfWork(Customer customer);
    }
}
