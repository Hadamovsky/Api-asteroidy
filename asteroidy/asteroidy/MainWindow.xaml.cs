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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace asteroidy
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<Asteroid> asteroids = new List<Asteroid>();

             async Task ZiskejJmeno()
            {
               
                HttpClient htc = new HttpClient();
                DateTime dateTime = DateTime.Now;
                //DateTime dateTime1 = dateTime.AddMinutes(-1);
                try
                {
                    string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + dateTime.ToString("yyyy-MM-dd") + "&end_date=" + dateTime.ToString("yyyy-MM-dd") + "&api_key=TEugrKwkX0hmTbP5HKSraiBzFMbX2RuIsDHiwAkq";
                    HttpResponseMessage message = await htc.GetAsync(url, HttpCompletionOption.ResponseContentRead);
                    JObject jObject = new JObject();
                    for (int i = 0; i < 9; i++)
                    {
                        Asteroid asteroid = new Asteroid();
                        asteroid.Jmeno = Convert.ToString(jObject["near_earth_objects"][dateTime.ToString("yyyy-MM-dd")][i]["name"]);
                        asteroids.Add(asteroid);
                    }
                }
                catch (HttpRequestException hre)
                {

                    MessageBox.Show("Chyba:" + hre);
                }
            }



            InitializeComponent();
        }

        static void method()
        {
            MessageBox.Show("co");
        }

        

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            method();
            //Lb1.Content = asteroids[0];
            //MessageBox.Show("css");
        }

        private void Label_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css2");
        }

        private void Label_MouseLeftButtonUp3(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css3");
        }

        private void Label_MouseLeftButtonUp4(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css4");
        }

        private void Label_MouseLeftButtonUp5(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css5");
        }

        private void Label_MouseLeftButtonUp6(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css6");
        }

        private void Label_MouseLeftButtonUp7(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css7");
        }

        private void Label_MouseLeftButtonUp8(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css8");
        }

        private void Label_MouseLeftButtonUp9(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css9");
        }

        private void Label_MouseLeftButtonUp10(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("css10");
        }
        
    }

    class Asteroid
    {
        [JsonProperty ("jmeno")]
        public string Jmeno { get; set; }
        [JsonProperty ("rychlost")]
        public double Rychlost { get; set; }
        [JsonProperty ("nebezpeci")]
        public bool Nebezpeci { get; set; }
    }
   public class Vsechny
    {
        List<Asteroid> asteroids = new List<Asteroid>();

        async Task ZiskejJmeno()
        {

            HttpClient htc = new HttpClient();
            DateTime dateTime = DateTime.Now;
            DateTime dateTime1 = dateTime.AddMinutes(-1);
            try
            {
                string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + dateTime1.ToString("yyyy-MM-dd") + "&end_date=" + dateTime.ToString("yyyy-MM-dd") + "&api_key=TEugrKwkX0hmTbP5HKSraiBzFMbX2RuIsDHiwAkq";
                HttpResponseMessage message = await htc.GetAsync(url, HttpCompletionOption.ResponseContentRead);
                JObject jObject = new JObject();
                for (int i = 0; i < 9; i++)
                {
                    Asteroid asteroid = new Asteroid();
                    asteroid.Jmeno = Convert.ToString(jObject["near_earth_objects"][dateTime1.ToString("yyyy-MM-dd")][i]["name"]);
                    asteroid.Nebezpeci = Convert.ToBoolean(jObject["near_earth_objects"][dateTime1.ToString("yyyy-MM-dd")][i]["is_potentially_hazardous_asteroid"]);
                    asteroid.Rychlost = Convert.ToDouble(jObject["near_earth_objects"][dateTime1.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["relative_velocity"]["kilometers_per_hour"]);
                    asteroids.Add(asteroid);
                }
            }
            catch (HttpRequestException hre)
            {

                MessageBox.Show("Chyba:" + hre);
            }
        }
    }
}
