   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5   
   )   #HRManagerClient.SystemUserManagerUI   5   
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
Horizontal=�6)   $	��Top=�5   )   {�5   )   �� *	CanModify+.+�5   "   4  .HRManagerClient.CustomControls.DBNavigationBar  $	��Top=�65      AddText$ 创建记录��5   5      
RemoveText$ 删除记录��5   5      AddItemCommand 5   5   �� *CreateItemCommand+   RemoveItemCommand 5   5   �� *RemoveItemCommand+   RefreshCommand 5   5   �� *RefreshCommand+	   SaveChangesCommand	 5   5   �� *UpdateItemCommand+�� 5   "   $��5q�6Q   ��6)   �� *CreateSubmitCommand+.��6\   创建完成6b   �� 5   "   $��5q�5   )   ��5   )   �� *ChangePasswordCommand+.��5   4   修改密码6:   5      &   System.Windows.Controls.DataGrid  5      -   5        
   AutoGenerateColumns
 .     CanUserAddRows .  ��5   '   �� *Model+ �� SelectedValue 5!   '   �� *SelectedItem+   Columns 5"   "   0  *System.Windows.Controls.DataGridTextColumn  5#   &   ,  &System.Windows.Controls.DataGridColumn   Header$ 	用户名��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5%   9   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5$   9   �� *
UserName+5%   9   4  .System.Windows.Controls.DataGridTemplateColumn  5&   &   $ 系统角色类型��6=   $	 150 5'   =      CellEditingTemplate 5(   *   �� 5)   .   .R�5*   2   ��  �� DisplayMemberPath$
 Name��5,   ;    �� SelectedItem 5*   ;   �� *
SystemRole+��5+   ;   �� *DataContext.SystemRoleItems+ �� RelativeSource �� *FindAncestor+ �� AncestorType)  #HRManagerClient.SystemUserManagerUI"  5,   V   5-   /      CellTemplate 5/   *   �� 50   .   .R�51   2   �� ��6<   �� *SystemRole.Name+6_   52   /   54   '     55   &   $ 创建时间��6=   $	 150 56   =      
IsReadOnly .  58   *   �� 59   .   .R�5:   2   5	 /HRManagerClient.CustomControls.MyDateTimePicker	   	  CustomFormat$ yyyy-MM-dd HH:mm��5;   F    	  Time 5:   F   �� *
CreateTime+ �� Mode$ TwoWay=�   StringToDateTimeConverter �� 	Converter# [  5;   F   5<   /    5>   *   �� 5?   .   .R�5@   2   �� ��6<   �� *
CreateTime+# [   �� StringFormat$ {0:yyyy-MM-dd HH:mm}��5A   /   5C   '     5D   &   $ 	创建人��69    .  5E   9   �� *	Creator+6U     5F   &   $ 启用状态��6=    5G   *   �� 5H   .   .R�5I   2   �� $��Center=�5J   ;    d� 	IsChecked 5I   ;   �� *
IsActive+5J   ;   5K   /    5M   *   �� 5N   .   .R�5O   2   �� {�.  $��Center=�5Q   ;    5O   ;   �� *
IsActive+5Q   ;   5R   /   5T   '   5V      5W      5X      5Z      5[      5]      