   M S B A M L   `   `   `  ����I  EInkDrawExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:InkDrawExample.MyInksInkDrawExample.MyInks  5   	       InkDrawExample.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2my#clr-namespace:InkDrawExample.MyInks     5   	     � Title$  
MainWindow��5   	   $	��458��6   $	��955��6)   .��5      � .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $
��Left=�6   $	��Top=�6,   $	��136��6D   $	��950��6Q    � 	Resources 5      6  0System.Windows.Controls.Ribbon.RibbonRadioButton �� 
TargetType �� Property �� Value��%  '        �� 5	      "  6   .�5
      ��  �@ LargeImageSource$ images/b1.png��69   �� 5       �@ SmallImageSource$ images/b1.gif��69   �� 5       �@ CornerRadius$ 13��65   �� 5       � ��$ 5 0 0 0q�6/   -   5        5      5         ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      -   5          Name$ appMenu1��5   (   $y�Visible=�6:    � ToolTip$ 菜单��6O    5      >  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem3  -System.Windows.Controls.Ribbon.RibbonMenuItem��%w   '        �� 5      "  6    .�5      ��  �@ ImageSource$ images/b1.gif��6<   -   5        5      5      .@�5        $��打开��60     5      $��	另存为��60     5      $��退出��60   5      .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  .@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  $��墨迹类型��6      GroupSizeDefinitions 5!      >  8System.Windows.Controls.Ribbon.RibbonGroupSizeDefinition  	   ControlSizeDefinitions.	 5"      @	  :System.Windows.Controls.Ribbon.RibbonControlSizeDefinition	  
 	  	ImageSize$
 Small=�6:   	  5#      $
 Small=�6:   	  5$      $
 Small=�6:   	  5%      $
 Small=�6:   	  5&      $
 Small=�6:   	  5'      $
 Small=�6:   	  5(      $
 Small=�6:   	  5)      $
 Small=�6:   	  5*      $
 Small=�6:   5+      .@�5-        -   5          Name$ rrbEllipseType��5-   (      Label$ 球形��6@    d� 	IsChecked$ FalseY�6K     5.      $ 矩形��6(     5/      $ 视频��6(     50      $ 球形序列��6(     51      $ 矩形序列��6(     52      $ 图像序列��6(     53      $ 直线��6(     54      $ 曲线��6(     55      $ 文字��6(   56        57      $��笔尖类型��6   .@�58        -   5        $ rrbEllipseStylus��58   (   $ 圆笔��6B   $
 TrueY�6M    	� 	GroupName$
 edit��6^     59      $ 竖笔��6(   $
 edit��63     5:      $ 横笔��6(   $
 edit��63     5;      $ 钢笔��6(   $
 edit��63   5<        5=      -   5          Name$ rgColor��5=      $��笔尖颜色��6/    5?        .	 5@      	  $
 Small=�6:   	  5A      $
 Small=�6:   	  5B      $
 Small=�6:   5C      .@�5E        -   5        $ rrbRed��5E   3   $ 红色��6(   $
 TrueY�6C     5F      $ 蓝色��6(     5G      $ 绿色��6(   5H        5I      -   5        $ rgWidth��5I      $��笔尖大小��6/    5K        .	 5L      	  $
 Small=�6:   	  5M      $
 Small=�6:   	  5N      $
 Small=�6:   	  5O      $
 Small=�6:   	  5P      $
 Small=�6:   	  5Q      $
 Small=�6:   5R      .@�5T        $ 2��6(     5U      $ 6��6(     5V      -	   5        $ 	rrbRadius��5V   (   $ 12��6;   $
 TrueY�6F     5W      $ 18��6(     5X      $ 24��6(     5Y      $ 30��6(   5Z        5[      -
   5        $ rgFill��5[      $��填充类型��6.    5]        .	 5^      	  $
 Small=�6:   	  5_      $
 Small=�6:   	  5`      $
 Small=�6:   5a      .@�5c        -   5        $ rrbLine��5c   (   $ 线性渐变��69   $
 TrueY�6F     5d      $ 仿射渐变��6(     5e      $ 纯色��6(   5f        5g      $��绘制选项��6    5i        .	 5j      	  $
 Small=�6:   	  5k      $
 Small=�6:   	  5l      $
 Small=�6:   5m      .@�5o        -   5        $ rrbAll��5o   (   $ 全部��68   $
 TrueY�6C     5p      $ 	仅填充��6(     5q      $ 	仅轮廓��6(   5r        5s      $��缩放选择��6    5u        .	 5v      	  $
 Small=�6:   	  5w      $
 Small=�6:   	  5x      $
 Small=�6:   5y      .@�5{        $ 套索选择��6(   $
 edit��65     5|      $ 全选��6(   $
 edit��63     5}      $ 	全不选��6(   $
 edit��64   5~        5      $��	橡皮擦��6    5�        .	 5�      	  $
 Small=�6:   	  5�      $
 Small=�6:   	  5�      $
 Small=�6:   5�      .@�5�        $ 墨迹擦除��6(   $
 edit��65     5�      $ 笔画擦除��6(   $
 edit��65     5�      $ 全部删除��6(   $
 edit��65   5�      5�      5�      '
  !InkDrawExample.MyInks.MyInkCanvas
  5�   
   -   5         
 Name$ myinkcanvas��5�      $��	0,135,0,0q�6.   6C   5�      5�      