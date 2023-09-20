//using ServiceTest.Models;
//using ServiceTest.Services;
using ServiceTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServiceTest.ViewModels
{
    public class MainPageViewModel:ViewModel
    {
        public TriviaService triviaService { get; set; }
        private string message;
        public string Message { 
            get { return message; } 
            set
            {
                message = value;
                OnPropertyChange(nameof(Message));
            } 
        }
        public ICommand getMessage { get; protected set; }


        public MainPageViewModel(TriviaService ts)
        {
            triviaService = ts;
            getMessage = new Command(async () => Message = await triviaService.CheckConnectionAsync());
        }
    }
}
