using CsvHelper;
using CsvHelper.Configuration;
using Nager.Country;
using RateConverter.Entities;
using RateConverter.Helpers;
using System.Globalization;
using System.IO;

namespace RateConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"";
            string fileName = "PTApp_EUR.csv";
            string filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, "EU", "EUR", "c", "13032025");

        }

        static void WriteToCsv(string filePath, string originCountryCode, string currency, string minorUnit, string validFrom)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }
                }
                var data = ReadFromCsv(filePath);
                if (data != null)
                {
                    data = data.Skip(1).ToList();
                    List<RateOutputModel> outputs = new List<RateOutputModel>();
                    List<string> unmatchedDestionations = new List<string>();
                    RateOutputModel rateOutput = null;
                    foreach (RateInputModel item in data)
                    {
                        var zoneName = item.Destination.Split('-')[0].Trim();
                        var phone_type_key = item.Destination.Contains("Mobile") ? "Mobile" : "Fixed";
                        var destinationSplit = item.Destination.Split(new[] { '-' }, 2);

                        string phoneNumberTypeKeyValue = "";
                        if (item.Destination.Contains("Mobile"))
                        {
                            var dt = "";
                            phoneNumberTypeKeyValue = item.Destination.Split(new[] { '-' }, 2)[1].Trim();
                        }
                        else
                        {
                            if (item.Destination.Split('-').Length > 1)
                            {
                                phoneNumberTypeKeyValue = "Fixed - " + item.Destination.Split('-')[1].Trim();
                            }
                            else
                            {
                                phoneNumberTypeKeyValue = "Fixed";

                            }
                        }


                        var countryCode = Helper.GetCountryCode(zoneName);
                        if (countryCode == "")
                        {
                            try
                            {
                                ICountryProvider countryProvider = new CountryProvider();
                                var countryInfo = countryProvider.GetCountryByName(zoneName);
                                if (countryInfo != null)
                                {
                                    countryCode = countryInfo.Alpha2Code.ToString();
                                }
                                else
                                {
                                    unmatchedDestionations.Add(zoneName);
                                    countryCode = "";
                                }
                            }
                            catch (Exception ex)
                            {

                                unmatchedDestionations.Add(zoneName);
                                countryCode = "";
                            }


                        }

                        rateOutput = new RateOutputModel()
                        {
                            originCountryCode = originCountryCode,
                            currency = currency,
                            destinationCountryCode = countryCode != null ? countryCode : "",
                            destinationKey = zoneName,
                            minorUnit = minorUnit,
                            validFrom = DateTime.Now.ToShortDateString(),
                            connectionFee = "0",
                            rate = item.Rate,
                            delimitedCode = item.Codes,
                            destinationAndDescriptionKey = phone_type_key,
                            phoneNumberTypeKey = phoneNumberTypeKeyValue

                        };

                        outputs.Add(rateOutput);
                    }

                    var groupedRateList = outputs.GroupBy(r => r.destinationCountryCode);


              


                    foreach (var countryCodeRate in groupedRateList)
                    {
                        
                        var minFixed = Convert.ToDecimal(countryCodeRate.Where(x => x.destinationAndDescriptionKey == "Fixed").Min(y => y.rate));
                        var minMobile = Convert.ToDecimal(countryCodeRate.Where(x => x.destinationAndDescriptionKey == "Mobile").Min(y => y.rate));

                        foreach (var item in countryCodeRate)
                        {
                            if(item.destinationCountryCode == "LV")
                            {
                                var latvia = "";
                            }
                            if(item.destinationAndDescriptionKey == "Fixed" && Convert.ToDecimal(item.rate) == minFixed)
                            item.phoneNumberTypeKey = "Fixed";
                            else if(item.destinationAndDescriptionKey == "Mobile" && Convert.ToDecimal(item.rate) == minMobile)                            
                                item.phoneNumberTypeKey = "Mobile";                            
                        }
                    }


                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true
                    };

                    var newFile = filePath.Split(".")[0] + "-" + originCountryCode + "-" + currency + "-" + validFrom + ".csv";
                    using (StreamWriter streamWriter = new StreamWriter(newFile))
                    {
                        using (CsvWriter csvWriter = new CsvWriter(streamWriter, config))
                        {
                            csvWriter.WriteRecords(outputs);

                        }
                    }

                    if (unmatchedDestionations.Count > 0)
                    {
                        Console.WriteLine("The following destinations could not be matched:");
                        foreach (var item in unmatchedDestionations)
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
                    }

                }


            }
            catch (Exception ex)
            {

                throw;
            }



        }
        static List<RateInputModel> ReadFromCsv(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false
                    };
                    using (StreamReader streamReader = new StreamReader(filepath))
                    {
                        using (CsvReader csvReader = new CsvReader(streamReader, config))
                        {
                            var records = csvReader.GetRecords<RateInputModel>().ToList();
                            return records;

                        }
                    }

                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
