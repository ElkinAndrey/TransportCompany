﻿using System.Data;
using System.Xml.Linq;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Enum;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;
using TransportCompanyAPI.Persistence.Queries;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TransportCompanyAPI.Persistence.Repositories
{
	public class ADOTransportRepository : ITransportRepository
	{
		/// <summary>
		/// Объект для отправки SQL запросов
		/// </summary>
		private readonly SqlQueries sqlQueries;

		/// <summary>
		/// Конструктор
		/// </summary>
		public ADOTransportRepository(SqlQueries sqlQueries)
		{
			this.sqlQueries = sqlQueries;
		}

		public ADOTransportRepository()
		{
		}

		public async Task<IEnumerable<string[]>> GetTransportPropertiesByCategoryIdAsync(short categoryId)
		{
			List<string[]> property = new List<string[]>();

			string query = @$"
                SELECT * 
                FROM GetTransportPropertiesByCategoryId({categoryId})  
            ";

			DataTable dataTable1 = sqlQueries.QuerySelect(query);

			foreach (DataRow row in dataTable1.Rows)
				property.Add(new string[]
				{
					row.Field<long>("property_id").ToString(),
					row.Field<string>("name") ?? "",
					row.Field<string>("translation") ?? "",
					row.Field<string>("type") ?? "",
				});

			return property;
		}

		public async Task<Transport> GetTransportByIdAsync(long transportId)
		{
			Transport transport;
			TransportCategories categoryId;
			string generalCharactQuery = @$"
                SELECT * 
                FROM GetTransportById({transportId})
            ";
			string uniqueCharactQuery = @$"
                SELECT * 
                FROM GetPropertyByTransportId({transportId})
            ";

			DataTable generalCharactTable = sqlQueries.QuerySelect(generalCharactQuery);
			transport = ConvertDataRow.ConvertTransport(generalCharactTable.Rows[0]);
			transport.Brigade = new Brigade()
			{
				BrigadeId = generalCharactTable.Rows[0].Field<long>("brigade_id"),
				Name = generalCharactTable.Rows[0].Field<string>("brigade_name") ?? "",
			};

			categoryId = (TransportCategories)generalCharactTable.Rows[0].Field<short>("category_id");
			DataTable uniqueCharactTable = sqlQueries.QuerySelect(uniqueCharactQuery);
			Dictionary<string, string> data = new Dictionary<string, string>();
			foreach (DataRow item in uniqueCharactTable.Rows)
				data[item.Field<string>("name") ?? ""] = item.Field<string>("content") ?? "";

			switch (categoryId)
			{
				case TransportCategories.Bus:
					transport = Downcast.TransportDowncast(
						transport,
						new Bus()
						{
							NumberSeats = Convert.ToInt32(data["NumberSeats"]),
							NumberStandingPlaces = Convert.ToInt32(data["NumberStandingPlaces"]),
							NumberPlacesForDisabled = Convert.ToInt32(data["NumberPlacesForDisabled"]),
							Route = GetRouteByTransportIdAsync(transportId),
						}
					);
					break;
				case TransportCategories.Taxi:
					transport = Downcast.TransportDowncast(
						transport,
						new Taxi()
						{
							NumberSeats = Convert.ToInt32(data["NumberSeats"]),
						}
					);
					break;
				case TransportCategories.ShuttleTaxi:
					transport = Downcast.TransportDowncast(
						transport,
						new ShuttleTaxi()
						{
							NumberSeats = Convert.ToInt32(data["NumberSeats"]),
							Route = GetRouteByTransportIdAsync(transportId),
						}
					);
					break;
				case TransportCategories.FreightTransport:
					transport = Downcast.TransportDowncast(
						transport,
						new FreightTransport()
						{
							LoadCapacity = Convert.ToInt32(data["LoadCapacity"]),
							Height = Convert.ToDouble(data["Height"].Replace('.', ',')),
						}
					);
					break;
				case TransportCategories.CargoTransportation:
					transport = Downcast.TransportDowncast(
						transport,
						new AuxiliaryTransport()
						{
							Height = Convert.ToDouble(data["Height"].Replace('.', ',')),
						}
					);
					break;
			}

			GetPersons getPersons = new GetPersons(sqlQueries);
			transport.Drivers = getPersons.Action(
				length: 100,
				transportId: transportId
			);

			return transport;
		}

		public async Task<IEnumerable<string[]>> GetTransportCategoriesAsync()
		{
			List<string[]> categories = new List<string[]>();

			string query = @$"
                SELECT * 
                FROM GetTransportCategories()
            ";

			DataTable dataTable = sqlQueries.QuerySelect(query);
			foreach (DataRow row in dataTable.Rows)
				categories.Add(new string[]
				{
					row.Field<short>("category_id").ToString(),
					row.Field<string>("name") ?? "",
				});

			return categories;
		}

		public async Task<IEnumerable<string[]>> GetTransportCompaniesAsync()
		{
			List<string[]> companies = new List<string[]>();

			string query = @$"
                SELECT * 
                FROM GetTransportCompanies()
            ";

			DataTable dataTable = sqlQueries.QuerySelect(query);
			foreach (DataRow row in dataTable.Rows)
				companies.Add(new string[]
				{
					row.Field<long>("company_id").ToString(),
					row.Field<string>("name") ?? "",
				});

			return companies;
		}

		public async Task<long> GetTransportCount(
			string series,
			string number,
			string regionCode,
			short transportCountryId,
			short transportCategoryId,
			DateTime? startBuy,
			DateTime? endBuy,
			DateTime? startWriteOff,
			DateTime? endWriteOff
		)
		{
			long count;

			string query = @$"
                SELECT *
                FROM GetTransportCount(
                    N'{series}',
                    N'{number}',
                    N'{regionCode}',
                    {transportCountryId},
                    {transportCategoryId},
                    N'{Helpers.ConvertDateTimeInISO8601(startBuy)}',
                    N'{Helpers.ConvertDateTimeInISO8601(endBuy)}',
                    N'{Helpers.ConvertDateTimeInISO8601(startWriteOff)}',
                    N'{Helpers.ConvertDateTimeInISO8601(endWriteOff)}'
                )
            ";

			DataTable dataTable = sqlQueries.QuerySelect(query);
			count = dataTable.Rows[0].Field<long>("count");

			return count;
		}

		public async Task<IEnumerable<string[]>> GetTransportCountriesAsync()
		{
			List<string[]> countries = new List<string[]>();

			string query = @$"
                SELECT * 
                FROM GetTransportCountries()
            ";

			DataTable dataTable = sqlQueries.QuerySelect(query);
			foreach (DataRow row in dataTable.Rows)
				countries.Add(new string[]
				{
					row.Field<short>("country_id").ToString(),
					row.Field<string>("country_code") ?? "",
					row.Field<string>("deciphering_country") ?? "",
				});

			return countries;
		}

		public async Task<IEnumerable<string[]>> GetTransportModelsByCompanyIdAsync(long companyId)
		{
			List<string[]> models = new List<string[]>();

			string query = @$"
                SELECT * 
                FROM GetTransportModelsByCompanyId({companyId})
            ";

			DataTable dataTable = sqlQueries.QuerySelect(query);
			foreach (DataRow row in dataTable.Rows)
				models.Add(new string[]
				{
					row.Field<long>("model_id").ToString(),
					row.Field<string>("name") ?? "",
				});

			return models;
		}

		public async Task<IEnumerable<Transport>> GetTransportsAsync(
			long offset,
			long length,
			string series,
			string number,
			string regionCode,
			short transportCountryId,
			short transportCategoryId,
			DateTime? startBuy,
			DateTime? endBuy,
			DateTime? startWriteOff,
			DateTime? endWriteOff
		)
		{
			GetTransports getTransports = new GetTransports(sqlQueries);
			var transports = getTransports.Action(
				offset: offset,
				length: length,
				series: series,
				number: number,
				regionCode: regionCode,
				transportCountryId: transportCountryId,
				transportCategoryId: transportCategoryId,
				startBuy: startBuy,
				endBuy: endBuy,
				startWriteOff: startWriteOff,
				endWriteOff: endWriteOff
			);

			return transports;
		}

		public async Task<IEnumerable<string[]>> GetTransportYearByModelIdAsync(long modelId)
		{
			List<string[]> models = new List<string[]>();

			string query = @$"
                SELECT * 
                FROM GetTransportYearByModelId({modelId})
            ";

			DataTable dataTable = sqlQueries.QuerySelect(query);
			foreach (DataRow row in dataTable.Rows)
				models.Add(new string[]
				{
					row.Field<long>("brand_id").ToString(),
					row.Field<int>("year_publishing").ToString(),
				});

			return models;
		}

		public async Task<Dictionary<string, long>> GetGarageFacilityCountByCategoryIdAsync(short categoryId)
		{
			Dictionary<string, long> garageFacilityCountByCategoryId = new Dictionary<string, long>();

			string query = @$"
                SELECT * 
                FROM GetGarageFacilityCountByCategoryId({categoryId})                
            ";

			DataTable dataTable = sqlQueries.QuerySelect(query);

			foreach (DataRow item in dataTable.Rows)
				garageFacilityCountByCategoryId[item.Field<string>("name") ?? ""] = item.Field<int>("count");

			return garageFacilityCountByCategoryId;
		}

		/// <summary>
		/// Получить маршрут по id транспорта
		/// </summary>
		/// <param name="transportId">Id транспорта</param>
		/// <returns>Маршрут</returns>
		private Route GetRouteByTransportIdAsync(long transportId)
		{
			Route route = new Route();

			string query = @$"
                SELECT * 
                FROM GetRouteNumberByTransportId({transportId})                
            ";
			DataTable dataTable = sqlQueries.QuerySelect(query);
			route.RouteId = dataTable.Rows[0].Field<long>("route_id");
			route.Number = dataTable.Rows[0].Field<string>("route_number") ?? "";

			string query2 = @$"
                SELECT * 
                FROM GetRouteByTransportId({transportId})                
            ";
			DataTable dataTable2 = sqlQueries.QuerySelect(query2);
			List<string> stops = new List<string>();
			foreach (DataRow item in dataTable2.Rows)
				stops.Add(item.Field<string>("stop_name") ?? "");
			route.Stops = stops;

			return route;
		}

		public async Task<IEnumerable<CargoTransportation>> GetCargoTransportationsAsync(
			long length,
			long transportId,
			DateTime? firstTransportation,
			DateTime? lastTransportation
		)
		{
			List<CargoTransportation> cargoTransportations = new List<CargoTransportation>();
			string generalCharactQuery = @$"
                SELECT *
                FROM GetCargoTransportations(
                    {length}, 
                    {transportId}, 
                    '{Helpers.ConvertDateTimeInISO8601(firstTransportation)}', 
                    '{Helpers.ConvertDateTimeInISO8601(lastTransportation)}'
                )
            ";
			DataTable dataTable = sqlQueries.QuerySelect(generalCharactQuery);
			foreach (DataRow row in dataTable.Rows)
			{
				cargoTransportations.Add(new CargoTransportation
				{
					CargoTransportationId = row.Field<long>("cargo_transportation_id"),
					Price = row.Field<decimal>("price"),
					AdditionalInformation = row.Field<string>("additional_information") ?? "",
					StartTransportation = row.Field<DateTime>("start"),
					EndTransportation = row.Field<DateTime?>("end"),
				});
			}
			return cargoTransportations;
		}

		public async Task<int> GetMileageByTransportIdAsync(long transportId, DateTime? start, DateTime? end)
		{
			int mileage;

			string query = @$"
                SELECT * 
                FROM GetMileageByTransportId(
                    {transportId}, 
                    '{Helpers.ConvertDateTimeInISO8601(start)}',                
                    '{Helpers.ConvertDateTimeInISO8601(end)}'
                )                
            ";
			DataTable dataTable = sqlQueries.QuerySelect(query);
			mileage = dataTable.Rows[0].Field<int>("mileage");

			return mileage;
		}

		public async Task<long> GetMileageByCategoryIdAsync(long categoryId, DateTime? start, DateTime? end)
		{
			long mileage;

			string query = @$"
                SELECT * 
                FROM GetMileageByCategoryId(
                    {categoryId}, 
                    '{Helpers.ConvertDateTimeInISO8601(start)}',                
                    '{Helpers.ConvertDateTimeInISO8601(end)}'
                )                
            ";
			DataTable dataTable = sqlQueries.QuerySelect(query);
			mileage = dataTable.Rows[0].Field<long>("mileage");

			return mileage;
		}

		public async Task<IEnumerable<Transport>> GetTransportsByBrigadeIdAsync(long brigadeId)
		{
			GetTransports getTransports = new GetTransports(sqlQueries);
			var transports = getTransports.Action(
				offset: 0,
				length: long.MaxValue,
				brigadeId: brigadeId
			);

			return transports;
		}

		public async Task<IEnumerable<Transport>> GetDistributionDriversTransportAsync()
		{
			IEnumerable<Transport> transports;
			List<Driver> drivers = new List<Driver>();

			string query = @$"
                SELECT * 
                FROM GetDistributionDriversTransport()                
            ";
			DataTable dataTable = sqlQueries.QuerySelect(query);

			long transportId = dataTable.Rows[0].Field<long>("transport_id");

			List<DataRow> rows = new List<DataRow>();
			foreach (DataRow row in dataTable.Rows)
				rows.Add(row);

			transports = rows
				.GroupBy(row => row.Field<long>("transport_id"))
				.Select(g =>
					{
						DataRow row = g.First();
						Transport transport = new Transport()
						{
							TransportId = row.Field<long>("transport_id"),
							Series = row.Field<string>("series") ?? "",
							Number = row.Field<string>("number") ?? "",
							RegionCode = row.Field<string>("region_code") ?? "",
							CountryCode = row.Field<string>("country_code") ?? "",
							DecipheringCountry = row.Field<string>("deciphering_country") ?? "",
							Drivers = g.Select(d => new Driver()
							{
								PersonId = d.Field<long>("person_id"),
								Name = d.Field<string>("name") ?? "",
								Surname = d.Field<string>("surname") ?? "",
								Patronymic = d.Field<string>("patronymic") ?? "",
							})
						};
						return transport;
					}
				);

			return transports;
		}
	}
}
