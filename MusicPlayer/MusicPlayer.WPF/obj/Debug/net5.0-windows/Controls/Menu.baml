   M S B A M L   `   `   `  ����J  FMusicPlayer.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MusicPlayer.WPF.ControlsMusicPlayer.WPF.Controls  5      #    MusicPlayer.WPF.Controls.Menu   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MusicPlayer.WPF.Controls     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesing1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      .��5      ]� .+�5   
   �� $	��Top=�5      ��5      ��   �� RelativeSource  ��  �� Mode$ FindAncestor=� �� AncestorType 
local:Menu �� Path$ ExpandedWidth�y�5      ��   �� $ FindAncestor=� 
local:Menu$ MenuExpanded� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5        $��45��5      $��45��5      $��15q�5      $��0q�5      $
��Left=�5      $	��Top=�5         ForegroundLightColor#���   5        MaterialDesignFlatButton#���  5      .��5      �� $��18��5       �� BitmapScalingMode$ HighQuality=�5        Menu#���  5      5      �� 5!   
   $
��Auto��5#      $��5,0,5,0q�5$      $��0q�5%      $
��Left=�5&      $	��Top=�5(      #���  5)      ��5"      ��  �� ElementName$
 line��$ ActualWidth���5'      �� *
ShowHome+.��5*      ��  �� Orientation$ 
Horizontal=�6   .+�5+      �� $��45��5,      $��45��5-       �� Padding$ 5q�5.      ._�5/      �� $��23��50      $ HighQuality=�51       	 Waves#���  52      53      �� 54      $
��Auto��55      $��20,0,0,0q�56      $��Center=�57      $��15(�58      $
��Bold"�59        ForegroundMidColor#���  5:      y�5;      ��   �� $ FindAncestor=� 
local:Menu$ MenuExpanded�$ PropertyChanged=�.��6�   
My music5=      5>      5?      �� 5A   
   $
��Auto��5C      $��5,0,5,0q�5D      $��0q�5E      $
��Left=�5F      $	��Top=�5G      #���  5H      ��5B      �� $
 line��$ ActualWidth�.��5I      �� $ 
Horizontal=�6   .+�5J      �� $��45��5K      $��45��5L      $ 5q�5M      ._�5N      �� $��23��5O      $ HighQuality=�5P        Library#���  5Q      5R      �� 5S      $
��Auto��5T      $��20,0,0,0q�5U      $��Center=�5V      $��15(�5W      $
��Bold"�5X      #���  5Y      y�5Z      ��   �� $ FindAncestor=� 
local:Menu$ MenuExpanded�$ PropertyChanged=�.��6�   Browse5\      5]      5^      �� 5`   
   $
��Auto��5b      $��5,0,5,0q�5c      $��0q�5d      $
��Left=�5e      $	��Top=�5g      #���  5h      ��5a      �� $
 line��$ ActualWidth���5f      �� *	ShowQueue+.��5i      �� $ 
Horizontal=�6   .+�5j      �� $��45��5k      $��45��5l      $ 5q�5m      ._�5n      �� $��23��5o      $ HighQuality=�5p       	 Queue#���  5q      5r      �� 5s      $
��Auto��5t      $��20,0,0,0q�5u      $��Center=�5v      $��15(�5w      $
��Bold"�5x      #���  5y      y�5z      ��   �� $ FindAncestor=� 
local:Menu$ MenuExpanded�$ PropertyChanged=�.��6�   Now Playing5|      5}      5~      �� 5�   
   -   5        $
��line��5�      $��2��5�      $��	15,5,15,5q�5�        ForegroundDarkColor#���  5�      	 �� CornerRadius$	 1��5�      $	��Top=�5�      
 J� Opacity$	
 0.3Q�5�      �� 5�   
   $
��Auto��5�      $��5,0,5,0q�5�      $��0q�5�      $
��Left=�5�      $	��Top=�5�      #���  5�      ��5�      �� $
 line��$ ActualWidth�.��5�      �� $ 
Horizontal=�6   .+�5�      �� $��45��5�      $��45��5�      $ 5q�5�      ._�5�      �� $��23��5�      $ HighQuality=�5�        	Playlists#���  5�      5�      �� 5�      $
��Auto��5�      $��20,0,0,0q�5�      $��Center=�5�      $��15(�5�      $
��Bold"�5�      #���  5�      y�5�      ��   �� $ FindAncestor=� 
local:Menu$ MenuExpanded�$ PropertyChanged=�.��6�   	Playlists5�      5�      5�      �� 5�   
   $��15,0,5,0q�5�      $	��Top=�5�      ��5�      �� *Width+  �� $ FindAncestor=� UserControl��5�      �� *InnerContent+  �� $ FindAncestor=� UserControl � DataContext 5�      �� *DataContext+  �� $ FindAncestor=� UserControl5�      5�      5�      