   M S B A M L   `   `   `  ����C  ?stickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:stickets.Assets.UserControlsstickets.Assets.UserControls  5      *    $stickets.Assets.UserControls.AddUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:stickets.Assets.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	      $��15(�5   8   
�������.��5
      � $	��280��6   $
��1500��6   .+�5   
   ��   �� CornerRadius$  40��6   $	��260��6#   $
��1480��60   
���   �._�5      �� $  40��6   
���  ��$	��250��6<   $
��1470��6I   ._�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5      �� .+�5      �� $ 
Horizontal=�6)   .+�5   "   �� -   5         ��Name$ 
SecondName��5   *   $	��250��6>   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия��6J   
�������6�   �� 5   "   �� 5   "   -   5        $ 	FirstName��5   *   $	��250��6=   $ Имя��6I   
�������6�   �� 5   "   �� 5   "   -   5        $ 
Patronymic��5   *   $	��250��6>   $ Отчество��6J   
�������6�   5      �� 5      $��20��6$   �� 5      $ 
Horizontal=�6)   $��Center=�6B   .+�5   "   �� -   5        $ Phone��5   *   $	��250��69    �� 	MaxLength$ 11��6E   $ Телефон��6T   
�������6�   �� 5   "   �� 5   "   -   5        $ Email��5   *   $	��250��69   $' !Электронная почта��6E   
�������6�   5      �� 5      $��20��6$   �� 5      -   5        $ Passport��5   &   $	��250��68   $ 11��6D   $1 +Серия и номер пасспорта��6S   
�������6�   �� 5      $��20��6$   �� 5       $ 
Horizontal=�6)   $��Center=�6B   .+�5!   "   �� .+�5"   &   �� -   5        $ Login��5"   .   $	��250��6=   $ 
Логин��6I   
�������6p   �� 5#   &   $��20��6,   �� 5$   &   -   5        $ Passcode��5$   .   $	��250��6@   $ Пароль��6L   
�������6t   5%   #   �� 5&   "   �� 5'   "   -	   5         ��Name$
 Role��5'   +   $	��250��69   $ Должность��6E   
���   �6p   5)      5*      �� 5+      &   System.Windows.Controls.Calendar  5,      -
   5          Name$ 	Birthdate��5,   #   $	��300��66   $	��250��6B   
�������
���  ��6y   �� 5-      �� 5.      $��Center=�6%   .+�5/      �� -   5         ��Name$
 Edit��5/   %   $��50��63   .��50   "   �� $
��Wrap=�6,   $	��100��6@    �� TextAlignment$ Center=�6L   '%Добавить сотрудника6x   51      52      53      54      55      56      57      58      