   M S B A M L   `   `   `  ���� J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity d `GalaSoft.MvvmLight.Extras, Version=5.3.0.19026, Culture=neutral, PublicKeyToken=f46ff315b1088208jKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.ExtrasGalaSoft.MvvmLight.Command )   #HRManagerClient.DepartmentManagerUI   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	    /localclr-namespace:HRManagerClient 	    :hrmodel&clr-namespace:HRModel;assembly=HRModel 	    ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 	    [cmdKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras 	    -   $
��root��  � 	Resources   �� MergedDictionaries �� Source �� DataType)  #HRManagerClient.DepartmentViewModel �� ItemsSource   SelectedTVItemBorder �� Color  SelectedTVItemFill  TVItemBorder  
TVItemFill  hiTreeviewitem �� 
TargetType �� Property  
CommonFont �� Value	 �� 
TargetType
 � RowDefinitions �� CornerRadius ��Name J� SnapsToDevicePixels �� Orientation K� IsItemsHost �� Triggers P� Property P� Value �� 
TargetName��  �� $ DepartmentProperty.xaml?�%S  (��       *, +)&	  a     &	 r     &	 �     &	 �     &	 �     7  7  7  7  7  7   �� "   �� *ChildrenDpvms+.R��� $��Center=�$��18(����� *Model.DepartName+�� $ Wheat���� $ MediumAquamarine���� $ MediumAquamarine���� $ AntiqueWhite���� " Q�.���  � ��8   ��  � �� �� "	 Q�.R�� $��Center=�
 �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Center=�$��20��$��2��
������ 8�� $��1���� $��Bd��$��1��8�� 8�� $��1q�$ 3��$	��6 2q�._��� $ PART_Header��$��1��#��z��#��z��$��Header��# z $��5q��� $��2��$��Center=�$ 
Horizontal=� .  P�  �@Q�
IsSelected . . ��� $ Bd��8   � ���� $ Bd��8   � ���� $ Bd�� � ��
 �����P�  �@J�IsMouseOver . . ��� $ Bd�� � ��
 �   ����� " ��.���  � �� �� .R�]� .+�]� $��Right=���.  .+��� $	��Top=�$��5q����� *SaveChangesCommand+.��保存修改)   #MahApps.Metro.Controls.ToggleSwitch     OnLabel$	 是��   OffLabel$	 否��$	��Top=�   Header$ 启用编辑��$��5q�   ThumbIndicatorBrush
 ��� �   	IsChecked �� *	IsEditing+�� $��2q�$ 3��$	��Top=�$��5q����� *EditBackgroundColor+���� *EditBorderColor+._���   DpPropTemplate#��[ ���� *
SelectedDp+{��� *	IsEditing+R� $
��Left=�   �� BasedOn��%U   'Q�       7Q��� " Q�8   .���  �@Q�
IsExpanded . ��  � ��$ 10q�.@�Q� $��部门信息��$��14(�
����� � �� TextAlignment$ Center=����� *TopDepartmentVMs+(� .��� $	��600��$	��500��.+�R� $��2q����� *EditBackgroundColor+���� *EditBorderColor+.@�Q� -   $��部门信息��$��18(�
����� �$ Center=� J� 	AllowDrop . ���� *TopDepartmentVMs+
 � Tag �� *AddNewTopDpCommand+���� " Q�.���  � �� �� "	 Q�.R�� $��Center=�
 �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Bd��$��1��#��[ #��[ $��2q�$ 15��$	��6 2q�._��� $ PART_Header��$��1��#��z��#��z��$��Header��# z $
��25 5q��� $��2��$��Center=�$ 
Horizontal=� .  P�  �@Q�
IsSelected . . ��� $ Bd��# [  � ���� $ Bd��# [   � ���� $ Bd�� � ��
 ����� � ContextMenu �� .@�m� $��添加部门�� m� Command �� *PlacementTarget.Tag+ �� RelativeSource �� *FindAncestor+  �� AncestorType$  ContextMenuL����� " Q�# [ .���  �@�Tag �� *DataContext+! �� ElementName$
! root����  �@�ContextMenu �� .@�m� $��添加子部门�� �� *(&PlacementTarget.Tag.AddNewSubDpCommand+ �� *FindAncestor+$  ContextMenuL�m� $&�� 移除部门(子部门将置顶)�� �� *%#PlacementTarget.Tag.RemoveDpCommand+ �� *FindAncestor+$  ContextMenuL�.  (System.Windows.Interactivity.Interaction"   Triggers" /  )System.Windows.Interactivity.EventTrigger  #   	EventName$# PreviewMouseDown��.  (System.Windows.Interactivity.TriggerBase$   Actions.$ /  )GalaSoft.MvvmLight.Command.EventToCommand  %   PassEventArgsToCommand% . &   Command& �� *SelectTreeNodeCommand+�� $��部门结构图��$��22(�$��15q�
����� �
������ ' J� IsHitTestVisible' .  