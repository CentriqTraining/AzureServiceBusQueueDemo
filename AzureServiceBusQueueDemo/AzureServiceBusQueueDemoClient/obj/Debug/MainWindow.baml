   M S B A M L   `   `   `  ����Y  UAzureServiceBusQueueDemoClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:AzureServiceBusQueueDemoClientAzureServiceBusQueueDemoClient  5   	   /    )AzureServiceBusQueueDemoClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:AzureServiceBusQueueDemoClient     5   	     � Title$  Messaging Client��5   	   $��100.105��6"   $��558.792��63   .��5	      ]� -   5        $��
mainParent��5	      .+�5
   
   � $	��Top=�6   $��40��6$    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��0* �6     � ColumnDefinitions 5      �� 5      $
��126* �6#   �� 5      $
��259* �6#   �� 5      $
��255* �6#   .+�5      �� $��Message Text��6   $��6,6,6,94q�6+   �� 5      -   5        $��txtMessageText��5       �� TextWrapping$
 Wrap=�6,   $�� ��6@   $��1��6H   $��	6,6,21,94q�6X   �� 5      $��0,4,4,0q�6   $��Right=�6*   $	��Top=�6F    �� Orientation$ 
Horizontal=�6^   $��1��6w   $��32��6�   $	��204��6�   $��2��6�   .+�5      �� -   5        $��cmdStart��5      $��Start Sending��6)   $
��Left=�6A   $	��Top=�6]   $��90��6u   {�6�   �� *
CanStart+�� 5      -   5        $��cmdStop��5      $��Stop Sending��6(   $
��Left=�6?   $	��Top=�6Z   $��90��6r   {�6�   �� *	CanStop+5      5      �� 5   
   $��Bottom=�6   $��Bottom=�6-   .@�5      �� .��5      �� -   5        $��
lblmessage��5      ��6.   ��  �� Path$ Message�5      5      5       5!      