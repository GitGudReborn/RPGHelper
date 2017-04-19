using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            LoadData();
            
        }

        public void LoadData()
        {
            var context = new RPGHelperContext();
            var user = AuthenticationService.GetCurrentUser();

            this.DataContext = new ObservableCollection<Hero>
                (
                    context.Heroes
                    .Where(h => h.UserId == user.Id)
                    .OrderBy(h => h.Name)
                    .ToList()
                );
        }

        private void AddHero_Click(object sender, RoutedEventArgs e)
        {
            var addNewHero = new AddHeroView();
            addNewHero.Show();
            LoadData();
        }

        private void EditHero_OnClick(object sender, RoutedEventArgs e)
        {
            var context = new RPGHelperContext();
            Button b = sender as Button;
            var currentHeroId = (int)b.DataContext;
            var currentHero = context.Heroes.FirstOrDefault(h => h.Id == currentHeroId);

            var edditHero = new EditHeroView(currentHero);
            edditHero.Show();
            LoadData();
        }

        private void DeleteHero_Click(object sender, RoutedEventArgs e)
        {
            var context = new RPGHelperContext();
            Button b = sender as Button;
            var currentHeroId = (int)b.DataContext;
            var currentHero = context.Heroes.FirstOrDefault(h => h.Id == currentHeroId);

            var result = MessageBox.Show("Are you sure you want to delete this Hero?", "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes && currentHero != null)
            {
                using (context = new RPGHelperContext())
                {
                    Hero heroToRemove = context.Heroes.FirstOrDefault(h => h.Id == currentHero.Id);
                    HeroStats heroStats = context.HeroStatistics.FirstOrDefault(hs => hs.Hero.Id == currentHero.Id);

                    if (heroStats != null)
                    {
                        context.HeroStatistics.Remove(heroStats);
                        context.SaveChanges();
                    }
                    if (heroToRemove != null)
                    {
                        context.Heroes.Remove(heroToRemove);
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Hero removed successfully!");
                LoadData();
            }
            if (currentHero == null)
            {
                MessageBox.Show("This Hero is not added yet!");
            }
        }

        private void HeroAddItem_OnClick_Click(object sender, RoutedEventArgs e)
        {
            var context = new RPGHelperContext();
            Button b = sender as Button;
            var currentHeroId = (int)b.DataContext;
            var currentHero = context.Heroes.FirstOrDefault(h => h.Id == currentHeroId);

            var heroAddItem = new HeroAddItemView(currentHero);
            heroAddItem.Show();
            LoadData();
        }
    }
}
