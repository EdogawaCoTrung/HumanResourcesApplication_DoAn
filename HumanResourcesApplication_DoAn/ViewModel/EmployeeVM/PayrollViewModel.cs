using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class PayrollViewModel:ViewModelBase
    {
        List<EmployeePayroll> employeePayroll;

        IGetPayrollByIdRepository getPayrollByIdRepository;
        private string? current;
        private string? previous;
        private string? different;

        public List<EmployeePayroll> EmployeePayroll { get => employeePayroll; set { employeePayroll = value; OnPropertyChanged(nameof(EmployeePayroll)); } }

        public string? Current { get => current; set { current = value; OnPropertyChanged(nameof(Current)); } }
        public string? Previous { get => previous; set { previous = value; OnPropertyChanged(nameof(Previous)); } }

        public string Different { get => different; set { different = value; OnPropertyChanged(nameof(Different)); } }

       

        public PayrollViewModel()
        {
            getPayrollByIdRepository = new GetPayrollByIdRepository();
            employeePayroll = getPayrollByIdRepository.GetPayrollById(MyApp.currentUser.userId);
            double? temp = employeePayroll[0].Payroll.salary;
            DateOnly? tempdate = employeePayroll[0].PayrollHistory.EndDate;
   
            foreach (EmployeePayroll item in employeePayroll )
            {
              
                if(item.PayrollHistory.StartDate > tempdate)
                {
                    temp = item.Payroll.salary;
                    tempdate = item.PayrollHistory.EndDate;
                }
            }
            current = temp.ToString();
            List<EmployeePayroll> listEmp = new List<EmployeePayroll>();
            listEmp = getPayrollByIdRepository.GetPayrollById(MyApp.currentUser.userId);
            foreach (EmployeePayroll item in listEmp)
            {
                if(item.PayrollHistory.EndDate == tempdate)
                {
                    listEmp.Remove(item);
                    break;
                }
            }
            if (listEmp.Count == 0)
            {
                previous = temp.ToString();
                different = "UNCHANGE 0%";
            }
            else
            {
                double? temp1 = listEmp[0].Payroll.salary;
                DateOnly? tempdate1 = listEmp[0].PayrollHistory.EndDate;
                foreach (EmployeePayroll item in listEmp)
                {

                    if (item.PayrollHistory.StartDate > tempdate1)
                    {
                        temp1 = item.Payroll.salary;
                        tempdate1 = item.PayrollHistory.EndDate;
                    }
                }
                previous = temp1.ToString();
            }
            if(int.Parse(current)-int.Parse(previous) > 0)
            {
                different = "INCREASE " + (((double.Parse(current) - double.Parse(previous)) / (double.Parse(Previous))).ToString("N2") + "%").ToString();
            }
            else if(int.Parse(current) - int.Parse(previous) == 0 )
            {
                different = "UNCHANGE 0%";
            }
            else
            {
                different = "DECREASE " + (((double.Parse(previous) - double.Parse(current)) / (double.Parse(Previous))).ToString("N2") + "%").ToString();
            }
           
        }
    }
}
