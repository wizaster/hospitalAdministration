   M S B A M L   `   `   `  ����K  GNorthenLightHosp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NorthenLightHospNorthenLightHosp  5   	   (    "NorthenLightHosp.nouvelleAdmission   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NorthenLightHosp     5   	     � Title$  nouvelleAdmission��5   	   $��365.011��6#   $��346.049��64   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Nouvelle admission��6   $
��Left=�6<   $��	10,10,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ label1��5      $��	Patient :��6    $
��Left=�64   $��	10,41,0,0q�6O   $	��Top=�6b   �� 5   
   -   5        $ lblInfoPatient��5      $��patient info��6(   $
��Left=�6?   $��	10,72,0,0q�6Z   $	��Top=�6m   $	��321��6�   �� 5   
   -   5         ��Name$ 
btnmodifer��5      $��Modifier��6%   $
��Left=�68   $��
240,47,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5         ��Name$ groupBox��5      $��	Admission��6%   $
��Left=�68   $��
10,108,0,0q�6S   $	��Top=�6g   $	��189��6   $	��321��6�   .��5      � $
��Left=�6   $	��166��6.   $��0,10,-0.2,0q�6;   $	��Top=�6P   $	��309��6h   .+�5      �� -   5        $ label3��5      $��Date d'admission:��6(   $
��Left=�6D   $��	10,10,0,0q�6_   $	��Top=�6r   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dateAdmission��5      $
��Left=�64   $��
197,11,0,0q�6O   $	��Top=�6c   �� 5      -   5        $ label4��5      $��Raison de l'admission:��6(   $
��Left=�6I   $��	10,41,0,0q�6d   $	��Top=�6w   �� 5      -	   5        $ label5��5      $�� ��6(   $
��Left=�63   $��
10,100,0,0q�6N   $	��Top=�6b   �� 5      -
   5        $ label6��5      $��médecin attitré:��6(   $
��Left=�6C   $��
10,103,0,0q�6^   $	��Top=�6r   �� 5      -   5         ��Name$ cbxRaisonAdmission��5      $
��Left=�67   $��
141,44,0,0q�6R   $	��Top=�6f   $	��158��6~    �� SelectedValuePath$ id��5   3    �� DisplayMemberPath$ designation��6J   ��6   �� 6J   �� 5      -   5        $ 
cbxMedecin��5      $
��Left=�6/   $��141,106,0,0q�6J   $	��Top=�6_   $	��158��6w   $ id��5   3   ��6   �� ��5      �� 5      .R�5      �� ��5   "   `� 5   &    �� StringFormat$ {0} {1}��63   .1�5   *   �� 	 �� Path$	 prenom�62   �� 5   *   $		 nom�62   5    '   5"      5#      5%      �� 5&      -   5        $ btnCommentaire��5&      $��Commentaire��61   $
��Left=�6G   $��197,133,0,0q�6b   $	��Top=�6w   $	��102��6�   6�   �� 5'      -   5        $ label2��5'      $��Département:��6(   $
��Left=�6?   $��	10,72,0,0q�6Z   $	��Top=�6m   �� 5(      -   5        $ cbxDepartement��5(      $
��Left=�63   $��
141,75,0,0q�6N   $	��Top=�6b   $	��158��6z   $ id��5)   3   $ designation��6J   ��6   �� 6J   5*      5+      �� 5,   
   -   5        $ 
btnValider��5,      $��Valider��6%   $
��Left=�67   $��240,302,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5-   
   -   5        $ 
btnAnnuler��5-      $��Annuler��6%   $
��Left=�67   $��133,302,0,0q�6R   $	��Top=�6g   $��75��6   6�   5/      50      