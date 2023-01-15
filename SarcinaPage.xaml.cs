using SarciniMuncitori.Models;

namespace SarciniMuncitori;

public partial class SarcinaPage : ContentPage
{
    SarcinaMuncitor sl;
    public SarcinaPage(SarcinaMuncitor slist)
    {
        InitializeComponent();
        sl = slist;

    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        await App.Database.SaveProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        await App.Database.DeleteProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Product p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Product;
            var lp = new ListaSarcina()
            {
                SarcinaMuncitorID = sl.ID,
                ProductID = p.ID
            };
            await App.Database.SaveListaSarcinaAsync(lp);
            p.ListaSarcinas = new List<ListaSarcina> { lp };
            await Navigation.PopAsync();
        }
    }


       
}
