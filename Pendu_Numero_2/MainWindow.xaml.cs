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
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //création d'une liste de pays
        List<string> pays = new List<string>();

        

        public MainWindow()
        {
            InitializeComponent();
            //ajouter des pays à la liste
            pays.Add("France");
            pays.Add("Espagne");
            pays.Add("Italie");
            pays.Add("Allemagne");
            pays.Add("Portugal");
            pays.Add("Belgique");
            pays.Add("Suisse");
            pays.Add("Angleterre");
            pays.Add("Pays-Bas");
            pays.Add("Autriche");
            pays.Add("Danemark");
            pays.Add("Suède");
            pays.Add("Norvège");
            pays.Add("Finlande");
            pays.Add("Irlande");
            pays.Add("Ecosse");
        }

        //afficher un mot aléatoire dans txtMot depuis la liste pays
        private void btnMotAleatoire_Click(object sender, RoutedEventArgs e)
        {
            //création d'un objet aléatoire
            Random aleatoire = new Random();
            //création d'une variable qui va contenir un nombre aléatoire entre 0 et le nombre d'éléments de la liste pays
            int index = aleatoire.Next(pays.Count);
            //afficher le mot aléatoire dans txtMot
            txtMot.Text = pays[index];
        }

        private void btnLetter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
