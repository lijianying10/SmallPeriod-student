   M S B A M L   `   `   `  ����
  SP_UIL    SP_UIL.Mark.Mark_manage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5      $	��568��5      $��760.8��6,   .��5      �    ContentRoot#��[  6     � ColumnDefinitions  5	   
   �� 5
      $
��243* �6   �� 5      $	��25* �6   .+�5   
   �� $��2��6   $��0,0,-0.2,0.4q�6+   .��5      � $	��468��6   $	��707��6    .+�5      �� -   5        $��cb_class��5      $
��Left=�6+   $��	94,10,0,0q�6F   $	��Top=�6Y   $	��120��6q   �� 5      -   5        $��btn_temp_output��5   9   $��output template��6P   $
��Left=�6j   $��
219,10,0,0q�6�   $	��Top=�6�   $	��147��6�   �� 5      $��Choose Class��6   $
��Left=�6/   $��	19,14,0,0q�6J   $	��Top=�6]   �� 5      -   5        $��
Input mark��5   0   $
��Left=�6E   $��	28,59,0,0q�6`   $	��Top=�6s   $	��145��6�   &   System.Windows.Controls.DataGrid  5      -   5        $��dg_mark��5   P      AutoGenerateColumns .  $
��Left=�6_   $��
41,135,0,0q�6z   $	��Top=�6�   $	��263��6�   $	��603��6�   ��6   ��    Columns 5      A  ;FirstFloor.ModernUI.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Delete��66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Delete+  5      $ Update��65    6E   �� *Update+=  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5      $	  ID��61    6?   �� *	stu_num+  5      $  name��61    6A   �� *s_name+  5      $ gener��61    6A   �� *
s_gender+  5      $ 
department��61    6F   �� *S_department+  5      $ Course name��61    6G   �� *C_name+  5      $ Course mark��61    6G   �� *C_mark+  5      $ Course describe��61    6K   �� *
C_course+  5      $ 
class name��61    6F   �� *	cl_name+5       �� 5!      -   5        $��tb_condation��5!      $
��Left=�6.   $��23��6I   $��
28,103,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��120��6�   �� 5"      -   5        $��Search��5"   0   $
��Left=�6A   $��153,100,0,0q�6\   $	��Top=�6q   $��75��6�   �� 5#      $
��Left=�6   $��8��6:   $��	10,41,0,0q�6E   $	��Top=�6X   $	��473��6p   �� 5$      $
��Left=�6   $��8��6:   $��	10,90,0,0q�6E   $	��Top=�6X   $	��473��6p   �� 5%      $
��Left=�6   $��8��6:   $��
19,431,0,0q�6E   $	��Top=�6Y   $	��473��6q     5&      $
��Left=�6   $��102,222,0,0q�66   $	��Top=�6K   �� 5'      -   5        $��Submit��5'      $
��Left=�6*   $��
41,400,0,0q�6E   $	��Top=�6Y   $��75��6q   6|   �� 5(      -   5         ��Name$ cb_class_Copy��5(      $
��Left=�62   $��
94,438,0,0q�6M   $	��Top=�6a   $	��120��6y   �� 5)      -	   5         ��Name$ btn_temp_output_Copy��5)   Y    � ToolTip$ update mark only��6   $��Analyse class��6w   $
��Left=�6�   $��219,438,0,0q�6�   $	��Top=�6�   $	��147��6�   �� 5*      $��Choose Class��6   $
��Left=�6/   $��
19,442,0,0q�6J   $	��Top=�6^   5+      5,      5-      5.      