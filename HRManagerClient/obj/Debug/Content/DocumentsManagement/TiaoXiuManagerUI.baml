   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   d `GalaSoft.MvvmLight.Extras, Version=5.3.0.19026, Culture=neutral, PublicKeyToken=f46ff315b1088208jKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.ExtrasGalaSoft.MvvmLight.Command 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5	   
   A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5
   
   &    HRManagerClient.TiaoXiuManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	    5   
   /localclr-namespace:HRManagerClient 	    5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel 	    5   
   [cmdKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras 	    5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 	    5   
   ;cc,clr-namespace:HRManagerClient.CustomControls 	    5	   
   9utility%clr-namespace:HRManagerClient.Utility 	    5
   
   -   5        $
��root��5   
     � 	Resources  5      + %HRManagerClient.ExpireRemindConverter   ExpireRemindConverter��%   &	          5   
   6&   5      ��5      �� 5   
    �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      4  .HRManagerClient.CustomControls.DBNavigationBar     AddText$ 添加调休记录��5   1      
RemoveText$ 删除调休记录��5   1   $	��Top=�5   1      RefreshCommand 5   1   �� *RefreshCommand+   SaveChangesCommand 5   1   �� *UpdateItemCommand+   AddItemCommand 5   1   �� *AddItemCommand+	   RemoveItemCommand	 5   1   �� *RemoveItemCommand+5   1   &   System.Windows.Controls.DataGrid  5      
   AutoGenerateColumns
 .     CanUserDeleteRows .     CanUserAddRows .  ��6'   �� *Model+ �� SelectedValue 5    '   �� *SelectedItem+   Columns 5!   "   0  *System.Windows.Controls.DataGridTextColumn  5"   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 调休单号��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 5#   9      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5$   9   �� *	TiaoXiuNo+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5b   &   $ 人员��6=      MinWidth$	 150Q�5c   =    .    CellEditingTemplate 5e   *   �� 5f   .   .R�5g   2   � .+�5h   6   �� $��5q�6>   *	   $MahApps.Metro.Controls.TextBoxHelper 	  	Watermark$ 请选择人员��5i   >    �� 
IsReadOnly . .��5j   P   ��5k   :   `� 5l   >    �� StringFormat$ [{0}]{1}��6K   .1�5m   B   ��  �� Path$ Employee.EmployeeNO�6J   �� 5n   B   $* $Employee.EmployeeBaseInfo.EmployName�6J   5o   ?   .��5p   H   5q   7   ]� 5r   6   ��.  $��0 5 5 5q�5s   @   .+�5t   :   �� $	��...��6A   $��Right=�5u   A   $��Right=�5w   A   ��5v   A   �� *DataContext.SelectEpCommand+ �� ElementName$
 root��5w   A   �� 5x   :   $	�� x ��6A   $��Right=�5y   A   $��Right=�5{   A   ��5z   A   �� *DataContext.ClearEpCommand+$
 root��5{   A   5|   7   5}   3   5~   /      CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6<   ��5�   6   `� 5�   :   $ [{0}]{1}��6G   .1�5�   >   �� $ Employee.EmployeeNO�6F   �� 5�   >   $* $Employee.EmployeeBaseInfo.EmployName�6F   5�   ;   5�   3   5�   /   5�   '     5�   &   $ 调休时间��6=   $	 150 5�   =    .  5�   *   �� 5�   .   .R�5�   2   5
 /HRManagerClient.CustomControls.MyDateTimePicker
   
  CustomFormat$ yyyy-MM-dd HH:mm��5�   F    
  Time 5�   F   �� *CurStartDateTimeStr+ �� Mode$ TwoWay=�  StringToDateTimeConverter �� 	Converter# [ 5�   F   5�   /    5�   *   �� 5�   .   .R�5�   2   �� ��6<   �� *CurStartDateTimeStr+$ {0:yyyy-MM-dd HH:mm}��# [ 5�   /   5�   '     5�   &   $ 被调时间��6=   $	 150 5�   =    .  5�   *   �� 5�   .   .R�5�   2   
  $ yyyy-MM-dd HH:mm��5�   F    5�   F   �� *TiaoXiuStartDateTimeStr+$ TwoWay=�# [ 5�   F   5�   /    5�   *   �� 5�   .   .R�5�   2   �� ��6<   �� *TiaoXiuStartDateTimeStr+$ {0:yyyy-MM-dd HH:mm}��# [ 5�   /   5�   '     5�   &   $ 是否只调休半天��6=   $	 150 5�   =    .  5�   *   �� 5�   .   .R�5�   2   �� {�.   d� 	IsChecked 6;   �� *	IsHalfDay+5�   ;   5�   /   5�   '     5�   &   $ 调休原因��69   $	 100 5�   9    .  5�   9   �� *Reason+5�   9   5�      5�      5�      5�      5�      5�      