### Template: App.xaml

<Application x:Class="?.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:?"
             StartupUri="MainWindow.xaml">
  <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/Wpf.MetroLib;component/Wpf.Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/Wpf.MetroLib;component/Wpf.Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/Wpf.MetroLib;component/Wpf.Styles/Colors.xaml" />
                <ResourceDictionary Source="pack://application:,,,/Wpf.MetroLib;component/Wpf.Styles/Accents/Green.xaml" />
                <ResourceDictionary Source="pack://application:,,,/Wpf.MetroLib;component/Wpf.Styles/Accents/BaseLight.xaml" />
            </ResourceDictionary.MergedDictionaries>

            <Style x:Key="DescriptionHeaderStyle"
                   TargetType="Label">
                <Setter Property="FontSize" Value="22" />
                <Setter Property="HorizontalAlignment" Value="Center" />
            </Style>
        </ResourceDictionary>
    </Application.Resources>
	
### Template: MainWindow.xaml	

<metro:MetroWindow
        x:Class="?.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:?"
        xmlns:metro="clr-namespace:MahApps.Metro.Controls;assembly=Wpf.MetroLib"
        mc:Ignorable="d"
        Title="?" Height="350" Width="825"
        ResizeMode="CanResizeWithGrip" EnableDWMDropShadow="True">
    <metro:MetroWindow.Behaviors>
        <metro:Bordless />
    </metro:MetroWindow.Behaviors>
	
	<Grid>
		...


### Template: UserControl.xaml	

<UserControl x:Class="WbxUsers.AppTools"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:m="clr-namespace:MahApps.Metro.Controls;assembly=Wpf.MetroLib" 
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"  mc:Ignorable="d" 
             xmlns:local="clr-namespace:WbxUsers"
             d:DesignHeight="30" d:DesignWidth="700">

    <UserControl.Resources>
        <ResourceDictionary>
            <Thickness x:Key="ControlMargin">0 5 0 0</Thickness>
            <Style TargetType="Button" BasedOn="{StaticResource AccentedSquareButtonStyle}">
                <Setter Property="Background" Value="White" />
                <Setter Property="Foreground" Value="Black" />
            </Style>
        </ResourceDictionary>
    </UserControl.Resources>

    <StackPanel Orientation="Horizontal">
        <ComboBox x:Name="comboCmd" 
                  Width="100" Margin="0 0 10 0" Visibility="Collapsed" />

        <Button x:Name="cmdEdit" Margin="0,0,4,0" 
                    Width="80">Edit</Button>

