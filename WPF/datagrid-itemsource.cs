// DataGrid feltöltése listából
// WPF DataGrid feltöltés minta
// ItemsSource használat

List<Versenyzo> versenyzok = new List<Versenyzo>();

versenyzok.Add(new Versenyzo()
{
    Nev = "Kiss Péter",
    Eredmeny = "10.25"
});

versenyzok.Add(new Versenyzo()
{
    Nev = "Nagy Anna",
    Eredmeny = "11.03"
});

// DataGrid neve: dgVersenyzok

dgVersenyzok.ItemsSource = versenyzok;

//xaml-ben a DataGrid oszlopainak definiálása, ha automatikus oszlopgenerálás van:

<DataGrid x:Name="dgHajok"
          Grid.Column="0"
          SelectionMode="Single"
          SelectionUnit="FullRow"
          AutoGenerateColumns="True"
          CanUserAddRows="False"
          SelectionChanged="DataGrid_SelectionChanged"/>

// Ha manuális oszlopdefiníciót szeretnénk:
<DataGrid x:Name="dgHajok"
          Grid.Column="0"
          SelectionMode="Single"
          SelectionUnit="FullRow"
          AutoGenerateColumns="False"
          CanUserAddRows="False"
          CanUserDeleteRows="False"
          SelectionChanged="DataGrid_SelectionChanged">

    <DataGrid.Columns>

        <DataGridTextColumn Header="Név"
                            Binding="{Binding Nev}" />
                            Width="*"/>         
        <DataGridTextColumn Header="Típus"
                            Binding="{Binding Tipus}" />
                            Width="*"/>
        <DataGridTextColumn Header="Év"
                            Binding="{Binding Ev}" />
                            Width="*"/>

    </DataGrid.Columns>

</DataGrid>