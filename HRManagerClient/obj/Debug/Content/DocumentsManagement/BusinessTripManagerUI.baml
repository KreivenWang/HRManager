   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5   
   +   %HRManagerClient.BusinessTripManagerUI   5   
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
TargetType"  ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      4  .HRManagerClient.CustomControls.DBNavigationBar  $	��Top=�61      AddText$ 添加出差单��5   1      
RemoveText$ 删除出差单��5   1      AddItemCommand 5   1   �� *AddItemCommand+   RemoveItemCommand 5   1   �� *RemoveItemCommand+&   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .     CanUserAddRows .  ��6'   �� *Model+	 �� SelectedValue	 5   '   �� *SelectedItem+
   Columns
 5   "   0  *System.Windows.Controls.DataGridTextColumn  5   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 单据编号��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5   9      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   9   �� *BusinessTripNo+5   9     5   &   $ 标题��69   $	 150 5    9    .  5!   9   �� *BusinessTripTitle+5"   9     5#   &   $ 员工��69   $	 150 5$   9    .  5%   9   �� *&$Employee.EmployeeBaseInfo.EmployName+5&   9     5'   &   $ 开始时间��69   $	 150 5(   9    .  5)   9   �� *	BeginDate+ �� StringFormat$ {0:yyyy-MM-dd HH:mm}��   StringToDateTimeConverter �� 	Converter# [  5*   9     5+   &   $ 结束时间��69   $	 150 5,   9    .  5-   9   �� *	EndDate+$ {0:yyyy-MM-dd HH:mm}��# [  5.   9     5/   &   $ 原因��69   $	 250 50   9    .  51   9   �� *Reason+52   9     53   &   $ 	制单人��69   $	 150 54   9    .  55   9   �� *	Creator+56   9   58      59      5:      5<      5=      5?      