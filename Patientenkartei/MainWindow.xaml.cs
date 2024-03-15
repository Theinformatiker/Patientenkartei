using System;
using System.IO;
using System.Text;
using System.Windows;

namespace Patientenkartei
{
    public partial class MainWindow : Window
    {

        public const string DIR_PATH = @"C:\Users\vkkor\source\repos\Patientenkartei\Patientenkartei\BespDateien\";
        public const string FILE_EXT = ".text";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = textBoxFileName.Text;
            

            if (!string.IsNullOrWhiteSpace(filename))
            {
                try
                {
                    using (FileStream fs = File.Create(DIR_PATH + filename + FILE_EXT))
                    {
                        byte[] contentBytes = Encoding.UTF8.GetBytes(content);
                        fs.Write(contentBytes, 0, contentBytes.Length);
                    }
                    MessageBox.Show("Datei erfolgreich erstellt.");
                    textBoxContent.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Erstellen der Datei: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Dateinamen ein.");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string filename = textBoxFileName.Text;
            string filePath = DIR_PATH + filename + FILE_EXT;
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string content = sr.ReadToEnd();
                        textBoxContent.Text = content;
                        MessageBox.Show("Datei erfolgreich geladen.");
                    }
                }
                else
                {
                    MessageBox.Show("Die angegebene Datei existiert nicht.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Datei: " + ex.Message);
            }
        }
    
    }
}
