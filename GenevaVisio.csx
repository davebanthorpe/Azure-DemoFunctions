#r "System.Configuration"
#r "System.Data"
#r "System.Threading"
#r "Newtonsoft.Json"
#r "System.Net.Http"
#r "System"

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

public static async void Run(string myEventHubMessage, TraceWriter log)
{
    log.Info($"C# Event Hub trigger function processed a message: {myEventHubMessage}");

    SensorMessage sensorMessage = JsonConvert.DeserializeObject<SensorMessage>(myEventHubMessage);  
  
    Boolean bAPIStatus = await PostToPowerBI (sensorMessage, log);

}

public static async Task<Boolean> PostToPowerBI(SensorMessage message, TraceWriter log)
{
    var url = "https://api.powerbi.com/beta/7f962d2b-5e45-4255-ba3e-7e22b1a2b8f9/datasets/0710a680-ba8f-438b-9186-9de855d782af/rows?key=NQhiU382ppiS%2B5gcKhzprjl87kRg0uQeb7rJD2U2p9%2F3LrMF79TZdPYgYfDHxCVOJg4natNHV8PQRXoBOTIfMg%3D%3D";

    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
       
    
        //JSON content for product row
        string rowsJson = "{\"rows\":" +
                "[" + 
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_ColdTemp\",\"value\":\"" + message.zone1_rcalculatedcoldisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_HotTemp\",\"value\":\"" + message.zone1_rcalculatedhotisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_HexATempIn\",\"value\":\"" + message.zone1_rcalculatedhexatemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_HexATempOut\",\"value\":\"" + message.zone1_rcalculatedhexatemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_HexBTempIn\",\"value\":\"" + message.zone1_rcalculatedhexbtemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_HexBTempOut\",\"value\":\"" + message.zone1_rcalculatedhexbtemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_Pressure\",\"value\":\"" + message.zone1_rcalculatedpressure + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_PressureFilter\",\"value\":\"" + message.zone1_rcalculatedpressurefilter + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z1_Fanspeed\",\"value\":\"" + message.zone1_routputcontrollerfanspeed + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_ColdTemp\",\"value\":\"" + message.zone2_rcalculatedcoldisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_HotTemp\",\"value\":\"" + message.zone2_rcalculatedhotisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_HexATempIn\",\"value\":\"" + message.zone2_rcalculatedhexatemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_HexATempOut\",\"value\":\"" + message.zone2_rcalculatedhexatemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_HexBTempIn\",\"value\":\"" + message.zone2_rcalculatedhexbtemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_HexBTempOut\",\"value\":\"" + message.zone2_rcalculatedhexbtemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_Pressure\",\"value\":\"" + message.zone2_rcalculatedpressure + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_PressureFilter\",\"value\":\"" + message.zone2_rcalculatedpressurefilter + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z2_Fanspeed\",\"value\":\"" + message.zone2_routputcontrollerfanspeed + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_ColdTemp\",\"value\":\"" + message.zone3_rcalculatedcoldisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_HotTemp\",\"value\":\"" + message.zone3_rcalculatedhotisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_HexATempIn\",\"value\":\"" + message.zone3_rcalculatedhexatemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_HexATempOut\",\"value\":\"" + message.zone3_rcalculatedhexatemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_HexBTempIn\",\"value\":\"" + message.zone3_rcalculatedhexbtemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_HexBTempOut\",\"value\":\"" + message.zone3_rcalculatedhexbtemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_Pressure\",\"value\":\"" + message.zone3_rcalculatedpressure + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_PressureFilter\",\"value\":\"" + message.zone3_rcalculatedpressurefilter + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z3_Fanspeed\",\"value\":\"" + message.zone3_routputcontrollerfanspeed + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_ColdTemp\",\"value\":\"" + message.zone4_rcalculatedcoldisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_HotTemp\",\"value\":\"" + message.zone4_rcalculatedhotisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_HexATempIn\",\"value\":\"" + message.zone4_rcalculatedhexatemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_HexATempOut\",\"value\":\"" + message.zone4_rcalculatedhexatemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_HexBTempIn\",\"value\":\"" + message.zone4_rcalculatedhexbtemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_HexBTempOut\",\"value\":\"" + message.zone4_rcalculatedhexbtemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_Pressure\",\"value\":\"" + message.zone4_rcalculatedpressure + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_PressureFilter\",\"value\":\"" + message.zone4_rcalculatedpressurefilter + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z4_Fanspeed\",\"value\":\"" + message.zone4_routputcontrollerfanspeed + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_ColdTemp\",\"value\":\"" + message.zone5_rcalculatedcoldisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_HotTemp\",\"value\":\"" + message.zone5_rcalculatedhotisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_HexATempIn\",\"value\":\"" + message.zone5_rcalculatedhexatemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_HexATempOut\",\"value\":\"" + message.zone5_rcalculatedhexatemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_HexBTempIn\",\"value\":\"" + message.zone5_rcalculatedhexbtemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_HexBTempOut\",\"value\":\"" + message.zone5_rcalculatedhexbtemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_Pressure\",\"value\":\"" + message.zone5_rcalculatedpressure + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_PressureFilter\",\"value\":\"" + message.zone5_rcalculatedpressurefilter + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z5_Fanspeed\",\"value\":\"" + message.zone5_routputcontrollerfanspeed + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_ColdTemp\",\"value\":\"" + message.zone6_rcalculatedcoldisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_HotTemp\",\"value\":\"" + message.zone6_rcalculatedhotisletemperature + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_HexATempIn\",\"value\":\"" + message.zone6_rcalculatedhexatemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_HexATempOut\",\"value\":\"" + message.zone6_rcalculatedhexatemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_HexBTempIn\",\"value\":\"" + message.zone6_rcalculatedhexbtemperaturein + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_HexBTempOut\",\"value\":\"" + message.zone6_rcalculatedhexbtemperatureout + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_Pressure\",\"value\":\"" + message.zone6_rcalculatedpressure + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_PressureFilter\",\"value\":\"" + message.zone6_rcalculatedpressurefilter + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"z6_Fanspeed\",\"value\":\"" + message.zone6_routputcontrollerfanspeed + "\"}," +
                "{\"timestamp\":\"" + message.date + "\",\"name\":\"time\",\"value\":\"" + message.date + "\"}" +
                "]}";

        HttpResponseMessage response = await client.PostAsync(url, new StringContent(rowsJson, Encoding.UTF8, "application/json"));
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

public class APIRootReply
{
    public DateTime date{ get; set;}
}
public class SensorMessage
{
    public DateTime date { get; set; }
    public int zone1_rcalculatedcoldisletemperature { get; set; }
    public int zone1_rcalculatedhotisletemperature { get; set; }
    public int zone1_rcalculatedhexatemperaturein { get; set; }
    public int zone1_rcalculatedhexatemperatureout { get; set; }
    public int zone1_rcalculatedhexbtemperaturein { get; set; }
    public int zone1_rcalculatedhexbtemperatureout { get; set; }
    public int zone1_rcalculatedpressure { get; set; }
    public int zone1_rcalculatedpressurefilter { get; set; }
    public int zone1_routputcontrollerfanspeed { get; set; }
    public int zone2_rcalculatedcoldisletemperature { get; set; }
    public int zone2_rcalculatedhotisletemperature { get; set; }
    public int zone2_rcalculatedhexatemperaturein { get; set; }
    public int zone2_rcalculatedhexatemperatureout { get; set; }
    public int zone2_rcalculatedhexbtemperaturein { get; set; }
    public int zone2_rcalculatedhexbtemperatureout { get; set; }
    public int zone2_rcalculatedpressure { get; set; }
    public int zone2_rcalculatedpressurefilter { get; set; }
    public int zone2_routputcontrollerfanspeed { get; set; }
    public int zone3_rcalculatedcoldisletemperature { get; set; }
    public int zone3_rcalculatedhotisletemperature { get; set; }
    public int zone3_rcalculatedhexatemperaturein { get; set; }
    public int zone3_rcalculatedhexatemperatureout { get; set; }
    public int zone3_rcalculatedhexbtemperaturein { get; set; }
    public int zone3_rcalculatedhexbtemperatureout { get; set; }
    public int zone3_rcalculatedpressure { get; set; }
    public int zone3_rcalculatedpressurefilter { get; set; }
    public int zone3_routputcontrollerfanspeed { get; set; }
    public int zone4_rcalculatedcoldisletemperature { get; set; }
    public int zone4_rcalculatedhotisletemperature { get; set; }
    public int zone4_rcalculatedhexatemperaturein { get; set; }
    public int zone4_rcalculatedhexatemperatureout { get; set; }
    public int zone4_rcalculatedhexbtemperaturein { get; set; }
    public int zone4_rcalculatedhexbtemperatureout { get; set; }
    public int zone4_rcalculatedpressure { get; set; }
    public int zone4_rcalculatedpressurefilter { get; set; }
    public int zone4_routputcontrollerfanspeed { get; set; }
    public int zone5_rcalculatedcoldisletemperature { get; set; }
    public int zone5_rcalculatedhotisletemperature { get; set; }
    public int zone5_rcalculatedhexatemperaturein { get; set; }
    public int zone5_rcalculatedhexatemperatureout { get; set; }
    public int zone5_rcalculatedhexbtemperaturein { get; set; }
    public int zone5_rcalculatedhexbtemperatureout { get; set; }
    public int zone5_rcalculatedpressure { get; set; }
    public int zone5_rcalculatedpressurefilter { get; set; }
    public int zone5_routputcontrollerfanspeed { get; set; }
    public int zone6_rcalculatedcoldisletemperature { get; set; }
    public int zone6_rcalculatedhotisletemperature { get; set; }
    public int zone6_rcalculatedhexatemperaturein { get; set; }
    public int zone6_rcalculatedhexatemperatureout { get; set; }
    public int zone6_rcalculatedhexbtemperaturein { get; set; }
    public int zone6_rcalculatedhexbtemperatureout { get; set; }
    public int zone6_rcalculatedpressure { get; set; }
    public int zone6_rcalculatedpressurefilter { get; set; }
    public int zone6_routputcontrollerfanspeed { get; set; }
}