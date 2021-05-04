﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EVENTS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            Button1.SetValue(Canvas.LeftProperty, p.X - Button1.ActualWidth / 2);
            Button1.SetValue(Canvas.TopProperty, p.Y - Button1.ActualHeight / 2);
            if ((string)Button2.Content == "Изменить")
            {
                Button2.Content = "";
                Button2.MouseMove += Button2_MouseMove;
                Button2.Click += Button2_Click;
                Button2.Click -= Button2_Click2;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button2.Content = "Изменить";
            Button2.MouseMove -= Button2_MouseMove;
            Button2.Click -= Button2_Click;
            Button2.Click += Button2_Click2;


        }

        private void Button2_Click2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void Button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                return;
            Point p = e.GetPosition(this);
            Canvas.SetLeft(Button2, r.NextDouble() * ((Content as Canvas).ActualWidth - 5));
            Canvas.SetTop(Button2, r.NextDouble() * ((Content as Canvas).ActualHeight - 5));
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            cursorImage.Visibility = cursorImage.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
            Button3.Content = Button3.Content == "Скрыть курсор" ? "Показать курсор" : "Скрыть курсор";
        } 


        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            Canvas.SetLeft(cursorImage, (Content as Canvas).ActualWidth - p.X);
            Canvas.SetTop(cursorImage, (Content as Canvas).ActualHeight - p.Y);
        }
    }
}
