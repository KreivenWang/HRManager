   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5   
   )   #HRManagerClient.AttendenceManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   /localclr-namespace:HRManagerClient     5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   ;cc,clr-namespace:HRManagerClient.CustomControls     5   
   -   5        $
��root��5	   
   ��5
      �� 5   
     �� 
TargetType"  ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      ��  �� Orientation$ 
Horizontal=�6)   $	��Top=�5   )   {�5   )   �� *	CanModify+.+�5   "   �� $��时间查询:��6,   $��Center=�69   6V   (  "System.Windows.Controls.DatePicker  5   "   $��5q�6P      SelectedDate 6-   �� *	StartTime+6P   �� 5   "   $	��至��6,   $��Center=�5   ,     5   "   $��5q�5   -    5   -   �� *	EndTime+5   -   �� 5   "   $��5q�5   )   ��5   )   �� *FilteCommand+.��5   4   查询68   �� 5   "   $��5q�5   )   ��5   )   �� *ClearFilteCommand+.��5   4   清除查询6:   5      &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .     CanUserAddRows .  ��6'   �� *FiltedItems+ �� SelectedValue 5!   '   �� *SelectedItem+   Columns 5"   "   0  *System.Windows.Controls.DataGridTextColumn  5#   &   ,  &System.Windows.Controls.DataGridColumn	   Header$	 打卡时间��69   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 5$   9      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5%   9   �� *
RecordTime+   StringToDateTimeConverter �� 	Converter# [   �� StringFormat$ yyyy-MM-dd HH:mm:ss��5&   9     5'   *   $	 员工工号��6=   $	
 150 5(   9    .  5)   9   �� *
EmployeeNo+5*   9     5+   &   $	 员工姓名��69   $	
 150 5,   9    .  5-   9   �� *EmployeeName+5.   9   50      51      52      54      55      57      