using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Threading;
using Bateaux;

namespace TP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _versHaut, _versBas, _versDroite, _versGauche;
        public static Pirate _joueur = new Pirate();
        private bool _toucheBar = false;
        private const int _vitesse = 2;
        private ImageBrush _imageJoueur = new ImageBrush();
        private ImageBrush _imageGallion = new ImageBrush();
        private ImageBrush _imageBackground = new ImageBrush();
        private ImageBrush _imageOr = new ImageBrush();
        private ImageBrush _imagePirate = new ImageBrush();
        private ImageBrush _imagePort = new ImageBrush();
        private ImageBrush _imageCannon = new ImageBrush();
        private ImageBrush _imageCannonGros = new ImageBrush();
        private ImageBrush _imageCannonPetit = new ImageBrush();
        private ImageBrush _imageEscorte = new ImageBrush();
        private Rect _carreJoueur = new Rect(380, 293,45,73);
        private DispatcherTimer _tempsJeu = new DispatcherTimer();
        /// <summary>
        /// La page du hub principal
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            myCanvas.Focus();
            RemplirImages();
            _tempsJeu.Tick += GameTimerEvent;
            _tempsJeu.Interval = TimeSpan.FromMilliseconds(1); 
            _tempsJeu.Start();
        }



        /// <summary>
        /// Fonction Timer: qui fait les déplacements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimerEvent(object sender, EventArgs e)
        {
            resutatOr.Content = _joueur.Or;
            equipageNb.Content = _joueur.equipage;
            cannonBase.Content = _joueur.cannonBase;
            cannonGros.Content = _joueur.grosCannon;
            cannonPetit.Content = _joueur.petitCannon;
            Arme.Content = "Armes";
            vitesse.Content = "vitesse = " + _joueur.vitesse ;
            cannonPetitDegat.Content = "Degat = " + _joueur.DegatCannonPetit;
            cannonMoyenDegat.Content = "Degat = " + _joueur.DegatCannonMoyen;
            cannonGrosDegat.Content = "Degat = " + _joueur.DegatCannonGros;
            Deplacement();
            Rect _carreEscorte1 = new Rect(Canvas.GetLeft(escorte1), Canvas.GetTop(escorte1), escorte1.Width, escorte1.Height);
            Rect _carreEscorte2 = new Rect(Canvas.GetLeft(escorte2), Canvas.GetTop(escorte2), escorte2.Width, escorte2.Height);
            Rect _carrePort = new Rect(Canvas.GetLeft(port), Canvas.GetTop(port), port.Width, port.Height);
            double nextX = Canvas.GetLeft(player);
            if (_toucheBar == false)
            {
                _carreJoueur = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                _toucheBar = false;
            }
            if (_carreJoueur.X <= 109)
            {
                nextX = 109;
                _toucheBar = true;
            }

            if (_toucheBar)
            {
                Canvas.SetLeft(player, nextX);
                _toucheBar = false;
            }
            if (_carreJoueur.IntersectsWith(_carrePort))
            {
                AfficherFenetreMagasin();
                ResetMouvement();
            }
            if (_carreJoueur.IntersectsWith(_carreEscorte1))
            {
                AfficherFenetreEscorte(600);
                ResetMouvement();
            }
            if (_carreJoueur.IntersectsWith(_carreEscorte2))
            {
                AfficherFenetreEscorte(200);
                ResetMouvement();
            }
        }
        /// <summary>
        /// Méthode qui fait déplacer le bateau
        /// </summary>
        private void Deplacement()
        {
            if (_versHaut && Canvas.GetTop(player) > 0)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - _vitesse);

            }

            if (_versBas && Canvas.GetTop(player) + (player.Height * 2) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + _vitesse);

            }
            if (_versGauche && Canvas.GetLeft(player) > 0)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - _vitesse);
            }
            if (_versDroite && Canvas.GetLeft(player) + (player.Width * 2) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + _vitesse);

            }
        }
        /// <summary>
        /// Affiche la fenetre de combat pour les bateaux d'escortes
        /// </summary>
        /// <param name="Endroit">la position du bateau pirate apres avoir fermer la fenetre</param>
        private void AfficherFenetreEscorte(int Endroit)
        {
            Combat combat = new Combat();
            combat.ShowInTaskbar = true;
            combat.ShowDialog();
            Canvas.SetLeft(player, Endroit);
        }
        /// <summary>
        /// Méthode qui affiche le magasin
        /// </summary>
        private void AfficherFenetreMagasin()
        {
            Window1 magasin = new Window1();
            magasin.ShowInTaskbar = true;
            magasin.ShowDialog();
            Canvas.SetLeft(player, 320);
        }
        /// <summary>
        /// Méthode qui réinitialise les touche pour que le bateau pirate
        /// puisse rester en place en quittant le magasin
        /// </summary>
        private void ResetMouvement()
        {
            _versBas = true;
            _versBas = false;
            _versHaut = true;
            _versHaut = false;
            _versGauche = true;
            _versGauche = false;
            _versDroite = true;
            _versDroite = false;
        }
        /// <summary>
        /// Méthode qui active les touche de clavier quand on click dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                _versBas = true;
            }
            else if (e.Key == Key.Up)
            {
                _versHaut = true;
            }
            else if (e.Key == Key.Left)
            {
                _versGauche = true;
            }
            else if (e.Key == Key.Right)
            {
                _versDroite = true;
            }
        }
        /// <summary>
        /// Méthode qui désactive les touche de clavier quand on ne click plus dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                _versBas = false;
            }
            else if (e.Key == Key.Up)
            {
                _versHaut = false;
            }
            else if (e.Key == Key.Left)
            {
                _versGauche = false;
            }
            else if (e.Key == Key.Right)
            {
                _versDroite = false;
            }
        }
        /// <summary>
        /// Méthode pour remplir les images
        /// </summary>
        private void RemplirImages()
        {
            _imageJoueur.ImageSource = new BitmapImage(new Uri("../../../images/bato1.png", UriKind.Relative));
            _imageGallion.ImageSource = new BitmapImage(new Uri("../../../images/bato2.png", UriKind.Relative));
            _imageBackground.ImageSource = new BitmapImage(new Uri("../../../images/background.png", UriKind.Relative));
            _imageOr.ImageSource = new BitmapImage(new Uri("../../../images/coin.png", UriKind.Relative));
            _imagePirate.ImageSource = new BitmapImage(new Uri("../../../images/pirate.png", UriKind.Relative));
            _imagePort.ImageSource = new BitmapImage(new Uri("../../../images/port.png", UriKind.Relative));
            _imageCannon.ImageSource = new BitmapImage(new Uri("../../../images/cannon.png", UriKind.Relative));
            _imageCannonGros.ImageSource = new BitmapImage(new Uri("../../../images/cannonGros.png", UriKind.Relative));
            _imageCannonPetit.ImageSource = new BitmapImage(new Uri("../../../images/cannonPetit.png", UriKind.Relative));
            _imageEscorte.ImageSource = new BitmapImage(new Uri("../../../images/bato3.png", UriKind.Relative));
            myCanvas.Background = _imageBackground;
            player.Fill = _imageJoueur;
            galion.Fill = _imageGallion;
            galion2.Fill = _imageGallion;
            or.Fill = _imageOr;
            port.Fill = _imagePort;
            equipage.Fill = _imagePirate;
            cannonMoyen.Fill = _imageCannon;
            grosCannon.Fill = _imageCannonGros;
            petitCannon.Fill = _imageCannonPetit;
            escorte1.Fill = _imageEscorte;
            escorte2.Fill = _imageEscorte;
            escorte3.Fill = _imageEscorte;
            escorte4.Fill = _imageEscorte;
        }

    }
}

