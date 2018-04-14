using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UniRx;
using Newtonsoft.Json;
using System;

using Stage.App.Models.Environment;
           
namespace Stage.App
{
    
    public class Environment
    {

        readonly EnvironmentConfig _config;

        public Environment(EnvironmentConfig config) 
        {
            _config = config;
        }

        public EnvironmentConfig Config
		{
			get { return _config; }
		}

        public static Dictionary<string, string> GetApiHeaders(EnvironmentApi api) 
        {
            Dictionary<string, string> headers = new Dictionary<string,string>();
            headers.Add("x-api-key", api.key);
            headers.Add("Content-Type", "application/json");
            return headers;
        }

        //public static string GetApiBaseUrl(EnvironmentApi api) {
        //    return api.apiUrl + "/v" + api.version;
        //}


	}



}