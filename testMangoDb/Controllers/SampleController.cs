using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using testMangoDb.AppCode;
using testMangoDb.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMangoDb.Controllers
{
    [Route("[controller]")]
    public class SampleController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Photo")]
        public IActionResult Photo()
        {
            return View();
        }

        // GET: /<controller>/
        [HttpGet("Insert")]
        public IActionResult Insert()
        {
            var client = new MongoClient(Website.Instance.Configuration["MangoDB"]);//連結db語法
            var database = client.GetDatabase("testMangoDB");
            testFile temp = new testFile();
            temp.userName = "Young2";
            temp.userPassword = "password";
            temp.userAccount = "YoungChen";
            temp.wishList = new List<wish>();
            temp.wishList.Add(new wish
            {
                prodName = "test",
                prodOid = "1"
            });
            temp.wishList.Add(new wish
            {
                prodName = "test2",
                prodOid = "2"
            });
            var testFileCollection = database.GetCollection<testFile>("testFile");//連接資料表
            testFileCollection.InsertOneAsync(temp);//Insert
            Dictionary<string, string> jsonResult = new Dictionary<string, string>();
            jsonResult.Add("result", "OK");
            return Json(jsonResult);
        }
        [HttpGet("InsertBatch")]
        public IActionResult InsertBatch()
        {
            List<testFile> testFiles = new List<testFile>();
            testFiles.Add(new testFile
            {
                userName = "Chen",
                userPassword = "Password",
                userAccount="ChenPassword",
                wishList=new List<wish>()
            });
            testFiles.Add(new testFile
            {
                userName = "Chen2",
                userPassword = "Password2",
                userAccount = "ChenPassword2",
                wishList = new List<wish>()
            });
            var client = new MongoClient(Website.Instance.Configuration["MangoDB"]);//連結db語法
            var database = client.GetDatabase("testMangoDB");
            var testFileCollection = database.GetCollection<testFile>("testFile");//連接資料表
            testFileCollection.InsertManyAsync(testFiles);//Insert
            Dictionary<string, string> jsonResult = new Dictionary<string, string>();
            jsonResult.Add("result", "OK");
            return Json(jsonResult);
        }
        [HttpGet("Select")]
        public IActionResult Select()
        {
            var client = new MongoClient(Website.Instance.Configuration["MangoDB"]);//連結db語法
            var database = client.GetDatabase("testMangoDB");
            var testFileCollection = database.GetCollection<testFile>("testFile");//連接資料表
            List<testFile> testFiles = testFileCollection.AsQueryable().ToList();

            Dictionary<string, string> jsonResult = new Dictionary<string, string>();
            jsonResult.Add("result", "OK");
            return Json(jsonResult);
        }
        [HttpGet("Update")]
        public IActionResult Update()
        {
            var client = new MongoClient(Website.Instance.Configuration["MangoDB"]);//連結db語法
            var database = client.GetDatabase("testMangoDB");
            var testFileCollection = database.GetCollection<testFile>("testFile");//連接資料表
            var filter = Builders<testFile>.Filter.Eq(x => x.userAccount, "YoungChen");//查詢條件
            testFile testFile = testFileCollection.Find(filter).FirstOrDefault();
            testFile.userAccount = "YoungUpdate";
            ReplaceOneResult result = testFileCollection.ReplaceOne(filter,testFile);
            Dictionary<string, string> jsonResult = new Dictionary<string, string>();
            jsonResult.Add("result", "OK");
            return Json(jsonResult);
        }
        [HttpGet("Delete")]
        public IActionResult Delete()
        {
            var client = new MongoClient(Website.Instance.Configuration["MangoDB"]);//連結db語法
            var database = client.GetDatabase("testMangoDB");
            var testFileCollection = database.GetCollection<testFile>("testFile");//連接資料表
            var filter = Builders<testFile>.Filter.Eq(x => x.userAccount, "YoungUpdate");//查詢條件
            DeleteResult result = testFileCollection.DeleteOne(filter);
            Dictionary<string, string> jsonResult = new Dictionary<string, string>();
            jsonResult.Add("result", "OK");
            return Json(jsonResult);
        }
    }
}
