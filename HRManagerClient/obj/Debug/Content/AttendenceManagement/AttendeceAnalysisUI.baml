   M S B A M L   `   `   `  ����J  FMahApps.Metro, Version=1.3.0.172, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   J FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRManagerClientHRManagerClient 5   
   B >HRModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:HRModel;assembly=HRModelHRModel 5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   
   O,clr-namespace:HRManagerClient.CustomControlsHRManagerClient.CustomControls 5   
   A%clr-namespace:HRManagerClient.UtilityHRManagerClient.Utility 5	   
   )   #HRManagerClient.AttendeceAnalysisUI   5   
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
TargetType"  ��6   .�5      ��  �� Property � �� �� Value 5      �� 5      .R�5      �  � RowDefinitions 5      �� 5   "   $
��Auto �60   6@   �� 5   "   $��* �60   6=   .+�5      ]� $	��0 5q�6(   $	��Top=�5   )   ��.  .+�5   "   *   $MahApps.Metro.Controls.NumericUpDown  $	��0 5q�69      Minimum$
 2000Q�5   9      Maximum$
 2050Q�5   9      Interval$ 1Q�5   9   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 分析年份��5   9      UseFloatingWatermark . 	   Value	 5   9   �� *AnalyseYear+5   o     5   "   $	��0 5q�69   $ 1Q�5   9   $ 12Q�5   9   $ 1Q�5    9   $ 分析月份��5"   9    . 	 5!   9   �� *AnalyseMonth+5#   n   �� 5$   "   $��0 5 5 5q�5%   )   ��5$   )   �� *AnalyseCommand+.��5%   :   分析6>   �� 5&   "   $	��100��6*   $	��0 5q�5'   *   $ 筛选工号��5)   *    . 
   ClearTextButton
 . ��5(   *   �� *
FilterEpNo+5+   Z   �� 5,   "   $	��100��6*   $	��0 5q�5-   *   $ 筛选姓名��5/   *    . 
 . ��5.   *   �� *FilterEpName+51   Z   �� 52   "   $	��0 5q�53   )   ��52   )   �� *SelectEpCommand+.��53   6   选择员工6<   �� 5;   "   $��5q�5<   )   ��5;   )   �� *SearchCommand+.��5<   4   分析结果查询6<   4  .HRManagerClient.CustomControls.DBNavigationBar  5=   "   $��5q�65      SaveChangesCommand 5>   5   �� *UpdateItemCommand+6h   5?      &   System.Windows.Controls.DataGrid  5@      -   5           AutoGenerateColumns . $��1��5F   '   ��5@   '   �� *FiltedItems+ �� SelectedItem 5A   '   �� *SelectedItem+5G      5H      5I      5K      5L      5N      