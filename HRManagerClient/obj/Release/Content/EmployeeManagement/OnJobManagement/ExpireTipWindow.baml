   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  J FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows %   HRManagerClient.ExpireTipWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     /localclr-namespace:HRManagerClient     6util%clr-namespace:HRManagerClient.Utility     :hrmodel&clr-namespace:HRModel;assembly=HRModel     Jsw;clr-namespace:System.Windows;assembly=PresentationFramework     -   $��w��# HRManagerClient.MainViewModel    MainWindowHandler � Owner# Z   �� BitmapScalingMode$ HighQuality=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ Manual=�$��0q�(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   �   WindowTransitionsEnabled .     IsCloseButtonEnabled .  	   TitlebarHeight$	 0��
 � ShowInTaskbar
 .  $	��200��$	��300�� � 	Resources  	  Start �� TargetProperty! HRManagerClient.ModelSource   WorkAreaWidth W� From   ExpectedTipLeft	 W� To g� Duration g� AccelerationRatio  End �� 
TargetName �� 
TargetType �� Property �� Value  
CommonFont��%  &	        &	 <     '�� x     7  �� .��W� $
 Left�# Z # Z $ 0:0:0.5D�$ 1Q��� .��W� $
 Left�$ w��# Z # Z $ 0:0:0.5D��� " ��.���  � ��$ 16(���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��8    � Triggers :�  :� RoutedEvent$ Loaded��.[��� #��[  .��]� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 
WhiteSmoke�� � Offset$ 0Q�� $ 	#FFF1B1B1��$ 1Q�.+��� $	��Top=�$��0q�
�������$��	新提醒�� �� TextAlignment$
 Left=�$	��Top=� �� Padding$ 5q����� $	 0,1&�$	 1,1&�.��� $ Brown��$ 0Q�� $ Brown��$ 1Q��� -   $��我知道了��$��Right=�$��20q�$��Bottom=�  SquareButtonStyle#���  $
��10 8q��� $[��Upack://application:,,,/HRManagerClient;component/ClientRes/CrystalIcons256/539867.png��$��64��$��64��$��Right=�$
��20 0q�� $��	10 15 0 0q� � RowDefinitions �� �� ��   � ColumnDefinitions  �� $��3* ��� $��* ��� $��* �.+��� $��合同已到期:��$
��Left=��� -   $��ExpiredCountTB��
���<��$��1���� $	��人��$��2���� $��合同将到期:��$��1��$��0��$
��Left=��� -   $��ExpireNearCountTB��
��� ���$��1��$��1���� $	��人��$��1��$��2���� $��自离人员:��$��2��$
��Left=��� -   $��LeaveCountTB��
���r���$��0��$��2��$��1���� $	��人��$��2��$��2��