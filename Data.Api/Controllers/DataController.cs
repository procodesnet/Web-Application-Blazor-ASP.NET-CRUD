using Data.Api.Models;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Data.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{
		private readonly IDataRepository dataRepository;

		public DataController(IDataRepository dataRepository)
		{
			this.dataRepository = dataRepository;
		}

		[HttpGet]
		public async Task<ActionResult> GetRecords()
		{
			try
			{
				return Ok(await dataRepository.GetRecords());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database.");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Record>> GetRecord(int id)
		{
			try
			{
				var result = await dataRepository.GetRecord(id);
				if(result == null)
				{
					return NotFound();
				}
				return result;
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database.");
			}
		}

		[HttpPost]
		public async Task<ActionResult<Record>> CreateRecord(Record record)
		{
			try
			{
				if (record == null)
				{
					return BadRequest();
				}

				var dat = dataRepository.GetRecordByField(record.Field);

				// debug dat == null
				if (dat != null)
				{
					ModelState.AddModelError("field", "Record field already in use.");
					return BadRequest(ModelState);
				}

				var createdRecord = await dataRepository.AddRecord(record);

				return CreatedAtAction(nameof(GetRecord), new { id = createdRecord.Id }, createdRecord);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database.");
			}
		}
	}
}
