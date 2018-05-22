using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAds.Domain.Entities;
using CarAds.Domain.Interfaces.Services;
using AutoMapper;
using CarAds.MVC.Models;
using System.Threading.Tasks;

namespace CarAds.MVC.Controllers
{
    public class MotoristasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMotoristaService _motoristaService;

        public MotoristasController(IMapper mapper, IMotoristaService motoristaService)
        {
            _mapper = mapper;
            _motoristaService = motoristaService;
        }

        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
            var result = _mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaService.GetAllAsync());
            return View(result);
        }

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var motorista = await _motoristaService.GetByIdAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<MotoristaViewModel>(motorista);
            return View(result);
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome")] MotoristaViewModel motorista)
        {
            if (ModelState.IsValid)
            {
                var result = _mapper.Map<Motorista>(motorista);
                await _motoristaService.AddAsync(result);
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var motorista = await _motoristaService.GetByIdAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<MotoristaViewModel>(motorista);
            return View(result);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome")] MotoristaViewModel motorista)
        {
            if (id != motorista.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _mapper.Map<Motorista>(motorista);
                    await _motoristaService.UpdateAsync(result);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaExists(motorista.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _motoristaService.GetByIdAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<MotoristaViewModel>(motorista);
            return View(result);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorista = await _motoristaService.GetByIdAsync(id);
            await _motoristaService.RemoveAsync(motorista);

            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaExists(int id)
        {
            //return _context.Motoristas.Any(e => e.ID == id);
            return !(_motoristaService.GetByIdAsync(id) == null);
        }
    }
}
