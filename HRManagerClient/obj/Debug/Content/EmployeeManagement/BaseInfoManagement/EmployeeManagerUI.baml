   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   '   !HRManagerClient.EmployeeManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   /localclr-namespace:HRManagerClient     5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   ��5      �� 5	   
     �� 
TargetType"  ��6   .�5
      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      �� $	��Top=�6)    �� Orientation$ 
Horizontal=�5   )   .+�5   "   �� $��添加员工��5   )   $��5q�5   )   ��5   )   �� *AddItemCommand+5   )   �� 5   "   $��删除员工��5   )   $��5q�5   )   ��5   )   �� *RemoveItemCommand+5   )   �� 5   "   $��刷新��5   )   $��5q�5   )   ��5   )   �� *RefreshCommand+5   )   5      9� 5      $	��Top=�6'   $��筛选条件��5   '   $��0q�5   '   .��5   "   � 
������� � 	Resources 5   &    �� BasedOn(  "System.Windows.Controls.DatePicker��%N  '��       '�� �     7��'�� )    7��'  �    7 �� 5   *   "  ��60   .�5    .   ��  �@��TextAlignment$ Right=�5!   5   �� 5"   .    � ��$ Center=�5#   5   �� 5$   .    � ��$ 5q�5%   5   5&   +   �� 5'   *   "  ��60   8   .�5)   .   ��  � ��$	 150��5*   5   �� 5+   .    � ��$ 5q�5,   5   5-   +   �� 5.   *   "  ��60   8   .�50   .   ��  � ��$ 70��51   5   �� 52   .    � ��$ 5q�53   5   54   +   �� 55   *   "   60   8   .�57   .   ��  � ��$	 100��58   5   �� 59   .    � ��$ 5q�5:   5   5;   +   5<   '   .+�5=   &   �� $��姓名:��60   �� 5>   &   ��6.   �� *NameFilterText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5?   &   $��工号:��60   �� 5@   &   ��6.   �� *WorkNumFilterText+$ PropertyChanged=��� 5A   &   $��电话:��60   �� 5B   &   ��6.   �� *PhoneFilterText+$ PropertyChanged=��� 5C   &   $��
现住址:��60   �� 5D   &   ��6.   �� *CurSiteFilterText+$ PropertyChanged=��� 5E   &   $��部门:��60   �� 5F   &    �� Text 6/   �� *WorkNumFilterText+$ PropertyChanged=��� 5G   &   $��岗位:��60   �� 5H   &    6/   �� *WorkNumFilterText+$ PropertyChanged=��� 5J   &   
�������$��1q�5K   -   $��2q�5L   -   ._�5M   *   �� $ 
Horizontal=�65   .+�5N   .   �� $��性别:��68   	� 5O   .   $��全部��5P   :    	� 	GroupName$ sexGroup��5Q   :   $��5 0 5 3q�5R   :   	 d� 	IsChecked	 5O   :   �� *	SexFilter+   EnumBooleanConverter
 �� 	Converter#
 [    HRModel.SexEnum   Unknown �� ConverterParameter# Z 5R   :   	� 5S   .   $	��男��5T   6   $ sexGroup��5U   6   $��5 0 5 3q�5V   6   	 5S   :   �� *	SexFilter+#
 [     Male# Z 5V   6   	� 5W   .   $	��女��5X   :   $ sexGroup��5Y   :   $��5 0 5 3q�5Z   :   	 5W   :   �� *	SexFilter+#
 [     Female# Z 5Z   :   5[   +   5\   '   �� 5]   &   
�������$��1q�5^   -   $��2q�5_   -   ._�5`   &   �� $ 
Horizontal=�61   .+�5a   .   �� $��状态:��68   	� 5b   .   $��全部��5c   6   $ epStatus��5d   :   $��5 0 5 3q�5e   :   	 5b   :   �� *JobStateFilter+#
 [    HRModel.JobStatusEnum   Other# Z 5e   :   	� 5f   *   $��在职��5g   6   $ epStatus��5h   :   $��5 0 5 3q�5i   :   	 5f   6   �� *JobStateFilter+#
 [     OnJob# Z 5i   :   	� 5j   *   $��离职��5k   6   $ epStatus��5l   :   $��5 0 5 3q�5m   :   	 5j   6   �� *JobStateFilter+#
 [     Resigned# Z 5m   :   5n   '   5o   '   �� 5p   &   $ 
Horizontal=�61   .+�5q   *   �� $��入职时间:��64     5r   *      SelectedDate 65   �� *HireDateStartFilter+$ PropertyChanged=� �� StringFormat$ {0:yyyy-MM-dd}���� 5s   *   $	��至��64     5t   *    65   �� *HireDateEndFilter+$ PropertyChanged=�$ {0:yyyy-MM-dd}��5u   '   �� 5v   &   $��清除所有条件��5w   -   $��5q�6>   ��5v   -   �� *ClearFilterCommand+5w   >   5x   #   5y      &   System.Windows.Controls.DataGrid  5z         AutoGenerateColumns .     CanUserAddRows .  ��6'   �� *FiltedItems+ �� SelectedValue 5�   '   �� *SelectedItem+.  (System.Windows.Interactivity.Interaction   Triggers 5�   "   /  )System.Windows.Interactivity.EventTrigger  5�   &      	EventName$ MouseDoubleClick��65   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   *   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6@   �� *ShowEmployeeDetailCommand+5�   '      Columns 5�   "   0	  *System.Windows.Controls.DataGridTextColumn	  5�   &   ,
  &System.Windows.Controls.DataGridColumn 
  Header$ 姓名��69    
  Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 5�   9    
  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   9   �� *EmployeeBaseInfo.EmployName+5�   9   	  5�   &   $ 工号��69   $ 75 5�   9    .  5�   9   �� *
EmployeeNO+5�   9   	  5�   &   $ 部门��69   $	 100 5�   9    .  5�   9   �� *Department.DepartName+  �� Mode$  TwoWay=�5�   9   	  5�   &   $ 岗位��69   $	 100 5�   9    .  5�   9   �� *!OperatingPost.OperatingPostName+5�   9   	  5�   &   $ 性别��69   $	 100 5�   9    .  5�   9   �� *EmployeeBaseInfo.Sex+  EnumChStringConverter#
 [ 5�   9   	  5�   &   $ 生日��69   $	 100 5�   9    .  5�   9   �� *EmployeeBaseInfo.Birthday+$ {0:yyyy-MM-dd}��  StringToDateTimeConverter#
 [ 5�   9   	  5�   &   $ 入职时间��69   $	 100 5�   9    .  5�   9   �� *
HireDate+$ {0:yyyy-MM-dd}��#
 [ 5�   9   	  5�   &   $ 联系电话��69   $	 100 5�   9    .  5�   9   �� *EmployeeBaseInfo.Phone+5�   9   	  5�   &   $ 	现住址��69   $	 100 5�   9    .  5�   9   �� *EmployeeBaseInfo.CurSite+5�   9   	  5�   &   $ 人员状态��69   $	 100 5�   9    .  5�   9   �� *State+#
 [ 5�   9   	  5�   &   $ 备注��69   $	 100 5�   9    .  5�   9   �� *EmployeeBaseInfo.Remark+5�   9   5�      5�      5�      5�      5�      5�      