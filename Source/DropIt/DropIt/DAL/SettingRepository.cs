using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DropIt.Models;

namespace DropIt.DAL
{
    public class SettingRepository: GenericRepository<Setting>
    {
        public SettingRepository(DropItContext context) : base(context)
        {
            
        }

        new public Setting AddOrUpdate(Setting setting)
        {
            var findSetting = context.Settings.Find(setting.Id);
            if (findSetting==null)
            {
                context.Settings.Add(setting);
            }
            else
            {
                var entry = context.Entry(setting);
                if (entry.State == EntityState.Detached)
                {
                    var set = context.Set<Setting>();
                    Setting attachedEntity = set.Find(setting.Id);
                    if (attachedEntity!=null)
                    {
                        context.Entry(attachedEntity).CurrentValues.SetValues(setting);
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                    }
                }
            }
            return setting;
        }
    }
}