// DataGrid feltöltése listából
// WPF DataGrid feltöltés minta
// ItemsSource használat
public partial class MainWindow : Window
{
    public static List<Lampa> lampak = new List<Lampa>();
    private readonly string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=vilagitas;";

    public MainWindow()
    {
        InitializeComponent();
            Betoltes();
            dataGrid.ItemsSource = lampak;
    }
    public void Betoltes()
    {

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT termekNev, foglalat, elettartam, katNev FROM termekek INNER JOIN kategoriak ON termekek.kategoriaID = kategoriak.katID", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lampak.Add(new Lampa(reader));
                }
            }
            connection.Close();
        }
    }
//xaml-ben a DataGrid oszlopainak definiálása, ha automatikus oszlopgenerálás van:

<DataGrid x:Name="dgHajok"
          Grid.Column="0"
          SelectionMode="Single"
          SelectionUnit="FullRow"
          AutoGenerateColumns="True"
          CanUserAddRows="False"
          SelectionChanged="DataGrid_SelectionChanged"/>

// Ha manuális oszlopdefiníciót szeretnénk:
 <DataGrid x:Name="dataGrid"
   Grid.Column="0"
   SelectionMode="Single"
   SelectionUnit="FullRow"
   AutoGenerateColumns="False"
   CanUserAddRows="False"
   SelectionChanged="DataGrid_SelectionChanged">

     <DataGrid.Columns>
         <DataGridTextColumn Header="Név" Binding="{Binding Nev}" Width="3*"/>
         <DataGridTextColumn Header="Foglalat" Binding="{Binding Foglalat}" Width="*"/>
         <DataGridTextColumn Header="Élettartam" Binding="{Binding Elettartam}" Width="*"/>
     </DataGrid.Columns>
 </DataGrid>