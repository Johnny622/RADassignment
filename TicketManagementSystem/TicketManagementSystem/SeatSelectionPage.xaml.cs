using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SeatSelectionPage : Page
    {
        public SeatSelectionPage()
        {
            this.InitializeComponent();
            GenerateSeats(38);
        }
        private void GenerateSeats(int totalSeats)
        {
            const int seatsPerRow = 10;
            int columns = (totalSeats + seatsPerRow - 1) / seatsPerRow;
            int remainingSeats = totalSeats % seatsPerRow;

            char[] seatLetters = { 'A', 'B', 'C', 'D' }; // 座位号的字母序列

            for (int column = 0; column < columns; column++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());

                int seatsInCurrentColumn = column == columns - 1 ? remainingSeats : seatsPerRow;

                for (int row = 0; row < seatsInCurrentColumn; row++)
                {
                    if (column == 0)
                        mainGrid.RowDefinitions.Add(new RowDefinition());

                    // 创建座位号 TextBlock
                    TextBlock seatNumberTextBlock = new TextBlock
                    {
                        Text = $"{row + 1}{seatLetters[column]}", // 使用行号和字母组合生成座位号
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(0, 0, 0, 5)
                    };

                    // 创建座位图像
                    Image seatImage = new Image
                    {
                        Source = new BitmapImage(new Uri("ms-appx:///Assets/chair.png")),
                        Width = 30,
                        Height = 30
                    };

                    // 创建座位按钮
                    Button seatButton = new Button
                    {
                        Content = new StackPanel { Children = { seatImage, seatNumberTextBlock } },
                        Background = new SolidColorBrush(Colors.Transparent),
                        Tag = $"{row + 1}{seatLetters[column]}" // 使用 Tag 属性存储座位号
                    };

                    seatButton.Click += SeatButton_Click; // 将点击事件处理程序与按钮关联

                    // 将座位按钮添加到网格中的正确位置
                    Grid.SetColumn(seatButton, column);
                    Grid.SetRow(seatButton, row);

                    // 将座位按钮添加到主网格中
                    mainGrid.Children.Add(seatButton);
                }
            }
        }

        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string seatNumber = clickedButton.Tag.ToString(); // 获取座位号

            // 处理座位点击事件，您可以在这里执行任何需要的操作，例如显示座位详情或者进行座位预订等
        }

    }
}
