   M S B A M L   `   `   `  ����F  BAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AudioPlayer.ViewAudioPlayer.View  5   	   $    AudioPlayer.View.AddSongWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AudioPlayer.View     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconsPack-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5          � Title$  AddSongWindow��5	   	   $	��450��6   $	��500��6,    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� Source�� 5   
   $ /Resources/Styles.xaml?�6   %    .��5      ��    SideNavigationBarColor#��[  6    �� CornerRadius$ 15��5        MainYellowColor#��[ 5      $��2q�5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    .+�5       � $��0��6   	 � ColumnDefinitions	 5!      �� 5"      $��* �6'   �� 5#      $
��auto �6'   .+�5%      �� $��0��6   $:��4Добавление новой композиции��5&        	TextColor#��[ 5'      $��5q�5(      $��15(�5)      �� 5*      $��1��6   $	��Top=�5+      
 �� Orientation$
 
Horizontal=�5,      $��0q�5-      .+�5.      �� -   5          WindowButtonStyle#��[ 5.      $��5q�5/      .��51      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Close=�65   $��11��6B   $��15��6N   #��[ 6Y   52      53      54      � 56      $��1��6    57      �� 58      $
��auto �6$   �� 59      $
��auto �6$   �� 5:      $
��auto �6$   �� 5;      $��* �6$   .+�5>      �� $��0��6   $��9,30,9,0q�5?      .+�5@      �� $��Путь к песни��6   $��0q�5A        MainOrangeColor#��[ 5B      $��0,0,0,4q�5C      $��21(�5D      $��Medium"�5E      �� 5F      $
 
Horizontal=�6!   .+�5G      �� $��22��6"     SongInfoTextBox#��[ 5H      $	��400��5J      ��5I      �� *
SongPath+5J      �� 5K        BrowseButtonStyle#��[ 6!   $��4,0,0,0q�5M      $��Center=�5N      ��5L      �� *BrowseCommand+.��5O        #��[ 69   $ Magnify=�6g   $��13��6v   $��13��6�   5P      5Q      5R      �� 5T      $��1��6   $��9,30,9,0q�5U      .+�5V      �� $!��Название песни��6   #��[ 5W      $��0q�5X      $��0,0,0,4q�5Y      $��21(�5Z      $��Medium"�5[      �� 5\      $��22��6   #��[ 5]      $	��400��5^      $
��Left=�5`      ��5_      �� *
SongName+5`      5a      �� 5c      $��2��6   $��9,30,9,0q�5d      .+�5e      �� $��Исполнитель��6   #��[ 5f      $��0q�5g      $��0,0,0,4q�5h      $��21(�5i      $��Medium"�5j      �� 5k      $��22��6   $	��400��5l      #��[ 5m      $
��Left=�5o      ��5n      �� *
PlayerName+5o      5p      �� 5r        OkButtonStyle#��[ 6   $��OK��5t      #��[  5u      $��3��5v      $��Right=�5w      $��Bottom=�5x      $��10q�5y      ��5s      �� *	OkCommand+5y      5z      5{      5|      5}      