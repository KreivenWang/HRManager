   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   d `GalaSoft.MvvmLight.Extras, Version=5.3.0.19026, Culture=neutral, PublicKeyToken=f46ff315b1088208jKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.ExtrasGalaSoft.MvvmLight.Command 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5	   
   %   HRManagerClient.OffJobManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	    5   
   /localclr-namespace:HRManagerClient 	    5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel 	    5   
   [cmdKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras 	    5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 	    5   
   ;cc,clr-namespace:HRManagerClient.CustomControls 	    5	   
   -   5        $
��root��5
   
     � 	Resources  5      + %HRManagerClient.ExpireRemindConverter   ExpireRemindConverter��%   &	          5   
   6&   5      ��5      �� 5   
    �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      4  .HRManagerClient.CustomControls.DBNavigationBar  $	��Top=�5   1      RefreshCommand 5   1   �� *RefreshCommand+   SaveChangesCommand 5   1   �� *UpdateItemCommand+5   1   &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  ��6'   �� *	LeftEps+	 �� SelectedValue	 5   '   �� *SelectedItem+
   Columns
 5   "   0  *System.Windows.Controls.DataGridTextColumn  5   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 姓名��69      Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 5   9      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   9   �� *EmployeeBaseInfo.EmployName+5    9     5!   &   $ 工号��69   $ 75 5#   9    .  5"   9   �� *
EmployeeNO+5$   9     5%   &   $ 部门��69   $	 100 5'   9    .  5&   9   �� *Department.DepartName+5(   9     5)   &   $ 岗位��69   $	 100 5+   9    .  5*   9   �� *!OperatingPost.OperatingPostName+5,   9     5-   &   $ 性别��69   $	 100 5/   9    .  5.   9   �� *EmployeeBaseInfo.Sex+  EnumChStringConverter �� 	Converter# [ 50   9     51   &   $ 入职时间��69   $	 100 53   9    .  52   9   �� *
HireDate+ �� StringFormat$ {0:yyyy-MM-dd}��  StringToDateTimeConverter# [ 54   9   4  .System.Windows.Controls.DataGridTemplateColumn  55   &   $ 离职时间��6=   $	 150 56   =     ModifiableDataGridHeader   HeaderTemplate# [ 57   =      CellEditingTemplate 58   *   �� 59   .   .R�5:   2   (	  "System.Windows.Controls.DatePicker	   	  SelectedDate 6=   �� *
ExpireDate+$ {0:yyyy-MM-dd}��# [ 5;   /      CellTemplate 5=   *   �� 5>   .   .R�5?   2   �� $
��Wrap=�5@   <   ��5?   <   �� *
ExpireDate+$ {0:yyyy-MM-dd}��# [ 5@   <   5A   /   5C   '     5D   &   $ 离职原因��6=   $	 150 5E   =   # [ 5F   =    5G   *   �� 5H   .   .R�5I   2   ��  �� TextWrapping$
 Wrap=�5J   :   ��5I   :   �� *ExpireReason+ �� UpdateSourceTrigger$ PropertyChanged=�5J   :   5K   /    5M   *   �� 5N   .   .R�5O   2   �� $
��Wrap=�6Z   ��6<   �� *ExpireReason+6Z   5P   /   5R   '     5S   &   $ 人员状态��69   $	 100 5U   9    .  5T   9   �� *State+# [ 5V   9     5W   &   $ 联系电话��69   $	 100 5Y   9    .  5X   9   �� *EmployeeBaseInfo.Phone+5Z   9     5[   &   $ 	现住址��69   $	 100 5]   9    .  5\   9   �� *EmployeeBaseInfo.CurSite+5^   9     5_   &   $ 备注��69   $	 100 5a   9    .  5`   9   �� *EmployeeBaseInfo.Remark+5b   9   5d      5e      5f      5h      5i      5k      