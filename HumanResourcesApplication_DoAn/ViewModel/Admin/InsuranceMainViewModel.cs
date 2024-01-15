using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Views.Admin;
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
        public ViewModelCommand AddInsuranceCommand { get; }
        public ViewModelCommand ChangeInsuranceCommand { get; }
        public ViewModelCommand DeleteInsuranceCommand { get; }
        public InsuranceMainViewModel()
        {
            insuranceRepository = new InsuranceRepository();
            listInsurances = new List<InsuranceForView>();
            listInsurances = insuranceRepository.GetByAll();
            AddInsuranceCommand = new ViewModelCommand(ExecuteAddInsuranceCommand);
            ChangeInsuranceCommand = new ViewModelCommand(ExcuteChangeDepartmentCommand);
            DeleteInsuranceCommand = new ViewModelCommand(ExcuteDeleteDepartmentCommand);
        }

        private void ExecuteAddInsuranceCommand(object? obj)
        {
            AddInsuranceViewModel addInsuranceViewModel = new AddInsuranceViewModel();
            Insurance_Add insurance_Add = new Insurance_Add();
            insurance_Add.DataContext = addInsuranceViewModel;
            insurance_Add.ShowDialog();
            ListInsurances = insuranceRepository.GetByAll();
        }

        private void ExcuteDeleteDepartmentCommand(object? obj)
        {
            MessageBox.Show("Delete");
        }

        private void ExcuteChangeDepartmentCommand(object? obj)
        {
            Insurance_Change insurance_Change = new Insurance_Change();
            insurance_Change.DataContext = new ChangeInsuranceViewModel(SelectedItem);
            insurance_Change.ShowDialog();
            ListInsurances = insuranceRepository.GetByAll();
        }
    }
}
