using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using ReportMicroservice.ContactReports;
using ReportMicroservice.Contacts;
using ReportMicroservice.Reports;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Confluent.Kafka;
using AutoMapper.Internal.Mappers;
using Volo.Abp.ObjectMapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ReportMicroservice.ContactReports
{
    public class ContactReportBackgroundWorker : BackgroundService
    {
        private readonly IReportService _reportService;
        private IWebHostEnvironment Environment;
        public ContactReportBackgroundWorker(IReportService reportService, IWebHostEnvironment webHostEnvironment)
        {
            _reportService = reportService;
            Environment = webHostEnvironment;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => ExecuteAsync(cancellationToken));
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var builderConf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfigurationRoot _configuration = builderConf.Build();
            var config = new ConsumerConfig
            {
                GroupId = _configuration["Kafka:EventBus:GroupId"],
                BootstrapServers = _configuration["Kafka:Connections:Default:BootstrapServers"],
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            try
            {
                using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumerBuilder.Subscribe(_configuration["Kafka:EventBus:TopicName"]);
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var consumer = consumerBuilder.Consume();
                        var data = consumer.Message.Value;
                        await DoWork(data);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Kafka background consumer error: "+ex.Message);
            }
        }

        private async Task DoWork(string requestData)
        {
            try
            {

                var reportRequestData = JsonConvert.DeserializeObject<ReportRequestDto>(requestData);


                Dictionary<string, string> query = new Dictionary<string, string>();
                query.Add("location", reportRequestData.Location);
                ContactReportDto report = new ContactReportDto();


                string uri = QueryHelpers.AddQueryString("https://localhost:44310/api/app/contact/report-data", query);
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        report = JsonConvert.DeserializeObject<ContactReportDto>(apiResponse);
                    }
                }

                if (report != null)
                {
                    var item = await _reportService.GetAsync(reportRequestData.Id);
                    if (item != null)
                    {
                        var rootPath = this.Environment.WebRootPath;
                        var filePath = Path.Combine("contents", "ContactReport_" + DateTime.Now.Date + ".xlsx");
                        var absolutePath = Path.Combine(rootPath, filePath);
                        var exportService = new ExportToExcelService();
                        var excelSource = await exportService.ExportToExcel(report);
                        exportService.SaveAsFile(excelSource, absolutePath);
                        var updatedItem = new CreateUpdateReportDto();
                        updatedItem.ReportURL = filePath;
                        updatedItem.ReportState = ReportState.Completed;
                        await _reportService.UpdateAsync(item.Id, updatedItem);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Backworker runtime error: "+ex.Message);
            }
        }
    }
}
