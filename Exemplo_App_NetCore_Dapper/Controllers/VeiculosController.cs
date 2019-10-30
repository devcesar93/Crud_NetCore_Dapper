using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exemplo_App_NetCore_Dapper.Models;
using Exemplo_App_NetCore_Dapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Exemplo_App_NetCore_Dapper.Controllers
{
    public class VeiculosController : Controller
    {
        private IVeiculosRepository _veiculoRepository;

        //DI
        public VeiculosController(IVeiculosRepository veiculoRepository)
        {
            this._veiculoRepository = veiculoRepository;
        }
        // GET: Veiculos
        public ActionResult Index()
        {
            return View(_veiculoRepository.GetModelos());
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(int id)
        {
            return View(_veiculoRepository.Get(id));
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            ViewBag.Marcas = new SelectList(_veiculoRepository.GetMarcas(), "Id", "Marca");
            return View();
        }

        // POST: Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Veiculo_Modelo modelo)
        {
            try
            {
                modelo.MarcaId = Convert.ToInt32(collection["Marca"]);
                _veiculoRepository.Add(modelo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Marcas = new SelectList(_veiculoRepository.GetMarcas(), "Id", "Marca");
            Veiculo_Modelo modelo = _veiculoRepository.Get(id);
            return View(modelo);
        }

        // POST: Veiculos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Veiculo_Modelo modelo)
        {
            try
            {
                modelo.MarcaId = Convert.ToInt32(collection["Marca"]);
                _veiculoRepository.Edit(modelo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Veiculos/Delete/5
        public ActionResult Delete(int id)
        {
            _veiculoRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}