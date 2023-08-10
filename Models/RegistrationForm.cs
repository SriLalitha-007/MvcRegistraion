using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MvcRegistraion.Models
{
    public class RegistrationForm
    {
        [BsonId] //for this class to be mapped into mongo db
        [BsonRepresentation(BsonType.ObjectId)]//this attributes converts mongo datatype to .net and vice versa
        public string? Id { get; set; }


        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }


        [BsonElement("DOB")]
        public DateTime DateOfBirth { get; set; }


        [BsonElement("Email")]
        public string Email  { get; set; }


        [BsonElement("MobileNumber")]
        public string MobileNumber { get; set; }


        [BsonElement("Telephone")]
        public string TelephoneNumber{ get; set; }


        [BsonElement("D.no")]
        public string D_No{ get; set; }


        [BsonElement("Street")]
        public string Street { get; set; }


        [BsonElement("City")]
        public string City { get; set; }


        [BsonElement("Pincode")]
        public String Pincode { get; set; }


        [BsonElement("RegDate")]
        public DateTime RegDate { get; set; }
    }
}
