using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using System.Data;

namespace DropIt.DAL
{
    public class CategoryRepository: BaseRepository,ICategoryRepository
    {
        public CategoryRepository(DropItContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Category> GetAll()
        {
            return ctx.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return ctx.Categories.Find(id);
        }

        public void AddOrUpdate(Category cat)
        {

            if (cat.CategoryId == default(int))
            {
                ctx.Categories.Add(cat);
            }
            else
            {

                ctx.Entry(cat).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            Category Cat = ctx.Categories.Find(id);
            ctx.Categories.Remove(Cat);
        }
    }
}