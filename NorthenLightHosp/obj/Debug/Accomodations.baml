   M S B A M L   `   `   `  ����K  GNorthenLightHosp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NorthenLightHospNorthenLightHosp  5   	   $    NorthenLightHosp.Accomodations   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NorthenLightHosp     5   	     � Title$  Accomodations��5   	   $	��236��6   $��450.477��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ ckbxTelevision��5
      $��
Television��6+   $
��Left=�6@   $��7,41,0,0q�6[   $	��Top=�6m   �� 5   
   -   5        $ ckbxTelephone��5      $��	Telephone��6*   $
��Left=�6>   $��7,67,0,0q�6Y   $	��Top=�6k   �� 5   
   -   5         ��Name$ label��5      $��Lits disponible :��6   $
��Left=�6;   $��
128,10,0,0q�6V   $	��Top=�6j   �� 5   
   -   5         ��Name$ 
btnValider��5      $��Valider��6%   $
��Left=�67   $��227,172,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ 
btnAnnuler��5      $��Annuler��6%   $
��Left=�67   $��128,172,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5         ��Name$ gbxChambres��5      $��Types de chambres��6(   $
��Left=�6C   $��	10,87,0,0q�6^   $	��Top=�6q   $	��104��6�   $	��113��6�   .��5      � $
��Left=�6   $��74��6.   $��0,10,0,-2.4q�6:   $	��Top=�6O   $	��103��6g   .+�5      	� -   5         	�Name$ 
rbStandard��5      $��Standard��62   $
��Left=�6E   $��	10,10,0,0q�6`   $	��Top=�6s   6�   	� 5      -   5        $ rbSemiPrive��5      $��
Semi-Prive��63   $
��Left=�6H   $��	10,31,0,0q�6c   $	��Top=�6v   6�   	� 5      -	   5        $ rbPrive��5      $��Prive��6/   $
��Left=�6?   $��	10,54,0,0q�6Z   $	��Top=�6m   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ dgLits��5      $
��Left=�6#   $��
128,41,0,0q�6>   $	��Top=�6R   $	��126��6j   $	��306��6w      AutoGenerateColumns .   �� SelectedValuePath$ id��5   G   ��6   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 no Lit��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+  5      $
 departement��6%    6:   �� *departement+  5      $

 type��6%    63   �� *type+5      5      5       