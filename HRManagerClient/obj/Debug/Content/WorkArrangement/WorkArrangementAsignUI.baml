   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5	   
   ,   &HRManagerClient.WorkArrangementAsignUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   /localclr-namespace:HRManagerClient     5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   ;cc,clr-namespace:HRManagerClient.CustomControls     5	   
   -   5        $
��root��5   
   ��5
      �� 5   
     �� 
TargetType"  ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      4  .HRManagerClient.CustomControls.DBNavigationBar  $	��Top=�61      AddText$ 添加排班��5   1      
RemoveText$ 删除排班��5   1      AddItemCommand 5   1   �� *AddItemCommand+   RemoveItemCommand 5   1   �� *RemoveItemCommand+   RefreshCommand 5   1   �� *RefreshCommand+&   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .  	   CanUserAddRows	 .  ��6'   �� *Model+
 �� SelectedItem
 5   '   �� *SelectedItem+ � 	Resources 5   "   ��%�   '��       �� 5   &   "  ��6,   .�5   *   ��  � ��$ 6q�5   1   �� 5   *    � ��$ Center=�5   1   5    '   5!   #      Columns 5"   "   0  *System.Windows.Controls.DataGridTextColumn  5#   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 部门��69      MinWidth$	 150Q�5$   9      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5%   9   �� *Department.DepartName+6c     5&   &   $ 岗位��69   $	 150Q�5'   9    .  5(   9   �� *!OperatingPost.OperatingPostName+5)   9     5*   &   $ 人员��69   $	 150Q�5+   9    .  5-   *   `� 5.   .    �� StringFormat$ [{0}]{1}��6;   .1�5/   2   ��  �� Path$ Employee.EmployeeNO�6:   �� 50   2   $* $Employee.EmployeeBaseInfo.EmployName�6:   51   /   53   '     54   &   $ 所属班次��69    .  55   9   �� *
WorkName+56   9     57   &   $ 所属工作班组��69    .  58   9   �� *ArrangeWorkNo+59   9   5;      5<      5=      5?      5@      5B      