   M S B A M L   `   `   `  ����F  BFlappy Bird, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Flappy_BirdFlappy_Bird  5   	       Flappy_Bird.Main   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Flappy_Bird     5   	     � Title$
  Main��5   	   $	��490��6   $	��525��6#    � WindowStartupLocation$ CenterScreen=�5	   	   $	��525��6.   $	��490��6=   $	��525��6M   $	��490��6\    � Cursor$ ScrollNE��6l    � WindowStyle$
 None=�6~    � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6$   .�5      ��  � ��$	 160��6&   �� 5       � ��$ Center=�64   �� 5       �@��Left$	 180��6,   �� 5       �@��Top$	 286��6+    5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��$	 180��6.   �� 5       �@��Left$	 170��64   �� 5       �@��Top$	 276��63   5      5      5      .��5      �� ��5   
   �� 5       �� ImageSource$ main.png��6   .+�5    
   �� -   5         ��Name$ userName��5       $��22(�6&   $
��Bold"�64    �� Left$ 73��6F   
 �� Top$ 27��6W    �� TextAlignment$ Center=�6g   Hello6�   �� 5!   
   -   5        $��move.png��5!      $��Right=�6"   $ 60��6>   $ 60��6O   $��56��6_   z�5"      �� 5#       �� Angle$	 180Q�6"   5%      �� 5&   
   -   5         ��Name$
 play��5&      $��buttonPlay.png��6   #��[  66   6[   �� 5(   
   -   5        $ endlessGame��5(      $��endlessGame.png��6%   #��[  6>   $	 189��6c   6t   �� 5*   
   -   5        $ rating��5*      $��buttonRating.png��6    #��[  6:   $	 374��6`   6r   �� 5,   
   -   5        $��	close.png��5,      $��49��6#   $��Right=�6.   $	 459��6J   $ 17��6\   6�   5.      5/      