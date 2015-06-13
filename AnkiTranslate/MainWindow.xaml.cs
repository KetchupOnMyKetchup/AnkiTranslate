using System;
using System.IO;
using System.Web;
using System.Windows;
using Microsoft.Win32;
using System.Xml.Linq;

namespace AnkiTranslate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box + force them to only try and open TXT files!!!
            var dialog = new OpenFileDialog {Filter = "Text Files (.txt)|*.txt", FilterIndex = 1, Multiselect = true};
            bool? userConfirmation = dialog.ShowDialog();

            if (userConfirmation != true) return;
            string file = dialog.FileName;

            try
            {
                ConfigClass.TextToTranslate = File.ReadAllText(file);
                MsgBoxLabel.Content = file;
            }
            catch (IOException) { throw new Exception("Something went wrong, eh?"); }


            // google translate API work
            ConfigClass.TranslatedText = new MicrosoftTranslator().Translate();

            // parse translator API work + initial values into anki format

            // native windows save file location option

            // export .txt file

            // display success message on textbox

        }
    }
}
