   M S B A M L   `   `   `  ����I  EWorldSkillsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorldSkillsAppWorldSkillsApp  5   	       WorldSkillsApp.ChangeRole   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorldSkillsApp     5   	   -   5          �Name$  ChangeRolePanel��5   	    � Title$ 	Edit Role��5	   	   $	��348��6   $	��392��6(   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��	40,0,40,0q�6I   .+�5      �� $��Email address��6    �� Target 6,   ��  �� ElementName$ email���� 5      -   5         ��Name$ email��5      $��200px��6&   $��20��64   .��6@   ��5      �� 5       �� Path$ EmailAddress�6    �� ValidationRules 5      5  /System.Windows.Controls.ExceptionValidationRule  5      5      .��5       5      5      �� 5   
   $ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��	40,0,40,0q�6V   .+�5       �� $��
First Name��6    6)   �� $ 	firstName���� 5!      -   5        $��	firstName��5!      $	��200��6'   $��20��63   $��16 0 0 0q�6?   .��6Q   ��5"      �� 5#      $ 	FirstName�6    5$        5%      5'      .��5(       5)      5*      �� 5+   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   $��	40,0,40,0q�6V   .+�5,      �� $��	Last Name��6    6(   �� $ 	firstName���� 5-      -   5        $��lastName��5-      $	��200��6&   $��20��62   $��18 0 0 0q�6>   .��6P   ��5.      �� 5/      $ LastName�6    50        51      53      .��54       55      56      �� 57   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��	40,0,40,0q�6V   .+�58      �� $��Office��6   �� 59      -   5        $��office��59      $��12(�6%   $��20��63   $	��100��6?   $��42 0 0 0q�6K   .@�5:      �� 	 �� 
IsSelected	 . $��All officces��61   �� 5;      $��	Abu dhabi��6   �� 5<      $��Cairo��6   �� 5=      $��Bahrain��6   �� 5>      $
��Doha��6   �� 5?      $��Riyadh��6   5@      5A      �� 5B   
   $ 
Horizontal=�6   $��Center=�6.   $��4��6K   $	��312��6X   $��23 0 0 0q�6d   .+�5C      �� $
��Role��6   �� 5D      $��64��6   $��55 0 0 0q�6%   .+�5E      	� -   5        $
��User��5E      
 d� 	IsChecked$

 TrueY�6-   6>   	� 5F      -   5        $��Administrator��5F      $��0 10 0 0q�66   6H   5G      5H      �� 5I   
   $��5��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5J      �� -   5        $��Apply��5J      $��0 0 60 0q�6%   $��20��67   $	��100��6C   
�������6a   �� 5K      -	   5        $��Cancel��5K      $��20��6&   $	��100��62   
�������6P   5L      5M      5N      