   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   d `GalaSoft.MvvmLight.Extras, Version=5.3.0.19026, Culture=neutral, PublicKeyToken=f46ff315b1088208jKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.ExtrasGalaSoft.MvvmLight.Command 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5	   
   +   %HRManagerClient.PostTransferManagerUI   5   
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
     � 	Resources  5      + %HRManagerClient.ExpireRemindConverter   ExpireRemindConverter  ModifiableDataGridHeader��%|   &	        &	        5   
   6&   �� 5   
   .R�5      �� $
��Bold"�6   
���<����5      �� 5      5      ��5      �� 5   
    �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      4  .HRManagerClient.CustomControls.DBNavigationBar  $	��Top=�61      AddText$ 添加记录��5   1      
RemoveText$ 删除记录��5   1      AddItemCommand 5   1   �� *AddItemCommand+   RemoveItemCommand 5   1   �� *RemoveItemCommand+&   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .  	   CanUserAddRows	 .  ��6'   �� *Model+
 �� SelectedValue
 5$   '   �� *SelectedItem+   Columns 5%   "   0  *System.Windows.Controls.DataGridTextColumn  5&   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 姓名��69      Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 5(   9      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5'   9   �� *&$Employee.EmployeeBaseInfo.EmployName+5)   9     5*   &   $ 工号��69   $ 75 5,   9    .  5+   9   �� *Employee.EmployeeNO+5-   9     5.   &   $ 	原部门��69   $	 100 50   9    .  5/   9   �� *)'PrevOperatingPost.Department.DepartName+51   9     52   &   $ 	现部门��69   $	 100 54   9    .  53   9   �� *(&CurOperatingPost.Department.DepartName+55   9     56   &   $ 	原岗位��69   $	 100 58   9    .  57   9   �� *%#PrevOperatingPost.OperatingPostName+59   9     5:   &   $ 	现岗位��69   $	 100 5<   9    .  5;   9   �� *$"CurOperatingPost.OperatingPostName+5=   9     5>   &   $ 岗位调整状态��69   $	 100 5?   9    .  5@   9   �� *
RankStatus+  LocalizationConverter �� 	Converter# [ 5A   9     5B   &   $ 岗位调整日期��69   $	 120 5C   9    .  5D   9   �� *AdjustDateTime+ �� StringFormat$ {0:yyyy-MM-dd}��  StringToDateTimeConverter# [ 5E   9     5F   &   $ 调整原因��69   $	 100 5G   9    .  5H   9   �� *AdjustReason+5I   9   5K      5L      5M      5O      5P      5R      