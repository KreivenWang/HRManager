   M S B A M L   `   `   `  ����J  FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0894   .HRManagerClient.CustomControls.ZoomIconControl  �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation ��Name    	IconWidth    
IconHeight �� ElementName	 J� OpacityMask
 j� Stretch !� Visual �� RelativeSource �� Mode � LayoutTransform J� RenderTransformOrigin J� Opacity ��Name    Text �� TextAlignment �� Triggers P� Property P� Value N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions :� RoutedEvent W� From g� FillBehavior�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      3cc,clr-namespace:HRManagerClient.CustomControls  5      %y  '         �� 5      "    6   .�5   
   ��  � �� 5      �� 5      "   6"   .R�5      �� $ 
Horizontal=�6!   .+�5	      � .+�5
      �� $
 rect��5   (   #��z 5   (   #��z 5   (   $��5 0 5 2q�5   (   ��5
   (   �� *
Foreground+$ 	textblock��	 5   "   !� 5   &   $

 Fill=�62    5   2   �� *Visual+ �� *TemplatedParent+$ OneWay=� 5   "   �� 5   &   5      �� 5      $ 	coverRect��6(   $ 0.5,0.5&�5   (   $ 0Q�5   (   ��5   "   !� 5   &    62   �� $
 rect��z�5   "   �� 5   &   5       5!      �� 5"      $ 	textblock��5%   $   #��z 5"   $   $ Center=�5#   $   $��Center=�5$   $   5%   $   5&       5'      P� 5(       �@J�IsMouseOver .  5*      �� 5+   "   .��5,   &   �� .��5-   *   W� $
 rect��6:   $ LayoutTransform.ScaleX�5.   :   $	 1.2X�5/   :   $ 0:0:0.2D�50   :   W� 52   *   $
 rect��6:   $ LayoutTransform.ScaleY�53   :   $	 1.2X�54   :   $ 0:0:0.2D�55   :   56   '   57   #    59      �� 5:   "   .��5;   &   �� .��5<   *   W� $
 rect��6:   $ LayoutTransform.ScaleX�5=   :   $ 1X�5>   :   $ 0:0:0.2D�5?   :   W� 5A   *   $
 rect��6:   $ LayoutTransform.ScaleY�5B   :   $ 1X�5C   :   $ 0:0:0.2D�5D   :   5E   '   5F   #   5H      :� 5I      $ PreviewMouseDown��6'   .[�5J      �� .��5K   "   �� .��5L   &   W� $ 	coverRect��66   $ Opacity�5M   6   $ 1X�5N   6   $ 0X�5O   6   $ 0:0:0.5D�5P   6   W� 5Q   &   $ 	coverRect��66   $ RenderTransform.ScaleX�5R   6   $ 1X�5S   6   $	 1.2X�5T   6   $
 Stop=�5U   6   $ 0:0:0.5D�5V   6   W� 5W   &   $ 	coverRect��66   $ RenderTransform.ScaleY�5X   6   $ 1X�5Y   6   $	 1.2X�5Z   6   $
 Stop=�5[   6   $ 0:0:0.5D�5\   6   5]   #   5^      5_      5a      5c      5d      5e      