using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace CYK_Project
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

        private void Check_Btn_Click(object sender, RoutedEventArgs e)
        {


           
            if (Inputgrammer_TB.Text == "")
            {

                output_lB.Foreground = Brushes.Red;
                output_lB.Content = "قوانین گرامر را وارد کنید  ";
            }
            else if (inputdata_TB.Text == "")
            {
                output_lB.Foreground = Brushes.Red;
                output_lB.Content = " ورودی را وارد کنید";
            }
            else
            {
                List<Rule> G = new List<Rule>();


                String inputData = Inputgrammer_TB.Text;

                inputData = inputData.Replace(" ", "");
                inputData = inputData.Replace("\n", "");
                String[] tempID = inputData.Split('/');


                try
                {
                    for (int i = 0; i <= tempID.Length - 1; i++)
                    {
                        if (tempID[i] != "")
                        {
                            String[] tempSplit = tempID[i].Split("->");

                            G.Add(new Rule(tempSplit[0][0], tempSplit[1]));

                        }
                    }
                }
                catch
                {
                    //errorMessage += "Problem in Dfa Definition\n";
                    //noProblem = false;
                }


                string word = inputdata_TB.Text;

                CYK parser = new CYK(word, G);

                parser.Parse();
                //parser.PrintTable();

                string not = "";

                if (!parser.GetResult())
                {
                    output_lB.Foreground = Brushes.Red;
                    output_lB.Content = $" در این گرامر یافت نشد{word} رشته ";

                }
                else
                {

                    output_lB.Foreground = Brushes.Green;
                    output_lB.Content = $" در این گرامر یافت شد{word} رشته ";
                }


            }

        }


        private void exit(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();

        }
    }
}
