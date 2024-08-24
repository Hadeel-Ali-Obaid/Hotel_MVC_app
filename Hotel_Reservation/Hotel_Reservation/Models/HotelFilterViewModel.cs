using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hotel_Reservation.Models
{
    public class HotelFilterViewModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Rates { get; set; }
        public IEnumerable<SelectListItem> RoomPrices { get; set; }

        public decimal? SelectedCityId { get; set; }
        public decimal? SelectedRate { get; set; }
        public decimal? SelectedRoomPrice { get; set; }
        public string? SearchTerm { get; set; }

    }
}
