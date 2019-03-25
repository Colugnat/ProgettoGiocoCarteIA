using GiocoCarteIA.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEye.Controls.Wpf;

namespace GiocoCarteIA.ViewModel
{
    public class StartGameViewModel : BindableBase
    {
        public Image ImageToAnalyze { get; set; }
        public IDelegateCommand SelectCard { get; private set; }
        public StartGameViewModel()
        {
            SelectCard = new DelegateCommand(OnSelectCard, CanSelectCard);
           //System.Environment.SpecialFolder.
        }

        private bool CanSelectCard(object arg)
        {
            return true;
        }

        private void OnSelectCard(object obj)
        {
        }
    }
}
