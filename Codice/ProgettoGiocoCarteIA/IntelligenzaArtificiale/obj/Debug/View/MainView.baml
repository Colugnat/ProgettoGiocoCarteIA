   M S B A M L   `   `   `  ����F  B01 BaseMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:IntelligenzaArtificiale.ViewIntelligenzaArtificiale.View  5      X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5      +    %IntelligenzaArtificiale.View.MainView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:IntelligenzaArtificiale.View     5      Kxctk:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $	��10* �6   .+�5   
   �� -   5         ��Name$ carta0��5      $��0��6$   66   �� 5   
   -   5        $ carta1��5      $��1��6$   66   �� 5   
   -   5        $ carta2��5      $��2��6$   66   �� 5   
   -   5        $ carta3��5      $��3��6$   66   �� 5   
   -   5        $ carta4��5      $��4��6$   66   �� 5    
   -   5        $ carta5��5       $��5��6$   66   �� 5!   
   -   5        $ carta6��5!      $��6��6$   66   	� 5"   
   -   5         	�Name$ color0��5"   '    d� 	IsChecked$
 TrueY�6    	� 	GroupName$ color��67   $��0��6I   $��1��6Y   $��Rosso��6f   6x   	� 5#   
   -	   5        $ color1��5#      $ color��6&   $��1��68   $��1��6H   $��Giallo��6U   6h   	� 5$   
   -
   5        $ color2��5$      $ color��6&   $��2��68   $��1��6H   $��Verde��6U   6g   	� 5%   
   -   5        $ color3��5%      $ color��6&   $��3��68   $��1��6H   $	��Blu��6U   6e   %  Xceed.Wpf.Toolkit.IntegerUpDown  5&   
   -   5          Name$ number��5&      $��0��6-   $��2��6=   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .  �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 0X�6a   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]	   	Increment$	 1X�6k   
   Minimum$
 0X�6y      Maximum$ 9X�6�   �� 5'   
   -   5        $��Scegli��5'   &   $��1��67   $��2��6G   6V   �� 5(   
   $��2��6   $��2��6$   $��Carta:��61   6A   �� 5)   
   -   5        $ cardGame��5)      $��3��6&   $��2��66   6E   �� 5*   
   $��0��6   $��3��6$   $��Mossa:��61   6A   �� 5+   
   -   5        $ 	cardsMove��5+      $��0��6'   $��4��67   $��7��6D   6Z   �� 5,   
   -   5        $��Shuffle��5,   (   $��6��6:   $��2��6J   6Y   5-      5.      