   M S B A M L   `   `   `  ����C  ?WpfApp15, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApp15.ViewsWpfApp15.Views  5      %    WpfApp15.Views.HaberListesiPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfApp15.Views     5        N� Title$  HaberListesiPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   $	��100��6,   �� 5      .+�5   
   �� -   5         ��Name$ TbFiltre��5      6$   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgKategoriler��5         
IsReadOnly .    AutoGenerateColumns .     VerticalGridLinesBrush �#999   HorizontalGridLinesBrush �#999$��1��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Kategori��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *KategoriAdı+5        5   
   -   5        $ 
DgHaberler��5       .  .  $��1��5        �#999 �#999$��1��5$      ��5!      �� *SelectedItem.Haberler+ �� ElementName$ DgKategoriler��	 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5'      $
 Resim��6)      CellTemplate 5(      �� 5)      .R�5*      �� $��50��6=   ��6$   �� *Resim+6=   5+      5-        5/      $
 Tarih��6%      DikeyOrtalıStyle   ElementStyle# [  6^    64   �� *Tarih+ �� StringFormat$ d��6^     50      $
 Başlık��6%   # [  6P    65   �� *
Başlık+6P     51      $
 Okunma Sayısı��6%   # [  6]    6<   �� *OkunmaSayısı+6]    � ContextMenu 55      �� 56      .@�57      m� -   5        $	��Oku��57      6,   m� 58      -   5        $��Düzenle��58      60   m� 59      -   5        $	��Sil��59      6,   5:      5<      5>      5?      