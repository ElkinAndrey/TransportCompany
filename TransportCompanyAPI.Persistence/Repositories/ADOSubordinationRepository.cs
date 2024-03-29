﻿using System.Data;
using TransportCompanyAPI.Domain.Entities.PersonEntities;
using TransportCompanyAPI.Domain.Entities.SubordinationEntities;
using TransportCompanyAPI.Domain.Entities.TransportEntities;
using TransportCompanyAPI.Domain.Repositories;
using TransportCompanyAPI.Persistence.Features;
using TransportCompanyAPI.Persistence.Queries;

namespace TransportCompanyAPI.Persistence.Repositories
{
	/// <summary>
	/// Класс для работы с подчиненностью.
	/// Доступ к базе данных при помощи средств ADO.NET
	/// </summary>
	public class ADOSubordinationRepository : ISubordinationRepository
	{
		/// <summary>
		/// Объект для отправки SQL запросов
		/// </summary>
		private SqlQueries sqlQueries;

		/// <summary>
		/// Конструктов
		/// </summary>
		public ADOSubordinationRepository(SqlQueries sqlQueries)
		{
			this.sqlQueries = sqlQueries;
		}

		public async Task<IEnumerable<Region>> GetAllSubjugationAsync()
		{
			IEnumerable<Region> regions;

			string query = @$"
                SELECT * 
                FROM GetAllSubjugation()                
            ";
			DataTable dataTable = sqlQueries.QuerySelect(query);

			List<DataRow> rows = new List<DataRow>();
			foreach (DataRow row in dataTable.Rows)
				rows.Add(row);

			regions = rows
				.GroupBy(row => row.Field<long>("region_id"))
				.Select(r =>
					{
						DataRow row = r.First();
						Region region = new Region()
						{
							RegionId = row.Field<long>("region_id"),
							Name = row.Field<string>("region_name") ?? "",
							Workshops = r
								.GroupBy(row => row.Field<long>("workshop_id"))
								.Select(w =>
									{
										DataRow row = w.First();
										Workshop workshop = new Workshop()
										{
											WorkshopId = row.Field<long>("workshop_id"),
											Name = row.Field<string>("workshop_name") ?? "",
											Brigades = w
												.GroupBy(row => row.Field<long>("brigade_id"))
												.Select(b =>
													{
														DataRow row = b.First();
														Brigade brigade = new Brigade()
														{
															BrigadeId = row.Field<long>("brigade_id"),
															Name = row.Field<string>("brigade_name") ?? "",
															ServiceStaffs = b
																.GroupBy(row => row.Field<long>("person_id"))
																.Select(p =>
																	{
																		DataRow row = p.First();
																		Person person = new Person()
																		{
																			PersonId = row.Field<long>("person_id"),
																			Name = row.Field<string>("person_name") ?? "",
																			Surname = row.Field<string>("person_surname") ?? "",
																			Patronymic = row.Field<string>("person_patronymic") ?? "",
																		};
																		return person;
																	}																	
																),
														};
														return brigade;
													}													
												),
										};
										return workshop;
									}
								),
						};
						return region;
					}
				);

			return regions;
		}

	public async Task<Brigade> GetBrigadeAsync(long brigadeId)
	{
		Brigade brigade;

		string brigadeQuery = @$"
                SELECT *
                FROM GetBrigadeById({brigadeId})
            ";
		DataTable brigadeTable = sqlQueries.QuerySelect(brigadeQuery);

		brigade = ConvertDataRow.ConvertBrigade(brigadeTable.Rows[0]);
		brigade.Workshop = ConvertDataRow.ConvertWorkshop(brigadeTable.Rows[0]);

		GetPersons getPersons = new GetPersons(sqlQueries);
		brigade.ServiceStaffs = getPersons.Action(
			length: 100,
			brigadeId: brigadeId
		);

		GetTransports getTransports = new GetTransports(sqlQueries);
		brigade.Transports = getTransports.Action(
			length: 100,
			brigadeId: brigadeId
		);

		return brigade;
	}

	public async Task<Region> GetRegionAsync(long regionId)
	{
		Region region;
		List<Workshop> workshops;

		string regionQuery = @$"
                SELECT *
                FROM GetRegionById({regionId})
            ";
		DataTable regionTable = sqlQueries.QuerySelect(regionQuery);
		region = ConvertDataRow.ConvertRegion(regionTable.Rows[0]);

		string workshopsQuery = @$"
                SELECT *
                FROM GetWorkshopsByRegionId({regionId})
            ";
		DataTable workshopsTable = sqlQueries.QuerySelect(workshopsQuery);
		workshops = new List<Workshop>();
		foreach (DataRow item in workshopsTable.Rows)
			workshops.Add(ConvertDataRow.ConvertWorkshop(item));

		region.Workshops = workshops;

		return region;
	}

	public async Task<IEnumerable<Region>> GetRegionsAsync()
	{
		List<Region> regions = new List<Region>();

		string query = @$"
                SELECT *
                FROM GetRegions()
            ";
		DataTable table = sqlQueries.QuerySelect(query);

		foreach (DataRow item in table.Rows)
			regions.Add(ConvertDataRow.ConvertRegion(item));

		return regions;
	}

	public async Task<SubordinationCount> GetSubordinationCountAsync(long RegionId, long WorkshopId, long BrigadeId)
	{
		string query = @$"
                SELECT *
                FROM GetSubordinationCount({RegionId}, {WorkshopId}, {BrigadeId})
            ";

		DataTable table = sqlQueries.QuerySelect(query);
		var subordinationCount = new SubordinationCount()
		{
			RegionCount = table.Rows[0].Field<long?>("region_count"),
			WorkshopCount = table.Rows[0].Field<long?>("workshop_count"),
			BrigadeCount = table.Rows[0].Field<long?>("brigade_count"),
			PersonCount = table.Rows[0].Field<long?>("person_count"),
		};

		return subordinationCount;
	}

	public async Task<Workshop> GetWorkshopAsync(long workshopId)
	{
		Workshop workshop;
		List<Brigade> brigades;

		string workshopQuery = @$"
                SELECT *
                FROM GetWorkshopById({workshopId})  
            ";
		DataTable workshopTable = sqlQueries.QuerySelect(workshopQuery);
		workshop = ConvertDataRow.ConvertWorkshop(workshopTable.Rows[0]);
		workshop.Region = ConvertDataRow.ConvertRegion(workshopTable.Rows[0]);

		string brigadesQuery = @$"
                SELECT *
                FROM GetBrigadesByWorkshopId({workshopId})
            ";
		DataTable brigadesTable = sqlQueries.QuerySelect(brigadesQuery);
		brigades = new List<Brigade>();
		foreach (DataRow item in brigadesTable.Rows)
			brigades.Add(ConvertDataRow.ConvertBrigade(item));

		workshop.Brigades = brigades;

		return workshop;
	}
}
}
