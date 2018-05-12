using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WSG.UI.Infrastructure;

namespace WSG.UI.Models
{
    public class MockRepository : Infrastructure.IRepository
    {
        //private List<AviaTicket> mockTicketsCollection = null;

        //public MockRepository()
        //{
        //    mockTicketsCollection = new List<AviaTicket>()
        //    {
        //        new AviaTicket()
        //        {
        //            AviaTicketId = Guid.NewGuid(),
        //            RecordLocator = "7EJTBG",
        //            CreationDate = "2016-11-08",
        //            OfficeidBooking = "IEVU23584",
        //            AgentSignBooking = "3333CC",
        //            ChangeDate = "2016-11-08",
        //            LastTransactionDate = new List<string>() { "2016-11-08" },

        //            FlightInfo = new FlightInfo()
        //                {
        //                    Tattoo = 1,
        //                    ElementNo = 1,
        //                    LastName = "POBIGUN",
        //                    FirstName = "ANDRIY",
        //                    Title = "MR",
        //                    Ap = new List<string>(){ "IEV 38044 5202727,2382727 - WORLD SERVICE GROUP - A" },
        //                    TicketCollection = new List<Ticket>()
        //                    {
        //                        new Ticket()
        //                        {
        //                            OfficeidTicketing = "IEVU23584",
        //                            Status = "issued",
        //                            No = "566-1122666847",
        //                            IataAgencyCode = "72320953",
        //                            ValidatingCarrier = "PS",
        //                            DocCurrency = "UAH",
        //                            FareCurrency = "USD",
        //                            Fare = 40.00,
        //                            FareEquiv = 1023.00,
        //                            FareRate = 25.5750,
        //                            DocTotal = 2277.00,
        //                            DocGrandTotal = 2277.00,
        //                            MiscellaneousFeesTotal = 0.00,
        //                            MiscellaneousFeesVatTotal = 0.00,
        //                            TaxTotal = 1254.00,
        //                            DocVat = 252.00,
        //                            Commission = "1A",
        //                            Endorsement = "NON END/NO REF/RBK USD10",
        //                            Type = "K",
        //                            Ttype = "Electron",
        //                            FlightClass = "C",
        //                            OrigCity = "IFO",
        //                            DestCity = "IEV",
        //                            AirSegment = new List<AirSegment>()
        //                            {
        //                                new AirSegment()
        //                                {
        //                                    No = 2,
        //                                    ServiceCarrier = "PS",
        //                                    FlightNo = 82,
        //                                    AirClass = "J",
        //                                    BkgClass = "J",
        //                                    DepartureDate = "2016-11-14",
        //                                    DepartureTime = "07:00:00",
        //                                    ArrivalDate = "2016-11-14",
        //                                    ArrivalTime = "08:15:00",
        //                                    OrigAirport = new AirSegment.Airport()
        //                                    {
        //                                        Code = "IFO",
        //                                        AmaName = "INTERNATIONAL"
        //                                    },
        //                                    DestAirport = new AirSegment.Airport()
        //                                    {
        //                                         Code = "KBP",
        //                                        AmaName = "BORYSPIL INTL"
        //                                    },
        //                                    FareBasis = "J2LUP1",
        //                                    BaggageAllow = "1PC",
        //                                    FlightDurationTime = "0115",
        //                                    Mileage = "298",
        //                                    Equipment = "E90",
        //                                    AcRecLoc = "7EJTBG"
        //                                }
        //                            },
        //                            Tax = new List<Tax>()
        //                            {
        //                                new Tax()
        //                                {
        //                                    Amount = 768.00,
        //                                    TaxCode = "YR",
        //                                    NatureCode = "VB"
        //                                },
        //                                new Tax()
        //                                {
        //                                    Amount = 252.00,
        //                                    TaxCode = "HF",
        //                                    NatureCode = "GO"
        //                                },
        //                                new Tax()
        //                                {
        //                                    Amount = 80.00,
        //                                    TaxCode = "UA",
        //                                    NatureCode = "SE"
        //                                },
        //                                new Tax()
        //                                {
        //                                    Amount = 154.00,
        //                                    TaxCode = "YK",
        //                                    NatureCode = "AE"
        //                                }
        //                            },
        //                            History = new List<History>()
        //                            {
        //                                new History()
        //                                {
        //                                    Action = "issue",
        //                                    ActionDate = "2016-11-08 10:40:11",
        //                                    AirFile = "AIR_20161108084011.851245.PDT",
        //                                    AgentSign = "3333CC",
        //                                    Amount = 2277.00,
        //                                    NationalAmount = 2277.00,
        //                                    NationalCurrency = "UAH",
        //                                    FormOfPayment = "INV"
        //                                }
        //                            }                                    
        //                        }                                
        //                    }                            
        //                },
        //            Remarks = new List<string>(){ "**** RESERV TILL 09.11 18:00" }
        //        }                
        //    };
        //}

        //public AviaTicket GetTicket(Guid id)
        //{
        //    return mockTicketsCollection.Where(item => item.AviaTicketId == id).FirstOrDefault();
        //}

        //public IEnumerable<AviaTicket> GetTickets()
        //{
        //    return mockTicketsCollection;
        //}
    }
}