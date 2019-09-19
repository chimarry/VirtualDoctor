using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class Place : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {

        public int IdPlace { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }

        public string PostalCode { get; set; }
        public int DrinkingWaterQuality { get; set; }
        public int FoodQuality { get; set; }
        public int RecreationalWaterQuality { get; set; }
        public int AirQuality { get; set; }
        public int InlandWaterQuality { get; set; }
        public int TerrainQuality { get; set; }
        public int MedicalVasteInformation { get; set; }
        public int NoiseInformation { get; set; }
        public int Radiation { get; set; }

        public sbyte Deleted { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Place";
        }
        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdPlace" };
        }
        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = 1906746711;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CountryName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostalCode);
            return hashCode;
        }

        public override string ToString()
        {
            return Name + ":" + CountryName;
        }
    }
}
