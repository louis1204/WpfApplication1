using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool filechosen = false;
        string savefilename = "";
        string filename = "";
        List<string> trans = new List<string>();
        List<string> labels = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Trans_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                savefilename = dlg.FileName;
                Assemble();

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@savefilename))
                {
                    foreach (string line in labels)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file. 
                        file.WriteLine(line);
                    }

                    foreach (string line in trans)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file. 
                        file.WriteLine(line);
                    }
                }
                labels = new List<string>();
                trans = new List<string>();
            }
        }

        private void Assemble()
        {
            int counter = 0;
            string line = "";    //line extracted from file
            string newline = ""; //creates the binary
            string[] elements;//split the line
            string imm = "";     //immediate

            if (filechosen)
            {
                StreamReader file = new StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    elements = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                    if (elements.Length > 0)
                    {
                        switch (elements[0])
                        {
                            case "sl":
                                newline = "0000";
                                if (elements[1].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "11";
                                if (elements[2].Contains("0"))
                                    newline = newline + "000";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "010";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "100";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "110";
                                break;
                            case "sr":
                                newline = "0001";
                                if (elements[1].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "11";
                                if (elements[2].Contains("0"))
                                    newline = newline + "000";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "010";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "100";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "110";
                                break;
                            case "lw":
                                newline = "0010";
                                if (elements[1].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "11";
                                if (elements[2].Contains("0"))
                                    newline = newline + "000";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "010";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "100";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "110";
                                break;
                            case "sw":
                                newline = "0011";
                                if (elements[2].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "11";
                                if (elements[1].Contains("0"))
                                    newline = newline + "000";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "010";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "100";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "110";
                                break;
                            case "add":
                                newline = "0100";
                                if (elements[1].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "11";
                                if (elements[2].Contains("0"))
                                    newline = newline + "000";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "010";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "100";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "110";
                                break;
                            case "leq":
                                newline = "0101";
                                if (elements[1].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "11";
                                if (elements[2].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "11";
                                if (elements[3] == "0")
                                    newline = newline + "0";
                                else if (elements[3] == "1")
                                    newline = newline + "1";
                                break;
                            case "and":
                                newline = "0110";
                                if (elements[1].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "11";
                                if (elements[2].Contains("0"))
                                    newline = newline + "000";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "010";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "100";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "110";
                                break;
                            case "mov":
                                newline = "0111";
                                if (elements[1].Contains("0"))
                                    newline = newline + "00";
                                else if (elements[1].Contains("1"))
                                    newline = newline + "01";
                                else if (elements[1].Contains("2"))
                                    newline = newline + "10";
                                else if (elements[1].Contains("3"))
                                    newline = newline + "11";
                                if (elements[2].Contains("0"))
                                    newline = newline + "000";
                                else if (elements[2].Contains("1"))
                                    newline = newline + "010";
                                else if (elements[2].Contains("2"))
                                    newline = newline + "100";
                                else if (elements[2].Contains("3"))
                                    newline = newline + "110";
                                break;
                            case "lui":
                                newline = "10";
                                imm = Convert.ToString(int.Parse(elements[1]), 2);
                                for (int i = 0; i < 7 - imm.Length; i++)
                                    newline = newline + "0";
                                newline = newline + imm;
                                break;
                            case "jmp":
                                newline = "110";
                                newline = newline + elements[1];
                                break;
                            default:
                                newline = null;
                                if (elements[0].Contains(":"))
                                    labels.Add(line + "\t" + counter);
                                else
                                    MessageBox.Show("Error at line " + counter + "\n\n" + line);
                                break;
                        }
                    }
                    if (!String.IsNullOrEmpty(newline) && elements.Length > 0)
                    {
                        trans.Add(newline);
                        counter++;
                    }
                }
            }
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
                filetext.Text = filename;
                filechosen = true;
            }
        }
    }
}
