using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using HRModel;

namespace HRManagerClient
{
    class VacationSolutionManagerViewModel : DBOperateViewModel<VacationPlan>
    {
        internal List<Calendar> Calendars { get; set; }
        public bool IsInitializingSelectedVSln { get; set; }

        public IEnumerable YearsSelections
        {
            get { return new List<int>() {2016, 2017, 2018}; }
        } 

        #region SelectedVSln 属性
        private VacationSolutionViewModel _backfield_SelectedVSln;
        public VacationSolutionViewModel SelectedVSln
        {
            get { return _backfield_SelectedVSln; }
            set
            {
                _backfield_SelectedVSln = value;
                RaisePropertyChanged(() => SelectedVSln);
            }
        }
        #endregion

        public override VacationPlan SelectedItem
        {
            get { return base.SelectedItem; }
            set
            {
                base.SelectedItem = value;
                if (value == null)
                {
                    SelectedVSln = null;
                    return;
                }
                else
                {
                    SelectedVSln =  new VacationSolutionViewModel(value);
                    ReselectVacationDays();
                }
            }
        }

        public ICommand ClearSelectionsCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public VacationSolutionManagerViewModel(EntityCollection<VacationPlan> model) : base(model)
        {
            ClearSelectionsCommand = new RelayCommand<object>(ClearSelectedCalendarSelections);
            SaveCommand = new RelayCommand(SaveChanges);
            RegistReceiverSlot(VacationSolutionViewModel.ClearAllToken, ClearAllSelections);
        }

        private void ClearSelectedCalendarSelections(object tag)
        {
            var cal = Calendars.Find(c => int.Parse(c.Tag.ToString()) == int.Parse(tag.ToString()));
            cal.SelectedDates.Clear();
        }

        private void ClearAllSelections()
        {
            foreach (var calendar in Calendars) {
                calendar.SelectedDates.Clear();
            }
        }

        private void ReselectVacationDays()
        {
            IsInitializingSelectedVSln = true;
            ClearAllSelections();
            foreach (var vacationDay in SelectedVSln.Model.VacationDays) {
                var calendar = Calendars.Find(c => int.Parse(c.Tag.ToString()) == vacationDay.Month);
                if (calendar != null) {
                    calendar.SelectedDates.Add(vacationDay);
                }
            }
            IsInitializingSelectedVSln = false;
        }

        protected override VacationPlan GetNewItemInstance()
        {
            var result = new VacationPlan
            {
                VacationDays = new List<DateTime>(),
                Year = DateTime.Now.Year
            };
            SelectedItem = result;
            return result;
        }

    }
}
