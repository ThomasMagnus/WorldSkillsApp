   M S B A M L   `   `   `  ����I  EWorldSkillsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorldSkillsAppWorldSkillsApp  5   	       WorldSkillsApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorldSkillsApp     5   	   -   5          �Name$  
mainWindow��5	   	    � Title$ Login��5   	   $	��550��6   $	��900��6$   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��200 �6   �� 5      .+�5   
   �� -   5         ��Name$ mainLogo��5      $��img/logo.png��6"      mainLogo#��[  68   $��0��6Z   $��0��6g   $��2��6w   �� 5   
   -   5         ��Name$ 	LabelText��5        	LabelText#��[ 6L   $��	Username:��5      $��1��6$   $��0��61   $��2��6A    �� Target 5   #   ��  �� ElementName$ 	InputText��5   A   �� 5   
   -   5         ��Name$ 	InputText��5        	InputText#��[ 6%   $��1��6H   $��0��6U   $��2��6e   �� 5   
   -   5        $ 	PassLabel��5        	PassLabel#��[ 6L   $��	Password:��5      $��1��6$   $��0��61    5   #   �� $ 	PassInput��5   1   G� 5   
   -   5        	 G�Name$	 	PassInput��5        	PassInput#��[ 6)   $��1��6L   $��0��6Y   $��2��6i   �� 5   
   -   5        
 ��Name$
 LoginBtn��5        LoginBtn#��[ 6#   $��Login��6E   $��3��6U   $��0��6b   6r   �� 5   
   -   5        $
 ExitBtn��5        ExitBtn#��[ 6"   $
��Exit��6C   $��3��6R   $��1��6_   6o   5      5      