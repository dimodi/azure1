using System;
using Telerik.Blazor.Components;
using TelerikBlazorEF.Data;

namespace TelerikBlazorEF.Pages
{
    //public partial class Index
    //{
    //    private DateTime DateValue { get; set; } = DateTime.Now;

    //    private List<Product> ProductData { get; set; } = new List<Product>();

    //    private List<Category> CategoryData { get; set; } = new List<Category>();

    //    private async Task OnCategoryUpdate(GridCommandEventArgs args)
    //    {
    //        var updatedCategory = (Category)args.Item;

    //        var originalIndex = CategoryData.FindIndex(x => x.Id == updatedCategory.Id);

    //        if (originalIndex >= 0)
    //        {
    //            CategoryData[originalIndex] = updatedCategory;

    //            await CategoryService.UpdateCategoryAsync(updatedCategory);
    //        }
    //    }

    //    private async Task OnCategoryCreate(GridCommandEventArgs args)
    //    {
    //        var createdCategory = (Category)args.Item;

    //        var newId = await CategoryService.CreateCategoryAsync(createdCategory);

    //        createdCategory.Id = newId;

    //        CategoryData.Insert(0, createdCategory);
    //    }

    //    private async Task OnCategoryDelete(GridCommandEventArgs args)
    //    {
    //        var deletedCategory = (Category)args.Item;

    //        CategoryData.Remove(deletedCategory);

    //        await CategoryService.DeleteCategoryAsync(deletedCategory);
    //    }

    //    private async Task OnProductUpdate(GridCommandEventArgs args)
    //    {
    //        var updatedProduct = (Product)args.Item;

    //        var originalIndex = ProductData.FindIndex(x => x.Id == updatedProduct.Id);

    //        if (originalIndex >= 0)
    //        {
    //            ProductData[originalIndex] = updatedProduct;

    //            await ProductService.UpdateProductAsync(updatedProduct);
    //        }
    //    }

    //    private async Task OnProductCreate(GridCommandEventArgs args)
    //    {
    //        var createdProduct = (Product)args.Item;

    //        var newId = await ProductService.CreateProductAsync(createdProduct);

    //        createdProduct.Id = newId;

    //        ProductData.Insert(0, createdProduct);
    //    }

    //    private async Task OnProductDelete(GridCommandEventArgs args)
    //    {
    //        var deletedProduct = (Product)args.Item;

    //        ProductData.Remove(deletedProduct);

    //        await ProductService.DeleteProductAsync(deletedProduct);
    //    }

    //    private async Task LoadData()
    //    {
    //        ProductData = await ProductService.GetProductsAsync();
    //        CategoryData = await CategoryService.GetCategoriesAsync();
    //    }

    //    protected override async Task OnInitializedAsync()
    //    {
    //        await LoadData();

    //        await base.OnInitializedAsync();
    //    }
    //}
}
