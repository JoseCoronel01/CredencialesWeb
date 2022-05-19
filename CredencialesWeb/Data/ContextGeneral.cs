using CredencialesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CredencialesWeb.Data
{
    public class ContextGeneral : DbContext
    {
        private readonly CredencialesContext credencialesContext;

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public ContextGeneral(CredencialesContext context)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            this.credencialesContext = context;
        }

        public async Task<List<Credenciales>> GetCredenciales()
        {
            return await this.credencialesContext.Credenciales.Where(x => x.Baja == 0).ToListAsync();
        }

        public async Task<Credenciales> ObtenerCredencial(int Id)
        {
            return await this.credencialesContext.Credenciales.Where(a => a.Id == Id).FirstAsync();
        }

        public async Task<int> NuevaCredencial(Credenciales obj)
        {
            this.credencialesContext.Credenciales.Add(obj);
            return await this.credencialesContext.SaveChangesAsync();
        }

        public async Task<int> NuevoIdCredencial()
        {
            int Id = 0;
            try
            {
                var obj = await this.credencialesContext.Credenciales.OrderByDescending(a => a.Id).FirstAsync();
                Id = obj.Id + 1;
            }
            catch 
            {
                Id = 1;
            }
            finally
            {
            }
            return Id;
        }

        public async Task<int> EditarCredencial(Credenciales obj)
        {
            this.credencialesContext.Entry<Credenciales>(obj).State = EntityState.Modified;
            return await this.credencialesContext.SaveChangesAsync();
        }

        public async Task<Protocolo> ObtenerProtocolo(int id)
        {
            return await this.credencialesContext.Protocolo.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<List<Menu>> GetMenu()
        {
            List<Menu> menus = new List<Menu>();
            List<Categoria> categorias = await this.credencialesContext.Categoria.OrderBy(x => x.Nombre).ToListAsync();
            foreach (Categoria item in categorias)
            {
                menus.Add(new Menu()
                {
                    MenuItem = item.Nombre,
                    SubMenuItems = await CargaSubMenus(item.Id)
                });
            }

            return menus;
        }

        private async Task<List<SubMenu>> CargaSubMenus(int categoriaid)
        {
            List<SitiosWeb> sitios = await this.credencialesContext.SitiosWeb.Where(x => x.CategoriaId == categoriaid).OrderBy(y => y.RutaUrl).ToListAsync();
            List<SubMenu> lista = new List<SubMenu>();
            foreach (SitiosWeb item in sitios)
            {
                SubMenu subMenu = new SubMenu();
                var proto = await ObtenerProtocolo(item.ProtocoloId);
                subMenu.SubItem = proto.Nombre + item.RutaUrl;
                lista.Add(subMenu);
            }
            return lista;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await this.credencialesContext.Categoria.OrderBy(x => x.Nombre).ToListAsync();
        }

        public async Task<Categoria> ObtenerCategoria(int id)
        {
            return await this.credencialesContext.Categoria.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<int> NuevaCategoria(Categoria obj)
        {
            this.credencialesContext.Categoria.Add(obj);
            return await this.credencialesContext.SaveChangesAsync();
        }

        public async Task<int> NuevoIdCategoria()
        {
            int id = 0;
            try
            {
                var obj = await this.credencialesContext.Categoria.OrderByDescending(x => x.Id).FirstAsync();
                id = obj.Id + 1;
            }
            catch
            {
                id = 1;
            }
            finally
            {

            }
            return id;
        }

        public async Task<int> EditarCategoria(Categoria obj)
        {
            this.credencialesContext.Entry<Categoria>(obj).State = EntityState.Modified;
            return await this.credencialesContext.SaveChangesAsync();
        }

        public async Task<List<SitiosWeb>> GetSitiosWeb(int categoria)
        {
            return await this.credencialesContext.SitiosWeb.Where(x => x.CategoriaId == categoria).OrderBy(y => y.RutaUrl).ToListAsync();
        }

        public async Task<SitiosWeb> ObtenerSitioWeb(int id)
        {
            return await this.credencialesContext.SitiosWeb.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<int> NuevoSitioWeb(SitiosWeb obj)
        {
            this.credencialesContext.SitiosWeb.Add(obj);
            return await this.credencialesContext.SaveChangesAsync();
        }

        public async Task<int> NuevoIdSitioWeb()
        {
            int id = 0;
            try
            {
                var obj = await this.credencialesContext.SitiosWeb.OrderByDescending(x => x.Id).FirstAsync();
                id = obj.Id + 1;
            }
            catch
            {
                id = 1;
            }
            return id;
        }

        public async Task<int> EditarSitioWeb(SitiosWeb obj)
        {
            this.credencialesContext.Entry<SitiosWeb>(obj).State = EntityState.Modified;
            return await this.credencialesContext.SaveChangesAsync();
        }
    }
}
