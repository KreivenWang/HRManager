   M S B A M L   `   `   `  ����J  FHRManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Steelsa.ViewModelSteelsa.ViewModel  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source&    System.Windows.Controls.DataGrid �� 
TargetType   AzureDataGrid �� BasedOn �� Property �� Value0   *Steelsa.ViewModel.DataGridRepairedBehavior�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      -	viewModelclr-namespace:Steelsa.ViewModel  5        5      �� 5   
   $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6   �� 5   
   $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6   �� 5   
   $G Apack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml?�6   �� 5
   
   $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Teal.xaml?�6   �� 5   
   $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6   �� 5   
   $K Epack://application:,,,/MahApps.Metro;component/Styles/FlatButton.xaml?�6   �� 5   
   $ Common.xaml?�6   �� 5   
   $ DialogUtility.xaml?�6   �� 5   
   $ Window.xaml?�6   �� 5   
   $ 
Icons.xaml?�6   �� 5   
   $ Converters.xaml?�6   �� 5   
   $E ?/HRManagerClient;component/CustomControls/MyDateTimePicker.xaml?�6   �� 5   
   $D >/HRManagerClient;component/CustomControls/ZoomIconControl.xaml?�6   �� 5   
   $E ?/HRManagerClient;component/CustomControls/ZoomImageControl.xaml?�6   �� 5   
   $C =/HRManagerClient;component/CustomControls/MainPageButton.xaml?�6   �� 5   
   $D >/HRManagerClient;component/CustomControls/DBNavigationBar.xaml?�6   �� 5   
   $C =/HRManagerClient;component/CustomControls/TimeSpanPicker.xaml?�6   �� 5   
   $C =/HRManagerClient;component/Content/FlyoutContentTemplate.xaml?�6   %�  '         7   �� 5      "   6   8   .�5%   
   ��  �@  EnableRowVirtualization . 5&       �� 5'   
   " �@  EnableColumnVirtualization . 5(       �� 5)   
    �@$�VirtualizationMode$ 	Recycling=�5*      6%   �� 5+   
    �@$�IsVirtualizing . 5,       �� 5-   
     �@  HorizontalGridLinesBrush
 ����5.      �� 5/   
    �@  VerticalGridLinesBrush
 ����50      �� 51   
    �@  GridLinesVisibility$ 
Horizontal=�52      �� 53   
     �@ LoadingRowEventToCommand 54      �� *LoadingRowEventToCommand+6>   �� 55   
    �@  HeadersVisibility$	 All=�56      6   �� 57   
    �@  CanUserDeleteRows .  58   !   �� 59   
    �@  CanUserAddRows .  5:   !   �� 5;   
    �@  SelectionMode$ Single=�6*   6;   �� 5<   
    �@  RowHeaderTemplate 5=      �� 5>      .R�5?      � .+�5@      �� $��Center=�5A   $   $��Center=�5B   $   $��5 1 5 0q�5C   $   $��Consolas)�5D   $   ��5@   $   �� 5D   <   �� 5E      $��1��6$   $��Stretch=�5F   $   $��Bottom=�5G   $   
������5H   8   5I      5K      5M      5N      5O      