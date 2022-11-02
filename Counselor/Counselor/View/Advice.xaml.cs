using Counselor.Model;
using Counselor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Counselor.View
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class Advice : ContentPage
    {
        public async void Default()
        {
            Advices advice = await DataService.GetAdvicebyNum("69");
            this.BindingContext = advice;
        }
        public Advice()
        {
            InitializeComponent();
            
            this.BindingContext = new Advices();
            Default();


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (!String.IsNullOrEmpty(ent_Num.Text))
                {
                    Advices advice = await DataService.GetAdvicebyNum(ent_Num.Text);
                    
                    this.BindingContext = advice;

                }
                else
                {

                    Advices advice = await DataService.GetAdviceRandom();
                    this.BindingContext = advice;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
    }
