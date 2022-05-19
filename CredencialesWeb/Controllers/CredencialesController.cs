using Microsoft.AspNetCore.Mvc;
using CredencialesWeb.Models;
using CredencialesWeb.Data;

namespace CredencialesWeb.Controllers
{
    public class CredencialesController : Controller
    {
        private readonly CredencialesContext _db;

        public CredencialesController(CredencialesContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Credenciales> lista = new List<Credenciales>();
            try
            {
                using (var db = new ContextGeneral(_db))
                {
                    lista.Clear();
                    lista = await db.GetCredenciales();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
            }
            return View(lista);
        }

        [HttpGet("/Credenciales/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empresa,Clave,Usuario,Producto,Baja")] Credenciales obj)
        {
            int Exito = 0;
            string ErrorMessage = "";
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new ContextGeneral(_db))
                    {
                        obj.Id = await db.NuevoIdCredencial();
                        Exito = await db.NuevaCredencial(obj);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
                finally
                {
                }
                if (Exito > 0)
                    return RedirectToAction("Index");
                else
                    return View(new ErrorViewModel() { RequestId = "Ocurrió un error al procesar la solicitud. " + ErrorMessage });
            }
            return View();
        }

        [HttpGet("/Credenciales/Edit/{Id}")]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Credenciales obj = new Credenciales();
            using (var db = new ContextGeneral(_db))
            {
                obj = await db.ObtenerCredencial((int)Id);
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Empresa,Clave,Usuario,Producto,Baja")] Credenciales obj)
        {
            if (Id != obj.Id)
            {
                return NotFound();
            }
            int Exito = 0;
            string ErrorMessage = "";
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new ContextGeneral(_db))
                    {
                        Exito = await db.EditarCredencial(obj);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
                finally
                {
                }
                if (Exito > 0)
                    return RedirectToAction("Index");
                else
                    return View(new ErrorViewModel() { RequestId = "Ocurrío un error al editar el registro. " + ErrorMessage });
            }
            return View();
        }
    }
}
