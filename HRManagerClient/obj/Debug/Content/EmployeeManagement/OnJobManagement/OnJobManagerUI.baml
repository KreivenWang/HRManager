   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   d `GalaSoft.MvvmLight.Extras, Version=5.3.0.19026, Culture=neutral, PublicKeyToken=f46ff315b1088208jKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.ExtrasGalaSoft.MvvmLight.Command 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   $   HRManagerClient.OnJobManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	    5   
   /localclr-namespace:HRManagerClient 	    5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel 	    5   
   [cmdKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras 	    5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 	    5   
   -   5        $
��root��5	   
     � 	Resources  5
      + %HRManagerClient.ExpireRemindConverter   ExpireRemindConverter��%   &	          5   
   6&   5      ��5      �� 5   
    �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      &   System.Windows.Controls.DataGrid  -   5           AutoGenerateColumns .     CanUserAddRows .  ��5   '   �� *Model+ �� SelectedValue 5   '   �� *SelectedItem+.  (System.Windows.Interactivity.Interaction   Triggers 5   "   /  )System.Windows.Interactivity.EventTrigger  5   &      	EventName$ MouseDoubleClick��65   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5   *   6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6@   �� *ShowEmployeeDetailCommand+5   '      RowDetailsTemplate 5    "   �� 5!   &   .R�5"   *   �� $��22(�5#   4   $��Center=�5$   4   $��5q�5%   4   ��5"   4   �� *
ExpireDate+ �� 	Converter# [  5%   4   5&   '      Columns 5(   "   0  *System.Windows.Controls.DataGridTextColumn  5)   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 姓名��69      Width5	  /System.Windows.Controls.DataGridLengthConverter$ 75	 5+   9      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5*   9   �� *EmployeeBaseInfo.EmployName+5,   9     5-   &   $ 工号��69   $ 75	 5/   9    .  5.   9   �� *
EmployeeNO+50   9     51   &   $ 部门��69   $	 100	 53   9    .  52   9   �� *Department.DepartName+ �� Mode$ TwoWay=�54   9     55   &   $ 岗位��69   $	 100	 57   9    .  56   9   �� *!OperatingPost.OperatingPostName+58   9     59   &   $ 性别��69   $	 100	 5;   9    .  5:   9   �� *EmployeeBaseInfo.Sex+  EnumChStringConverter# [ 5<   9     5=   &   $ 入职时间��69   $	 100	 5?   9    .  5>   9   �� *
HireDate+ �� StringFormat$ {0:yyyy-MM-dd}��  StringToDateTimeConverter# [ 5@   9     5A   &   $ 合同到期日��69    .  5B   9   �� *
ExpireDate+$ {0:yyyy-MM-dd}��# [ 5C   9     5D   &   $ 联系电话��69   $	 100	 5F   9    .  5E   9   �� *EmployeeBaseInfo.Phone+5G   9     5H   &   $ 	现住址��69   $	 100	 5J   9    .  5I   9   �� *EmployeeBaseInfo.CurSite+5K   9     5L   &   $ 人员状态��69   $	 100	 5N   9    .  5M   9   �� *State+# [ 5O   9     5P   &   $ 备注��69   $	 100	 5R   9    .  5Q   9   �� *EmployeeBaseInfo.Remark+5S   9   5U      5V      5W      5Y      5Z      5\      