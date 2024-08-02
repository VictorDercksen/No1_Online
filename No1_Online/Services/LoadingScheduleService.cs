using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.Interfaces;
using No1_Online.Models;
using No1_Online.ViewModels;
using System.Web.Mvc;

namespace No1_Online.Services
{
    public class LoadingScheduleService : ILoadingScheduleService
    {
        private readonly AppDbContext _context;

        public LoadingScheduleService(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<LoadingScheduleVM> GetLoadingSchedule(int? searchId)
        {
            var loadingScheduleVM = new LoadingScheduleVM();

            if (searchId == null)
            {
                // Initialize with default values for a new LoadingSchedule
                loadingScheduleVM.Initialize(new LoadingSchedule(), new List<TransportedProduct>(), new ClientPayment(), new Remitance());
                return loadingScheduleVM;
            }

            var loadingSchedule = await _context.LoadingSchedules
                .Include(c => c.Company)
                .Include(c => c.LoadingPointLoad)
                .Include(c => c.LoadingPointOff)
                .Include(c => c.Note)
                .Include(c => c.Vehicle)
                .Include(c => c.CompanyTrans)
                .FirstOrDefaultAsync(c => c.Id == searchId);

            if (loadingSchedule == null)
            {
                return null;
            }

            var transportedProducts = await _context.TransportedProducts
                .Include(c => c.Product)
                .Where(c => c.LoadingScheduleId == loadingSchedule.Id)
                .ToListAsync();

            var clientPayment = await _context.ClientPayments
                .FirstOrDefaultAsync(c => c.LoadingScheduleId == loadingSchedule.Id);

            var remitance = await _context.Remitances
                .FirstOrDefaultAsync(c => c.LoadingScheduleId == loadingSchedule.Id);

            loadingScheduleVM.Initialize(loadingSchedule, transportedProducts, clientPayment ?? new ClientPayment(), remitance ?? new Remitance());

            // Populate additional view models if needed
            loadingScheduleVM.NotesComponent.PreviousNotes = await _context.Notes
                .Where(n => n.LoadingSchedules.Any(ls => ls.Id == loadingSchedule.Id))
                .ToListAsync();

            return loadingScheduleVM;
        }

        [HttpPost]
        public async Task UpdateLoadingSchedule(LoadingScheduleVM loadingScheduleVM)
        {
            var loadingSchedule = loadingScheduleVM.LoadingScheduleDetails.LoadingSchedule;

            if (loadingSchedule.Id == 0)
            {
                _context.LoadingSchedules.Add(loadingSchedule);
            }
            else
            {
                _context.Entry(loadingSchedule).State = EntityState.Modified;
            }

            // Update ClientPayment
            var clientPayment = loadingScheduleVM.ClientPaymentInput.ClientPayment;
            if (clientPayment.Id == 0)
            {
                clientPayment.LoadingScheduleId = loadingSchedule.Id;
                _context.ClientPayments.Add(clientPayment);
            }
            else
            {
                _context.Entry(clientPayment).State = EntityState.Modified;
            }

            // Update Remitance
            var remitance = loadingScheduleVM.TransporterPaymentInput.Remitance;
            if (remitance.Id == 0)
            {
                remitance.LoadingScheduleId = loadingSchedule.Id;
                _context.Remitances.Add(remitance);
            }
            else
            {
                _context.Entry(remitance).State = EntityState.Modified;
            }

            // Update TransportedProducts
            foreach (var product in loadingScheduleVM.ProductTable.TransportedProducts)
            {
                if (product.Id == 0)
                {
                    product.LoadingScheduleId = loadingSchedule.Id;
                    _context.TransportedProducts.Add(product);
                }
                else
                {
                    _context.Entry(product).State = EntityState.Modified;
                }
            }

            // Update Notes
            if (!string.IsNullOrEmpty(loadingScheduleVM.NotesComponent.NoteDescription))
            {
                var note = new Note
                {
                    Description = loadingScheduleVM.NotesComponent.NoteDescription,
                    Revision = DateTime.Now
                };
                note.LoadingSchedules = new List<LoadingSchedule> { loadingSchedule };
                _context.Notes.Add(note);
            }

            await _context.SaveChangesAsync();
        }
    }
}