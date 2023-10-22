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

namespace Pendu_Numero_2
{
    public partial class MainWindow : Window
    {
        List<string> pays = new List<string>();
        List<string> capitales = new List<string>();
        private int vie = 7;
        private string motMystere;

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
            // Ajoutez d'autres capitales ici...

            // Désactiver tous les boutons du clavier au démarrage
            foreach (Button button in Clavier.Children)
            {
                button.IsEnabled = false;
            }
        }

        private void btnPays_Click(object sender, RoutedEventArgs e)
        {
            // Réinitialiser le nombre de vies à 7
            vie = 7;
            TBvie.Text = "Vies : " + vie.ToString();

            // Mettre à jour l'image
            Image.Source = null;

            // Prendre un mot aléatoire dans la liste de pays
            Random aleatoire = new Random();
            int index = aleatoire.Next(pays.Count);
            motMystere = pays[index];

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

        private void btnCapitale_Click(object sender, RoutedEventArgs e)
        {
            // Réinitialiser le nombre de vies à 7
            vie = 7;
            TBvie.Text = "Vies : " + vie.ToString();

            // Mettre à jour l'image
            Image.Source = null;

            // Prendre un mot aléatoire dans la liste de capitales
            Random aleatoire = new Random();
            int index = aleatoire.Next(capitales.Count);
            motMystere = capitales[index];

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

            // Mettre à jour l'image
            UpdateImage();
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

            // Mettre à jour l'image
            UpdateImage();
        }

        private void UpdateImage()
        {
            int imageIndex = 7 - vie; // Calcul de l'index de l'image en fonction du nombre de vies restantes
            if (imageIndex >= 1 && imageIndex <= 7)
            {
                string imagePath = $"pack://application:,,,/Ressources/Images/{imageIndex}.png";
                ImageSource imageSource = new BitmapImage(new Uri(imagePath));
                Image.Source = imageSource;
            }
        }
    }
}