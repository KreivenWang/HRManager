   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   !   J FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   !   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   !   A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5   !   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   !   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5
   !   *   $HRManagerClient.CreateReSignInDialog   5   !   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   !   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   !   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   !   /localclr-namespace:HRManagerClient     5   !   6util%clr-namespace:HRManagerClient.Utility     5   !   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   !   @d2http://schemas.microsoft.com/expression/blend/2008     5   !   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   !   ;cc,clr-namespace:HRManagerClient.CustomControls     5
   !   # HRManagerClient.MainViewModel    MainWindowHandler � Owner# Z  5   !    � Title$ 创建补签单��5   !    � SizeToContent$ WidthAndHeight=�5   !    � 
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
��Auto �6   .+�5@   
   �� $��单据编号��6   $��0��5A      $��0��5B      6&   �� 5C   
   $��单据标题��6   $��2��5D      $��0��5E      6&   �� 5I   
   $��补签时间��6   $��3��5J      $��0��5K      6&   �� 5O   
   $��补签原因��6   $��3��5P      $��3��5Q      6&   �� 5U   
   $��补签类型��6   $��2��5V      $��3��5W      6&   �� 5[   
   $��0��6   $��1��5\      ��5]      �� *ModelExample.Number+69   �� 5c   
   $��2��6   $��1��5d      ��5e      �� *ModelExample.Title+68   �� 5t   
   $��2��6   $��4��5u       �� SelectedItem 5v      �� *ModelExample.ReSignInType+��5w      �� *ReSignInTypeItems+6?   5 /HRManagerClient.CustomControls.MyDateTimePicker  5x   
   $��3��6   $��1��5y         CustomFormat$ yyyy-MM-dd HH:mm��5{      $��5q�5|         Time 5z      �� *ModelExample.ReSignInDate+ �� Mode$ TwoWay=�  StringToDateTimeConverter �� 	Converter# [ 5|      �� 5�   
   $��3��6   $��4��5�       5�      �� *ModelExample.Reason+��5�      �� *ReSignInReasonTypeItems+6E   �� 5�   
   $��	制单人��6   $��0��5�      $��3��5�      6&   �� 5�   
   $��0��6   $��4��5�       �� 
IsReadOnly . ��5�      �� *ModelExample.Creator+6:   �� 5�   
   $��*��6   $��Center=�5�      $��Center=�5�      
���  ��$��18(�5�      $��0q�5�      $��2��5�      $��5��5�      6&   �� 5�   
   $��*��6   $��Center=�5�      $��Center=�5�      
���  ��$��18(�5�      $��0q�5�      $��3��5�      $��2��5�      6&   �� 5�   
   $��*��6   $��Center=�5�      $��Center=�5�      
���  ��$��18(�5�      $��0q�5�      $��3��5�      $��5��5�      6&   �� 5�   
   $ 
Horizontal=�6   $��0��5�      $��4��6%   $��5��62   .+�5�      �� ��6   �� *AddEmployeeCommand+.��6<   添加补签人员6D   �� 5�      $	��5 0q�6   ��5�      �� *RemoveEmployeeCommand+.��6?   删除补签人员6G   5�      �� 5�   
   $��5q�5�      $��1q�5�      $��0��5�      $��5��5�      $��5��5�      $��6��5�      $	��150��6$   ��5�      �� *SelectedEmployees+ 5�      �� *
SelectedEp+ �� View 5�      �� 5�      .P�5�      �� $��工号��6%    �� Width$ 75��5�   %    �� DisplayMemberBinding 5�   %   �� *
EmployeeNO+5�   2   �� 5�      $��姓名��6%   $	 100��5�   %    �� CellTemplate 5�      �� 5�      .R�5�   "   �� ��6,   �� *EmployeeBaseInfo.EmployName+5�      5�      �� 5�      $��部门��6%    5�      �� 5�      .R�5�   "   �� ��6,   �� *Department.DepartName+5�      5�      �� 5�      $��岗位��6%    5�      �� 5�      .R�5�   "   �� ��6,   �� *!OperatingPost.OperatingPostName+5�      5�      5�      5�      5�      5�      