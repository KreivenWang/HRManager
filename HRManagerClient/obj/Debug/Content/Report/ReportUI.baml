   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5   
   A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5	   
      HRManagerClient.ReportUI   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   
   /localclr-namespace:HRManagerClient     5   
   :hrmodel&clr-namespace:HRModel;assembly=HRModel     5   
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
   ;cc,clr-namespace:HRManagerClient.CustomControls     5   
   9utility%clr-namespace:HRManagerClient.Utility     5	   
   -   5        $
��root��5   e   ��5
      �� 5   
     �� 
TargetType"  ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      ]� .+�5      �� $��5q�6)   $	��Top=�64    �� Orientation$ 
Horizontal=�6I   .+�5   "   �� $	��100��6*   $	��0 5q�5   *   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 筛选工号��5   *      UseFloatingWatermark .    ClearTextButton . ��5   *   �� *
FilterEpNo+ �� UpdateSourceTrigger$ PropertyChanged=�5   Z   �� 5   "   $	��100��6*   $	��0 5q�5   *   $ 筛选姓名��5   *    .  . ��5   *   �� *FilterEpName+$ PropertyChanged=�5   Z   �� 5   "   $	��0 5q�5   )   ��5   )   �� *SelectEpCommand+.��5   6   选择员工6<   �� 5   "   $��5q�5!   )   ��5   )   �� *ExportCsvCommand+��5    )   ��  �� ElementName$
 grid��.��5!   4   	导出csv6;   5"      &   System.Windows.Controls.DataGrid  5#      $
��grid��5(   >   -   5        	   AutoGenerateColumns	 . 
   CanUserDeleteRows
 .  $��微软雅黑)�5'   '      CanUserAddRows .  ��5#   '   �� *FiltedItems+5(   >   5)      5*      5,      5-      5/      