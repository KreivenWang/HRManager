   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      J FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5      A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5      B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows 5	      %   HRManagerClient.ExpireTipWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      /localclr-namespace:HRManagerClient     5      6util%clr-namespace:HRManagerClient.Utility     5      :hrmodel&clr-namespace:HRModel;assembly=HRModel     5      Jsw;clr-namespace:System.Windows;assembly=PresentationFramework     5	      -   5        $��w��5      # HRManagerClient.MainViewModel    MainWindowHandler � Owner# Z  5
       �� BitmapScalingMode$ HighQuality=�5       � WindowStyle$
 None=�5       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ Manual=�5      $��0q�5      (  "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   �   WindowTransitionsEnabled .     IsCloseButtonEnabled .  	   TitlebarHeight$	 0��5      
 � ShowInTaskbar
 .  $	��200��5      $	��300��5       � 	Resources 5       	  Start �� TargetProperty! HRManagerClient.ModelSource   WorkAreaWidth W� From   ExpectedTipLeft	 W� To g� Duration g� AccelerationRatio  End �� 
TargetName �� 
TargetType �� Property �� Value  
CommonFont��%�  &	        &	 �     '�� 	    7  �� 5   
   .��5      W� $
 Left�6   # Z 5      # Z 5      $ 0:0:0.5D�5      $ 1Q�5      5      5       �� 5!   
   .��5"      W� $
 Left�6   $ w��5#      # Z 5$      # Z 5%      $ 0:0:0.5D�5&      5'      �� 5(   
   " ��6   .�5)      ��  � ��$ 16(�5*      �� 5+       �@��TextAlignment$ Center=�5,      �� 5-       � ��$ Center=�62   6C   �� 5.       � ��8   6Q   5/      50       � Triggers 51      :� 52   
    :� RoutedEvent$ Loaded��53   H   .[�54      �� #��[  6   55      .��57      ]� ��58   
   �� 59       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�5:   "   .��5;      �  � Color$ 
WhiteSmoke��6    � Offset$ 0Q�5<      � 5=      $ 	#FFF1B1B1��6   $ 1Q�5>      5?      .+�5A   
   �� $	��Top=�6   $��0q�6)   
�������$��	新提醒��6L    �� TextAlignment$
 Left=�6W   $	��Top=�6l    �� Padding$ 5q�6�   ��5B      �� 5C      $	 0,1&�6&   $	 1,1&�5D   &   .��5E      � $ Brown��6#   $ 0Q�5F   #   � 5G      $ Brown��6#   $ 1Q�5H   #   5I      5K      �� 5L   
   -   5        $��我知道了��5L      $��Right=�5M      $��20q�5N      $��Bottom=�5O        SquareButtonStyle#���  5P      $
��10 8q�5Q      5S      �� 5T   
   $[��Upack://application:,,,/HRManagerClient;component/ClientRes/CrystalIcons256/539867.png��6   $��64��5U      $��64��5V      $��Right=�5W      $
��20 0q�5X      � 5Y   
   $��	10 15 0 0q�6    � RowDefinitions 5Z      �� 5[      6"   �� 5\      6"   �� 5]      6"     � ColumnDefinitions  5_      �� 5`      $��3* �6#   60   �� 5a      $��* �6#   60   �� 5b      $��* �6#   6/   .+�5d      �� $��合同已到期:��6   $
��Left=�5e      �� 5f      -   5        $��ExpiredCountTB��5f      
���<��$��1��5h      �� 5i      $	��人��6   $��2��5j      �� 5l      $��合同将到期:��6   $��1��5m      $��0��5n      $
��Left=�5o      �� 5p      -   5        $��ExpireNearCountTB��5p      
��� ���$��1��5r      $��1��5s      �� 5t      $	��人��6   $��1��5u      $��2��5v      �� 5x      $��自离人员:��6   $��2��5y      $
��Left=�6%   �� 5z      -   5        $��LeaveCountTB��5z      
���r���$��0��5|      $��2��5}      $��1��5~      �� 5      $	��人��6   $��2��5�      $��2��5�      5�      5�      5�      