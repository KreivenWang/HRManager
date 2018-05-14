using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HRModel;

namespace HRManagerClient
{
    class VacationSolutionViewModel : ViewModelBase<VacationPlan>
    {
        public const string ClearAllToken = "VacationPlan.ClearAllSelections";

        #region IsAllSundaySelected 属性
        public bool IsAllSundaySelected
        {
            get { return Model.IsSundaysIncluded; }
            set
            {
                Model.IsSundaysIncluded = value;
                RaisePropertyChanged(() => IsAllSundaySelected);
                RaisePropertyChanged(() => AllSundaySelectedVisibility);
            }
        }
        public Visibility AllSundaySelectedVisibility
        {
            get { return IsAllSundaySelected ? Visibility.Visible : Visibility.Hidden; }
        }
        #endregion


        #region IsAllSaturdaySelected 属性
        public bool IsAllSaturdaySelected
        {
            get { return Model.IsSaturdaysIncluded; }
            set
            {
                Model.IsSaturdaysIncluded = value;
                RaisePropertyChanged(() => IsAllSaturdaySelected);
                RaisePropertyChanged(() => AllSaturdaySelectedVisibility);
            }
        }
        public Visibility AllSaturdaySelectedVisibility
        {
            get { return IsAllSaturdaySelected ? Visibility.Visible : Visibility.Hidden; }
        }
        #endregion

        #region Year 属性
        public int Year
        {
            get { return Model.Year; }
            set
            {
                Model.Year = value;
                RaisePropertyChanged(() => Year);
                ResetSelectStatus();
            }
        }

        private void ResetSelectStatus()
        {
            IsAllSaturdaySelected = false;
            IsAllSundaySelected = false;
            SendSignal(ClearAllToken);
        }

        #endregion

        public VacationSolutionViewModel(VacationPlan model):base(model)
        {
            Model.Year = DateTime.Now.Year;
        }

        //private void SetWeekendSelectStatus(bool isSelect, DayOfWeek dow)
        //{
        //    if (Calendars == null) return;
        //    foreach (var calendar in Calendars) {
        //        var month = int.Parse(calendar.Tag.ToString());
        //        foreach (var day in GetAllWeekendDays(Year, month, dow)) {
        //            if (isSelect)
        //                calendar.SelectedDates.Add(day);
        //            else
        //                calendar.SelectedDates.Remove(day);
        //        }
        //    }
        //}

        
    }
}
