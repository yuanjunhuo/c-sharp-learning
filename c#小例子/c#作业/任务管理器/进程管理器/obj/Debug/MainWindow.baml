   M S B A M L   `   `   `  ����J  F进程管理器, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:进程管理器进程管理器  5   	        进程管理器.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:进程管理器     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $L��F                                        启动、停止、观察进程��6   $
��Left=�6M   $��39��6h   $��	10,10,0,0q�6t   $
��20px(�6�   $	��Top=�6�   $	��772��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	datagrid1��5      $
��Left=�6&   $	��298��6A   $��	10,49,0,0q�6N   $	��Top=�6a   $	��772��6y      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 进程Id��6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6=     5      $ 进程名称��6F    6%   �� *ProcessName+6F     5      $ 占用内存��6F    6%   �� *TotalMemory+6F     5      $ 启动时间��6C    6%   �� *	StartTime+6C     5      $ 文件路径��6C    6%   �� *
FileName+6C   5      �� 5   
   -   5        $��启动进程��5      $
��Left=�6    $��39��6;   $��142,370,0,0q�6G   $	��Top=�6\   $	��123��6t   6�   �� 5   
   -   5        $��结束进程��5      $
��Left=�6    $��39��6;   $��423,370,0,0q�6G   $	��Top=�6\   $	��140��6t   6�   5      5      