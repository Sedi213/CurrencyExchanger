   M S B A M L   `   `   `  ?????  ;Coin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Coin.MVVM.ViewModelCoin.MVVM.ViewModel  5      clr-namespace:CoinCoin  5   	       Coin.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7	viewModel!clr-namespace:Coin.MVVM.ViewModel     5      $localclr-namespace:Coin     5   	   $	??600??5	   	   $	??920??6     ? WindowStyle$
  None=?5
   	    ? 
ResizeMode$ NoResize=?5   	   
??????  ? AllowsTransparency$
 True??5   	    ? DataContext 5      '  !Coin.MVVM.ViewModel.MainViewModel  5   
   .??5      ?? ???#272537 ?? CornerRadius$ 20??5      ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $	??200 ?6#   ?? 5       ? RowDefinitions 5      ?? 5      $??75 ?6    ?? 5      .+?5      ?? $
??COIN??6   $??Center=?5       $
??Left=?5!      $??20,0,0,0q?5"      
???????$??22(?5$      ?? 5&      $??1??6   .+?5'      	? $??Top 7??6   $??50??5(      $??14(?5)      
???????   MenuButtonStyle#??[  5+       d? 	IsChecked$
 TrueY?5,      ??5-      ?? *TopVMComand+	? 5.      $??Search??6   $??50??5/      $??14(?50      
???????#??[  52      ??53      ?? *SearchVMComand+	? 54      $??	Conventor??6   $??50??55      $??14(?56      
???????#??[  58      ??59      ?? *ConvertorVMComand+5:      ?? 5;      $??1??6   $??1??6*   $??10q?5<      ??5=      ?? *CurrentView+5A      5B      5C      