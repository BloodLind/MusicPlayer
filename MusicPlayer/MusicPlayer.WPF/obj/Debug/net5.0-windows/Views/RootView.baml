   M S B A M L   `   `   `  ����J  FMusicPlayer.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MusicPlayer.WPF.ControlsMusicPlayer.WPF.Controls  5      =#clr-namespace:MusicPlayer.WPF.ViewsMusicPlayer.WPF.Views  5      O,clr-namespace:MusicPlayer.WPF.InfrastructureMusicPlayer.WPF.Infrastructure  5
      $    MusicPlayer.WPF.Views.RootView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;controls&clr-namespace:MusicPlayer.WPF.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MusicPlayer.WPF.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      7view,clr-namespace:MusicPlayer.WPF.Infrastructure  5
      $	��750��5      $	��500��5        � AllowsTransparency$
  True��5       � 
ResizeMode$ 	CanResize=�5         Font#���   5       � WindowStyle$
 None=�5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6      ResizeBorderThickness$ 5q�6)    � 	Resources 5        ScrollBarLineButton �� 
TargetType �� Property	 �� Value  ScrollBarPageButton  ScrollBarThumb
 �� 
TargetType �� CornerRadius  VerticalScrollBar � RowDefinitions  ForegroundDarkColor ]� DecreaseRepeatButton ]� Thumb  ForegroundLightColor ]� IncreaseRepeatButton �� Triggers P� Property P� Value��%�  &	       &	 �     &	 �    &	 �    7  7  7  7  7  '�� B    7  �� 5   
   " ��6,   .�5      ��  � y�$	 Hidden=�6+   �� 5       �@J�SnapsToDevicePixels$
	 True��64   �� 5       �@�OverridesDefaultStyle$
	 true��66   �� 5        � |�$
	 True��6*   5"      �� 5$   
   " ��6,   .�5%      ��  � y�$	 Hidden=�6+   �� 5&       �@J�SnapsToDevicePixels$
	 True��64   �� 5'       �@�OverridesDefaultStyle$
	 true��66   �� 5(       � ��$	 false��6*   �� 5)       � |�$
	 True��6*   5*      �� 5,   
   " n�6'   .�5-      ��  �@J�SnapsToDevicePixels$
	 True��64   �� 5.       �@�OverridesDefaultStyle$
	 true��66   �� 5/       � ��$	 false��6*   �� 50       � |�$	 false��6*   �� 52       � ��	 53      �� 54      "
 n�6&   .R�55      �� $
��grip��56      $��7��57      $��8,0,-2,0q�58      #��z��59      #��z��5:      $��0q�5;      $ 2��5<      5=      5?      5@      �� 5B   
   "
 ��64   .R�5C      �  5D      �� 5E      $��0��6$   �� 5F      $��0.00001* �6$   �� 5G      $��0��6$   .+�5I      �� $��3��5J      $��5��5K      $��10.75,10,3,12q�5L      $��Center=�5M      #���  5N      $ 2��5O      �� 5P      $��0��5Q      $��18��5R      $��ScrollBar.LineUpCommand��5S      $��M 0 4 L 8 4 L 4 0 Z��5T      8��  5U      ]� 5V      $��
PART_Track��5W      $��1��5X      $��5��5Y      $
��true��5Z       5[      �� 5\      $��ScrollBar.PageUpCommand��6'   8�� 6I    5^      n� 5_      $��	1,0,2.5,0q�5`      #���  5a      8�� 5b       5d      �� 5e      $��ScrollBar.PageDownCommand��6'   8�� 6K   5h      �� 5i      $��3��5j      $��18��5k      $��ScrollBar.LineDownCommand��5l      $��M 0 0 L 4 4 L 8 0 Z��5m      8�� 5n      5p      5q      �� 5s   
   " ��6+   .�5t      ��  �@J�SnapsToDevicePixels$
	 True��64   �� 5u       �@�OverridesDefaultStyle$
	 true��66    5v      P� 5w       �@��Orientation$ Vertical=�61   . �5x      ��  � ��$	 18��6.   �� 5y       � ��$
	 Auto��6/   �� 5z       � ��8	   61   5{      5}      5      ��5�      �� 5�   
   .R�5�      � .+�5�      ��  ��Name$ 
Background��5�      $	��-25q�5�        
Background#���  5�      ]� 5�      $
��auto��6   $
��True��6*   .+�5�      � $	��Top=�5�       K� ZIndex$
 9999��5�      $	��Top=�5�      .+�5�      #  MaterialDesignThemes.Wpf.Card  -   5        $��24��5�      $��40��5�      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5�        PrimaryMidColor#���  5�       J� Opacity$
 0.95Q�5�         UniformCornerRadius$ 0Q�5�      .��5�      �� $��Right=�5�   !   $��Center=�5�   !    �� Orientation$ 
Horizontal=�5�   !   .+�5�   "   �� -   5        $��50��5�   %   $��25��5�   %    	 MaterialDesignFlatButton#��� 	 5�   %   .��5�   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��17��5�   )   $��17��5�   )   #���  5�   )      Kind$ WindowMinimize=�5�   )   5�   #   �� 5�   "   -   5        $��50��5�   %   $��25��5�   %   #��� 	 5�   %   .��5�   &     $��17��5�   )   $��17��5�   )   #���  5�   )   $ WindowMaximize=�5�   )   5�   #   �� 5�   "   -   5        $��50��5�   %   $��25��5�   %   #��� 	 5�   %   .��5�   &     $��17��5�   )   $��17��5�   )   #���  5�   )   $ WindowClose=�5�   )   5�   #   5�      5�      5�      +   %MusicPlayer.WPF.Controls.TrackControl  5�        Name$ TrackControl��5�      $	��110��5�      $��Bottom=�5�       � DataContext 5�      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType view:CustomWindow �� Path$ DataContext�5�      #   MusicPlayer.WPF.Controls.Menu  5�         Name$
  Menu��5�      !   ExpandedWidth$	! 225Q�5�      "   MenuExpanded$" Visible=�5�       5�      ��  �� $ FindAncestor=� view:CustomWindow$ DataContext�#   InnerContent# 5�      /   )MusicPlayer.WPF.Controls.PlaylistMenuList  5�      5�      �� 5�      $ ��Name$$ ContentPage��5�      $��Right=�5�      ��5�      �� 5�      5�      5�      5�      5�      