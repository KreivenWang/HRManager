   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   !   J FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   !   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   !   A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5   !   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   !   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5
   !   .   (HRManagerClient.CreateBusinessTripDialog   5   !   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   !   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   !   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   !   /localclr-namespace:HRManagerClient     5   !   6util%clr-namespace:HRManagerClient.Utility     5   !   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   !   @d2http://schemas.microsoft.com/expression/blend/2008     5   !   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   !   ;cc,clr-namespace:HRManagerClient.CustomControls     5
   !   # HRManagerClient.MainViewModel    MainWindowHandler � Owner# Z  5   !    � Title$ 创建出差单��5   !    � SizeToContent$ WidthAndHeight=�5   !    � 
ResizeMode$ CanResizeWithGrip=�5   !    � WindowStyle$ 
ToolWindow=�5   !    � WindowStartupLocation$ CenterOwner=�5   !      ToolbarDialogWindow#��[  5   !   (  "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� ��6   �� *SubmitCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��20��6    $��20��5       ��5       �� *
Foreground+	 �� RelativeSource	 �� 
 �� AncestorType"
 �� J� OpacityMask 5      !� 5       j� Stretch$
 Fill=�6*     appbar_save !� Visual# �  5   *   5      �� 5       $��4 0 0 0q�6    $��Center=�5!       $��提交��5"       5#      5$      5%       � 	Resources 5'       �� MergedDictionaries �� Source�� 5(   
    5)      �� 5*      $C =/HRManagerClient;component/ClientRes/DialogDefaultLayout.xaml?�6%   6n   %    5,      .��5.      � $��5q�6    � RowDefinitions 5/   
   �� 50      �� 51      �� 52      �� 53      �� 54      �� 55      �� 56       � ColumnDefinitions 58   
   �� 59      $
��Auto �6   �� 5:      �� 5;      $
��Auto �6   �� 5<      $
��Auto �6   �� 5=      �� 5>      $
��Auto �6   �� 5?      $
��Auto �6   .+�5A   
   �� $��单据编号��6   $��0��5B      $��0��5C      6&   �� 5D   
   $��单据标题��6   $��2��5E      $��0��5F      6&   �� 5J   
   $��开始时间��6   $��3��5K      $��0��5L      6&   �� 5P   
   $��出差原因��6   $��5��5Q      $��0��5R      6&   �� 5Y   
   $��结束时间��6   $��3��5Z      $��3��5[      6&   �� 5\   
   $��0��6   $��1��5]      ��5^      �� *ModelExample.BusinessTripNo+6A   �� 5d   
   $��2��6   $��1��5e      $��4��5f   B   ��6   �� * ModelExample.BusinessTripTitle+6X   5 /HRManagerClient.CustomControls.MyDateTimePicker  5y   
   $��3��6   $��1��5z         CustomFormat$ yyyy-MM-dd HH:mm��5|      $��5q�5}         Time 5{      �� *ModelExample.BeginDate+ �� Mode$ TwoWay=�  StringToDateTimeConverter �� 	Converter# [ 5}        5~   
   $��3��6   $��4��5      $ yyyy-MM-dd HH:mm��5�      $��5q�5�       5�      �� *ModelExample.EndDate+$ TwoWay=�# [ 5�      �� 5�   
   $��5��6   $��1��5�      $��4��5�      " �� VerticalScrollBarVisibility$ Visible=�5�       �� TextWrapping$
 Wrap=�5�       �� AcceptsReturn . $	��100��5�      ��5�      �� *ModelExample.Reason+69   �� 5�   
   $��	制单人��6   $��0��5�      $��3��5�      6&   �� 5�   
   $��0��6   $��4��5�       �� 
IsReadOnly . ��5�      �� *ModelExample.Creator+6:   �� 5�   
   $��*��6   $��Center=�5�      $��Center=�5�      
���  ��$��18(�5�      $��0q�5�      $��2��5�      $��5��5�      6&   �� 5�   
   $��*��6   $��Center=�5�      $��Center=�5�      
���  ��$��18(�5�      $��0q�5�      $��3��5�      $��2��5�      6&   �� 5�   
   $��*��6   $��Center=�5�      $��Center=�5�      
���  ��$��18(�5�      $��0q�5�      $��3��5�      $��5��5�      6&   �� 5�   
   $ 
Horizontal=�6   $��6��5�      .+�5�      �� ��6   �� *AddEmployeeCommand+.��6<   添加出差人员6D   �� 5�      $	��5 0q�6   ��5�      �� *RemoveEmployeeCommand+.��6?   删除出差人员6G   5�      �� 5�   
   $��5q�5�      $��1q�5�      $��6��5�      $��1��5�      $��6��5�      ��5�      �� *SelectedEmployees+ �� SelectedItem 5�      �� *
SelectedEp+ �� View 5�      �� 5�      .P�5�      �� $��工号��6%    �� Width$ 75��5�   %    �� DisplayMemberBinding 5�   %   �� *
EmployeeNO+5�   2   �� 5�      $��姓名��6%   $	 100��5�   %    �� CellTemplate 5�      �� 5�      .R�5�   "   �� ��6,   �� *EmployeeBaseInfo.EmployName+5�      5�      �� 5�      $��部门��6%    5�      �� 5�      .R�5�   "   �� ��6,   �� *Department.DepartName+5�      5�      �� 5�      $��岗位��6%    5�      �� 5�      .R�5�   "   �� ��6,   �� *!OperatingPost.OperatingPostName+5�      5�      5�      5�      5�      5�      