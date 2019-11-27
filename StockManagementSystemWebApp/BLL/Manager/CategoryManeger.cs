using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Model;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class CategoryManeger
    {
        private CategoryGateway setupCategoryGateway;

        public CategoryManeger()
        {
            setupCategoryGateway = new CategoryGateway();
        }

        public string Save(Category category)
        {
            bool IsExistsCategory = setupCategoryGateway.IsExistsCategory(category.CategoryName);
            if (IsExistsCategory)
            {
                return "Category already exist! Try another category.";
            }
            else
            {
                int rowAffect = setupCategoryGateway.Save(category);
                if (rowAffect > 0)
                {
                    return "Category saved succesfully!";
                }
                else
                {
                    return "Failed to save category!";
                }
            }
        }

        public List<Category> GetAllCategories()    
        {
            return setupCategoryGateway.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return setupCategoryGateway.GetCategoryById(id);
        }

        public string UpdateCategoryById(Category category)
        {
            int rowAffect = setupCategoryGateway.UpdateCategoryById(category);
            if (rowAffect > 0)
            {
                return "Updated successfully!";
            }
            else
            {
                return "Failed to update!";
            }
        }

        public bool IsExistsCategory(string categoryName)
        {
            return setupCategoryGateway.IsExistsCategory(categoryName);
        }
    }
}