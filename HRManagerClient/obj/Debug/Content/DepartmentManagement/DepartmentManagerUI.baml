   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   d `GalaSoft.MvvmLight.Extras, Version=5.3.0.19026, Culture=neutral, PublicKeyToken=f46ff315b1088208jKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.ExtrasGalaSoft.MvvmLight.Command 5   
   )   #HRManagerClient.DepartmentManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro 	    5   
   /localclr-namespace:HRManagerClient 	    5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel 	    5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 	    5   
   [cmdKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras 	    5   
   -   5        $
��root��5	   
     � 	Resources  5
       �� MergedDictionaries �� Source �� DataType)  #HRManagerClient.DepartmentViewModel �� ItemsSource   SelectedTVItemBorder �� Color  SelectedTVItemFill  TVItemBorder  
TVItemFill  hiTreeviewitem �� 
TargetType �� Property  
CommonFont �� Value	 �� 
TargetType
 � RowDefinitions �� CornerRadius ��Name J� SnapsToDevicePixels �� Orientation K� IsItemsHost �� Triggers P� Property P� Value �� 
TargetName�� 5   
    5      �� 5      $ DepartmentProperty.xaml?�6%   %�  (��       5   '   *, +)&	  �     &	 �     &	     &	 1    &	 [    7  7  7  7  7  7   �� 5      "  5   '    5   '   �� *ChildrenDpvms+.R�5      �� $��Center=�5      $��18(�5      ��5      �� *Model.DepartName+5      5      �� 5      $ Wheat��5      �� 5      $ MediumAquamarine��5      �� 5      $ MediumAquamarine��5      �� 5      $ AntiqueWhite��5      �� 5      " Q�5      .�5      ��  � ��8   5    ?   �� 5!       � �� 5"      �� 5#      "	 Q�6*   .R�5$      � $��Center=�6#   
 5%   "   �� 5&   &   $
��Auto �64   �� 5'   &   $
��Auto �64   �� 5(   &   $��* �64   .+�5*   "   �� $��Center=�6,   $��20��5+   ,   $��2��5,   ,   
������ 8�� $��1��5/   ,   �� 50   "   $��Bd��6)   $��1��51   )   8�� 8�� $��1q�54   )   $ 3��55   )   $	��6 2q�56   )   ._�57   &   �� $ PART_Header��67   $��1��58   7   #��z��59   7   #��z��5:   7   $��Header��5;   7   # z 5<   7   $��5q�5=   7   5>   #   �� 5?   "   $��2��6-   $��Center=�5@   -   $ 
Horizontal=�5A   -    . 5B   -   5C       5D      P� 5E   "    �@Q�
IsSelected . . �5G   &   �� $ Bd��6-   8   � ��5I   -   �� 5J   &   $ Bd��6-   8   � ��5L   -   �� 5M   &   $ Bd��6-    � ��
 �����5O   -   5P   #   P� 5Q   "    �@J�IsMouseOver . . �5S   &   �� $ Bd��5T   -    � ��
 �   �5U   -   5V   #   5X      5Z      5[      5\      ��5^      �� 5_   
   " ��6   .�5`      ��  � �� 5a      �� 5b      .R�5c      ]� .+�5d      ]� $��Right=�6(   ��.  .+�5f   "   �� $	��Top=�6)   $��5q�5g   )   ��5h   )   �� *SaveChangesCommand+.��6P   保存修改6V   )   #MahApps.Metro.Controls.ToggleSwitch  5i   "      OnLabel$	 是��68      OffLabel$	 否��5j   8   $	��Top=�5k   8      Header$ 启用编辑��5m   8   $��5q�5n   8      ThumbIndicatorBrush
 ��� �   	IsChecked 5l   8   �� *	IsEditing+5n   C   �� 5o   "   $��2q�6)   $ 3��5r   )   $	��Top=�5s   )   $��5q�5t   )   ��5p   )   �� *EditBackgroundColor+��5q   )   �� *EditBorderColor+._�5u   &   ��   DpPropTemplate#��[ 65   ��5v   5   �� *
SelectedDp+{�5w   5   �� *	IsEditing+5x   #   5y      R� 5z      $
��Left=�6'     5{   "    �� BasedOn��%�   'Q�       7Q��� 5|   &   " Q�6,   8   .�5~   *   ��  �@Q�
IsExpanded . 5   1   �� 5�   *    � ��$ 10q�5�   1   5�   '   5�   #   .@�5�   "   Q� $��部门信息��6/   $��14(�5�   /   
����� � �� TextAlignment$ Center=�5�   /   ��5�   /   �� *TopDepartmentVMs+5�   #   5�      (� 5�      .��5�   "   � $	��600��6'   $	��500��66   .+�5�   &   R� $��2q�5�   /   ��5�   /   �� *EditBackgroundColor+��5�   /   �� *EditBorderColor+.@�5�   *   Q� -   5        $��部门信息��5�   7   $��18(�5�   7   
����� �$ Center=�5�   7    J� 	AllowDrop . ��5�   7   �� *TopDepartmentVMs+
 � Tag 5�   7   �� *AddNewTopDpCommand+��5�   .   �� 5�   2   " Q�68   .�5�   6   ��  � �� 5�   :   �� 5�   >   "	 Q�6N   .R�5�   B   � $��Center=�6G   
 5�   F   �� 5�   J   $
��Auto �6X   �� 5�   J   $
��Auto �6X   �� 5�   J   $��* �6X   .+�5�   F   �� $��Bd��6M   $��1��5�   M   #��[ 5�   M   #��[ 5�   M   $��2q�5�   M   $ 15��5�   M   $	��6 2q�5�   M   ._�5�   J   �� $ PART_Header��6[   $��1��5�   [   #��z��5�   [   #��z��5�   [   $��Header��5�   [   # z 5�   [   $
��25 5q�5�   [   5�   G   �� 5�   F   $��2��6Q   $��Center=�5�   Q   $ 
Horizontal=�5�   Q    . 5�   Q   5�   C    5�   B   P� 5�   F    �@Q�
IsSelected . . �5�   J   �� $ Bd��6Q   # [ 5�   Q    � ���� 5�   J   $ Bd��6Q   # [  5�   Q    � ���� 5�   J   $ Bd��6Q    � ��
 �����5�   Q   5�   G   5�   ?   5�   7   5�   3    � ContextMenu 5�   .   �� 5�   2   .@�5�   6   m� $��添加部门��6?    m� Command 5�   ?   �� *PlacementTarget.Tag+ �� RelativeSource �� *FindAncestor+  �� AncestorType$  ContextMenuL�5�   3   ��5�   .   �� 5�   2   " Q�68   # [ 5�   8   .�5�   6   ��  �@�Tag 5�   =   �� *DataContext+! �� ElementName$
! root���� 5�   6    �@�ContextMenu 5�   :   �� 5�   >   .@�5�   B   m� $��添加子部门��6K    5�   K   �� *(&PlacementTarget.Tag.AddNewSubDpCommand+ �� *FindAncestor+$  ContextMenuL�m� 5�   B   $&�� 移除部门(子部门将置顶)��6K    5�   K   �� *%#PlacementTarget.Tag.RemoveDpCommand+ �� *FindAncestor+$  ContextMenuL�5�   ?   5�   7   5�   3   5�   +   .  (System.Windows.Interactivity.Interaction"   Triggers" 5�   *   /  )System.Windows.Interactivity.EventTrigger  5�   .   #   	EventName$# PreviewMouseDown��6=   .  (System.Windows.Interactivity.TriggerBase$   Actions.$ 5�   2   /  )GalaSoft.MvvmLight.Command.EventToCommand  %   PassEventArgsToCommand% . &   Command& 6E   �� *SelectTreeNodeCommand+5�   E   5�   /   5�   '   �� 5�   &   $��部门结构图��60   $��22(�5�   0   $��15q�5�   0   
����� �
������ ' J� IsHitTestVisible' .  5�   K   5�   #   5�      5�      5�      5�      5�      5�      