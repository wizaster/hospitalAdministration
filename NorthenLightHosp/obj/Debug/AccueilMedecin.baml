   M S B A M L   `   `   `  ����K  GNorthenLightHosp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NorthenLightHospNorthenLightHosp  5   	   %    NorthenLightHosp.AccueilMedecin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NorthenLightHosp     5   	     � Title$  AccueilMedecin��5   	   $��381.264��6    $��545.824��61   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��393* �6   �� 5      $��5* �6   �� 5      $
��142* �6   .+�5   
   �� -   5         ��Name$ lblGreeting��5      $��	Bonjour, ��6%   $
��Left=�69   $��	31,10,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ label1��5      $��Recherche :��6    $
��Left=�66   $��	31,41,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5         ��Name$ txtRecherche��5      $
��Left=�6(   $��23��6C   $��
106,45,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��142��6�   �� 5   
   -   5         ��Name$ 
cboPatient��5      $
��Left=�6'   $��
31,103,0,0q�6B   $	��Top=�6V   $	��217��6n   $ �� IsSynchronizedWithCurrentItem$
 trueY�5       �� SelectedValuePath$ 	id_client��6P   ��68   �� ��5      �� 5      .R�5      �� ��5      `� 5       �� StringFormat$ {0} {1}��6+   .1�5   "   �� 	 �� Path$	 prenom�6*   �� 5   "   $		 nom�6*   5      5      5      5       �� 5!   
   -   5        $ label2��5!      $��Liste patients :��6    $
��Left=�6;   $��	31,72,0,0q�6V   $	��Top=�6i   &   System.Windows.Controls.DataGrid  5"   
   -   5        
  Name$
 
dgPatients��5"      $
��Left=�6'   $��
10,130,0,0q�6B   $	��Top=�6V   $��74��6n   $	��480��6z   $��3��6�      AutoGenerateColumns .     
IsReadOnly .    CanUserSortColumns .  ��5#      ��    Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ prenom��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *prenom+  5&      $	 nom��6%    62   �� *nom+  5'      $ date d'admission��6%    6?   �� *date_admission+  5(      $ raison d'admission��6%    6A   �� *raison_admission+5*      �� 5+   
   -   5         ��Name$ btnConge��5+      $��Donner conge��6#   $
��Left=�6:   $��2.466,103,0,0q�6U   $	��Top=�6l   $��90��6�   $��2��6�   6�     5,   
   -   5        $
 dgHistorique��5,      $
��Left=�6)   $��10,240,0,10q�6D   $��3��6Y   $	��480��6m    .   .  ��5-      ��  5.        5/      $ date d'admission��6%    6?   �� *date_admission+  50      $ date de congé��6%    6<   �� *
date_conge+  51      $ raison d'admission��6%    6A   �� *raison_admission+  52      $ médecin��6%    66   �� *	medecin+54      �� 55   
   -	   5        $ label��55      $��historique :��6   $
��Left=�66   $��
10,209,0,0q�6Q   $	��Top=�6e   57      58      