using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VirtualDoctor.LoginAuthentication;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.Shared.Helpers
{
    public static class WindowHelper
    {
        public static void Refresh(IRefreshable window)
        {
            window.Refresh();

        }
        public static int SetBorder(Window window, Grid grid)
        {
            window.Height = Shared.Config.Properties.Default.WindowHeightProportion * SystemParameters.FullPrimaryScreenHeight;
            window.Width = Shared.Config.Properties.Default.WindowWidthProportion * SystemParameters.FullPrimaryScreenWidth;
            int Count = WindowHelper.CalculateGridMaxCount(grid);
            window.Left = SystemParameters.BorderWidth;
            window.Top = SystemParameters.FixedFrameHorizontalBorderHeight;
            return Count;
        }
        public static void SetModal(Window modalWindow, double parentWindowHeight, double parentWindowWidth)
        {
            modalWindow.Top = 20;
            modalWindow.Left = (parentWindowWidth - modalWindow.Width) / 2;
            modalWindow.Height = parentWindowHeight;
            modalWindow.Title = GetUserFullName();
        }
        public static void CenterWindow(Window modalWindow, double parentWindowHeigth, double parentWindowWidth)
        {
            modalWindow.Left = (parentWindowWidth - modalWindow.Width) / 2;
            modalWindow.Top = (parentWindowHeigth - modalWindow.Height) / 2;
        }
        public static int CalculateGridMaxCount(Grid grid)
        {
            return grid.RowDefinitions.Count > grid.ColumnDefinitions.Count ? grid.RowDefinitions.Count : grid.ColumnDefinitions.Count;
        }
        public static void ShowWindow(Window toClose, Window toShow)
        {
            toShow.Title = GetUserFullName();
            toShow.Left = toClose.Left;
            toShow.Top = toClose.Top;
            toClose.Close();
            toShow.Show();
        }
        public static void ReturnToPrevious(Window returnToWindow, Window currentWindow)
        {
            returnToWindow = Activator.CreateInstance(returnToWindow.GetType()) as Window;
            ShowWindow(currentWindow, returnToWindow);
        }
        public static void WriteMessage(string mesage, Label label, bool success)
        {
            label.Content = new TextBlock()
            {
                Text = mesage,
                Foreground = success == true ? new SolidColorBrush(Colors.LightGreen) : new SolidColorBrush(Colors.Red),
                FontWeight = FontWeights.Bold,
                FontSize = Shared.Config.Properties.Default.LabelFontSize,
                TextWrapping = TextWrapping.Wrap
            };
        }
        public static string GetUserFullName()
        {
            try
            {
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                return customPrincipal?.Identity.Name ?? string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
