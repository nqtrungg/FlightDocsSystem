using System.ComponentModel.DataAnnotations;


namespace FlightDocsSystem.Models
{
    public class DocumentModel
    {
        public int document_id { get; set; }
        public string? document_name { get; set; }
        public string? document_type { get; set; }
        public int version { get; set; }
        public DateTime departure_date { get; set; }
        public DateTime updated_date { get; set; }
        public string? creator { get; set; }
        public string? description { get; set; }
    }

    public class AircraftModel
    {
        public int aircraft_id { get; set; }
        public string? aircraft_type { get; set; }
        public string? manufacturer { get; set; }
        public string? model { get; set; }
        public string? registration_number { get; set; }
    }

    public class FlightModel
    {
        public int flight_id { get; set; }
        public string? flight_number { get; set; }
        public DateTime departure_date { get; set; }
        public DateTime arrival_date { get; set; }
        public string? origin { get; set; }
        public string? destination { get; set; }
        public int aircraft_id { get; set; }
        public AircraftModel? aircraft { get; set; }
    }

    public class UserModel
    {
        public int user_id { get; set; }
        public string? usertype { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? fullname { get; set; }
        public string? email { get; set; }
        public string? phonenumber { get; set; }
        public string? role { get; set; }
    }

    public class Document_Flight
    {
        public int documentflight_id { get; set; }
        public int document_id { get; set; }
        public int flight_id { get; set; }
        public DocumentModel? document { get; set; }
        public FlightModel? flight { get; set; }
    }

    public class FlightDocServer
    {
        public int server_id { get; set; }
        public string? server_name { get; set; }
        public string? server_address { get; set; }
    }

    public class ServerDocument
    {
        public int id { get; set; }
        public int server_id { get; set; }
        public int document_id { get; set; }
        public FlightDocServer? server { get; set; }
        public DocumentModel? document { get; set; }
    }

    public class UserDocument
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int document_id { get; set; }
        public UserModel? user { get; set; }
        public DocumentModel? document { get; set; }
    }
}
