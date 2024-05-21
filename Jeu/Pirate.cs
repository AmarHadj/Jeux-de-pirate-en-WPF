using System;
using System.Collections.Generic;
using System.Text;

namespace Bateaux
{
    /// <summary>
    /// Classe qui représente un bateau pirate que le joueur va incarner
    /// </summary>
    public class Pirate
    {
        private bool _carte;
        private int _nbOr;
        private int _nbPirate;
        private int _nbCannonBase;
        private int _nbCannonPetit;
        private int _nbCannonGros;
        private int _vitesse;
        private int _degatCannonMoyen;
        private int _degatCannonPetit;
        private int _degatCannonGros;

        public int DegatCannonGros
        {
            get { return _degatCannonGros; }
            set { _degatCannonGros = value; }
        }


        public int DegatCannonPetit
        {
            get { return _degatCannonPetit; }
            set { _degatCannonPetit = value; }
        }


        public int DegatCannonMoyen
        {
            get { return _degatCannonMoyen; }
            set { _degatCannonMoyen = value; }
        } 


        public bool carteTresor
        {
            get { return _carte; }
            set { _carte = value; }
        }


        public int vitesse
        {
            get { return _vitesse; }
            set { _vitesse = value; }
        }


        public int grosCannon
        {
            get { return _nbCannonGros; }
            set { _nbCannonGros = value; }
        }

        public int petitCannon
        {
            get { return _nbCannonPetit; }
            set { _nbCannonPetit = value; }
        }


        public int cannonBase
        {
            get { return _nbCannonBase; }
            set { _nbCannonBase = value; }
        }

        public int equipage
        {
            get { return _nbPirate; }
            set { _nbPirate = value; }
        }


        public int Or
        {
            get { return _nbOr; }
            set { _nbOr = value; }
        }
        /// <summary>
        /// Constructeur qui déclare un bateau pirate
        /// </summary>
        public Pirate()
        {
            _nbOr = 200;
            _nbPirate = 80;
            _nbCannonBase = 5;
            _nbCannonGros = 0;
            _nbCannonPetit = 0;
            _vitesse = 10;
            _degatCannonMoyen = 50;
            _carte = false;
        }
        /// <summary>
        /// Méthode qui calcule le nombre de degat en fonction du nombre de petits cannons
        /// </summary>
        /// <param name="nbCannon">le nombre de cannons</param>
        /// <returns></returns>
        public int CalculerDegatPetitCannon(int nbCannon)
        {
            int degat = nbCannon * 5;
            return degat;
        }
        /// <summary>
        /// Méthode qui calcule le nombre de degat en fonction du nombre de gros cannons
        /// </summary>
        /// <param name="nbCannon">le nombre de cannons</param>
        /// <returns></returns>
        public int CalculerDegatGrosCannon(int nbCannon)
        {
            int degat = nbCannon * 20;
            return degat;
        }
        /// <summary>
        /// Méthode qui calcule le nombre de degat en fonction du nombre de cannons moyens
        /// </summary>
        /// <param name="nbCannon">le nombre de cannons</param>
        /// <returns></returns>
        public int CalculerDegatMoyenCannon(int nbCannon)
        {
            int degat = nbCannon * 10;
            return degat;
        }
    }
}
