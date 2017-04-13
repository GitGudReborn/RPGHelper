using RPGHelper.Data;
using RPGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Client.ViewModels
{
    public class ProfileViewModel : ObservableObject
    {
        public virtual User User { get; set; }
    }
}
