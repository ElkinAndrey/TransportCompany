using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyAPI.Domain.Entities.TransportEntities;

namespace TransportCompanyAPI.Persistence.Features
{
    public static class Downcast
    {
        /// <summary>
        /// Передать общие характеристики транспорта
        /// </summary>
        /// <typeparam name="T">Класс наследник транспорта</typeparam>
        /// <param name="transport">Общие характеристики</param>
        /// <param name="uniqeTransport">Уникальные характеристики</param>
        /// <returns>Транспорт со скопированными общими характеристиками</returns>
        public static T TransportDowncast<T>(Transport transport, T uniqeTransport) where T : Transport
        {
            uniqeTransport.TransportId = transport.TransportId;
            uniqeTransport.Category = transport.Category;
            uniqeTransport.Series = transport.Series;
            uniqeTransport.Number = transport.Number;
            uniqeTransport.RegionCode = transport.RegionCode;
            uniqeTransport.CountryCode = transport.CountryCode;
            uniqeTransport.DecipheringCountry = transport.DecipheringCountry;
            uniqeTransport.Start = transport.Start;
            uniqeTransport.End = transport.End;
            uniqeTransport.Mileage = transport.Mileage;
            uniqeTransport.ManufacturerCompany = transport.ManufacturerCompany;
            uniqeTransport.TransportModel = transport.TransportModel;
            uniqeTransport.YearPublishing = transport.YearPublishing;

            return uniqeTransport;
        }
    }
}
