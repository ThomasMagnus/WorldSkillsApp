   M S B A M L   `   `   `  ����I  EWorldSkillsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorldSkillsAppWorldSkillsApp  5   	       WorldSkillsApp.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorldSkillsApp     5   	   -   5          �Name$  
userWindow��5	   	    � Title$' !Anonic Airlines Automation System��5   	   $	��550��63   $	��700��6@   .��5      � .+�5   
   �� .+�5      �� $��0 0 0 1q�6   
���   �._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��0q�5      $��14(�61   
�������
������� � Cursor$
 Hand��5   1   $��27��6?   $��	10 5 10 5q�6K   $
��Exit��6`   6o   5      5      �� 5      $��0 30 0 0q�6   .+�5      �� -   5         ��Name$ welcomeText��5      $��30 0 0 0q�61   '%Hi Henri, Welcome to AMONIC Airlines.6j   �� 5      $ 
Horizontal=�6   $��Center=�66   $��	70 15 0 0q�6S   .+�5      �� -   5        $ 	TimeSpant��5        Time spent on system: 00:19:036S   �� 5      $��60 0 0 0q�6    Number of crushes: 16H   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ CrashesData��5         AutoGenerateColumns .  $��Center=�6H   $��0 70 0 0q�5         HeadersVisibility$ Column=�6)      CanUserAddRows .  ��6D   �� *getCrashesData+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Date��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   ��  �� Path$ NowDate�  5      $
 
Login Time��6)   $	 100 6=    6I   �� $ 	LoginTime�  5       $
 Logout Time��6)   $	 110 6>    6J   �� $ 
LogoutTime�  5!      $
 Time spent on system��6)   $	 160 6G    6S   �� $ FullTime�  5"      $ 
 Unsuccessful logout reason��6)   $	 200 6M    6Y   �� $ Error�5$      5%      5&      5'      