   M S B A M L   `   `   `  ����  WorldSkillsApp    WorldSkillsApp.AdminPanel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  AdminPanelWindow��5   	    � Title$' !AMONIC Airlines Automation System��5   	   $	��650��63   $	��800��6@   .��5
      � .+�5   
   �� .+�5      �� $��0 0 0 1q�6   
���   �._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��0q�5      $��14(�61   $��0��6?   
�������
�������$��10q�5   1   $��	10 5 10 5q�6=    � Cursor$
 Hand��6Q   .��6s   
Add user6}   �� 5      -   5        $��0q�5      $��14(�61   
�������
�������$
 Hand��5   1   $��27��6?   $��	10 5 10 5q�6K   $
��Exit��6`   6o   5      5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Office:��6   $��18(�6+   $��10q�69   �� 5      -   5        $��18(�5      $��30��6)   $	��150��65   .@�5      ��  �� 
IsSelected . $��All officces��65   �� 5      $��	Abu dhabi��6#   �� 5      $��Cairo��6#   �� 5      $��Bahrain��6#   �� 5      $
��Doha��6#   �� 5      $��Riyadh��6#   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ OfficesData��5         AutoGenerateColumns .  $��16(�6H   $	��750��5          CanUserAddRows .     HeadersVisibility$ Column=�6:   	 �� SelectedItem	 5!      �� 
 �� Path$
 Button_Click_1� �� Mode$ TwoWay=���6Q   �� *
dataTables+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� $
 	FirstName�  5$      $ 	Last Name��6)   $	 150 6<    6H   �� $
 LastName�  5%      $	 Age��6)   $ 60 66    6A   �� $	
 Age�  5&      $ 	User Role��6)   $ 80 6<    6G   �� $

 Role�  5'      $ Email Address��6)   $	 250 6@    6L   �� $
 EmailAddress�  5(      $ Office��6)   $ * 69    6C   �� $
 Offices�5*      �� 5+      $ 
Horizontal=�6   $��	20 10 0 0q�62   .+�5,      �� -   5        $��Change Role��5,      $��0 0 50 0q�6/   $��14(�6A   $��5q�6O   6[   �� 5-      -   5        $��Enable/Disable Login��5-      $��14(�68   $��5q�6F   6S   5.      5/      50      51      