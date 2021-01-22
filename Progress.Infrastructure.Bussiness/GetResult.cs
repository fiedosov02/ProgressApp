using Progress.Domain.Data;
using Progress.Infrastructure.Data;
using Progress.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Infrastructure.Bussiness
{
    public class GetResult : IResult, IEnumerable
    {
        
        public (double,double,double) CreateResult(Customer customer)
        {
            //int dayInMonth = DateTime.DaysInMonth(customer.Year, customer.Month); // how many days in a month
            var allTime = customer.TimeForTask * 24; // all time (hours)
            var timeforWork = allTime / 2.4; // it`s all work time (10 hours for a study/work)
            var workTimeWitPlayTime = (timeforWork * 0.75); // each hours timeout for 15 minutes
            var result = (allTime, timeforWork, workTimeWitPlayTime);
            return result;
            
		}
        public DateTime FinishOfWork(Customer customer)
        {
            var finish = customer.Time.AddDays(customer.TimeForTask); // date of finishing of work
           
            //CustomerRepository customer1 = new CustomerRepository();
            //customer1.Save();
           // customer.Time = finish;
            return finish;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
