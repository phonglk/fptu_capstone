using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;
using DropIt.Common;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DropIt.DAL
{
    public class    GenericRepository<TEntity> where TEntity : class
    {
        protected DropItContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(DropItContext ctx)
        {
            this.context = ctx;
            this.dbSet = ctx.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        
        public int Count { 
            get { return dbSet.Count();}
        }

        public virtual IEnumerable<TEntity> JTGet(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            var query = GetAll();

            if (jtSorting != null)
            {
                query = query.OrderBy(jtSorting);
            }

            if (jtPageSize != 0)
            {
                query = query.Skip(jtStartIndex).Take(jtPageSize);
            }

            return query.ToList();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public TEntity AddOrUpdate(TEntity entity)
        {
            DateTime now = DateTime.Now;
            var currentUser = GetCurrentUser();

            var propsEntity = typeof(TEntity).GetProperties();

            var entityId = propsEntity.FirstOrDefault(p => p.Name.Equals(typeof(TEntity).Name + "Id")).GetValue(entity,null);
            var createdDate = propsEntity.FirstOrDefault(p => p.Name.Equals("CreatedDate"));
            var lastModifiedDate = propsEntity.FirstOrDefault(p => p.Name.Equals("ModifiedDate"));
            var createdBy = propsEntity.FirstOrDefault(p => p.Name.Equals("CreatedBy"));
            var lastModifiedBy = propsEntity.FirstOrDefault(p => p.Name.Equals("LastModifedBy"));
            if ((int)entityId == default(int))
            {
                if (createdDate != null)
                {
                    createdDate.SetValue(entity, now,null);
                }
                if (lastModifiedDate != null)
                {
                    lastModifiedDate.SetValue(entity, now, null);
                }
                if (createdBy != null)
                {
                    createdBy.SetValue(entity, (currentUser != null) ? currentUser.UserId : 1, null);
                }
                if (lastModifiedBy != null)
                {
                    lastModifiedBy.SetValue(entity, (currentUser != null) ? currentUser.UserId : 1, null);
                }
                try
                {
                    return dbSet.Add(entity);
                }
                catch (Exception e)
                {
                    throw e;
                }
                
            }
            else
            {
                if (lastModifiedDate != null)
                {
                    lastModifiedDate.SetValue(entity, now, null);
                }
                if (lastModifiedBy != null)
                {
                    lastModifiedBy.SetValue(entity, (currentUser != null) ? currentUser.UserId : 1, null);
                }

                var entry = context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    var set = context.Set<TEntity>();
                    TEntity attachedEntity = set.Find(entityId);
                    if (attachedEntity != null)
                    {
                        var attachedEntry = context.Entry(attachedEntity);
                        attachedEntry.CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                    }
                }
                
            }

            return null;
        }

        protected User GetCurrentUser()
        {
            try
            {
                return context.Users.First(u => u.UserName.Equals(HttpContext.Current.User.Identity.Name));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

    }
}