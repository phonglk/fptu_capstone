using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.DAL;
using DropIt.Models;

namespace DropIt.Common
{
    public static class Settings
    {
        private static SettingRepository Repository = new SettingRepository(new DropItContext());
        public static string get(string SettingName)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Setting record = unitOfWork.SettingRepository.Get(s => s.SettingName == SettingName).FirstOrDefault();
            if(record == null)
            {
                return null;
            }
            else
            {
                return record.Value;
            }
        }

        public static void set(string SettingName, string Value)
        {
            Setting record = Repository.Get(s => s.SettingName == SettingName).FirstOrDefault();
            if (record!= null)
            {
                record.Value = Value;
                Repository.AddOrUpdate(record);
                Repository.Save();
            }            
            
        }
    }
}