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
using Crypt;
using Microsoft.Win32;

namespace NewApp
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
        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile=new OpenFileDialog();
            openfile.Multiselect = false;
            openfile.ShowDialog();
            pathFile.Text = openfile.FileName;
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pathFile.Text))
                {
                    throw new Exception("The Text Input Of File Is Empty");
                }
                else if (passInput.Text.Length <= 5)
                {
                    throw new Exception("Password Must Be more than 5 char ");
                }
                
                else
                {
                    Warriorx_Crypto.Encrypt(pathFile.Text, $"{pathFile.Text}.Black", passInput.Text);
                    MessageBox.Show($"{pathFile.Text} Encrypted");
                }
                
            }catch(Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pathFile.Text))
                {
                    throw new Exception("The Text Input Of File Is Empty");
                }
                else if (passInput.Text.Length <= 5 )
                {
                    throw new Exception("Password Must Be more than 5 char ");
                }
                else
                {
                    int length = pathFile.Text.Length;
                    string outfile = pathFile.Text.Remove(length - 6);
                    Warriorx_Crypto.Decrypt(pathFile.Text, outfile, passInput.Text);
                    MessageBox.Show($"{pathFile.Text} Decrypted");
                }

            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }
    }
}
