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
            var openFileDialog = new OpenFileDialog {Filter = "Text Files (.txt)|*.txt", FilterIndex = 1, Multiselect = true};
            bool? userConfirmation = openFileDialog.ShowDialog();

            if (userConfirmation != true) return;
            string file = openFileDialog.FileName;

            try
            {
                // Made global variable and properties for text to translate / translated output
                ConfigClass.TextToTranslate = File.ReadAllText(file);
                MsgBoxLabel.Content = file;
            }
            catch (IOException) { throw new Exception("Something went wrong, eh?"); }

            // Microsfot translate work. Don't need to pass anything in because its saved in global variable. 
            ConfigClass.TranslatedText = new MicrosoftTranslator().Translate();

            // native windows save file location option
            var saveDialog = new SaveFileDialog { Filter = "Text Files (.txt)|*.txt", FilterIndex = 1};
            bool? userSaveConfirmation = saveDialog.ShowDialog();

            if (userSaveConfirmation != true) return;
            string savePath = @saveDialog.FileName;

            // export .txt file
            File.WriteAllText(savePath, ConfigClass.TranslatedText);


            // display success message on textbox

        }
    }
}
