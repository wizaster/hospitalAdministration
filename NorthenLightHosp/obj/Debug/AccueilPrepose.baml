   M S B A M L   `   `   `  ����K  GNorthenLightHosp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NorthenLightHospNorthenLightHosp  5   	   %    NorthenLightHosp.AccueilPrepose   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NorthenLightHosp     5   	     � Title$  AccueilPrepose��5   	   $��363.428��6    $��438.149��61   .��5	      � .+�5
   
   �� -   5         ��Name$ lblGreeting��5
      $��Bonjour��6%   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   �� 5   
   -   5        $ label��5      $��Trouver patient : ��6   $
��Left=�6<   $��	10,48,0,0q�6W   $	��Top=�6j   �� 5   
   -   5         ��Name$ txtRecherche��5      $
��Left=�6(   $��23��6C   $��
114,52,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��295��6�   6�   �� 5   
   -   5         ��Name$ btnMiseAJour��5      $ ��Mettre A jour informations��6'   $
��Left=�6L   $��
10,232,0,0q�6g   $	��Top=�6{   $	��151��6�   {�.  6�   �� 5   
   -   5        $ btnAdmission��5      $��Nouvelle Admission��6'   $
��Left=�6D   $��
10,256,0,0q�6_   $	��Top=�6s   $	��151��6�   {�.  6�   �� 5   
   -   5        $ btnNouveauPatient��5      $��Nouveau Patient��6,   $
��Left=�6F   $��
10,280,0,0q�6a   $	��Top=�6u   $	��151��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgPatientTrouver��5      $
��Left=�6-   $��	10,75,0,0q�6H   $	��Top=�6[   $	��148��6s   $	��399��6�      AutoGenerateColumns .     
IsReadOnly . ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 prenom��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *prenom+  5      $		 nom��6%   
 62   �� *nom+  5      $	 date de naissance��6%   
 6@   �� *date_naissance+5      5      5      