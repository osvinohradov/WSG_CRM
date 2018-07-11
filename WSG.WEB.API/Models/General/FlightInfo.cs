using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.WEB.API.Models.General
{
    public class FlightInfo
    {
        private string flightNumber;        
        private string arrivalPlace;
        private string departurePlace;
        private string place;
        private string serviceType;
        private DateTime? departureDateTime;
        private DateTime? arrivalDateTime;
        public Guid Id { get; set; }
        public FlightInfo()
        {
            Id = Guid.NewGuid();
        }

        public FlightInfo(string flightNumber, string arrivalPlace, string departurePlace, string place, string serviceType, DateTime? departureDateTime, DateTime? arrivalDateTime)
        {
            this.flightNumber = flightNumber;
            this.arrivalPlace = arrivalPlace;
            this.departurePlace = departurePlace;
            this.place = place;
            this.serviceType = serviceType;
            this.departureDateTime = departureDateTime;
            this.arrivalDateTime = arrivalDateTime;
        }

        public string FlightNumber
        {
            get { return this.flightNumber; }
            set { this.flightNumber = value; }
        }        
        public string Place
        {
            get { return this.place; }
            set { this.place = value; }
        }
        public string ArrivalPlace
        {
            get { return this.arrivalPlace; }
            set { this.arrivalPlace = value; }
        }
        public string DeparturePlace
        {
            get { return this.departurePlace; }
            set { this.departurePlace = value; }
        }
        public string ServiceType
        {
            get { return this.serviceType; }
            set { this.serviceType = value; }
        }
        public DateTime? DepartureDateTime
        {
            get { return this.departureDateTime; }
            set { this.departureDateTime = value; }
        }
        public DateTime? ArrivalDateTime
        {
            get { return this.arrivalDateTime; }
            set { this.arrivalDateTime = value; }
        }
    }
}