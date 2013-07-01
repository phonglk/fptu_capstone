using System.Data;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class FollowEventRepository : GenericRepository<UserFollowEvent>
    {
        public FollowEventRepository(DropItContext context)
            : base(context)
        {
            
        }

        override public UserFollowEvent AddOrUpdate(UserFollowEvent entity)
        {
            DateTime now = DateTime.Now;
            var currentUser = GetCurrentUser();

            var propsEntity = typeof(UserFollowEvent).GetProperties();

            var entityId = propsEntity.FirstOrDefault(p => p.Name.Equals("FollowEventId")).GetValue(entity, null);
            var createdDate = propsEntity.FirstOrDefault(p => p.Name.Equals("CreatedDate"));
            var lastModifiedDate = propsEntity.FirstOrDefault(p => p.Name.Equals("ModifiedDate"));
            var createdBy = propsEntity.FirstOrDefault(p => p.Name.Equals("CreatedBy"));
            var lastModifiedBy = propsEntity.FirstOrDefault(p => p.Name.Equals("LastModifedBy"));
            if ((int)entityId == default(int))
            {
                if (createdDate != null)
                {
                    createdDate.SetValue(entity, now, null);
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
                    var set = context.Set<UserFollowEvent>();
                    UserFollowEvent attachedEntity = set.Find(entityId);
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

        public UserFollowEvent GetById(int UserId, int EventId)
        {
            var findFollow = context.UserFollowEvents.Find(UserId, EventId);
            if (findFollow == null)
            {
                return null;
            }
            else
            {
                return findFollow;
            }
        }
    }
}