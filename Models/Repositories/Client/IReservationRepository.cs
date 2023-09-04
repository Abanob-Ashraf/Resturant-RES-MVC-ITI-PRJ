using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IReservationRepository
    {
        public List<Reservation> GetAllReservations();

        public Reservation GetReservationById(int id);

        public void InsertReservation(Reservation Reservation);

        public void UpdateReservation(int id, Reservation Reservation);

        public void DeleteReservation(int id);
    }
}
