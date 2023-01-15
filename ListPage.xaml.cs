using SarciniMuncitori.Models;
namespace SarciniMuncitori;

public partial class ListPage : ContentPage
{
    public ListPage()
	{
		InitializeComponent();
	}

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SarcinaPage((SarcinaMuncitor)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (SarcinaMuncitor)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveSarcinaMuncitorAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (SarcinaMuncitor)BindingContext;
        await App.Database.DeleteSarcinaMuncitorAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Product product;
        var SarcinaMuncitor = (SarcinaMuncitor)BindingContext;
        if(listView.SelectedItem != null)
        {
            product = listView.SelectedItem as Product;
            var ListaSarcinaAll = await App.Database.GetListaSarcinas();
            var ListaSarcina = ListaSarcinaAll.FindAll(x => x.ProductID == product.ID & x.SarcinaMuncitorID == SarcinaMuncitor.ID);
            await App.Database.DeleteListaSarcinaAsync(ListaSarcina.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (SarcinaMuncitor)BindingContext;

        listView.ItemsSource = await App.Database.GetListaSarcinasAsync(shopl.ID);
    }

}