   M S B A M L   `   `   `  ���� J  FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0894   .HRManagerClient.CustomControls.ZoomIconControl  �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation ��Name    	IconWidth    
IconHeight �� ElementName	 J� OpacityMask
 j� Stretch !� Visual �� RelativeSource �� Mode � LayoutTransform J� RenderTransformOrigin J� Opacity ��Name    Text �� TextAlignment �� Triggers P� Property P� Value N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions :� RoutedEvent W� From g� FillBehavior�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     3cc,clr-namespace:HRManagerClient.CustomControls  %  '         �� "    .���  � �� �� "   .R��� $ 
Horizontal=�.+�� .+��� $
 rect��#��z #��z $��5 0 5 2q����� *
Foreground+$ 	textblock��	 !� $

 Fill=� �� *Visual+ �� *TemplatedParent+$ OneWay=� �� �� $ 	coverRect��$ 0.5,0.5&�$ 0Q���!�  �� $
 rect��z��� �� $ 	textblock��#��z $ Center=�$��Center=� P�  �@J�IsMouseOver .  �� .���� .��W� $
 rect��$ LayoutTransform.ScaleX�$	 1.2X�$ 0:0:0.2D�W� $
 rect��$ LayoutTransform.ScaleY�$	 1.2X�$ 0:0:0.2D� �� .���� .��W� $
 rect��$ LayoutTransform.ScaleX�$ 1X�$ 0:0:0.2D�W� $
 rect��$ LayoutTransform.ScaleY�$ 1X�$ 0:0:0.2D�:� $ PreviewMouseDown��.[��� .���� .��W� $ 	coverRect��$ Opacity�$ 1X�$ 0X�$ 0:0:0.5D�W� $ 	coverRect��$ RenderTransform.ScaleX�$ 1X�$	 1.2X�$
 Stop=�$ 0:0:0.5D�W� $ 	coverRect��$ RenderTransform.ScaleY�$ 1X�$	 1.2X�$
 Stop=�$ 0:0:0.5D�