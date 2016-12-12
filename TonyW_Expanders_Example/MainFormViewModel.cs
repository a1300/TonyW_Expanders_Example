using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace OptionsDialog
{
    public class MainFormViewModel : BindableObject
    {
        public ObservableCollection<Category> AvailableColumns { get; set; }
        public ObservableCollection<Category> VisibleColumns { get; set; }

        public Category CurrentItemLeft
        {
            get { return _currentItemLeft; }
            set
            {
                _currentItemLeft = value;
                RaisePropertyChanged("CurrentItemLeft");
            }
        }
        public Category CurrentItemRight
        {
            get { return _currentItemRight; }
            set
            {
                _currentItemRight = value;
                RaisePropertyChanged("CurrentItemRight");
            }
        }

        public ICommand ShiftToRightCommand { get; private set; }
        public ICommand ShiftToLeftCommand { get; private set; }

        public MainFormViewModel()
        {
            AvailableColumns = new ObservableCollection<Category>();
            VisibleColumns = new ObservableCollection<Category>();

            ShiftToRightCommand = new RelayCommand(ExecuteShiftToRight, CanExecuteShiftToRight);
            ShiftToLeftCommand = new RelayCommand(ExecuteShiftToLeft, CanExecuteShiftToLeft);
            Load();
        }

        public void Load()
        {
            //normall you would
            //load your data from a db or webservice

            //Some dummy Data
            AvailableColumns.Add(new Category() { Name = "Thumbnail", Type = CategoryType.Image });
            AvailableColumns.Add(new Category() { Name = "LastName", Type = CategoryType.GeneralInformation });
            AvailableColumns.Add(new Category() { Name = "ZIP", Type = CategoryType.AddressData });
            AvailableColumns.Add(new Category() { Name = "Address", Type = CategoryType.AddressData });
            AvailableColumns.Add(new Category() { Name = "FirstName", Type = CategoryType.GeneralInformation });
            AvailableColumns.Add(new Category() { Name = "Portrait", Type = CategoryType.Image });
        }

        #region Commands
        private bool CanExecuteShiftToRight(object obj)
        {
            return CurrentItemLeft != null;
        }
        private void ExecuteShiftToRight(object obj)
        {
            var temp = CurrentItemLeft;
            CurrentItemLeft = null;

            AvailableColumns.Remove(temp);
            VisibleColumns.Add(temp);

            CurrentItemLeft = null;
            CurrentItemRight = null;
            CurrentItemRight = VisibleColumns.LastOrDefault();
        }


        private bool CanExecuteShiftToLeft(object obj)
        {
            return CurrentItemRight != null;
        }
        private void ExecuteShiftToLeft(object obj)
        {
            var temp = CurrentItemRight;
            CurrentItemRight = null;

            VisibleColumns.Remove(temp);
            AvailableColumns.Add(temp);

            CurrentItemLeft = null;
            CurrentItemRight = null;
            CurrentItemLeft = AvailableColumns.LastOrDefault();
        }
        #endregion


        #region Private/Protected
        private Category _currentItemLeft;
        private Category _currentItemRight;
        #endregion
    }
}
