using Entities.Models;
using Repositories.UnitOfWorks;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await unitOfWork.GetRepository<Category>().GetAllAsync();
        }
    }
}