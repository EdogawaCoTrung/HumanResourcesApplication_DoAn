using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class InsuranceMainViewModel : ViewModelBase
    {
        List<InsuranceForView> listInsurances;
        InsuranceForView _selectedItem;
        public List<InsuranceForView> ListInsurances
        {
            get => listInsurances;
            set
            {
                listInsurances = value;
                OnPropertyChanged(nameof(listInsurances));
            }
        }
        public InsuranceForView SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public IInsuranceRepository insuranceRepository;
        public ViewModelCommand ChangeInsuranceCommand { get; }
        public ViewModelCommand DeleteInsuranceCommand { get; }
        public InsuranceMainViewModel()
        {
            insuranceRepository = new InsuranceRepository();
            listInsurances = new List<InsuranceForView>();
            listInsurances = insuranceRepository.GetByAll();
            ChangeInsuranceCommand = new ViewModelCommand(ExcuteChangeDepartmentCommand);
            DeleteInsuranceCommand = new ViewModelCommand(ExcuteDeleteDepartmentCommand);
        }

        private void ExcuteDeleteDepartmentCommand(object? obj)
        {
            MessageBox.Show("Delete");
        }

        private void ExcuteChangeDepartmentCommand(object? obj)
        {
            MessageBox.Show("Change");

        }
    }
}
