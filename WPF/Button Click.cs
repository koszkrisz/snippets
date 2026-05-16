// WPF Button Click esemény minta

private void btnMent_Click(object sender, RoutedEventArgs e)
{
    MessageBox.Show("A gomb működik!");
}

/*
<Button
    x:Name="btnMent"
    Content="Mentés"
    Click="btnMent_Click"
/>
*/

// TextBox szövegének kiolvasása

private void btnKiir_Click(object sender, RoutedEventArgs e)
{
    string szoveg = txtNev.Text;

    MessageBox.Show(szoveg);
}

/*
<TextBox x:Name="txtNev"/>

<Button
    Content="Kiírás"
    Click="btnKiir_Click"
/>
*/