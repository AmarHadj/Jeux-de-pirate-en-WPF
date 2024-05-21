using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bateaux;

namespace TP3
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ImageBrush _imageBackground = new ImageBrush();
        ImageBrush _imageCannon = new ImageBrush();
        ImageBrush _imageCannonGros = new ImageBrush();
        ImageBrush _imageCannonPetit = new ImageBrush();
        ImageBrush _imagePirate = new ImageBrush();
        ImageBrush _imageAmelioration = new ImageBrush();
        ImageBrush _imageCarte = new ImageBrush();
        ImageBrush _imageMarchant = new ImageBrush();
        ImageBrush _imageCoin = new ImageBrush();
        /// <summary>
        /// La page du magasin
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            Magasin.Focus();
            RemplirImages();
            Or.Content = "Or : " + MainWindow._joueur.Or;
        }
        /// <summary>
        /// Méthode qui vend un petit cannon aux pirates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AchatPetitCannon(object sender, RoutedEventArgs e)
        {

            if (MainWindow._joueur.Or >= 75)
            {
                impossible.Content = "";
                MainWindow._joueur.Or -= 75;
                MainWindow._joueur.petitCannon ++;
                Or.Content = "Or : " + MainWindow._joueur.Or;
                MainWindow._joueur.DegatCannonPetit = MainWindow._joueur.CalculerDegatPetitCannon(MainWindow._joueur.petitCannon);
            }
            else if (MainWindow._joueur.Or < 75)
            {
                impossible.Content = "or insuffisant";
            }
        }
        /// <summary>
        /// Méthode qui vend un cannon moyen aux pirates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AchatMoyenCannon(object sender, RoutedEventArgs e)
        {

            if (MainWindow._joueur.Or >= 50)
            {
                impossible.Content = "";
                MainWindow._joueur.Or -= 50;
                MainWindow._joueur.cannonBase ++;
                Or.Content = "Or : " + MainWindow._joueur.Or;
                MainWindow._joueur.DegatCannonMoyen = MainWindow._joueur.CalculerDegatMoyenCannon(MainWindow._joueur.cannonBase);
            }
            else if (MainWindow._joueur.Or < 50)
            {
                impossible.Content = "or insuffisant";
            }
        }
        /// <summary>
        /// Méthode qui vend un gros cannon aux pirates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AchatGrosCannon(object sender, RoutedEventArgs e)
        {

            if (MainWindow._joueur.Or >= 100)
            {
                impossible.Content = "";
                MainWindow._joueur.Or -= 100;
                MainWindow._joueur.grosCannon ++;
                Or.Content = "Or : " + MainWindow._joueur.Or;
                MainWindow._joueur.DegatCannonGros = MainWindow._joueur.CalculerDegatGrosCannon(MainWindow._joueur.grosCannon);

            }
            else if (MainWindow._joueur.Or < 100)
            {
                impossible.Content = "or insuffisant";
            }
        }
        /// <summary>
        /// Méthode qui vend des membres d'équipages aux pirates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AchatPirate(object sender, RoutedEventArgs e)
        {

            if (MainWindow._joueur.Or >= 10)
            {
                impossible.Content = "";
                MainWindow._joueur.Or -= 10;
                MainWindow._joueur.equipage ++;
                Or.Content = "Or : " + MainWindow._joueur.Or;
            }
            else if (MainWindow._joueur.Or < 10)
            {
                impossible.Content = "or insuffisant";
            }
        }
        /// <summary>
        /// Méthode qui vend une amelioration de vitesse aux pirates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AchatAmelioration(object sender, RoutedEventArgs e)
        {

            if (MainWindow._joueur.Or >= 30)
            {
                impossible.Content = "";
                MainWindow._joueur.Or -= 30;
                MainWindow._joueur.vitesse ++;
                Or.Content = "Or : " + MainWindow._joueur.Or;
            }
            else if (MainWindow._joueur.Or < 30)
            {
                impossible.Content = "or insuffisant";
            }
        }
        /// <summary>
        /// Méthode qui vend une carte aux tresors aux pirates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AchatCarte(object sender, RoutedEventArgs e)
        {

            if (MainWindow._joueur.Or >= 1000)
            {
                impossible.Content = "";
                MainWindow._joueur.Or -= 1000;
                MainWindow._joueur.carteTresor = true;
                Or.Content = "Or : " + MainWindow._joueur.Or;
            }
            else if (MainWindow._joueur.Or < 1000)
            {
                impossible.Content = "or insuffisant";
            }
        }
        /// <summary>
        /// Méthode pour remplir les images
        /// </summary>
        private void RemplirImages()
        {
            _imageMarchant.ImageSource = new BitmapImage(new Uri("../../../images/Marchant.png", UriKind.Relative));
            _imageCarte.ImageSource = new BitmapImage(new Uri("../../../images/carteTresor.png", UriKind.Relative));
            _imageAmelioration.ImageSource = new BitmapImage(new Uri("../../../images/Amelioration.png", UriKind.Relative));
            _imagePirate.ImageSource = new BitmapImage(new Uri("../../../images/pirate.png", UriKind.Relative));
            _imageCannon.ImageSource = new BitmapImage(new Uri("../../../images/cannon.png", UriKind.Relative));
            _imageCannonGros.ImageSource = new BitmapImage(new Uri("../../../images/cannonGros.png", UriKind.Relative));
            _imageCannonPetit.ImageSource = new BitmapImage(new Uri("../../../images/cannonPetit.png", UriKind.Relative));
            _imageBackground.ImageSource = new BitmapImage(new Uri("../../../images/background_magasin.png", UriKind.Relative));
            _imageCoin.ImageSource = new BitmapImage(new Uri("../../../images/petitCoin.png", UriKind.Relative));
            Magasin.Background = _imageBackground;
            cannonMoyen.Fill = _imageCannon;
            grosCannon.Fill = _imageCannonGros;
            petitCannon.Fill = _imageCannonPetit;
            pirate.Fill = _imagePirate;
            amelioration.Fill = _imageAmelioration;
            Marchant.Fill = _imageMarchant;
            carteTresor.Fill = _imageCarte;
            Coin.Fill = _imageCoin;
        }
    }
}
