using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using fenn;
using fenn.Models;
using Newtonsoft.Json;

namespace fenn.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocationsController : ApiController
    {

        // GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        private fennix360_pdnEntities2 db = new fennix360_pdnEntities2();

        // GET: api/Locations
        public IQueryable<Location> GetLocations()
        {
            return db.Locations;
        }

        [HttpPost]
       [Route("api/Locations/Login")]
       public  IHttpActionResult Login(Person person)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // var result = db.Persons.Where(x => x.DocumentId == person.DocumentId && x.Phone == person.Phone).Select new (XmlRead,PersonTypeId).FirstOrDefault();
            var result = (from p in db.Persons
                          where p.DocumentId == person.DocumentId && p.Phone == person.Phone
                          select new
                          {
                              p.Id,
                             p.CenterId,
                             p.CountryId,
                             p.LanguageId,
                             p.PersonTypeId,
                             p.DeviceId,
                             p.OwnerUserId,
                             p.FirstName,
                             p.LastName,
                             p.GenreId,
                             p.Birthdate,
                             p.DocumentId,
                             p.Height,
                             p.Weight,
                             p.EyesColor,
                             p.HairColor,
                             p.EthnyId,
                             p.Address,
                             p.Phone,
                             p.FamilyPhones
                            
                          }).FirstOrDefault();
            return Json(result);
        }

        [HttpGet]
        [Route("api/Location/BatteryStatus/{PersonId}")]
        public IEnumerable<object> BatteryStatus(int personId)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var date = System.DateTime.Now.AddDays(-1);
            var resultDate = date.Date;
           // List<object> result = new List<object>();
            var result = (from l in db.Locations
                          where l.PersonId == personId && l.ServerDate >= date
                          select new
                          {
                            l.BatteryPercentage,
                            l.ServerDate
                          }).Distinct().Take(100).ToList();
            return result;
            //
        }




        [HttpGet]
        [Route("api/Locations/GetCountList")]
        public async Task<CountClass> GetCountList(int centerID)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            CountClass clObj = new CountClass();
            var lcounts = await (from persons in db.Persons
                                 join Locations in db.Locations on persons.Id equals Locations.PersonId
                                 where persons.CenterId == centerID && Locations.BatteryPercentage <= 10 && DbFunctions.TruncateTime(Locations.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)
                                 select new
                                 {
                                     ID = Locations.PersonId
                                 }).ToListAsync();

            clObj.lowCount = lcounts.Distinct().Count(); ;
            var mcounts = await (from persons in db.Persons
                                 join Locations in db.Locations on persons.Id equals Locations.PersonId
                                 where persons.CenterId == centerID && Locations.BatteryPercentage > 10 && Locations.BatteryPercentage <= 35 && DbFunctions.TruncateTime(Locations.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)

                                 select new
                                 {
                                     ID = Locations.PersonId
                                 }).ToListAsync();
            clObj.mediumCount = mcounts.Distinct().Count();
            var ncounts = await (from persons in db.Persons
                                 join Locations in db.Locations on persons.Id equals Locations.PersonId
                                 where persons.CenterId == centerID && Locations.BatteryPercentage > 35 && DbFunctions.TruncateTime(Locations.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)

                                 select new
                                 {
                                     ID = Locations.PersonId
                                 }).ToListAsync();
            clObj.NormalCount = ncounts.Distinct().Count();

            //clObj.lowCount = (await db.Locations.Where(tbl => tbl.BatteryPercentage <= 10 && DbFunctions.TruncateTime(tbl.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)).LongCountAsync());
            //clObj.mediumCount = (await db.Locations.Where(tbl => tbl.BatteryPercentage <= 35 && tbl.BatteryPercentage >= 11 && DbFunctions.TruncateTime(tbl.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)).LongCountAsync());
            //clObj.NormalCount = (await db.Locations.Where(tbl => tbl.BatteryPercentage >= 36 && DbFunctions.TruncateTime(tbl.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)).LongCountAsync());
            return clObj;

        }
        [HttpGet]
        [Route("api/Locations/GetCountList")]
        public async Task<CountClass> GetCountList()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            CountClass clObj = new CountClass();

            var date = System.DateTime.Now.AddDays(-600);
            var result=date.Date;
           // var total="";
            //DateTime result ="";
           // var lowCount = (from p in db.Persons
           //                 join l in db.Locations on p.Id equals l.PersonId
           //                 where p.CenterId == 4 && p.Active == true && l.BatteryPercentage <= 10 
           //                 select new
           //                 {
           //                     l.ServerDate,
           //                     l.PersonId,
           //                     l.BatteryPercentage
           //                 }).ToList();
           //foreach(var s in lowCount)
           // {
           //   var  final = s.ServerDate<= result;
           //     if (final != false)
           //     {


           //         total += final;
           //     }
           // }




            //l.ServerDate.Date == System.DateTime.Now.Date
            // DateTime.Compare(l.ServerDate,System.DateTime.Now)==0


            clObj.lowCount = (await db.Locations.Where(tbl => DbFunctions.TruncateTime(tbl.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now) && tbl.BatteryPercentage <= 10).Distinct().LongCountAsync());
            clObj.mediumCount = (await db.Locations.Where(tbl => DbFunctions.TruncateTime(tbl.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now) && tbl.BatteryPercentage <= 35 && tbl.BatteryPercentage >= 11  ).LongCountAsync());
            clObj.NormalCount = (await db.Locations.Where(tbl => DbFunctions.TruncateTime(tbl.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now) && tbl.BatteryPercentage >= 36 ).LongCountAsync());
            return clObj;

        }
        [HttpGet]
        [Route("api/Locations/getLowList/{centerID}")]
        public async Task<IEnumerable<object>> GetLowList(int centerID)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //DateTime today = DateTime.Today;
            //DateTime sevenDaysEarlier = today.AddDays(-1);
            //List<Lsssi> lowList = new List<Lsssi>();
            // lowList =await db.Locations.Where(tbl => tbl.BatteryPercentage <= 10 && tbl.ServerDate.Day == System.DateTime.Now.Day).ToListAsync();

            var lowList = await (from person in db.Persons
                                 join Loc in db.Locations on person.DeviceId equals Loc.DeviceId
                                 join dvce in db.Devices on Loc.PersonId equals dvce.PersonId
                                 where person.CenterId == centerID && Loc.BatteryPercentage <= 10 && DbFunctions.TruncateTime(Loc.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)

                                 select new
                                 {
                                     FullName = person.FirstName + person.LastName,
                                     IMEIn = dvce.IMEI,
                                     //DeviceName = dvce.DeviceType,
                                     battteryPercentage = Loc.BatteryPercentage,
                                     chargeStatus = Loc.ChargeStatus,
                                     lowpowerStatus = Loc.LowPowerStatus,
                                     beltStatus = Loc.BeltStatus
                                 }).Distinct().Take(40).ToListAsync();

            return lowList;
        }
        [HttpGet]
        [Route("api/FennixLocations/getMediumList/{centerID}")]
        public async Task<IEnumerable<object>> getMediumList(int centerID)
        {

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //DateTime today = DateTime.Today;
            //DateTime sevenDaysEarlier = today.AddDays(-1);

            var midList = await (from person in db.Persons
                                 join Loc in db.Locations on person.DeviceId equals Loc.DeviceId
                                 join dvce in db.Devices on Loc.PersonId equals dvce.PersonId
                                 where person.CenterId == centerID && Loc.BatteryPercentage <= 35 && Loc.BatteryPercentage >= 11 && DbFunctions.TruncateTime(Loc.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)

                                 select new
                                 {
                                     FullName = person.FirstName + person.LastName,
                                     IMEIn = dvce.IMEI,
                                     //DeviceName = dvce.DeviceType,
                                     battteryPercentage = Loc.BatteryPercentage,
                                     chargeStatus = Loc.ChargeStatus,
                                     lowpowerStatus = Loc.LowPowerStatus,
                                     beltStatus = Loc.BeltStatus
                                 }).Distinct().Take(40).ToListAsync();

            //List<Location> midList = new List<Location>();
            //   midList = await db.Locations.Where(tbl => tbl.BatteryPercentage <= 35 && tbl.BatteryPercentage >= 11 && tbl.ServerDate.Day == System.DateTime.Now.Day).ToListAsync();
            return midList;
        }
        [HttpGet]
        [Route("api/FennixLocations/getNormalList/{centerID}")]
        public async Task<IEnumerable<object>> getNormalList(int centerID)
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var normList = await (from person in db.Persons
                                  join Loc in db.Locations on person.DeviceId equals Loc.DeviceId
                                  join dvce in db.Devices on Loc.PersonId equals dvce.PersonId
                                  where person.CenterId == centerID && Loc.BatteryPercentage >= 35 && DbFunctions.TruncateTime(Loc.ServerDate) == DbFunctions.TruncateTime(System.DateTime.Now)

                                  select new
                                  {
                                      FullName = person.FirstName + person.LastName,
                                      IMEIn = dvce.IMEI,
                                      //DeviceName = dvce.DeviceType,
                                      battteryPercentage = Loc.BatteryPercentage,
                                      chargeStatus = Loc.ChargeStatus,
                                      lowpowerStatus = Loc.LowPowerStatus,
                                      beltStatus = Loc.BeltStatus
                                  }).Distinct().Take(40).ToListAsync();

            //DateTime today = DateTime.Today;
            //DateTime sevenDaysEarlier = today.AddDays(-1);
            //List<Location> normList = new List<Location>();
            //normList = await db.Locations.Where(tbl => tbl.BatteryPercentage >= 36 && tbl.ServerDate.Day == System.DateTime.Now.Day).ToListAsync();
            return normList;
        }
        [HttpGet]
        [Route("api/FennixLocations/GetCentersCountList")]
        public async Task<List<CountClass>> GetCentersCountList([FromUri]int[] centerID)
        {
            List<CountClass> list = new List<CountClass>();
            foreach (int i in centerID)
            {
                CountClass obj = new CountClass();
                obj = await GetCountList(i);
                list.Add(obj);
            }
            return list;
        }
        private static string key = "aAJ6njX2ynZI2IW:01,fG$Fo";
        private static string vec = "yM#xItqa";
        public static string byte2strHexa(byte[] bytes)
        {
            StringBuilder hexa;
            hexa = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hexa.AppendFormat("{0:x2}", b);
            }
            return hexa.ToString();
        }
        public static byte[] strHexa2byte(string hexa)
        {
            int i = 0;
            byte[] bytes = null;
            bytes = new byte[(hexa.Length / 2)];
            for (i = 1; i <= hexa.Length / 2; i++)
            {
                bytes[i - 1] = Convert.ToByte(hexa.Substring(i * 2 - 2, 2), 16);

            }
            return bytes;
        }

        public enum cypherMode
        {
            encryptor = 1,
            decryptor = 2
        }
        private static string cypherStream(cypherMode mode, string input, ICryptoTransform transform)
        {
            byte[] inputByte;
            byte[] outputByte;
            MemoryStream stream = new MemoryStream();
            CryptoStream cypher = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            if (mode == cypherMode.decryptor)
            {
                inputByte = strHexa2byte(input);
            }
            else
            {
                inputByte = Encoding.UTF8.GetBytes(input);
            }
            cypher.Write(inputByte, 0, inputByte.Length);
            cypher.FlushFinalBlock();
            stream.Close();
            outputByte = stream.ToArray();
            if (mode == cypherMode.decryptor)
            {
                return Encoding.UTF8.GetString(outputByte);
            }
            else
            {
                return byte2strHexa(outputByte);
            }
        }
        private static byte[] keybytes()
        {
            return Encoding.UTF8.GetBytes(key);
        }
        private static byte[] vecbytes()
        {
            return Encoding.UTF8.GetBytes(vec);
        }
        [HttpGet]
        [Route("api/FennixLocations/Decrypt")]
        public  string Decrypt( )
        {
            string encryptedText = "fa434e30803a1c5c036c461d2fc5b0a0";
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            ICryptoTransform decryptor;
            decryptor = provider.CreateDecryptor(keybytes(), vecbytes());
            return cypherStream(cypherMode.decryptor, encryptedText, decryptor);
        }


        private static string GetPageContent(string FullUri)
        {
            HttpWebRequest Request;
            StreamReader ResponseReader;
            Request = ((HttpWebRequest)(WebRequest.Create(FullUri)));
            ResponseReader = new StreamReader(Request.GetResponse().GetResponseStream());
            return ResponseReader.ReadToEnd();
        }
        [HttpGet]
        [Route("api/FennixLocations/SendSms")]
        public string SendSms() {
            WebClient client = new WebClient();
            string message = "bus crossed jntu please be ready at your pickup point";
        string result = "http://jst.smsmobile.co.in/index.php/api/bulk-sms?username=Kumesh&password=Redbull@9703&from=REACHD&to=7729906111&message="+message;
            return client.DownloadString(result);

        }

        //}



    }
    public class CountClass
    {
        public long lowCount { get; set; }
        public long mediumCount { get; set; }
        public long NormalCount { get; set; }

    }
    public class Lsssi
    {
        public string FullName { get; set; }
        public string IMEIn { get; set; }
        public string DeviceName { get; set; }
        public string battteryPercentage { get; set; }
        public bool chargeStatus { get; set; }
        public bool lowpowerStatus { get; set; }
        public bool beltStatus { get; set; }

    }
}