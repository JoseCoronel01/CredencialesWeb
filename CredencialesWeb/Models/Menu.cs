namespace CredencialesWeb.Models
{
    public class Menu
    {
        public string? MenuItem { get; set; }
        public List<SubMenu>? SubMenuItems { get; set; }
    }

    public class SubMenu
    {
        public string? SubItem { get; set; }
    }
}
