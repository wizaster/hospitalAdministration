   M S B A M L   `   `   `  ����K  GNorthenLightHosp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NorthenLightHospNorthenLightHosp  5   	   $    NorthenLightHosp.ListePatients   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NorthenLightHosp     5   	     � Title$  ListePatients��5   	   $	��300��6   $	��300��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ txtRecherche��5
      $
��Left=�6(   $��23��6C   $��	10,10,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��274��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgPatients��5      $
��Left=�6'   $��	10,38,0,0q�6B   $	��Top=�6U   $	��193��6m   $	��274��6z      AutoGenerateColumns .     
IsReadOnly . ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ prenom��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *prenom+  5      $	 nom��6%    62   �� *nom+  5      $ date de naissance��6%    6@   �� *date_naissance+5      �� 5   
   -   5        	 ��Name$	 	btnDetail��5      $��Details��6$   $
��Left=�66   $��177,241,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $	 	btnFermer��5      $��Fermer��6$   $
��Left=�65   $��
41,241,0,0q�6P   $	��Top=�6d   $��75��6|   6�   5      5      