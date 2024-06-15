using BlazorTest.Models;

namespace BlazorTest.Components.Pages
{
    public partial class Table
    {
        private List<Product> lsProducts = new List<Product>();
        private Product product = new Product();

        protected override void OnInitialized()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            lsProducts = DbContext.Products.ToList();
        }

        private void ResetProduct()
        {
            product = new Product();
        }

        private void SaveProduct()
        {
            if (product.Id == 0)
            {
                DbContext.Products.Add(product);
            }
            else
            {
                var product = DbContext.Products.Find(this.product.Id);
                if (product != null)
                {
                    product.Name = this.product.Name;
                    product.Color = this.product.Color;
                    product.Category = this.product.Category;
                    product.Price = this.product.Price;
                }
            }

            DbContext.SaveChanges();
            LoadProducts();
            ResetProduct();
        }

        private void EditProduct(Product product)
        {
            this.product = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Color = product.Color,
                Category = product.Category,
                Price = product.Price
            };
        }

        private void DeleteProduct(int id)
        {
            var product = DbContext.Products.Find(id);
            if (product != null)
            {
                DbContext.Products.Remove(product);
                DbContext.SaveChanges();
                LoadProducts();
            }
        }

        private bool IsSaveDisabled()
        {
            return string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Color) || string.IsNullOrWhiteSpace(product.Category) || product.Price <= 0;
        }

        private string GetSaveButtonClass()
        {
            return IsSaveDisabled()
                ? "bg-gray-500 text-white font-bold py-2 px-4 rounded cursor-not-allowed"
                : "bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded";
        }
    }
}
