   M S B A M L   `   `   `  ����F  BWpfSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfSolution.ControlsWpfSolution.Controls  5      ?$clr-namespace:WpfSolution.ViewModelsWpfSolution.ViewModels  5      )    #WpfSolution.Controls.FileUploadView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WpfSolution.Controls     5      3vm$clr-namespace:WpfSolution.ViewModels     5      .��5      �   � RowDefinitions  5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��50 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� $
��File��6   $
��10 0q�6$   $��Center=�62   6P   �� 5      -   5        $��
tbFilePath��5      $	��300��6p   $��2q�6|   $
��Left=�6�   ��6(   ��  �� Path$ FilePath� �� Mode$ TwoWay=� �� NotifyOnTargetUpdated . 6�   �� 5      -   5        $	��...��5      $��50��69   $
��10 0q�6D   �� 5      $��Upload File��6   $	��100��6V   $
��10 0q�6b   ��6+   �� $ UploadFileCommand�6b   5      �� 5   
   $��2��6   .+�5      �� $��Progress��6   $
��10 0q�6(   $	��Top=�66   � 5      $
��10 0q�6s   $	��500��6�   $
��Left=�6�   $��20��6�    � Value 6   �� *CurrentProgress+$ OneWay=�y�6I   �� *ProgressVisibility+6�   5      �� 5   
   $��3��6   $ 
Horizontal=�6"   .+�5       �� $��Successful transactions :��6   $
��10 0q�69   �� 5!      $
��10 0q�6>   ��6   �� $ CountSuccessful�6>   5"      �� 5$   
   $��4��6   $ Vertical=�6"   .+�5%      �� $��Failed transactions :��6   $
��10 0q�64   &   System.Windows.Controls.DataGrid  5&         AutoGenerateColumns .  $
��10 0q�6^   $	��400��6l   ��6   �� *FailedTransactions+   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Row Number��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *	RowNumber+  5)      $ Account��6)   	 6:   �� *Code+  5*      $ Description��6)   	 6>   �� *Description+  5+      $ Currency��6)   	 6;   �� *
Currency+  5,      $ Amount��6)   	 69   �� *Amount+  5-      $ Error Description��6)   	 6D   �� *ErrorString+5/      50      51      52      