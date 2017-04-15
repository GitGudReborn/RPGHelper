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
using RPGHelper.Data;
using RPGHelper.Models;
using RPGHelper.Services;

namespace RPGHelper.Client.Views
{
    /// <summary>
    /// Interaction logic for HeroesView.xaml
    /// </summary>
    public partial class HeroesView : UserControl
    {
        public HeroesView()
        {
            InitializeComponent();

            //var hero1 = new Hero()
            //{
            //    Name = "Kunkka",
            //    Gold = 2000m
            //};

            //var hero2 = new Hero()
            //{
            //    Name = "Sven",
            //    Gold = 2000m
            //};

            //var hero3 = new Hero()
            //{
            //    Name = "Mirana",
            //    Gold = 2000m
            //};

            //var heroes = new List<Hero>();

            //heroes.Add(hero1);
            //heroes.Add(hero2);
            //heroes.Add(hero3);

            //foreach (var hero in heroes)
            //{
            //    var listHeroes = new ListViewItem();
            //    listHeroes.Content = hero.Name;
            //    HeroesList.Items.Add(listHeroes);
            //}

            //HeroesList.Items.Add(heroes);

            var context = new RPGHelperContext();

            var user = AuthenticationService.GetCurrentUser();

            var heroes = context.Heroes
                //.Where(h => h.UserId == user.Id)
                .OrderBy(h => h.Name)
                .ToList();

            var heroesList = new List<Hero>();

            foreach (var hero in heroes)
            {
                heroesList.Add(hero);
            }

            this.DataContext = new List<Hero>(heroesList);
            //HeroesList.ItemsSource = heroesList;
        }

        private void AddHero_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
