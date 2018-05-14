using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public enum CardFillRecordType
    {
        Personal,
        Company
    }
   public class CardFillRecord : ObservableObject, IViewNeededModel
    {
       [NotMapped]
       public int Id { get { return CardFillRecordId; }}


       public int CardFillRecordId { get; set; }


       public CardFillRecordType CardFillRecordType { get; set; }


       #region Employee 属性
       private Employee _backfield_Employee;
       public Employee Employee
       {
           get { return _backfield_Employee; }
           set
           {
               _backfield_Employee = value;
               RaisePropertyChanged(() => Employee);
           }
       }

       public int EmployeeId { get; set; }
       #endregion
    }
}
