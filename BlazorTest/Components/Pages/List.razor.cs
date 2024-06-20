using BlazorTest.Models;
using BlazorTest.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTest.Components.Pages
{
    public partial class List
    {
        [Inject]
        private ApiService apiService { get; set; }
        private List<Comment> lsComments = new List<Comment>();
        private List<Comment> pagedComments = new List<Comment>();
        private int currentPage = 1;
        private int pageSize = 9;

        protected override async Task OnInitializedAsync()
        {
            lsComments = await apiService.GetCommentsAsync();
            await base.OnInitializedAsync();

            UpdatePagedComments();
        }

        private void UpdatePagedComments()
        {
            pagedComments = lsComments
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        private void NextPage()
        {
            if (currentPage * pageSize < lsComments.Count)
            {
                currentPage++;
                UpdatePagedComments();
            }
        }

        private void PreviousPage()
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdatePagedComments();
            }
        }

        private bool IsNextDisabled => currentPage * pageSize >= lsComments.Count;
        private bool IsPreviousDisabled => currentPage <= 1;
    }
}

