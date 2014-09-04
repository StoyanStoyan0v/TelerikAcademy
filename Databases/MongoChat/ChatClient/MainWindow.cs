namespace ChatClient
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using MongoChat.Data;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MongoData mongoController;

        public MainWindow()
        {
            this.mongoController = new MongoData();           
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.usernaeBox.Text))
            {
                MessageBox.Show("Please enter a username!");
            }
            else if (string.IsNullOrEmpty(this.messageBox.Text))
            {
                MessageBox.Show("Please enter a message!");
            }
            else
            {
                this.mongoController.InsertMessage(this.messageBox.Text, this.usernaeBox.Text);
                this.LoadMessages(mongoController);
            }
        }

        private void LoadMessages(MongoData mongoData)
        {
            var messages = mongoData.GetMessages();
            foreach (var message in messages)
            {
                this.chatBox.Items.Add(message);
            }
            
            this.messageBox.Text = string.Empty;
            this.chatBox.SelectedIndex = this.chatBox.Items.Count - 1;
            this.chatBox.ScrollIntoView(this.chatBox.SelectedItem);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
     
        private void messageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.usernaeBox.Text))
            { 
                this.chatBox.Items.Clear();
                this.LoadMessages(mongoController);
            }
            else
            {
                this.chatBox.Items.Clear();
            }
        }
    }
}