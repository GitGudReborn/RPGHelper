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
using System.Windows.Shapes;
using RPGHelper.Data;
using RPGHelper.Models;
using RPGHelper.Services;

namespace RPGHelper.Client.Views
{
    /// <summary>
    /// Interaction logic for EditHeroView.xaml
    /// </summary>
    public partial class EditHeroView : Window
    {
        private RPGHelperContext context = new RPGHelperContext();

        public EditHeroView(Hero currentHero)
        {
            InitializeComponent();
            DataContext = currentHero;
        }

        private void SaveHero_Button(object sender, RoutedEventArgs e)
        {
            var currentHero = (Hero)DataContext;
            stsBarTextBlock.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
            if (HeroNameBox.Text == null || HeroNameBox.Text.Length < 3 || HeroNameBox.Text.Length > 60)
            {
                stsBarTextBlock.Text = "Hero name length allowed: 3-60!";
                HeroNameBox.Focus();
                HeroNameBox.SelectAll();
                return;
            }
            if (GoldBox.Text == null || GoldBox.Text == "" || decimal.Parse(GoldBox.Text) < 0)
            {
                stsBarTextBlock.Text = "Gold cannot be negative or null!";
                GoldBox.Focus();
                GoldBox.SelectAll();
                return;
            }
            if (HpBox.Text == null || HpBox.Text == "" || double.Parse(HpBox.Text) < 0)
            {
                stsBarTextBlock.Text = "Hp cannot be negative or null!";
                HpBox.Focus();
                HpBox.SelectAll();
                return;
            }
            if (ManaBox.Text == null || ManaBox.Text == "" || double.Parse(ManaBox.Text) < 0)
            {
                stsBarTextBlock.Text = "Mana cannot be negative or null!";
                ManaBox.Focus();
                ManaBox.SelectAll();
                return;
            }
            if (DefenceBox.Text == null || DefenceBox.Text == "" || double.Parse(DefenceBox.Text) < 0)
            {
                stsBarTextBlock.Text = "Defence cannot be negative or null!";
                DefenceBox.Focus();
                DefenceBox.SelectAll();
                return;
            }
            if (AttackPowerBox.Text == null || AttackPowerBox.Text == "" || double.Parse(AttackPowerBox.Text) < 0)
            {
                stsBarTextBlock.Text = "AttackPower cannot be negative or null!";
                AttackPowerBox.Focus();
                AttackPowerBox.SelectAll();
                return;
            }

            var hero = context.Heroes.FirstOrDefault(h => h.Id == currentHero.Id);

            hero.Name = HeroNameBox.Text;
            hero.Gold = decimal.Parse(GoldBox.Text);
            hero.HeroStats.Hp = double.Parse(HpBox.Text);
            hero.HeroStats.Mana = double.Parse(ManaBox.Text);
            hero.HeroStats.Defence = double.Parse(DefenceBox.Text);
            hero.HeroStats.AttackPower = double.Parse(AttackPowerBox.Text);


            context.SaveChanges();
            stsBarTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            stsBarTextBlock.Text = "Success!";
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            stsBarTextBlock.Foreground = new SolidColorBrush(Colors.Blue);

            HeroNameBox.Text = string.Empty;
            GoldBox.Text = string.Empty;
            HpBox.Text = string.Empty;
            ManaBox.Text = string.Empty;
            DefenceBox.Text = string.Empty;
            AttackPowerBox.Text = string.Empty;

            stsBarTextBlock.Text = "Canceled, all clear!";
        }
    }
}
