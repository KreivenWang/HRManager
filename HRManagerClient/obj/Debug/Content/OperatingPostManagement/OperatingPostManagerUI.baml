   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5   
   ,   &HRManagerClient.OperatingPostManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   /localclr-namespace:HRManagerClient     5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   9utility%clr-namespace:HRManagerClient.Utility     5   
   -   5        $
��root��5	   
   ��5
      �� 5   
     �� 
TargetType"  ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      �� $	��Top=�6)    �� Orientation$ 
Horizontal=�5   )   .+�5   "   �� $��添加岗位��5   )   $��5q�5   )   ��5   )   �� *AddItemCommand+5   )   �� 5   "   $��删除岗位��5   )   $��5q�5   )   ��5   )   �� *RemoveItemCommand+5   )   �� 5   "   $��保存修改��5   )   $��5q�5   )   ��5   )   �� *UpdateItemCommand+5   )   �� 5   "   $��刷新��5   )   $��5q�5   )   ��5   )   �� *RefreshCommand+5   )   5      &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .     CanUserAddRows .  ��6'   �� *Model+ �� SelectedValue 5%   '   �� *SelectedItem+   Columns 5'   "   0  *System.Windows.Controls.DataGridTextColumn  5(   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 岗位编号��69   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 150 5)   9   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5*   *   �� 5+   .    �� Path$ OperatingPostNo�66    �� UpdateSourceTrigger$ PropertyChanged=�6M    �� ValidationRules 5,   2   *  $HRManagerClient.Utility.IntValidator  5-   6   5/   /   51   '     53   &   $ 岗位名称��69   $		 150 54   9   
 55   9   �� *OperatingPostName+4  .System.Windows.Controls.DataGridTemplateColumn  56   &   $ 岗位隶属部门��6=      MinWidth$	 150Q�6M      CellEditingTemplate 57   *   �� 58   .   .R�59   2   ]� .+�5:   6   �� $��选择部门��6=   $	��5 0q�5=   =   ��5;   =   �� *DataContext.DpSelectCommand+ �� RelativeSource �� *FindAncestor+ �� AncestorType,  &HRManagerClient.OperatingPostManagerUI"  ��5<   =   �� 5=   =   �� 5>   6   $��清除已选��6=   $	��5 0q�5A   =   ��5?   =   �� *$"DataContext.ClearSelectedDpCommand+ �� *FindAncestor+"  ��5@   =   �� 5A   =   5B   3   5C   /      CellTemplate 5E   *   �� 5F   .   .R�5G   2   �� ��6<   �� *Department.DepartName+5H   /   5J   '     5K   &   $ 岗位员工数量��69   $		 150 5L   9      
IsReadOnly . 
 5M   9   �� *Employees.Count+5N   9   5P      5Q      5R      5T      5U      5W      