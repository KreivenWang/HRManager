   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5	   
   A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5
   
   -   'HRManagerClient.WorkArrangementDefineUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   /localclr-namespace:HRManagerClient     5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   ;cc,clr-namespace:HRManagerClient.CustomControls     5	   
   9utility%clr-namespace:HRManagerClient.Utility     5
   
   -   5        $
��root��5   
   ��5      �� 5   
     �� 
TargetType"  ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      4  .HRManagerClient.CustomControls.DBNavigationBar  $	��Top=�61      AddText$ 添加班次定义��5   1      
RemoveText$ 删除班次定义��5   1      AddItemCommand 5   1   �� *AddItemCommand+   RemoveItemCommand 5   1   �� *RemoveItemCommand+   RefreshCommand 5   1   �� *RefreshCommand+   SaveChangesCommand 5   1   �� *UpdateItemCommand+&   System.Windows.Controls.DataGrid  5      	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  ��6'   �� *Model+ �� SelectedItem 5   '   �� *SelectedItem+ � 	Resources 5   "   ��%�   '��       �� 5   &   "  ��6,   .�5   *   ��  � ��$ 6q�5   1   �� 5    *    � ��$ Center=�5!   1   5"   '   5#   #      Columns 5$   "   0  *System.Windows.Controls.DataGridTextColumn  5%   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 班次编码��69      SortMemberPath$ ArrangeWorkNoForSort��5&   9   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5'   *   �� 5(   .    �� Path$ ArrangeWorkNo�66    �� UpdateSourceTrigger$ PropertyChanged=�5)   6    �� ValidationRules 5*   2   *  $HRManagerClient.Utility.IntValidator  5+   6   5-   /   5/   '     50   &   $ 班次名称��69    51   9   �� *
WorkName+  52   &   $ 班次分组��69    53   9   �� *	WorkGroup+4  .System.Windows.Controls.DataGridTemplateColumn  54   &   $ 坐班类型��6=      CellEditingTemplate 55   *   �� 56   .   .R�57   2   ��  �� SelectedValuePath$ SelectedValue��59   ;    �� DisplayMemberPath$ DisplayMember��5:   ;    �� SelectedValue 57   ;   �� *
SpanType+��58   ;   �� *DataContext.SpanTypeItems+ �� RelativeSource �� *FindAncestor+ �� AncestorType-  'HRManagerClient.WorkArrangementDefineUI"  5:   _   5;   /      CellTemplate 5=   *   �� 5>   .   .R�5?   2   �� ��6<   �� *
SpanType+   LocalizationConverter �� 	Converter# [  6�   5@   /   5B   '     5C   &   $ 上班正点��6=    5D   *   �� 5E   .   .R�5F   2   5	 /HRManagerClient.CustomControls.MyDateTimePicker	   	  Time 6F   �� *
OnDutyTime+ �� Mode$ TwoWay=�  StringToDateTimeConverter# [ 5G   /    5I   *   �� 5J   .   .R�5K   2   �� ��6<   �� *
OnDutyTime+# [  �� StringFormat$ 	{0:HH:mm}��5L   /   5N   '     5g   &   $ 下班正点��6=    5h   *   �� 5i   .   .R�5j   2   	   6F   �� *OffDutyTime+$ TwoWay=�# [ 5k   /    5m   *   �� 5n   .   .R�5o   2   �� ��6<   �� *OffDutyTime+# [ $ 	{0:HH:mm}��5p   /   5r   '     5   &   $ 允许加班��6=    5�   *   �� 5�   .   .R�5�   2   �� $��Center=�5�   ;    d� 	IsChecked 5�   ;   �� *AllowOverWork+5�   ;   5�   /    5�   *   �� 5�   .   .R�5�   2   �� {�.  $��Center=�5�   ;    5�   ;   �� *AllowOverWork+5�   ;   5�   /   5�   '     5�   &   $ 加班开始时间��6=    5�   *   �� 5�   .   .R�5�   2   	   6F   �� *OverWorkBeginTime+$ TwoWay=�# [ 5�   /    5�   *   �� 5�   .   .R�5�   2   �� ��6<   �� *OverWorkBeginTime+# [ $ 	{0:HH:mm}��5�   /   5�   '     5�   &   $ 默认班次��6=    5�   *   �� 5�   .   .R�5�   2   �� $��Center=�5�   ;    5�   ;   �� *DefaultArrange+5�   ;   5�   /    5�   *   �� 5�   .   .R�5�   2   �� {�.  $��Center=�5�   ;    5�   ;   �� *DefaultArrange+5�   ;   5�   /   5�   '   5�      5�      5�      5�      5�      5�      