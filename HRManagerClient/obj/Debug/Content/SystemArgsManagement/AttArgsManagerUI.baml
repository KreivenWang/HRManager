   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5   
   &    HRManagerClient.AttArgsManagerUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   /localclr-namespace:HRManagerClient     5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   ;cc,clr-namespace:HRManagerClient.CustomControls     5   
   -   5        $
��root��5	   
     � 	Resources  5
       �� MergedDictionaries �� Source*   $MahApps.Metro.Controls.NumericUpDown �� 
TargetType �� BasedOn �� Property �� Value�� 5   
    5      �� 5      $C =/HRManagerClient;component/ClientRes/DialogDefaultLayout.xaml?�6%   6n   %�   '        7 �� 5      "  6   8   .�5      ��  � ��$	 180��5      �� 5       � ��$ 5q�5      5      5      ��5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      .R�5      ]� .+�5      �  � RowDefinitions 5   "   �� 5    &   66   �� 5!   &   66   �� 5"   &   66   �� 5#   &   66    � ColumnDefinitions 5%   "   �� 5&   &   69   �� 5'   &   69   �� 5(   &   69   .+�5*   "   �� $��迟到时间限制��6,   $��0��6:   $��0��6G   6Y   �� 5+   "   $��旷工时间限制��6,   $��1��5,   ,   $��0��5-   ,   6>   �� 5.   "   $��早退时间限制��6,   $��2��5/   ,   $��0��50   ,   6>     51   "   $��0��69   $��1��52   9   	   Minimum$	 0Q�54   9   
   Maximum$
 10000Q�55   9      Value 53   9   �� *Arg.BeLateMinuteLimit+55   K     56   "   $��1��69   $��1��57   9   $	 0Q�59   9   $
 10000Q�5:   9    58   9   �� *Arg.AbsenteeismMinuteLimit+5:   K     5;   "   $��2��69   $��1��5<   9   $	 0Q�5>   9   $
 10000Q�5?   9    5=   9   �� *Arg.EarlyLeftMinuteLimit+5?   K   �� 5@   "   $��分钟��6,   $��0��5A   ,   $��2��5B   ,   6>   �� 5C   "   $��分钟��6,   $��1��5D   ,   $��2��5E   ,   6>   �� 5F   "   $��分钟��6,   $��2��5G   ,   $��2��5H   ,   6>   �� 5I   "   $��5q�6)   $��3��5K   )   $��0��5L   )   ��5J   )   �� *SaveCommand+.��5L   9   保存修改6?   5M      5N      5O      5Q      5R      5T      