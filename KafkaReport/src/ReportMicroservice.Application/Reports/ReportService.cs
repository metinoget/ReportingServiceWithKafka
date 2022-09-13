using Confluent.Kafka;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ReportMicroservice.Reports
{
    public class ReportService : CrudAppService<
        Report,
        ReportDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateReportDto>, IReportService
    {

        private readonly IRepository<Report> _reportRepository;


        public ReportService(IRepository<Report, Guid> repository) : base(repository)
        {
            _reportRepository = repository;
        }

        public async Task<ReportDto> RequestNewReportAsync(ReportRequestDto dto)
        {
            try
            {
                var reportItem = new Report
                {
                    ReportState = ReportState.Preparing
                };
                var report = await _reportRepository.InsertAsync(reportItem);


                dto.Id = report.Id;
                await SendDataKafkaProducer(JsonConvert.SerializeObject(dto));

                return ObjectMapper.Map<Report, ReportDto>(report);
            }
            catch (Exception ex)
            {
                Logger.LogError("Report request error: ", ex.Message);
                return null;
            }
        }

        private async Task SendDataKafkaProducer(string apiResponse)
        {
            var builderConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfigurationRoot _config = builderConfig.Build();
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = _config["Kafka:Connections:Default:BootstrapServers"],
                ClientId = Dns.GetHostName(),
            };

            var topic = _config["Kafka:EventBus:TopicName"];
            try
            {
                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var data = await producer.ProduceAsync(topic, new Message<Null, string>
                    {
                        Value = apiResponse
                    }); ;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Send Kafka Data error: " + ex.Message);
            }
        }
    }
}
