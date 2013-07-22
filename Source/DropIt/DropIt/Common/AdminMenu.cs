using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using DropIt.Common;

namespace DropIt.Common
{
    public class Menu
    {
        public string Title { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
        public string CustomHref { get; set; }
        public string Icon = "home";

        public Menu()
        {

        }

        public string TagA()
        {
            string href = "";
            if (CustomHref != null)
            {
                href = CustomHref;
            }
            else
            {
                if (Area != null) href += "/" + Area;
                href += "/" + Controller;
                if (Action != null || Action != "Index") href += "/" + Action;
                if (Data != null) href += Data;
            }
            return "<a href='" + href + "'><i class='icon-" + Icon + "'></i>" + Title + "</a>";
        }
    }

    public class AdminMainMenu : Menu
    {
        public string DefaultAction = "Index";
        public List<AdminSubMenu> Childs = new List<AdminSubMenu>();
        public AdminMainMenu()
        {
            Area = "Administration";
            Action = DefaultAction;
        }
        public void AddChild(AdminSubMenu menu)
        {
            menu.Area = Area;
            menu.Controller = Controller;
            Childs.Add(menu);
        }
    }

    public class AdminSubMenu : Menu
    {

    }

    public class AdminMenuList : IEnumerable
    {
        public Dictionary<String, AdminMainMenu> AdminMenu = new Dictionary<string, AdminMainMenu>();
        public void Add(AdminMainMenu menu)
        {
            string name = menu.Controller.ToLower();
            AdminMenu.Add(name, menu);
        }
        public List<AdminSubMenu> GetSubMenu(string MainMenuName)
        {
            return AdminMenu[MainMenuName.ToLower()].Childs;
        }

        public IEnumerator GetEnumerator()
        {
            return AdminMenu.Values.GetEnumerator();
        }
    }

    public static class AdminMenu
    {
        public static AdminMenuList adminMenuList = new AdminMenuList();

        public static void Init()
        {
            Equals(adminMenuList, null);
        }

        static AdminMenu()
        {
            AdminMainMenu Dashboard = new AdminMainMenu()
            {
                Controller = "Dashboard",
                Title = "Dashboard"

            };
            Dashboard.AddChild(new AdminSubMenu()
            {
                Action = "Index",
                Title = "Trang chủ",
                Icon = "icon-camera-retro"
            });
            Dashboard.AddChild(new AdminSubMenu()
            {
                Action = "Statictist",
                Title = "Thống kê"
            });
            Dashboard.AddChild(new AdminSubMenu()
            {
                Action = "Article",
                Title = "Bài viết"
            });

            adminMenuList.Add(Dashboard);

            AdminMainMenu User = new AdminMainMenu()
            {
                Controller = "User",
                Title = "Người dùng",
                Icon = "user"
            };
            User.AddChild(new AdminSubMenu()
            {
                Action = "Index",
                Title = "Danh sách",
                Icon = "list"
            });
            adminMenuList.Add(User);

            AdminMainMenu Ticket = new AdminMainMenu()
            {
                Controller = "Ticket",
                Title = "Vé",
                Icon = "tags"
            };
            adminMenuList.Add(Ticket);

            AdminMainMenu Event = new AdminMainMenu()
            {
                Controller = "Event",
                Title = "Sự kiện",
                Icon = "tasks"
            };

            adminMenuList.Add(Event);

            AdminMainMenu Transaction = new AdminMainMenu()
            {
                Controller = "Transaction",
                Title = "Giao dịch",
                Icon = "shopping-cart"
            };

            adminMenuList.Add(Transaction);
            // category,event,province,venue
            AdminMainMenu Venue = new AdminMainMenu()
              {
                  Controller = "Venue",
                  Title = "Địa điểm",
                  Icon = "globe"
              };
            adminMenuList.Add(Venue);

            AdminMainMenu Setting = new AdminMainMenu()
            {
                Controller = "Setting",
                Title = "Tùy chỉnh",
                Icon = "wrench"
            };
            adminMenuList.Add(Setting);
        }
    }
}