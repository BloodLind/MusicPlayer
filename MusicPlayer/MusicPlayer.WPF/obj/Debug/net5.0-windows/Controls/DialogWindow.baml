   M S B A M L   `   `   `  ����J  FMusicPlayer.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MusicPlayer.WPF.ControlsMusicPlayer.WPF.Controls  5      +    %MusicPlayer.WPF.Controls.DialogWindow   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MusicPlayer.WPF.Controls     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � Title$  DialogWindow��5	      $	��400��5
      $	��250��5       J� 	AllowDrop$
 True��5       � AllowsTransparency$
 True��5      
������  � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      .+�5   
   �� $��2��5         PrimaryMidColor#���   5       J� Opacity$
 0.96Q�5      �� 5   
   $��25,40,25,25q�5      $��Center=�5      $��18(�5        ForegroundLightColor#���  5        �� TextAlignment$ Center=�5"      $
��Wrap=�5#      ��5!      ��  �� RelativeSource �� 	 �� Mode$	 FindAncestor=�
 �� AncestorType
 local:DialogWindow �� Path$ Message�5#      � 5$   
   $	��Top=�6   $	��Top=�6'   .+�5%      #  MaterialDesignThemes.Wpf.Card  -   5        $��24��5&      $��40��5'      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5(      #���   5)      $
 0.75Q�5+      .��5-      �� -   5        $��50��5.      $��25��5/      $��Right=�50        MaterialDesignFlatButton#���  52      .��53      '  !MaterialDesignThemes.Wpf.PackIcon  $��17��54      $��17��55      #���  56         Kind$ WindowClose=�57      58      5:      5;      A� 5=   
   $��1��6    A� Columns$ 2��6#   .+�5>      �� -   5        $��15q�5?        PrimaryDarkColor#���  5@      $	��Yes��5B      $��18(�5C      #���  5D      #���  5E      �� 5F      -   5        $��15q�5G      #���  5H      $��No��5J      $��18(�5K      #���  5L      5M      5N      5O      