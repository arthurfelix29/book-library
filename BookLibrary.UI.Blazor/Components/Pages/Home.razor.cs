using BookLibrary.Application.Dtos;
using BookLibrary.Application.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BookLibrary.UI.Blazor.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private IApiService ApiService { get; set; }

        private IEnumerable<BookDto> Books { get; set; } = [];
        private IList<BookDto> BooksSelected { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            Books = await ApiService.Get<BookDto>("v1/books");

            await base.OnInitializedAsync();
        }

        private void OnRender(DataGridRenderEventArgs<BookDto> args)
        {
            if (args.FirstRender)
                args.Grid.Sorts.Add(new SortDescriptor { Property = "Title", SortOrder = SortOrder.Ascending });
        }
    }
}