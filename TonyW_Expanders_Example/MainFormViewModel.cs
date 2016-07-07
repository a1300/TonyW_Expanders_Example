using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TonyW_Expanders_Example
{
    public class MainFormViewModel : BindableObject
    {
        public ObservableCollection<SimpleModel> AvailableColumns { get; set; }
        public ObservableCollection<SimpleModel> VisibleColumns { get; set; }

        public SimpleModel CurrentItemLeft
        {
            get
            {
                return _currentItemLeft;
            }
            set
            {
                _currentItemLeft = value;
                RaisePropertyChanged("CurrentItemLeft");
            }
        }
        public SimpleModel CurrentItemRight
        {
            get
            {
                return _currentItemRight;
            }
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
            AvailableColumns = new ObservableCollection<SimpleModel>();
            VisibleColumns = new ObservableCollection<SimpleModel>();

            ShiftToRightCommand = new RelayCommand(ExecuteShiftToRight, CanExecuteShiftToRight);
            ShiftToLeftCommand = new RelayCommand(ExecuteShiftToLeft, CanExecuteShiftToLeft);
            Load();
        }

        public void Load()
        {
            //normall you would
            //load your data from a db or webservice

            //Some dummy Data
            AvailableColumns.Add(new SimpleModel() { FirstName = "Louise", LastName="Burling" });
            AvailableColumns.Add(new SimpleModel() { FirstName = "Hana", LastName = "Gregor" });
            AvailableColumns.Add(new SimpleModel() { FirstName = "Don", LastName = "Giovanni" });
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
        private SimpleModel _currentItemLeft;
        private SimpleModel _currentItemRight;
        #endregion
    }
}
