   M S B A M L   `   `   `  ���� J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity /   )HRManagerClient.VacationSolutionManagerUI   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     /localclr-namespace:HRManagerClient     6util%clr-namespace:HRManagerClient.Utility     ;cc,clr-namespace:HRManagerClient.CustomControls     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     -   $
��root��  � 	Resources   �� 
TargetType �� Property �� Value �� BasedOn1 +HRManagerClient.Utility.YearToDateConverter   YearToDateConverter  LockNavigateCalendarItem5  /System.Windows.Controls.Primitives.CalendarItem �� 
TargetType � 	Resources J� Opacity �Name  Key	 �� Color'  !System.Windows.VisualStateManager
   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration	 W� To �� TargetProperty �� 
TargetName � Cursor	 �� To ��Name � ColumnDefinitions � RowDefinitions  AccentColorBrush ��Name �� Stretch J� IsHitTestVisible ��Name �� RadiusY �� RadiusX �� Triggers P� Property P� Value �� 
TargetName  �� Value! �� Binding" �� RelativeSource# �� AncestorLevel$ �� AncestorType&   System.Windows.Controls.Calendar ! HideInactiveCalendarDayButton:  4System.Windows.Controls.Primitives.CalendarDayButton% ��Name��%�  '��       '�� %     '�� J     7��'�� �     7��'�� �     7��'�� .    &	  P    &	 U    7  &	 "    7 7  '  P    7 7  7  �� " ��.���  � ��$
 Auto ��� " ��.���  � ��$
 Auto ��� " ��8   .���  �@��TextAlignment$ Right=���  � ��$ Center=���  � ��$ 5q��� " ��8   .���  � ��$	 200����  � ��$ 5q��� " ��8   .���  � ��$	 120����  � ��$ 5q��� " ��.���  � ��$ 5q�  �� "  .���  � ��$	 0,3q���  � �� �� "   ���� (��       **(CalendarItem.DayTitleTemplateResourceKey+).R��� $
��Bold"�
����� �$��12(�$��Center=�$��Center=�$��0,6,0,6q�$	 0.8Q����� .R�� $ 	PART_Root��  ���� Ð $	 	#A5FFFFFF��
   CommonStates��.   
Normal��  Disabled��. �� .��W� $ 0D�$ 1X�$ Opacity�$ PART_DisabledVisual��.+��� #��z��#��z��#��z��._��   ���� Ñ " ��.R�� $
 Hand��
   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$ 	#FFC5C5BBX�$6 0(TextElement.Foreground).(SolidColorBrush.Color)�$ buttonContent��  Disabled��. �� .��W� $ 0D�$	 0.5X�$ Opacity�$ buttonContent��.+��� $ buttonContent��#��z��#��z��#��z��$��1,4,1,9q�#��z������ #	 � �� �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��3��8��  $��2q��� $ PART_PreviousButton��$��0��|�.  $
��Left=�$��15��$��8,0,0,0q�$��0��$��20��$y�Hidden=�.��� .+�F� "�����5���Ѱ�5h�W��<�h�	#��� ��$��Center=�$��10��$
 Fill=�$��Center=�$��6���� $ PART_HeaderButton�� .  $��1��$��0 4 0 0q�$
��Bold"�|�.  $��14(�$��Center=�$��0��$��Center=�$��Center=����� " ��.R�� $
 Hand��
   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$ 	#FFC5C5BBX�$6 0(TextElement.Foreground).(SolidColorBrush.Color)�$ buttonContent��  Disabled��. �� .��W� $ 0D�$	 0.5X�$ Opacity�$ buttonContent��.+��� $ buttonContent��#��z��#��z��#��z��$��1,4,1,9q�#��z������ $	 AntiqueWhite���� $ PART_NextButton��$��2��|�.  $��Right=�$��15��$��0,0,8,0q�$��0��$��20��$y�Hidden=�.��� .+�F� "����xT��!��xT���S�h4 	#��� ��$��Center=�$��10��$
 Fill=�$��Center=�$��6��� $ PART_MonthView��$��3��$��Center=�$��6,-1,6,6q�$��1��$y�Visible=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �� $ PART_YearView��$��3��$��Center=�$��6,-3,7,6q�$��1��$y�Hidden=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $ PART_DisabledVisual�����	#A5FFFFFF$ 0Q�$ 2��$ 2��$
 Fill=����	#A5FFFFFF$��1��$y�	Collapsed=� P�  � {� .  . ��� $ PART_DisabledVisual�� � y�$ Visible=��� $
  Year��! �� *DisplayMode+" �� *FindAncestor+$# 1��"$  .a��� $ PART_MonthView�� � y�$ Hidden=��� $ PART_YearView�� � y�$ Visible=��� $  Decade��! �� *DisplayMode+" �� *FindAncestor+$# 1��"$  .a��� $ PART_MonthView�� � y�$ Hidden=��� $ PART_YearView�� � y�$ Visible=��� "  8   .���  � ��$ 25����  � ��$ 5����  � ��$ Center=���  � ��$ Center=���  � ��
 ���� ��  � ��
 �   ���  � ��$ 0q���  � ��$ 14(���  � �� .  ��  � �� �� "  .R�� $
 Grid��#��z��.+��� $% Bg��#��z���� $ 
NormalText��#��z��$��5,2,5,2q�#��z��#��z�� P�  �@ 
IsSelected . . ���  � ��
 ��� ���  � ��
 �����P�  �@ IsToday . . ��� 8   � ����  � ��
 �����P�  �@J�IsMouseOver . . ���  � ��
 ���H���  � ��
 �����P�  �@ IsBlackedOut . . ��� $
 Grid�� �@J�Opacity$	 0.5Q�P�  �@ 
IsInactive . . ��� $
 Grid�� � y�$ Hidden=�P�  � {� .  . ��� $
 Grid�� �@J�Opacity$	 0.5Q��� "  8   .���  � ��$
 20 5q���  �@ CalendarItemStyle8  ��  �@ CalendarDayButtonStyle8  ��  �@ SelectionMode$ MultipleRange=���  �@ FirstDayOfWeek$ Monday=���  �@ DisplayMode$ Month=����� " ��.���  � �� �� .R�]� .+�]� $��Right=�y��� & �� Mode$& OneWay=� ! HasValueToVisibilityConverter' �� 	Converter#' [ ( � DataContext( �� *SelectedVSln+.+��� $	��Top=�) �� Orientation$) 
Horizontal=�.+��� $��方案名称:���� ���� *Model.PlanName+�� $��年份:���� * �� SelectedItem* �� *Year+���� *DataContext.YearsSelections++ �� ElementName$
+ root���� $��公用方案:���� , d� 	IsChecked, �� *Model.IsPublicPlan+�� $��备注:���� ���� *Model.Remark+�� $��5q����� *DataContext.SaveCommand+$
+ root��.��保存�� $��5q�
������$	��Top=��� $	��Top=�$) 
Horizontal=�.+�)   #MahApps.Metro.Controls.ToggleSwitch  -   OnLabel$- 选中周六��.   OffLabel$. 选中周六��$��5q�/   ThumbIndicatorBrush
/ ���H�0   	IsChecked0 �� *IsAllSaturdaySelected+  $- 选中周日��$. 选中周日��$��5q�
/ ���H�0 �� *IsAllSundaySelected+�� $	��Top=�$_��Y法定节假日选择: (在日期上 [按住Ctrl] 或 [按住鼠标左键拖动] 多选 )��$��18(�$
��Left=��� .��� $��calendarGrid��  ��%�   '��       �� " ��.���  � �� �	#3300AA55��  � ��
 �/�����  � ��$ 1q���  � ��$	 150����  � ��$ 20����  � ��$ Right=���  � ��$ 	0 30 30 0q���  �@J�IsHitTestVisible .   �� �� ��  �� �� �� �� .+�� $��0��$��0��.+�  -   
1 � Tag$1 1��2   DisplayDate2 �� *
Model.Year+$& OneWay=�   VaccationYearToDateConverter#' [ 3 �� ConverterParameter$3 1���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��1��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��0��$��1��.+�  -   $1 2��2 �� *
Model.Year+$& OneWay=�#' [ $3 2���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��2��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��0��$��2��.+�  -   $1 3��2 �� *
Model.Year+$& OneWay=�#' [ $3 3���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��3��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��0��$��3��.+�  -   $1 4��2 �� *
Model.Year+$& OneWay=�#' [ $3 4���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��4��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��1��$��0��.+�  -   $1 5��2 �� *
Model.Year+$& OneWay=�#' [ $3 5���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��5��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��1��$��1��.+�  -   $1 6��2 �� *
Model.Year+$& OneWay=�#' [ $3 6���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��6��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��1��$��2��.+�  -   $1 7��2 �� *
Model.Year+$& OneWay=�#' [ $3 7���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��7��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��1��$��3��.+�  -	   $1 8��2 �� *
Model.Year+$& OneWay=�#' [ $3 8���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��8��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��2��$��0��.+�  -
   $1 9��2 �� *
Model.Year+$& OneWay=�#' [ $3 9���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��9��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��2��$��1��.+�  -   $1 10��2 �� *
Model.Year+$& OneWay=�#' [ $3 10���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��10��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��2��$��2��.+�  -   $1 11��2 �� *
Model.Year+$& OneWay=�#' [ $3 11���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��11��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root��� $��2��$��3��.+�  -   $1 12��2 �� *
Model.Year+$& OneWay=�#' [ $3 12���� $��	0 30 30 0q�y��� *AllSundaySelectedVisibility+�� $��	0 30 54 0q�y��� *AllSaturdaySelectedVisibility+�� $��12��$��清除��$��24 12q�$��Right=�$	��Top=����� *$"DataContext.ClearSelectionsCommand+$
+ root���� $��2��
����� �$��Right=�$	��5 0q�]� .+�4	  .HRManagerClient.CustomControls.DBNavigationBar	  $	��Top=�4 	  AddText$4 添加假期方案��5 	  
RemoveText$5 删除假期方案��6 	  AddItemCommand6 �� *AddItemCommand+7 	  RemoveItemCommand7 �� *RemoveItemCommand+&
   System.Windows.Controls.DataGrid
  8 
  AutoGenerateColumns8 .  9 
  CanUserAddRows9 .  ���� *Model+* �� *SelectedItem+: 
  Columns: 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn;   
IsReadOnly; . <   Header$< 方案名称��=   Width5  /System.Windows.Controls.DataGridLengthConverter$	= 180 1  +System.Windows.Controls.DataGridBoundColumn>   Binding> �� *
PlanName+$& OneWay=�  ; . $< 年份��> �� *Year+4  .System.Windows.Controls.DataGridCheckBoxColumn    MetroDataGridCheckBox?   ElementStyle#? �  @   EditingElementStyle#@ �  $< 公用方案��; . > �� *IsPublicPlan+  $< 备注��$	= 100 ; . > �� *Remark+$& OneWay=�