   M S B A M L   `   `   `  ����J  FMusicPlayer.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MusicPlayer.WPF.ServicesMusicPlayer.WPF.Services  5      =#clr-namespace:MusicPlayer.WPF.ViewsMusicPlayer.WPF.Views  5      G(clr-namespace:MusicPlayer.WPF.PropertiesMusicPlayer.WPF.Properties  5
      R NMvvmCross.Platforms.Wpf, Version=8.0.2.0, Culture=neutral, PublicKeyToken=nullnLclr-namespace:MvvmCross.Platforms.Wpf.Views;assembly=MvvmCross.Platforms.WpfMvvmCross.Platforms.Wpf.Views 5      K GMusicPlayer.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcCclr-namespace:MusicPlayer.Core.ViewModels;assembly=MusicPlayer.CoreMusicPlayer.Core.ViewModels 5      *    $MusicPlayer.WPF.Views.NowPlayingView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =
converters&clr-namespace:MusicPlayer.WPF.Services     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MusicPlayer.WPF.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      9
properties(clr-namespace:MusicPlayer.WPF.Properties  5
      WviewLclr-namespace:MvvmCross.Platforms.Wpf.Views;assembly=MvvmCross.Platforms.Wpf  5      T
viewmodelsCclr-namespace:MusicPlayer.Core.ViewModels;assembly=MusicPlayer.Core  5      
������ $��14(�5      $��Medium"�5         MaterialDesignBody#���   5      ��5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension    � 	Resources  5      2   ,MusicPlayer.WPF.Services.TrackImageConverter  imageConverter2   ,MusicPlayer.WPF.Services.TrackMultiConverter  trackMultiConverter,   &MusicPlayer.WPF.Services.TimeConverter  timeConverter0   *MusicPlayer.WPF.Services.PlayIconConverter  iconConverter��%t   &	       &	      &	 &     &	 9       5   
   6)     5   
   6)     5   
   6#     5   
   6'   5      .��5      � .+�5    
   ��   PrimaryDarkColor#���  6    J� Opacity$	 0.2Q�6A   (� 5#   
   $	��400��5$      $
��1020��5%      $
��Left=�5&      $��Bottom=�5'       (� Stretch$ Uniform=�5(       (� StretchDirection$
 Both=�5)      .��5+      A� $	��350��5,      $��20q�5-      $
��Left=�5.       A� Columns$ 2��5/      .+�50      #  MaterialDesignThemes.Wpf.Card  -   5        $��LeftSide��51      $	��450��53      $��	40,0,0,40q�54      $��Bottom=�55      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�56         UniformCornerRadius$ 5Q�57      ��52      ��  �� RelativeSource ��  �� Mode$
 Self=�	 �� Path$	 ActualWidth���58      �� 59      
 �� ImageSource
 5:      `� 5;   "    `� 	Converter# [ 6/   .1�5<   &   �� $	 SelectedTrack�6.    �� UpdateSourceTrigger$ PropertyChanged=�6C   �� 5=   &   $	 HighResolution�6.   /  )MusicPlayer.WPF.Properties.GlobalSettings   Default �� Source# Z 6D   5>   #   5@      .��5C      �  � RowDefinitions 5D      �� 5E      $	��10* �6,   �� 5F      $��2* �6,    � ColumnDefinitions 5H      �� 5I      �� 5J      �� 5K      �� 5L      .+�5N        $��1��5O      $��4��5P      #���  5Q      $
 0.93Q�5R      �� 5T      $��1��5U      $��0��5V      $��55��5W      $��50��5X      $��0q�5Y      
������   MaterialDesignFlatButton#���  5\      ��5[      �� *ReturnCommand+.��5]      �� $��30��5^   !   $��30��5_   !    �� BitmapScalingMode$ HighQuality=�5`   !     	Equalizer#���  5a   !   $
��Fill=�5b   !   5c      �� 5d      $��1��5e      $��1��5f      $��55��5g      $��50��5h      $��0q�5i      
������ #���  5l      ��5k      �� *ReturnCommand+.��5m      �� $��35��5n   !   $��30��5o   !   $ HighQuality=�5p   !     LyricsButton#���  5q   !   $��Uniform=�5r   !   5s      �� 5t      $��1��5u      $��2��5v      $��55��5w      $��50��5x      $��0q�5y      
������ #���  5|      ��5{      �� *MoreCommand+.��5}      �� $��35��5~   !   $��30��5   !   $ HighQuality=�5�   !    		 Queue#��� 	 5�   !   $
��Fill=�5�   !   5�      �� 5�      $��1��5�      $��3��5�      $��55��5�      $��50��5�      $��0q�5�      
������ #���  5�      ��5�      �� *MoreCommand+.��5�      �� $��35��5�   !   $��30��5�   !   $ HighQuality=�5�   !    
 More#��� 
 5�   !   $
��Fill=�5�   !   5�      5�      5�      � 5�      -   5         �Name$ 	RightSide��5�      $��1��5�      $	��350��5�      $��	40,0,0,40q�5�      $��Bottom=�5�      $y�Hidden=�5�      ��5�      ��  �� $
 Self=�$	 ActualWidth�.+�5�        $��Bottom=�5�      #���  5�      $
 0.85Q�5�      $ 5Q�5�      ��5�      ��  �� $
 Self=�$	 ActualWidth�5�      �� 5�      $��18(�5�      $��Medium"�5�        ForegroundLightColor#���  5�       " MaterialDesignCaptionTextBlock#��[ 5�      $
��Wrap=�5�      $y�Hidden=�5�      ��5�      �� *SelectedTrack.Title+$ PropertyChanged=�5�      5�      5�      5�      5�      5�      