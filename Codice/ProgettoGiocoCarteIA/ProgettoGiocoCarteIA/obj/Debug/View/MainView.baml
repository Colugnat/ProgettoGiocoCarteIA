   M S B A M L   `   `   `  ����F  B01 BaseMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProgettoGiocoCarteIA.ViewProgettoGiocoCarteIA.View  5      _ [WebEye.Controls.Wpf.WebCameraControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullgOclr-namespace:WebEye.Controls.Wpf;assembly=WebEye.Controls.Wpf.WebCameraControlWebEye.Controls.Wpf 5      (    "ProgettoGiocoCarteIA.View.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ProgettoGiocoCarteIA.View     5      _wpfOclr-namespace:WebEye.Controls.Wpf;assembly=WebEye.Controls.Wpf.WebCameraControl     5      -   5        $	��440��5	      $��664.667��6   .��5
      � .+�5   
   �� $
��Left=�6   $	��363��60   $��	10,10,0,0q�6=   $	��Top=�6P   $	��637��6h   .@�5      �� $��Camera��6   .��5      �   � ColumnDefinitions  5      �� 5      $��* �6+   �� 5      $��* �6+    � RowDefinitions 5      �� 5      $	��10* �6(   �� 5      $��* �6(   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��1��6W   $��2��6d   $��-12,0q�6x   .+�5      �� -   5         ��Name$ comboBox��5   #   $	��100��65    �� DisplayMemberPath$
 Name��6A   6Z   �� 5      -   5         ��Name$ startButton��5   !   $��Start��66   $��75��6F   {�.  6c   �� 5      -   5        $ 
stopButton��5   !   $
��Stop��65   $��75��6D   {�6O   ��  �� Path$ IsCapturing� �� ElementName$ webCameraControl��6�   5      *  $WebEye.Controls.Wpf.WebCameraControl  5      -   5          Name$ webCameraControl��5   +   $��2��6E   5      5      �� 5      $��Learning��6   .��5      � ���	#FFE5E5E5$��0,0,0,-2q�6.     5       �� 5!      $
��102* �6+   �� 5"      $
��491* �6+   .+�5$      �� -   5        	 ��Name$	 LearningImageOne��5$      $
��Left=�66   $	��195��6Q   $��	10,36,0,0q�6^   $	��Top=�6q   $	��219��6�   $��2��6�   �� 5%      -   5        $	 LearningImageTwo��5%      $��1��66   $
��Left=�6F   $	��193��6a   $��
135,38,0,0q�6n   $	��Top=�6�   $	��212��6�   �� 5&      -   5        
 ��Name$
 LearnedObjectsList��5&      $��1��6:   $
��Left=�6J   $	��161��6e   $��
369,41,0,0q�6r   $	��Top=�6�   $	��136��6�   �� 5'      $��Background image��6   $
��Left=�67   $��8,10,0,0q�6R   $	��Top=�6d   $��2��6|   $	��157��6�   �� 5(      $ ��Image with object to learn��6   $��1��6A   $
��Left=�6Q   $��
134,10,0,0q�6l   $	��Top=�6�   $	��218��6�   �� 5)      -	   5        $ LearningImageOneButton��5)      $��
Load Image��6=   $��1��6R   $
��Left=�6b   $��
46,236,0,0q�6}   $	��Top=�6�   $��75��6�    J� RenderTransformOrigin$ 0.067,0.364&�6�   6�   �� 5*      -
   5        $ LearningImageTwoButton��5*      $��
Load Image��6=   $��1��6R   $
��Left=�6b   $��272,238,0,0q�6}   $	��Top=�6�   $��75��6�   6�   �� 5+      $��Learned objects��6   $��1��66   $
��Left=�6F   $��
369,10,0,0q�6a   $	��Top=�6u   $	��120��6�   �� 5,      -   5        $ LearnObjectButton��5,      $��Learn��68   $��1��6H   $
��Left=�6X   $��434,274,0,0q�6s   $	��Top=�6�   $��75��6�   6�   �� 5-      -   5        $ DeleteObjectButton��5-      $��Delete��69   $��1��6J   $
��Left=�6Z   $��434,301,0,0q�6u   $	��Top=�6�   $��75��6�   6�   �� 5.      -   5         ��Name$ ObjectNameText��5.      $��1��66   $
��Left=�6F   $��23��6a   $��369,238,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   �� 5/      $��Name of object to learn��6   $��1��6>   $
��Left=�6N   $��369,207,0,0q�6i   $	��Top=�6~   $��24��6�   50      51      �� 52      $��Recognition��6   .��53      � ���	#FFE5E5E5$��	0,0,-9,-1q�6.     54      �� 55      $��7* �6+   �� 56      $	��22* �6+   �� 57      $
��167* �6+   .+�59      �� -   5         ��Name$ AnalysisResultsText��59       $
��Left=�6=   $��207.478,55,0,0q�6X   $
��Wrap=�6p   $	��Top=�6�   $	��168��6�   $	��284��6�   $ 
0.47,0.401&�6�   $��2��6�   �� 5:      $!��What image recognizer finds��6   $
��Left=�6B   $��202.478,17,0,0q�6]   $	��Top=�6u   $��2��6�   �� 5;      $��Image to Analyze��6   $
��Left=�67   $��	10,17,0,0q�6R   $	��Top=�6e   $��3��6}   �� 5<      -   5        $ AnalyzeButton��5<      $��Analyze Image��64   $
��Left=�6L   $��326.478,251,0,0q�6g   $	��Top=�6�   $	��114��6�   $ 0.067,0.364&�6�   $��2��6�   6�   �� 5=      -   5        $ AnalyzeImageButton��5=      $��
Load Image��69   $
��Left=�6N   $��
40,251,0,0q�6i   $	��Top=�6}   $��75��6�   $��2��6�   6�   �� 5>      -   5        $	 AnalysisImage��5>      $
��Left=�63   $	��184��6N   $��0,48,0,0q�6[   $	��Top=�6m   $	��250��6�   $��2��6�   $��1��6�   5?      5@      5A      5B      5C      