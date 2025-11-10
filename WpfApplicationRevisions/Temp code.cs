< Grid Name = "pnlMainGrid" MouseUp = "pnlMainGrid_MouseUp" Background = "ForestGreen" >


		< !--Affichage des Resources static dans du texte-->
        <StackPanel Margin="10">
            <TextBlock x:Name = "txtHello" Text = "{StaticResource strHello}" FontSize = "50" />

			< TextBlock > Just another "<TextBlock Text="{StaticResource strHello}"/>" example of static resources</TextBlock>

		</ StackPanel >

		< !--Affichage des static resources dans des tableaux-->
        <StackPanel Margin="10">
            <Label Content="{StaticResource ComboBoxTitle}" Width="160"/>
            <ComboBox x:Name = "cbxResources" ItemsSource = "{StaticResource ComboBoxItems}" SelectedIndex = "0" Height = "30" Width = "160" VerticalAlignment = "Center" />

		</ StackPanel >


		< StackPanel Margin = "20" VerticalAlignment = "Bottom" >

			< TextBlock Text = "{Binding Name}" FontWeight = "Bold" Margin = "0,10,0,0" />

			< TextBox Text = "{Binding Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Height = "20" Width = "532" />

		</ StackPanel >



		< Label FontSize = "55" Content = "WPF Hello!" HorizontalAlignment = "Center" VerticalAlignment = "Center" ></ Label >



		< Label FontSize = "60" x: Name = "largeNumberValue" Height = "117" VerticalAlignment = "Top" HorizontalAlignment = "Left" Width = "345" Margin = "208,259,0,0" > Empty space </ Label >



		< !--On affiche la valeur de la DependencyProperty NE MARCHE PAS -->
        <local:MyCustomControl Label = "{Binding Name}" Width="200" Height="50" HorizontalAlignment="Right" VerticalAlignment="Top" Margin="10"></local:MyCustomControl >


		< TextBlock Text = "{Binding Label, RelativeSource={RelativeSource AncestorType=UserControl}}"

				   FontSize = "16"

				   Foreground = "DarkBlue" Height = "59" VerticalAlignment = "Top" HorizontalAlignment = "Left" Width = "237" Margin = "543,109,0,0" RenderTransformOrigin = "0.5,0.5" >

		</ TextBlock >

		< !--< Button FontWeight = "Bold" >

		< Button.Content >

			< WrapPanel >

				< TextBlock Foreground = "Black" > Multi </ TextBlock >

				< TextBlock Foreground = "Yellow" > Color </ TextBlock >

				< TextBlock > Button </ TextBlock >

			</ WrapPanel >

		</ Button.Content >

		</ Button > -->

		< Button Click = "OpenWindow_Click" HorizontalAlignment = "Left" VerticalAlignment = "Center" Margin = "15" > Open another Window!</Button>
        

    </Grid>