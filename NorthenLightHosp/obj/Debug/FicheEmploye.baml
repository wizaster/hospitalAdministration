   M S B A M L   `   `   `  ����K  GNorthenLightHosp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NorthenLightHospNorthenLightHosp  5   	   #    NorthenLightHosp.FicheEmploye   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NorthenLightHosp     5   	     � Title$  FicheEmploye��5   	   $	��300��6   $	��300��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Fiche de l'employe��6   $
��Left=�6<   $��	10,10,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ label1��5      $��Nom :��6    $
��Left=�60   $��	10,41,0,0q�6K   $	��Top=�6^   �� 5   
   -   5        $ label2��5      $��Prenom :��6    $
��Left=�63   $��	10,72,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $ label3��5      $��Nom utilisateur :��6    $
��Left=�6<   $��
10,103,0,0q�6W   $	��Top=�6k   �� 5   
   -   5        $ label4��5      $��Mot de passe :��6    $
��Left=�69   $��
10,134,0,0q�6T   $	��Top=�6h   �� 5   
   -   5         ��Name$ cbxRole��5      $
��Left=�6$   $��113,166,0,0q�6?   $	��Top=�6T   $	��142��6l    �� DisplayMemberPath$ designation��5   +    �� SelectedValuePath$ id��6L   ��6   �� 6L   �� 5   
   -   5         ��Name$ txtUsername��5      $
��Left=�6'   $��23��6B   $��113,107,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��142��6�   �� 5   
   -   5        $ 	txtPrenom��5      $
��Left=�6%   $��23��6@   $��
113,76,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��142��6�   �� 5   
   -	   5        $ txtNom��5      $
��Left=�6"   $��23��6=   $��
113,45,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��142��6�   �� 5   
   -
   5        $ label5��5      $��Poste :��6    $
��Left=�62   $��
10,166,0,0q�6M   $	��Top=�6a   �� 5   
   -   5         ��Name$ 
btnAnnuler��5      $��Annuler��6%   $
��Left=�67   $��
68,209,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ 
btnValider��5      $��Valider��6%   $
��Left=�67   $��180,209,0,0q�6R   $	��Top=�6g   $��75��6   6�   G� 5   
   -   5         G�Name$ 	txtPasswd��5      $
��Left=�6)   $��113,138,0,0q�6D   $	��Top=�6Y   $	��142��6q   $��23��6}   5      5      