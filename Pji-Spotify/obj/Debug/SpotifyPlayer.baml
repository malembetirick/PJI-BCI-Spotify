   M S B A M L   `   `   `  ����F  BPji-Spotify, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Pji_SpotifyPji_Spotify  5   	       Pji_Spotify.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   %localclr-namespace:Pji_Spotify  5   	     � Title$  
MainWindow��5	   	   $	��650��6   $	��525��6)    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.New��5      6X     5   
   -   5        $ ApplicationCommands.New��5      6U     5   
   -   5        $ ApplicationCommands.New��5      6U     5   
   -   5        $ ApplicationCommands.New��5      6U     5   
   -   5        $ ApplicationCommands.New��5      6V     5   
   -   5        $ ApplicationCommands.New��5      6U     5   
   -   5        $ ApplicationCommands.New��5      6S   .��5      � .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $��68��6T   $��
178,10,0,0q�6`   $	��Top=�6t   $	��329��6�   ._�5      �� "  WpfAnimatedGif.ImageBehavior   RepeatBehavior$ 1000x��6      AnimatedSource$ musicreal.gif��6=   $
��Fill=�6n   5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��550��6T   $��	10,10,0,0q�6a   $	��Top=�6t   $	��163��6�   ._�5      �� -   5         ��Name$ 
textBlock1��5      $
��Wrap=�6,   $��Emotions��6@   5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��480��6T   $��
178,83,0,0q�6a   $	��Top=�6u   $	��329��6�   ._�5      �� .+�5      �� -	   5        $	��con��5      $��ApplicationCommands.New��6$   $��	Connexion��6F   �� 5      -
   5        $��playTextBox��5      $�� ��6-   �� 5      -   5        $��playUrl��5      $��ApplicationCommands.New��6(   .��6_   	PlayURL6h   �� 5       -   5        $
��play��5       $��ApplicationCommands.New��6%   .��6^   Play6d   �� 5!      -   5        $��pause��5!      $��ApplicationCommands.New��6&   .��6`   Pause6g   �� 5"      -   5        $
��prev��5"      $��ApplicationCommands.New��6%   .��6^   
Previous6h   �� 5#      -   5        $
��skip��5#      $��ApplicationCommands.New��6%   .��6^   Skip6d   �� 5$      -   5        $
��alea��5$      $��ApplicationCommands.New��6%   .��6^   Skip aleatoire6n   �� 5%      -   5        $ tb��5%      $
��Wrap=�6(   $��
Track info��6<   �� 5&      -   5         ��Name$ smallAlbumPicture��5&      $�� ��63   �� 5'      -   5        $	 tb1��5'      $
��Wrap=�6)   $��Titre��6=   �� 5(      -   5        $ titleLinkLabel��5(      $�� ��60   �� 5)      -   5        $	 tb2��5)      $
��Wrap=�6)   $��Artiste��6=   �� 5*      -   5        $ artistLinkLabel��5*      $�� ��61   �� 5+      -   5        $	 tb3��5+      $
��Wrap=�6)   $��Album��6=   �� 5,      -   5        $ albumLinkLabel��5,      $�� ��60   �� 5-      -   5        $	 tb5��5-      $
��Wrap=�6)   $��
Is playing��6=   �� 5.      -   5        $ isPlayingLabel��5.      $�� ��60   �� 5/      -   5        $	 tb6��5/      $
��Wrap=�6)   $��Volume��6=   �� 50      -   5        $ volumeLabel��50      $�� ��6-   �� 51      -   5        $	 tb4��51      $
��Wrap=�6)   $��Temps��6=   �� 52      -   5        $ 	timeLabel��52      $�� ��6+   � 53      -   5        $��timeProgressBar��53   8    � Minimum$ 0Q�6    � Maximum$	 100Q�6*   	 � Value$	 50Q�6P   54      55      56      57      