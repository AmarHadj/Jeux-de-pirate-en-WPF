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
using System.Windows.Threading;
using Bateaux;
using System.Windows.Shapes;


namespace TP3
{
    /// <summary>
    /// Logique d'interaction pour Combat.xaml
    /// </summary>
    public partial class Combat : Window
    {
        private ImageBrush _imageBackground = new ImageBrush();
        private ImageBrush _imageEscorte = new ImageBrush();
        private ImageBrush _imageJoueur = new ImageBrush();
        private ImageBrush _imagePirate = new ImageBrush();
        private ImageBrush _imageEscortEquipage = new ImageBrush();
        private int _vitessePirate = MainWindow._joueur.vitesse;
        private int _degatTotauxPirate = 0;
        private int _nbEquipagePerdu = 0;
        private const int _vitesseEscorte = 15;
        private bool _tourJoueur = true;
        private int _nbEquipageEscorte = 100;
        private DispatcherTimer _tempsJeu = new DispatcherTimer();
        /// <summary>
        /// La page de combat
        /// </summary>
        public Combat()
        {
            InitializeComponent();
            CanvasCombat.Focus();
            RemplirImages();
            _tempsJeu.Tick += GameTimerEvent;
            _tempsJeu.Interval = TimeSpan.FromMilliseconds(1);
            _tempsJeu.Start();
        }
        /// <summary>
        /// Le timer du jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimerEvent(object sender, EventArgs e)
        {
            
            equipageNb.Content = MainWindow._joueur.equipage;
            equipageNbEnnemie.Content = _nbEquipageEscorte;
            if (_tourJoueur == false)
            {
                AvancerEnnemie();
            }


        }
        /// <summary>
        /// Méthode qui fait avancer le bateau pirate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Avancer(object sender, RoutedEventArgs e)
        {
            Rect _carrePirate = new Rect(Canvas.GetLeft(bateauPirate), Canvas.GetTop(bateauPirate), bateauPirate.Width, bateauPirate.Height);
            Canvas.SetLeft(bateauPirate, _carrePirate.X + _vitessePirate);
            _tourJoueur = false;
            
        }
        /// <summary>
        /// Méthode qui fait avancer le bateau d'escorte
        /// </summary>
        private void AvancerEnnemie()
        {
            Rect carreEscorte = new Rect(Canvas.GetLeft(bateauEscorte), Canvas.GetTop(bateauEscorte), bateauEscorte.Width, bateauEscorte.Height);
            Canvas.SetLeft(bateauEscorte, carreEscorte.X - _vitesseEscorte);
            _tourJoueur = true;
        }
        /// <summary>
        /// Méthode qui fait tirer le bateau pirate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tirer(object sender, RoutedEventArgs e)
        {
            _degatTotauxPirate += MainWindow._joueur.DegatCannonPetit +
                                 MainWindow._joueur.cannonBase +
                                 MainWindow._joueur.DegatCannonGros;
            _nbEquipagePerdu = _degatTotauxPirate / 2;
            _nbEquipageEscorte -= _nbEquipagePerdu;
            _nbEquipagePerdu = 0;
            _degatTotauxPirate = 0;

        }
        private void Abordage(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Méthode pour remplir les images
        /// </summary>
        private void RemplirImages()
        {
            _imageBackground.ImageSource = new BitmapImage(new Uri("../../../images/background_combat.png", UriKind.Relative));
            _imageEscorte.ImageSource = new BitmapImage(new Uri("../../../images/bato escorte_combat.png", UriKind.Relative));
            _imageJoueur.ImageSource = new BitmapImage(new Uri("../../../images/bato pirate_combat.png", UriKind.Relative));
            _imagePirate.ImageSource = new BitmapImage(new Uri("../../../images/pirate.png", UriKind.Relative));
            _imageEscortEquipage.ImageSource = new BitmapImage(new Uri("../../../images/escorte.png", UriKind.Relative));
            equipage.Fill = _imagePirate;
            equipageEnnemie.Fill = _imageEscortEquipage;
            CanvasCombat.Background = _imageBackground;
            bateauPirate.Fill = _imageJoueur;
            bateauEscorte.Fill = _imageEscorte;
        }
    }
}
