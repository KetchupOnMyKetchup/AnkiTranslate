using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;

namespace AnkiTranslate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Languages languageChoices = new Languages();
            languageChoices.Populate();
        }

        private void ComboBoxFrom_Loaded(object sender, RoutedEventArgs e) { ComboboxDoWork(sender); }

        private void ComboBoxTo_Loaded(object sender, RoutedEventArgs e) { ComboboxDoWork(sender); }

        private void ComboboxDoWork(object sender)
        {
            var comboBox = sender as ComboBox;

            if (comboBox == null) return;
            comboBox.ItemsSource = ConfigClass.Languages;
            comboBox.SelectedIndex = 0;
        }

        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            ConfigClass.LanguageTranslatedFrom = ((ConfigClass.ComboboxItem) lanFromComboBox.SelectedValue).Value;
            ConfigClass.LanguageToTranslateTo = ((ConfigClass.ComboboxItem) lanToComboBox.SelectedValue).Value;

            var openFileDialog = new OpenFileDialog {Filter = "Text Files (.txt)|*.txt", FilterIndex = 1, Multiselect = true};
            bool? userConfirmation = openFileDialog.ShowDialog();

            if (userConfirmation != true) return;
            string file = openFileDialog.FileName;

            try
            {
                ConfigClass.TextToTranslate = File.ReadAllText(file);
                MsgBoxLabel.Content = file;
            }
            catch (IOException) { throw new Exception("Something went wrong, eh?"); }

            ConfigClass.TranslatedText = new MicrosoftTranslator().Translate();

            // DOWORK to make anki format
            string[] textToTranslateArray = ConfigClass.TextToTranslate.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] translatedTextArray = ConfigClass.TranslatedText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string finalText = "";

            for (int i = 0; i < textToTranslateArray.Length - 1; i++)
            {
                finalText += textToTranslateArray[i] + "\t" + translatedTextArray[i] + System.Environment.NewLine;
            }

            var saveDialog = new SaveFileDialog { Filter = "Text Files (.txt)|*.txt", FilterIndex = 1};
            bool? userSaveConfirmation = saveDialog.ShowDialog();

            if (userSaveConfirmation != true) return;
            string savePath = @saveDialog.FileName;

            File.WriteAllText(savePath, finalText);
            MsgBoxLabel.Content = "Successfully saved to: " + saveDialog.FileName;
        }
    }
}
