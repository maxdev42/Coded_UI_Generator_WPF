using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CodedUI_Generator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void ListTechnology()
        {
            List<string> list = new List<string>();
            list.Add("");
            list.Add("WPF");
            list.Add("WinForm");
            comboboxTechnology.ItemsSource = list;
        }

        public void comboboxTechnology_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxTechnology.SelectedItem.ToString() == "WPF")
            {
                ListTypeControlsWPF();
                VisilityAfterSelectTechnology();
            }
            else if (comboboxTechnology.SelectedItem.ToString() == "WinForm")
            {
                ListTypeControlsWinForm();
                VisilityAfterSelectTechnology();
            }
        }

        private void VisilityAfterSelectTechnology()
        {
            typeControlLabel.Visibility = Visibility.Visible;
            comboboxTypeControls.Visibility = Visibility.Visible;
            nomControlLabel.Visibility = Visibility.Visible;
            nameControl.Visibility = Visibility.Visible;
            parentLabel.Visibility = Visibility.Visible;
            parentText.Visibility = Visibility.Visible;
            checkboxClick.Visibility = Visibility.Visible;
            generateButton.IsEnabled = true;
        }

        public void ListTypeControlsWPF()
        {
            List<string> list = new List<string>();
            list.Add("Button");
            list.Add("CheckBox");
            list.Add("ListBox");
            list.Add("ComboBox");
            list.Add("ContextMenu");
            list.Add("DataGrid");
            list.Add("DatePicker");
            list.Add("TextBox");
            list.Add("WrapPanel");
            list.Add("Window");
            list.Add("GroupBox");
            list.Add("ScrollBar");
            list.Add("Label");
            list.Add("ListBox");
            list.Add("ListView");
            list.Add("Menu");
            list.Add("Calendar");
            list.Add("RepeatButton");
            list.Add("OpenFileDialog");
            list.Add("Canvas");
            list.Add("Image");
            list.Add("PrintDialog");
            list.Add("DocumentViewer");
            list.Add("PrgoressBar");
            list.Add("RadioButton");
            list.Add("RichTextBox");
            list.Add("SaveFileDialog");
            list.Add("ScrollViewer");
            list.Add("MediaPlayer");
            list.Add("GridSplitter");
            list.Add("StatusBar");
            list.Add("TabControl");
            list.Add("Grid");
            list.Add("TextBox");
            list.Add("Dispatcher");
            list.Add("ToolBar");
            list.Add("ToolTip");
            list.Add("Slider");
            list.Add("TreeView");
            list.Add("UserControl");
            list.Add("ScrollBar");
            list.Add("Frame");
            comboboxTypeControls.ItemsSource = list;
        }

        public void ListTypeControlsWinForm()
        {
            List<string> list = new List<string>();
            list.Add("Button");
            list.Add("CheckBox");
            list.Add("CheckedListBox");
            list.Add("ComboBox");
            list.Add("ContextMenuStrip");
            list.Add("DataGridView");
            list.Add("DateTimePicker");
            list.Add("DomainUpDown");
            list.Add("FlowLayoutPanel");
            list.Add("Window");
            list.Add("GroupBox");
            list.Add("HSScrollBar");
            list.Add("Label");
            list.Add("ListBox");
            list.Add("ListView");
            list.Add("MenuStrip");
            list.Add("MonthCalendar");
            list.Add("NumericUpDown");
            list.Add("OpenFileDialog");
            list.Add("Panel");
            list.Add("PictureBox");
            list.Add("PrintDialog");
            list.Add("PrintPreviewControl");
            list.Add("PrgoressBar");
            list.Add("RadioButton");
            list.Add("RichTextBox");
            list.Add("SaveFileDialog");
            list.Add("ScrollableControl");
            list.Add("SoundPlayer");
            list.Add("SplitContainer");
            list.Add("StatusStrip");
            list.Add("TabControl");
            list.Add("TableLayoutPanel");
            list.Add("TextBox");
            list.Add("Timer");
            list.Add("ToolStrip");
            list.Add("ToolTip");
            list.Add("TrackBar");
            list.Add("TreeView");
            list.Add("UserControl");
            list.Add("VScrollBar");
            list.Add("WebBrowser");
            comboboxTypeControls.ItemsSource = list;
        }

        public void MakeConcatCode(object sender, RoutedEventArgs e)
        {
            string technology = null;
            string control = null;
            string name = null;
            string parent = null;
            string clickResult = null;

            technology = comboboxTechnology.SelectedValue.ToString();
            control = comboboxTypeControls.SelectedValue.ToString();
            name = nameControl.Text;
            parent = parentText.Text;

            if (checkboxClick.IsChecked == true)
            {
                clickResult = "Mouse.Click(" + name + ");";
            }
            ConcatCode(technology, control, name, parent, clickResult);
        }

        public void ResetButton(object sender, RoutedEventArgs e)
        {
            comboboxTechnology.SelectedItem = "";
            comboboxTypeControls.ItemsSource = null;
            nameControl.Text = null;
            parentText.Text = null;
            checkboxClick.IsChecked = false;
        }

        public string ConcatCode(string technology, string control, string nameControl, string parent, string click)
        {
            string code = null;

            code = technology + "." + control + "SearchProperty.Add(" + nameControl + ")On(" + parent + ");\n" + click + "\n";
            textAreaResultVisible();
            resultatTextArea.SelectedText = resultatTextArea.Text + "\n" + code;

            return code;
        }

        private void textAreaResultVisible()
        {
            resultatTextArea.Visibility = Visibility.Visible;
        }

        public void QuitterApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public MainWindow()
        {
            InitializeComponent();
            ListTechnology();
           
            
        }
    }
}
