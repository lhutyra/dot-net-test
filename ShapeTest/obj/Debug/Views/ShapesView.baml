   M S B A M L   `   `   `  ����H  DMvvmCross.Wpf, Version=4.0.0.0, Culture=neutral, PublicKeyToken=nullP8clr-namespace:MvvmCross.Wpf.Views;assembly=MvvmCross.WpfMvvmCross.Wpf.Views  5      O KShapeTests.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:ShapeTests.ViewModel.ViewModels;assembly=ShapeTests.ViewModelShapeTests.ViewModel.ViewModels 5      Y@clr-namespace:ShapeTests.ViewModel;assembly=ShapeTests.ViewModelShapeTests.ViewModel 5       ShapeTest.Wpf$   ShapeTest.Wpf.Views.ShapesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jviews8clr-namespace:MvvmCross.Wpf.Views;assembly=MvvmCross.Wpf     5      b
viewModelsKclr-namespace:ShapeTests.ViewModel.ViewModels;assembly=ShapeTests.ViewModel     5      V	viewModel@clr-namespace:ShapeTests.ViewModel;assembly=ShapeTests.ViewModel     5        � 	Resources  5         FigureListItemTemplate �� DataType=  7ShapeTests.ViewModel.ViewModels.FigureListItemViewModel ��Name   BooleanToVisibilityConverter4  .ShapeTests.ViewModel.NullToVisibilityConverter  NullToVisibilityConverter��%�   &	        &	 �     &	 �     �� 5   
   "  67   .R�5      � .+�5      �� $ TriangleName��6   ��62   �� *
FigureName+5      5      �� 5   
   6'     5   
   6.   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��0��6   #��[  6�   ��6/   �� *FigureListItems+ �� SelectedItem 6W   �� *!SelectedFigureListItemViewModel+6�   � 5   
   $��0��6   $��1��6    5      �� 5       $��* �6    �� 5!      $��40 �6    .+�5#      �� $��0��6   ��6-   �� *!SelectedFigureeContentViewModel+  5$      ,  &ShapeTests.ViewModel.TriangleViewModel ��Name*  $ShapeTests.ViewModel.SquareViewModel*  $ShapeTests.ViewModel.CircleViewModel-  'ShapeTests.ViewModel.RectangleViewModel��%�  (��       5%   %   *, +)(�� �    5@   $   *, +)(�� �    5Y   $   *, +)(�� �	    5r   $   *, +)�� 5%      "  6%   .R�5&      � $��Center=�6    5'      �� 5(   "   $��50 �60   �� 5)   "   $
��Auto �60   �� 5*   "   $
��Auto �60   �� 5+   "   $
��Auto �60   �� 5,   "   $
��Auto �60    5.      �� 5/   "   $
��Auto �63   �� 50   "   $
��Auto �63   .+�53      �� $��0��6(   $��2��65   $��Center=�6I   $��Triangle Data Entry��6f   �� 55      $��1��6(   $��0��65   $��Name:��6E   �� 56      $ 	NameEntry��6D   $��1��6&   $��1��63   $	��120��6W   $��4,0,4,0q�6c   ��6t   �� *Name+�� 58      $��2��6(   $��0��65   $��Base:��6E   �� 59      $ 	BaseEntry��6D   $��2��6&   $��1��63   $	��120��6W   $��4,0,4,0q�6c   ��6t   �� *Base+�� 5;      $��3��6(   $��0��65   $��Height:��6E   �� 5<      $ HeightEntry��6D   $��3��6&   $��1��63   $	��120��6Y   $��4,0,4,0q�6e   ��6v   �� *Height+5>      5?      �� 5@      "  6$   .R�5A      � $��Center=�6    5B      �� 5C   "   $��50 �60   �� 5D   "   $
��Auto �60   �� 5E   "   $
��Auto �60   �� 5F   "   $
��Auto �60   �� 5G   "   $
��Auto �60    5I      �� 5J   "   $
��Auto �63   �� 5K   "   $
��Auto �63   .+�5N      �� $��0��6(   $��2��65   $��Center=�6I   $��Triangle Data Entry��6f   �� 5P      $��1��6(   $��0��65   $��Name:��6E   �� 5Q      $ 	NameEntry��6D   $��1��6&   $��1��63   $	��120��6W   $��4,0,4,0q�6c   ��6t   �� *Name+�� 5S      $��2��6(   $��0��65   $��Side Length:��6E   �� 5T      $ 	BaseEntry��6D   $��2��6&   $��1��63   $	��120��6W   $��4,0,4,0q�6c   ��6t   �� *
SideLength+5W      5X      �� 5Y      "  6$   .R�5Z      � $��Center=�6    5[      �� 5\   "   $��50 �60   �� 5]   "   $
��Auto �60   �� 5^   "   $
��Auto �60   �� 5_   "   $
��Auto �60   �� 5`   "   $
��Auto �60    5b      �� 5c   "   $
��Auto �63   �� 5d   "   $
��Auto �63   .+�5g      �� $��0��6(   $��2��65   $��Center=�6I   $��Circle Data Entry��6f   �� 5i      $��1��6(   $��0��65   $��Name:��6E   �� 5j      $ 	NameEntry��6D   $��1��6&   $��1��63   $	��120��6W   $��4,0,4,0q�6c   ��6t   �� *Name+�� 5l      $��2��6(   $��0��65   $��Radius:��6E   �� 5m      $ RadiusEntry��6D   $��2��6&   $��1��63   $	��120��6Y   $��4,0,4,0q�6e   ��6v   �� *Radius+5p      5q      �� 5r      "  6$   .R�5s      � $��Center=�6    5t      �� 5u   "   $��50 �60   �� 5v   "   $
��Auto �60   �� 5w   "   $
��Auto �60   �� 5x   "   $
��Auto �60   �� 5y   "   $
��Auto �60    5{      �� 5|   "   $
��Auto �63   �� 5}   "   $
��Auto �63   .+�5�      �� $��0��6(   $��2��65   $��Center=�6I   $��Triangle Data Entry��6f   �� 5�      $��1��6(   $��0��65   $��Name:��6E   �� 5�      $ 	NameEntry��6D   $��1��6&   $��1��63   $	��120��6W   $��4,0,4,0q�6c   ��6t   �� *Name+�� 5�      $��1��6(   $��0��65   $��Name:��6E   �� 5�      $ LengthEntry��6D   $��1��6&   $��1��63   $	��120��6Y   $��4,0,4,0q�6e   ��6v   �� *Length+�� 5�      $��2��6(   $��0��65   $��Width:��6E   �� 5�      $ 
WidthEntry��6D   $��2��6&   $��1��63   $	��120��6X   $��4,0,4,0q�6d   ��6u   �� *Width+5�      5�      5�      5�      � 5�      $��1��6   $��Right=�6    .+�5�      � $
��Left=�6�   $	��Top=�6�   y�6   �� *SubmitCommandAsync.Execution+ �� 	Converter# [ .+�5�      �� $�� ��6�   $��12(�6�   y�6   �� *-+SubmitCommandAsync.Execution.IsNotCompleted+# [ 6�   �� 5�      ��6   �� *%#SubmitCommandAsync.Execution.Result+y�6T   �� *64SubmitCommandAsync.Execution.IsSuccessfullyCompleted+# [ �� 5�      
���  ����6   �� *+)SubmitCommandAsync.Execution.ErrorMessage+y�6Z   �� *(&SubmitCommandAsync.Execution.IsFaulted+# [ 6�   5�      5�      5�      � 5�   
   $��4,4,4,4q�6   $��1��6    $��0��6-    5�      �� 5�      $��* �6#   �� 5�      $��8 �6#   �� 5�      $��* �6#   .+�5�      �� -   5         ��Name$	 Add��5�   %   $��0��6   $	��Add��62   ��6@   �� *AddFigureCommand+�� 5�      -   5        $ Remove��5�   %   $��2��6   $��Remove��65   ��6F   �� *RemoveFigureCommand+5�      � 5�   
   $��4,4,4,4q�6   $��1��6    $��1��6-    5�      �� 5�      $��* �6#   �� 5�      $��* �6#   �� 5�      $��* �6#   .+�5�      �� $��0��6   $��Compute Total Area��6%   ��6B   �� *ComputeAreaCommand+�� 5�      $��1��6   	 �� Orientation$	 
Horizontal=�6)   .+�5�      �� $��Center=�6   $��Total Area:��67   �� 5�      $��Center=�6   ��67   �� *	TotalArea+
 �� StringFormat$
 N2��6e   5�      �� 5�      $��2��6   $��Submit Total Area��6%   ��6A   �� *SubmitCommandAsync+5�      5�      5�      