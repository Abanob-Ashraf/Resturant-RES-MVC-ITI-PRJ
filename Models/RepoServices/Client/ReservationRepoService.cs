using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class ReservationRepoService : IReservationRepository
    {
        public ResturantDbContext Ctx { get; }

        public ReservationRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<Reservation> GetAllReservations()
        {
            return Ctx.Reservations
                  .Include(Res => Res.Customer)
                  .Include(Res => Res.Table)
                  .ToList();
        }

        public Reservation GetReservationById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Reservation with Id: {id}");
            }
            return Ctx.Reservations
                   .Include(Res => Res.Customer)
                   .Include(Res => Res.Table)
                   .Where(Res => Res.ReservationID == id).SingleOrDefault();
        }

        public void InsertReservation(Reservation Reservation)
        {
            if (Reservation != null)
            {
                try
                {
                    Ctx.Reservations.Add(Reservation);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateReservation(int id, Reservation Reservation)
        {
            var updatedReservation = GetReservationById(id);
            if (updatedReservation != null)
            {
                try
                {
                    updatedReservation.TableID = Reservation.TableID;
                    updatedReservation.Notes = Reservation.Notes;
                    updatedReservation.CustomerID = Reservation.CustomerID;
                    updatedReservation.ReservarionDate = Reservation.ReservarionDate;
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteReservation(int id)
        {
            var deletedReservation = GetReservationById(id);
            if (deletedReservation != null)
            {
                try
                {
                    Ctx.Reservations.Remove(deletedReservation);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
