using LeaveRequest.WPF.BusinessLogic.Services;
using LeaveRequest.WPF.BusinessLogic.Services.Master;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System;
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

namespace LeaveRequest.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        IPositionService _positionService = new PositionService();
        PositionParam positionParam = new PositionParam();
        ILeaveService _leaveService = new LeaveService();
        LeaveParam leaveParam = new LeaveParam();
        MyContext _context = new MyContext();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PositionDataGrid.ItemsSource = _positionService.Get();
            LeaveDataGrid.ItemsSource = _leaveService.Get();
        }

        //Source Code Manage Position
        private void SearchPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchPositionComboBox.Text) == true)
            {
                MessageBox.Show("Please Select a Position Category Search");
            }
            else
            {
                if (string.IsNullOrEmpty(SearchPositionTextBox.Text) == true)
                {
                    MessageBox.Show("Please Insert Search Keyword");
                }
                else if(string.IsNullOrWhiteSpace(SearchPositionTextBox.Text) == true)
                {
                    MessageBox.Show("Don't Insert White Space");
                }
                else
                {
                    PositionDataGrid.ItemsSource = _positionService.Search(SearchPositionTextBox.Text, SearchPositionComboBox.Text);
                }
            }
        }

        private void InsertPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (PositionNameTextBox == null)
            {
                MessageBox.Show("Please Insert Position Name");
            }
            else if (string.IsNullOrWhiteSpace(PositionNameTextBox.Text) == true)
            {
                MessageBox.Show("Please Insert Position Name");
            }
            else
            {
                Position position = new Position();
                positionParam.Name = PositionNameTextBox.Text;
                _positionService.Insert(positionParam);
                MessageBox.Show("Insert Sucess");
                PositionNameTextBox.Text = "";
            }
            RefreshPosition();
        }
        private void UpdatePositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (PositionIdTextBox == null)
            {
                MessageBox.Show("Please Select a Position");
            }
            else if (PositionNameTextBox == null)
            {
                MessageBox.Show("Please Insert Position Name");
            }
            else
            {
                var Id = Convert.ToInt16(PositionIdTextBox.Text);
                positionParam.Name = PositionNameTextBox.Text;
                _positionService.Update(Id, positionParam);
                MessageBox.Show("Update Sucess");
            }
            RefreshPosition();
        }
        private void DeletePositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (PositionIdTextBox == null)
            {
                MessageBox.Show("Please Select a Position Id");
            }
            else
            {
                var Id = Convert.ToInt16(PositionIdTextBox.Text);
                _positionService.Delete(Id);
                MessageBox.Show("Delete Sucess");
                PositionNameTextBox.Text = "";
            }
            RefreshPosition();
        }

        private void PositionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object position = PositionDataGrid.SelectedItem;
            if (PositionDataGrid.SelectedIndex < 0)
            {
                PositionIdTextBox.Text = "";
                PositionNameTextBox.Text = "";
            }
            else
            {
                PositionIdTextBox.Text = (PositionDataGrid.SelectedCells[0].Column.GetCellContent(position) as TextBlock).Text;
                PositionNameTextBox.Text = (PositionDataGrid.SelectedCells[1].Column.GetCellContent(position) as TextBlock).Text;
            }
        }

        private void RefreshPosition()
        {
            PositionDataGrid.ItemsSource = _positionService.Get();
        }

        private void InsertPositionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckPositionIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PositionNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Source Code Manage Leave
        private void SearchLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchLeaveComboBox.Text) == true)
            {
                MessageBox.Show("Please Select a Leave Category Search");
            }
            else
            {
                if (string.IsNullOrEmpty(SearchLeaveTextBox.Text) == true)
                {
                    MessageBox.Show("Please Insert Search Keyword");
                }
                else if (string.IsNullOrWhiteSpace(SearchLeaveTextBox.Text) == true)
                {
                    MessageBox.Show("Don't Insert White Space");
                }
                else
                {
                    LeaveDataGrid.ItemsSource = _leaveService.Search(SearchLeaveTextBox.Text, SearchLeaveComboBox.Text);
                }
            }
        }
        private void InsertLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeaveNameTextBox == null)
            {
                MessageBox.Show("Please Insert Leave Name");
            }
            else if (string.IsNullOrWhiteSpace(LeaveNameTextBox.Text) == true)
            {
                MessageBox.Show("Please Insert Leave Name");
            }
            else
            {
                leaveParam.Name = LeaveNameTextBox.Text;
                if (string.IsNullOrEmpty(LeaveStatusComboBox.Text) == true)
                {
                    MessageBox.Show("Please Select a Leave Status Category");
                }
                else
                {
                    leaveParam.Status = LeaveStatusComboBox.Text;
                }
                leaveParam.Days = Convert.ToInt16(LeaveDaysTextBox.Text);
                _leaveService.Insert(leaveParam);
                MessageBox.Show("Insert Sucess");
                LeaveNameTextBox.Text = "";
                LeaveDaysTextBox.Text = "";
            }
            RefreshLeave();
        }

        private void UpdateLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeaveIdTextBox == null)
            {
                MessageBox.Show("Please Select a Leave");
            }
            else if (LeaveNameTextBox == null)
            {
                MessageBox.Show("Please Insert Leave Name");
            }
            else
            {
                var Id = Convert.ToInt16(LeaveIdTextBox.Text);
                leaveParam.Name = LeaveNameTextBox.Text;
                if (string.IsNullOrEmpty(LeaveStatusComboBox.Text) == true)
                {
                    MessageBox.Show("Please Select a Leave Status Category");
                }
                else
                {
                    leaveParam.Status = LeaveStatusComboBox.Text;
                }
                leaveParam.Days = Convert.ToInt16(LeaveDaysTextBox.Text);
                _leaveService.Update(Id, leaveParam);
                MessageBox.Show("Update Sucess");
            }
            RefreshLeave();
        }

        private void DeleteLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeaveIdTextBox == null)
            {
                MessageBox.Show("Please Select a Leave Id");
            }
            else
            {
                var Id = Convert.ToInt16(LeaveIdTextBox.Text);
                _leaveService.Delete(Id);
                MessageBox.Show("Delete Sucess");
                LeaveNameTextBox.Text = "";
            }
            RefreshLeave();
        }

        private void LeaveDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object leave = LeaveDataGrid.SelectedItem;
            if (LeaveDataGrid.SelectedIndex < 0)
            {
                LeaveIdTextBox.Text = "";
                LeaveNameTextBox.Text = "";
                LeaveStatusComboBox.Text = "";
                LeaveDaysTextBox.Text = "";
            }
            else
            {
                LeaveIdTextBox.Text = (LeaveDataGrid.SelectedCells[0].Column.GetCellContent(leave) as TextBlock).Text;
                LeaveNameTextBox.Text = (LeaveDataGrid.SelectedCells[1].Column.GetCellContent(leave) as TextBlock).Text;
                LeaveStatusComboBox.Text = (LeaveDataGrid.SelectedCells[2].Column.GetCellContent(leave) as TextBlock).Text;
                LeaveDaysTextBox.Text = (LeaveDataGrid.SelectedCells[3].Column.GetCellContent(leave) as TextBlock).Text;
            }
        }
        private void RefreshLeave()
        {
            LeaveDataGrid.ItemsSource = _leaveService.Get();
        }

        private void SearchLeaveComboBox_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
