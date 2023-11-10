﻿using System;
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

namespace Pendu_Numero_2
{
    public partial class MainWindow : Window
    {
        List<string> pays = new List<string>();
        List<string> capitales = new List<string>();
        private int vie = 7;
        private string motMystere;
        private ImageSource debutImageSource;



        public MainWindow()
        {
            InitializeComponent();

            pays.Add("FRANCE");
            pays.Add("ESPAGNE");
            pays.Add("ITALIE");
            pays.Add("ALLEMAGNE");
            pays.Add("PORTUGAL");
            pays.Add("BELGIQUE");
            pays.Add("SUISSE");
            pays.Add("ROYAUME-UNI");
            pays.Add("AUTRICHE");
            pays.Add("IRLANDE");
            pays.Add("SUEDE");
            pays.Add("DANEMARK");
            pays.Add("FINLANDE");
            pays.Add("NORVEGE");
            pays.Add("GRECE");
            pays.Add("TURQUIE");
            pays.Add("POLOGNE");
            pays.Add("TCHEQUIE");
            pays.Add("HONGRIE");
            pays.Add("ROUMANIE");
            pays.Add("BULGARIE");
            pays.Add("CROATIE");
            pays.Add("SERBIE");
            pays.Add("SLOVENIE");
            pays.Add("SLOVAQUIE");
            pays.Add("UKRAINE");
            pays.Add("BIELORUSSIE");
            pays.Add("RUSSIE");
            pays.Add("ESTONIE");
            pays.Add("LETTONIE");
            pays.Add("LITUANIE");
            pays.Add("MOLDAVIE");
            pays.Add("BOSNIE-HERZEGOVINE");
            // Ajoutez d'autres pays ici...

            capitales.Add("PARIS");
            capitales.Add("MADRID");
            capitales.Add("ROME");
            capitales.Add("BERLIN");
            capitales.Add("LISBONNE");
            capitales.Add("BRUXELLES");
            capitales.Add("BERNE");
            capitales.Add("LONDRES");
            capitales.Add("VIENNE");
            capitales.Add("DUBLIN");
            capitales.Add("STOCKHOLM");
            capitales.Add("COPENHAGUE");
            capitales.Add("HELSINKI");
            capitales.Add("OSLO");
            capitales.Add("ATHENES");
            capitales.Add("ANKARA");
            capitales.Add("VARSOVIE");
            capitales.Add("PRAGUE");
            capitales.Add("BUDAPEST");
            capitales.Add("BUCHAREST");
            capitales.Add("SOFIA");
            capitales.Add("ZAGREB");
            capitales.Add("BELGRADE");
            capitales.Add("LJUBLJANA");
            capitales.Add("BRATISLAVA");
            capitales.Add("KIEV");
            capitales.Add("MINSK");
            capitales.Add("SARAJEVO");
            // Ajoutez d'autres capitales ici...

            // Charger et stocker l'image de départ
            string debutImagePath = "pack://application:,,,/Ressources/Images/debut.jpg";
            debutImageSource = new BitmapImage(new Uri(debutImagePath));
            Image.Source = debutImageSource;

            // Désactiver tous les boutons du clavier au démarrage
            foreach (Button button in Clavier.Children)
            {
                button.IsEnabled = false;
            }
        }


        public void startGame(List<string> LisInfo)
        {
            // Remettre l'image de départ
            Image.Source = debutImageSource;

            // Activer le bouton d'indice
            BTNindice.IsEnabled = true;

            // Réinitialiser le nombre de vies à 7
            vie = 7;
            TBvie.Text = "Vies : " + vie.ToString();

            // Prendre un mot aléatoire dans la liste de capitales
            Random aleatoire = new Random();
            int index = aleatoire.Next(LisInfo.Count);
            motMystere = LisInfo[index];

            // Cacher le mot avec des *
            TBmot.Text = new string('*', motMystere.Length);

            // Activer les boutons du clavier
            foreach (Button button in Clavier.Children)
            {
                button.IsEnabled = true;
            }

            // Mettre à jour l'image
            UpdateImage();
        }

        private void btnPays_Click(object sender, RoutedEventArgs e)
        {
            startGame(pays);
        }

        private void btnCapitale_Click(object sender, RoutedEventArgs e)
        {
            startGame(capitales);
        }

        private void btnLetter_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer la lettre du bouton cliqué
            Button button = (Button)sender;
            string lettre = button.Content.ToString();

            if (motMystere.Contains(lettre))
            {
                // La lettre est dans le mot mystère
                char[] motAffiche = TBmot.Text.ToCharArray();
                for (int i = 0; i < motMystere.Length; i++)
                {
                    if (motMystere[i].ToString() == lettre)
                    {
                        motAffiche[i] = lettre[0];
                    }
                }
                TBmot.Text = new string(motAffiche);

                // Désactiver le bouton cliqué
                button.IsEnabled = false;
            }
            else
            {
                // La lettre n'est pas dans le mot mystère
                vie--;
                TBvie.Text = "Vies : " + vie.ToString();

                // Désactiver le bouton cliqué
                button.IsEnabled = false;
            }

            // Mettre à jour l'image
            UpdateImage();



            // Vérifier si le joueur a gagné ou perdu
            if (TBmot.Text == motMystere)
            {
                MessageBox.Show("Bravo ! Vous avez gagné. Le mot était : " + motMystere);
                // Réinitialiser le jeu
                ResetGame();
            }
            else if (vie == 0)
            {

                MessageBox.Show("Désolé, vous avez perdu. Le mot était : " + motMystere);

                // Réinitialiser le jeu
                ResetGame();
            }

            // Désactiver le bouton d'indice si le joueur a une seule vie restante
            if (vie == 1)
            {
                BTNindice.IsEnabled = false;
            }

        }

        private void ResetGame()
        {
            motMystere = "";
            TBmot.Text = "Mot à deviner";
            // Désactiver les boutons du clavier
            foreach (Button button in Clavier.Children)
            {
                button.IsEnabled = false;
            }
            // Désactiver le bouton d'indice
            BTNindice.IsEnabled = false;
            // Mettre à jour l'image
            UpdateImage();
        }

        private void UpdateImage()
        {
            int imageIndex = 7 - vie; // Calcul de l'index de l'image en fonction du nombre de vies restantes


            if (imageIndex >= 1 && imageIndex <= 7)
            {
                string imagePath = $"pack://application:,,,/Ressources/Images/{imageIndex}.jpg";
                ImageSource imageSource = new BitmapImage(new Uri(imagePath));
                Image.Source = imageSource;
            }

        }

        private void BTNindice_Click(object sender, RoutedEventArgs e)
        {
            if (vie > 0)
            {
                // Trouver la première lettre cachée dans le mot mystère
                char[] motAffiche = TBmot.Text.ToCharArray();
                for (int i = 0; i < motMystere.Length; i++)
                {
                    if (motMystere[i] != '*' && motAffiche[i] == '*')
                    {
                        motAffiche[i] = motMystere[i];
                        break;
                    }
                }
                TBmot.Text = new string(motAffiche);

                // Décrémenter le nombre de vies
                vie--;
                TBvie.Text = "Vies : " + vie.ToString();

                // Désactiver le bouton d'indice après utilisation
                BTNindice.IsEnabled = false;

                // Mettre à jour l'image
                UpdateImage();
            }
        }

        private void btnRegle_Click(object sender, RoutedEventArgs e)
        {
            string regles = "Les règles du jeu sont les suivantes :\n\n" +
                            "1. Choisissez une catégorie (Pays ou Capitales) en cliquant sur le bouton correspondant.\n" +
                            "2. Un mot mystère sera sélectionné aléatoirement dans la catégorie choisie.\n" +
                            "3. Devinez les lettres en cliquant sur les boutons du clavier.\n" +
                            "4. Vous avez 7 vies. Chaque mauvaise lettre vous fait perdre une vie.\n" +
                            "5. Utilisez le bouton Indice pour révéler une lettre du mot mystère (1 utilisation par partie).\n" +
                            "   Note : Vous ne pouvez pas utiliser l'indice s'il ne vous reste qu'une vie.\n" +
                            "6. Gagnez en devinant correctement le mot ou perdez si vous épuisez toutes vos vies.\n" +
                            "7. Vous pouvez cliquer sur les boutons 'Pays' ou 'Capitale' à la fin d'une partie pour recommencer.\n\n" +
                            "Amusez-vous bien !";

            MessageBox.Show(regles, "Règles du jeu");
        }
    }
}